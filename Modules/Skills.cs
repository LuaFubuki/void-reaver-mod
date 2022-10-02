using EntityStates;
using R2API;
using RoR2;
using RoR2.Projectile;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

namespace FubukiMods.Modules
{
    internal static class Skills
    {
        public class VoidPrimary : EntityStates.BaseState
        {
            GameObject projectile = MainPlugin.voidPrimaryProjectile;
            //GameObject muzzleFlash = Addressables.LoadAssetAsync<GameObject>(key: "RoR2/Junk/LunarSkillReplacements/WoundSlashImpact.prefab").WaitForCompletion();
            float baseDuration = 1f;
            float duration;
            float spread = 0.6f;
            float recoil = 0f;
            int bulletIndex = 0;
            int maxBullets = MainPlugin.configPrimaryBullets.Value;
            float damage = 0.5f * MainPlugin.configPrimaryDamage.Value;
            public override void OnEnter()
            {
                base.OnEnter();
                this.duration = baseDuration;// / base.attackSpeedStat;
                base.StartAimMode(2f, false);
                if (!base.isAuthority)
                {
                    Util.PlaySound(EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.fireSound, base.gameObject);
                }
            }
            public override void FixedUpdate()
            {
                base.FixedUpdate();
                if (base.isAuthority && bulletIndex < Math.Round(maxBullets * base.attackSpeedStat))
                {
                    if (base.fixedAge >= this.duration * (0.1 / base.attackSpeedStat) * bulletIndex)
                    {
                        var addSpread = spread * bulletIndex;
                        Ray aimRay = base.GetAimRay();
                        aimRay.direction = Util.ApplySpread(aimRay.direction, 0f * addSpread, 0.2f * addSpread, 1f * addSpread, 1f * addSpread, 0f, 0f);
                        FireProjectileInfo fireProjectileInfo = default(FireProjectileInfo);
                        fireProjectileInfo.position = aimRay.origin;
                        fireProjectileInfo.rotation = Quaternion.LookRotation(aimRay.direction);
                        fireProjectileInfo.crit = base.RollCrit();
                        fireProjectileInfo.damage = base.damageStat * damage;
                        fireProjectileInfo.damageColorIndex = DamageColorIndex.Default;
                        fireProjectileInfo.owner = base.gameObject;
                        fireProjectileInfo.procChainMask = default(ProcChainMask);
                        fireProjectileInfo.force = 0f;
                        fireProjectileInfo.useFuseOverride = false;
                        fireProjectileInfo.useSpeedOverride = false;
                        fireProjectileInfo.target = null;
                        fireProjectileInfo.projectilePrefab = projectile;
                        ProjectileManager.instance.FireProjectile(fireProjectileInfo);
                        base.AddRecoil(-0.4f * recoil, -0.8f * recoil, -0.3f * recoil, 0.3f * recoil);
                        //EffectManager.SimpleMuzzleFlash(muzzleFlash, base.gameObject, "Head", true);
                        Util.PlaySound(EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.fireSound, base.gameObject);
                        bulletIndex++;
                    }
                }
                if (base.isAuthority && base.fixedAge >= this.duration)
                {
                    this.outer.SetNextStateToMain();
                }
                //base.characterBody.AddSpreadBloom(EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.spreadBloomValue);
            }
            public override void OnExit()
            {
                base.OnExit();
            }
            public override InterruptPriority GetMinimumInterruptPriority()
            {
                return InterruptPriority.Skill;
            }
        }
        public class VoidAltPrimary : EntityStates.BaseState
        {
            GameObject projectile = MainPlugin.voidPrimaryProjectile;
            float baseDuration = 1f;
            float duration;
            float damage = 0.5f * MainPlugin.configAltPrimaryDamage.Value;
            public override void OnEnter()
            {
                base.OnEnter();
                this.duration = baseDuration / base.attackSpeedStat;
                base.StartAimMode(2f, false);
                Util.PlayAttackSpeedSound(EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.fireSound, base.gameObject, 0.75f);
                Util.PlayAttackSpeedSound(EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.fireSound, base.gameObject, 1f);
                Util.PlayAttackSpeedSound(EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.fireSound, base.gameObject, 1.25f);
                if (base.isAuthority)
                {
                var addYaw = -8f * MainPlugin.configAltPrimaryHSpread.Value;
                var i = 0;
                var recoil = 0.25f;
                var addSpread = 1;
                    while (i < 5)
                    {
                        Ray aimRay = base.GetAimRay();
                        aimRay.direction = Util.ApplySpread(aimRay.direction, 0f * addSpread, 0.2f * addSpread, 1f * addSpread, 1f * addSpread, addYaw, 0f);
                        addYaw += 4 * MainPlugin.configAltPrimaryHSpread.Value;
                        FireProjectileInfo fireProjectileInfo = default(FireProjectileInfo);
                        fireProjectileInfo.position = aimRay.origin;
                        fireProjectileInfo.rotation = Quaternion.LookRotation(aimRay.direction);
                        fireProjectileInfo.crit = base.RollCrit();
                        fireProjectileInfo.damage = base.damageStat * damage;
                        fireProjectileInfo.damageColorIndex = DamageColorIndex.Default;
                        fireProjectileInfo.owner = base.gameObject;
                        fireProjectileInfo.procChainMask = default(ProcChainMask);
                        fireProjectileInfo.force = 0f;
                        fireProjectileInfo.useFuseOverride = false;
                        fireProjectileInfo.useSpeedOverride = false;
                        fireProjectileInfo.target = null;
                        fireProjectileInfo.projectilePrefab = projectile;
                        ProjectileManager.instance.FireProjectile(fireProjectileInfo);
                        base.AddRecoil(-0.4f * recoil, -0.8f * recoil, -0.3f * recoil, 0.3f * recoil);
                        //EffectManager.SimpleMuzzleFlash(muzzleFlash, base.gameObject, "Head", true);
                        i++;
                    }
                }
            }
            public override void FixedUpdate()
            {
                base.FixedUpdate();
                if (base.isAuthority && base.fixedAge >= this.duration)
                {
                    this.outer.SetNextStateToMain();
                }
            }
            public override void OnExit()
            {
                base.OnExit();
            }
            public override InterruptPriority GetMinimumInterruptPriority()
            {
                return InterruptPriority.Skill;
            }
        }
        public class VoidSecondary : BaseState
        {
            private float duration;
            private float totalDuration = 0.5f;
            private float maxDistance = 200f;
            private float baseRandRadius = MainPlugin.configSecondaryRadius.Value;
            private float randRadius;
            private int baseBombCount = MainPlugin.configSecondaryStock.Value;
            private int bombCount;
            private float bombDamage = 3 * MainPlugin.configSecondaryDamage.Value;
            private Ray aimRay;
            GameObject areaSphere;
            GameObject myProjectile = MainPlugin.voidSecondaryProjectile;
            public override void OnEnter()
            {
                base.OnEnter();
                randRadius = baseRandRadius * (0.75f + (attackSpeedStat * 0.25f));
                bombCount = (int)Math.Round(attackSpeedStat * baseBombCount);
                if (base.isAuthority)
                {
                    this.areaSphere = UnityEngine.Object.Instantiate<GameObject>(EntityStates.Huntress.ArrowRain.areaIndicatorPrefab);
                    this.areaSphere.transform.localScale = Vector3.one * randRadius;
                }

                this.duration = totalDuration / this.attackSpeedStat;
                //base.StartAimMode(4f, false);
                //myProjectile = EntityStates.NullifierMonster.FirePortalBomb.portalBombProjectileEffect.InstantiateClone("Prefabs/Projectiles/ShortPortalBomb");
                //myProjectile = Resources.Load<GameObject>("Prefabs/Projectiles/NullifierPreBombProjectile").InstantiateClone("Prefabs/Custom/ShortPortalBomb");
                
                Util.PlaySound(this.sfxLocator.barkSound, base.gameObject);

            }
            public override void Update()
            {
                base.Update();
                if (base.isAuthority)
                {
                    RaycastHit raycastHit;
                    if (Physics.Raycast(base.GetAimRay(), out raycastHit, maxDistance, LayerIndex.world.mask | LayerIndex.entityPrecise.mask))
                    {
                        this.areaSphere.transform.position = raycastHit.point;
                        this.areaSphere.transform.up = raycastHit.normal;
                        this.areaSphere.transform.localScale = Vector3.one * randRadius;
                    }
                    else
                    {
                        this.areaSphere.transform.localScale = Vector3.zero;
                    }
                }
            }
            public override void FixedUpdate()
            {
                base.FixedUpdate();
                if (base.isAuthority && !inputBank.skill2.down)
                {
                    if (base.isAuthority)
                    {
                        aimRay = base.GetAimRay();
                        RaycastHit aimRayHit;
                        if (Physics.Raycast(aimRay, out aimRayHit, maxDistance))
                        {
                            for (int i = 0; i < bombCount; i++)
                            {
                                Vector3 b = UnityEngine.Random.insideUnitSphere * randRadius;
                                b.y = 0f;
                                if (i == 0)
                                {
                                    b = Vector3.zero;
                                }
                                Vector3 vector = aimRayHit.point + Vector3.up * randRadius + b;
                                RaycastHit raycastHit;
                                if (Physics.Raycast(vector, Vector3.down, out raycastHit, randRadius * 2f, LayerIndex.world.mask | LayerIndex.entityPrecise.mask))
                                {
                                    vector = raycastHit.point;
                                }
                                else
                                {
                                    vector += Vector3.down * UnityEngine.Random.Range(0f, randRadius * 2f);
                                }

                                ProjectileManager.instance.FireProjectile
                                    (
                                    myProjectile,
                                    vector,
                                    Quaternion.identity,
                                    base.gameObject,
                                    base.damageStat * bombDamage,
                                    200f,
                                    Util.CheckRoll(this.critStat, base.characterBody.master),
                                    DamageColorIndex.Default,
                                    null,
                                    -1f
                                    );
                            }
                        }
                        else { base.skillLocator.secondary.stock += 1; }
                        this.outer.SetNextStateToMain();
                    }
                }
            }
            public override void OnExit()
            {
                if (base.isAuthority)
                {
                    EntityState.Destroy(this.areaSphere.gameObject);
                }
                EffectManager.SimpleMuzzleFlash(EntityStates.NullifierMonster.FirePortalBomb.muzzleflashEffectPrefab, base.gameObject, EntityStates.NullifierMonster.FirePortalBomb.muzzleString, true);
                base.OnExit();
            }
            public override InterruptPriority GetMinimumInterruptPriority()
            {
                return InterruptPriority.PrioritySkill;
            }
        }
        public class VoidUtility : BaseState
        {
            private Transform modelTransform;
            private float stopwatch;
            private Vector3 slipVector = Vector3.zero;
            private float yVector = 0f;
            public float duration = 1f;
            public float speedCoefficient = 4f;
            private CharacterModel characterModel;
            private HurtBoxGroup hurtboxGroup;
            public override void OnEnter()
            {
                EffectManager.SpawnEffect(GenericCharacterDeath.voidDeathEffect, new EffectData
                {
                    origin = base.characterBody.corePosition,
                    scale = base.characterBody.bestFitRadius
                }, false);
                Util.PlayAttackSpeedSound(EntityStates.ImpMonster.BlinkState.beginSoundString, base.gameObject, 0.6f);
                Util.PlayAttackSpeedSound(EntityStates.ImpMonster.BlinkState.beginSoundString, base.gameObject, 0.7f);
                base.OnEnter();
                this.modelTransform = base.GetModelTransform();
                if (this.modelTransform)
                {
                    this.characterModel = this.modelTransform.GetComponent<CharacterModel>();
                    this.hurtboxGroup = this.modelTransform.GetComponent<HurtBoxGroup>();
                }
                if (this.characterModel)
                {
                    this.characterModel.invisibilityCount++;
                }
                if (this.hurtboxGroup)
                {
                    HurtBoxGroup hurtBoxGroup = this.hurtboxGroup;
                    int hurtBoxesDeactivatorCounter = hurtBoxGroup.hurtBoxesDeactivatorCounter + 1;
                    hurtBoxGroup.hurtBoxesDeactivatorCounter = hurtBoxesDeactivatorCounter;
                }
                if (NetworkServer.active)
                {
                    //base.healthComponent.HealFraction(0.1f, default(ProcChainMask));
                    base.characterBody.AddTimedBuff(RoR2Content.Buffs.Cloak, duration);
                    base.characterBody.AddTimedBuff(RoR2Content.Buffs.CrocoRegen, 0.75f);
                }
                this.slipVector = ((base.inputBank.moveVector == Vector3.zero) ? base.characterDirection.forward : base.inputBank.moveVector).normalized;
                this.yVector = base.characterMotor.velocity.y;
                //this.footVfxInstance = UnityEngine.Object.Instantiate<GameObject>(GhostUtilitySkillState.footVfxPrefab);
            }
            public override void FixedUpdate()
            {
                base.FixedUpdate();
                this.stopwatch += Time.fixedDeltaTime;
                if (base.characterMotor && base.characterDirection)
                {
                    base.characterMotor.velocity = Vector3.zero;
                    base.characterMotor.rootMotion += this.slipVector * (this.moveSpeedStat * this.speedCoefficient * Time.fixedDeltaTime) * Mathf.Sin((stopwatch / duration) * ((Mathf.PI * 0.5f)+(Mathf.PI * 0.25f)));
                    base.characterMotor.rootMotion += new Vector3(0f, this.yVector * (Time.fixedDeltaTime) * Mathf.Cos((stopwatch / duration) * (Mathf.PI * 0.5f)), 0f);
                }
                if (this.stopwatch >= this.duration && base.isAuthority)
                {
                    this.outer.SetNextStateToMain();
                }
            }

            public override void OnExit()
            {
                EffectManager.SpawnEffect(GenericCharacterDeath.voidDeathEffect, new EffectData
                {
                    origin = base.characterBody.corePosition,
                    scale = base.characterBody.bestFitRadius
                }, false);
                Util.PlayAttackSpeedSound(EntityStates.ImpMonster.BlinkState.endSoundString, base.gameObject, 1f);
                if (this.characterModel)
                {
                    this.characterModel.invisibilityCount--;
                }
                if (this.hurtboxGroup)
                {
                    HurtBoxGroup hurtBoxGroup = this.hurtboxGroup;
                    int hurtBoxesDeactivatorCounter = hurtBoxGroup.hurtBoxesDeactivatorCounter - 1;
                    hurtBoxGroup.hurtBoxesDeactivatorCounter = hurtBoxesDeactivatorCounter;
                }
                base.OnExit();
            }
            public override InterruptPriority GetMinimumInterruptPriority()
            {
                return InterruptPriority.Frozen;
            }
        }
        public class VoidSpecial : BaseState
        {
            private bool hasFiredVoidPortal = false;
            private GameObject projectile = MainPlugin.voidSpecialProjectile;
            private Transform muzzleTransform;
            float totalDuration = 2.5f;
            float selfDamage;
            //Vector3 defaultCam;
            int ticks;
            CameraTargetParams.CameraParamsOverrideRequest zoomOutParams;
            CameraTargetParams.CameraParamsOverrideHandle zoomOutHandle;
            public override void OnEnter()
            {
                base.OnEnter();
                selfDamage = base.healthComponent.combinedHealth * MainPlugin.configSpecialSelfDamage.Value;
                ticks = 0;
                //defaultCam = base.GetComponent<CameraTargetParams>().cameraParams.data.idealLocalCameraPos.value;
                //base.GetComponent<CameraTargetParams>().cameraParams.data.idealLocalCameraPos = new Vector3(0.0f, 1f, -30f);
                zoomOutParams = new CameraTargetParams.CameraParamsOverrideRequest();
                zoomOutParams.cameraParamsData.idealLocalCameraPos = new Vector3(0f, 1f, -30f);
                zoomOutParams.cameraParamsData.pivotVerticalOffset = 0f;
                zoomOutHandle = base.GetComponent<CameraTargetParams>().AddParamsOverride(request: zoomOutParams, 2f);
                this.muzzleTransform = base.FindModelChild(EntityStates.NullifierMonster.DeathState.muzzleName);
                base.PlayCrossfade("Body", "Death", "Death.playbackRate", totalDuration, 0.1f);
                if (base.isAuthority)
                {
                    if (this.muzzleTransform && base.isAuthority)
                    {
                        FireProjectileInfo fireProjectileInfo = default(FireProjectileInfo);
                        fireProjectileInfo.projectilePrefab = projectile;
                        fireProjectileInfo.position = this.muzzleTransform.position;
                        fireProjectileInfo.rotation = Quaternion.identity;
                        fireProjectileInfo.owner = base.gameObject;
                        fireProjectileInfo.damage = base.damageStat * 60f * MainPlugin.configSpecialDamage.Value;
                        fireProjectileInfo.crit = base.characterBody.RollCrit();
                        ProjectileManager.instance.FireProjectile(fireProjectileInfo);
                    }
                }
                if (MainPlugin.configSpecialProtection.Value == true)
                {
                    HurtBoxGroup hurtboxGroup = base.GetModelTransform().GetComponent<HurtBoxGroup>();
                    int hurtBoxesDeactivatorCounter = hurtboxGroup.hurtBoxesDeactivatorCounter + 1;
                    hurtboxGroup.hurtBoxesDeactivatorCounter = hurtBoxesDeactivatorCounter;
                }
            }

            public override void FixedUpdate()
            {

                if (NetworkServer.active && base.fixedAge >= totalDuration * (0.2f * ticks))
                {
                    DamageInfo damageInfo = new DamageInfo
                    {
                        attacker = base.gameObject,
                        crit = false,
                        damage = selfDamage / 3f,
                        damageType = DamageType.NonLethal,
                        inflictor = base.gameObject,
                        position = base.transform.position,
                        procCoefficient = 0,
                    };
                    base.healthComponent.TakeDamage(damageInfo);
                    ticks++;
                }
                if (base.fixedAge >= totalDuration)
                {
                    if (!hasFiredVoidPortal)
                    {
                        hasFiredVoidPortal = true;
                        base.PlayAnimation("Gesture, Additive", "Empty");
                        base.PlayAnimation("Gesture, Override", "Empty");
                        this.outer.SetNextStateToMain();
                        return;
                    }
                }
                base.characterMotor.velocity = Vector3.zero;
                base.FixedUpdate();
            }
            public override void OnExit()
            {
                //base.GetComponent<CameraTargetParams>().cameraParams.data.idealLocalCameraPos = defaultCam;
                base.GetComponent<CameraTargetParams>().RemoveParamsOverride(handle: zoomOutHandle, 1f);
                var radius = 30f;
                EffectManager.SpawnEffect(EntityStates.NullifierMonster.DeathState.voidDeathEffect, new EffectData
                {
                    origin = base.characterBody.corePosition,
                    scale = radius
                }, false);
                if (MainPlugin.configSpecialProtection.Value == true)
                {
                    HurtBoxGroup hurtboxGroup = base.GetModelTransform().GetComponent<HurtBoxGroup>();
                    int hurtBoxesDeactivatorCounter = hurtboxGroup.hurtBoxesDeactivatorCounter - 1;
                    hurtboxGroup.hurtBoxesDeactivatorCounter = hurtBoxesDeactivatorCounter;
                }

                base.OnExit();
            }

            public override InterruptPriority GetMinimumInterruptPriority()
            {
                return InterruptPriority.Death;
            }
        }
        public class VoidDeath : EntityStates.GenericCharacterDeath
        {
            bool hasFired;
            public override void OnEnter()
            {
                base.OnEnter();
                base.PlayCrossfade("Body", "Death", "Death.playbackRate", 1f, 0.1f);
                hasFired = false;
            }
            public override void FixedUpdate()
            {
                base.FixedUpdate();
                if (!hasFired && base.fixedAge >= 1f)
                {
                    hasFired = true;
                    EffectManager.SpawnEffect(EntityStates.NullifierMonster.DeathState.voidDeathEffect, new EffectData
                    {
                        origin = base.characterBody.corePosition,
                        scale = 4f
                    }, false);
                    Util.PlaySound(EntityStates.Missions.Arena.NullWard.Complete.soundEntryEvent, base.gameObject);
                    var characterModel = base.GetModelTransform().GetComponent<CharacterModel>();
                    characterModel.invisibilityCount++;
                    PrintController.print("Character Death Test");
                }
            }
            public override void OnExit()
            {
                if (hasFired)
                {
                    var characterModel = base.GetModelTransform().GetComponent<CharacterModel>();
                    characterModel.invisibilityCount--;
                }
                base.OnExit();
            }
        }

        public class VoidLunarPrimary : BaseState
        {
            public override void OnEnter()
            {
                base.OnEnter();
                this.duration = totalDuration / this.attackSpeedStat;
                if (base.isAuthority)
                {
                    Ray aimRay = base.GetAimRay();
                    aimRay.direction = Util.ApplySpread(aimRay.direction, 0f, EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.maxSpread, 1f, 1f, 0f, 0f);
                    FireProjectileInfo fireProjectileInfo = default(FireProjectileInfo);
                    fireProjectileInfo.position = aimRay.origin;
                    fireProjectileInfo.rotation = Quaternion.LookRotation(aimRay.direction);
                    fireProjectileInfo.crit = base.characterBody.RollCrit();
                    fireProjectileInfo.damage = base.characterBody.damage * EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.damageCoefficient;
                    fireProjectileInfo.damageColorIndex = DamageColorIndex.Default;
                    fireProjectileInfo.owner = base.gameObject;
                    fireProjectileInfo.procChainMask = default(ProcChainMask);
                    fireProjectileInfo.force = 0f;
                    fireProjectileInfo.useFuseOverride = false;
                    fireProjectileInfo.useSpeedOverride = false;
                    fireProjectileInfo.target = null;
                    fireProjectileInfo.projectilePrefab = EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.projectilePrefab;
                    ProjectileManager.instance.FireProjectile(fireProjectileInfo);
                }
                var recoil = EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.recoilAmplitude;
                base.AddRecoil(-0.4f * recoil, -0.8f * recoil, -0.3f * recoil, 0.3f * recoil);
                base.characterBody.AddSpreadBloom(EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.spreadBloomValue);
                base.StartAimMode(2f, false);
                EffectManager.SimpleMuzzleFlash(EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.muzzleFlashEffectPrefab, base.gameObject, "Head", false);
                Util.PlaySound(EntityStates.GlobalSkills.LunarNeedle.FireLunarNeedle.fireSound, base.gameObject);
            }

            public override void FixedUpdate()
            {
                base.FixedUpdate();
                if (base.isAuthority && base.fixedAge >= this.duration)
                {
                    this.outer.SetNextStateToMain();
                }
            }

            public override InterruptPriority GetMinimumInterruptPriority()
            {
                return InterruptPriority.PrioritySkill;
            }
            readonly float totalDuration = 0.1f;
            float duration;
        }
        public class VoidLunarUtility : GhostUtilitySkillState
        {

        }
    }
}
