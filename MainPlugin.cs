using BepInEx;
using BepInEx.Configuration;
using R2API;
using R2API.Utils;
using RoR2;
using RoR2.Projectile;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace FubukiMods
{
    [R2APISubmoduleDependency("SurvivorAPI", "PrefabAPI", "LoadoutAPI")]
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("com.Fubuki.VoidReaver", "Void Reaver Survivor", "0.6.8")]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod)]

    public class MainPlugin : BaseUnityPlugin
    {
        public static GameObject voidPrimaryProjectile;
        public static GameObject voidSecondaryProjectile;
        public static GameObject voidSpecialProjectile;
        public static ConfigEntry<float> configDamage { get; set; }
        public static ConfigEntry<float> configMaxHealth { get; set; }
        public static ConfigEntry<float> configArmor { get; set; }
        public static ConfigEntry<float> configRegen { get; set; }
        public static ConfigEntry<float> configMoveSpeed { get; set; }
        public static ConfigEntry<float> configAttackSpeed { get; set; }
        public static ConfigEntry<bool> configLunarSkills { get; set; }
        public static ConfigEntry<float> configLunarPrimaryScale { get; set; }
        public static ConfigEntry<float> configLunarUtilityScale { get; set; }
        public static ConfigEntry<float> configPrimaryDamage { get; set; }
        public static ConfigEntry<int> configPrimaryBullets { get; set; }
        public static ConfigEntry<float> configAltPrimaryDamage { get; set; }
        public static ConfigEntry<float> configAltPrimaryHSpread { get; set; }
        public static ConfigEntry<float> configSecondaryDamage { get; set; }
        public static ConfigEntry<float> configSecondaryCooldown { get; set; }
        public static ConfigEntry<int> configSecondaryStock { get; set; }
        public static ConfigEntry<float> configSecondaryRadius { get; set; }
        public static ConfigEntry<float> configSpecialDamage { get; set; }
        public static ConfigEntry<float> configSpecialCooldown { get; set; }
        //public static ConfigEntry<float> configSpecialSpeed { get; set; }
        public static ConfigEntry<float> configSpecialSelfDamage { get; set; }
        public static ConfigEntry<bool> configSpecialProtection { get; set; }
        public void Awake()
        {
            configDamage = Config.Bind<float>
                (
                "0. Base Stats",
                "Damage",
                12f,
                "Base damage value."
                );
            configMaxHealth = Config.Bind<float>
                (
                "0. Base Stats",
                "Max Health",
                160f,
                "Base maximum health value."
                );
            configArmor = Config.Bind<float>
                (
                "0. Base Stats",
                "Armor",
                12f,
                "Base armor value."
                );
            configRegen = Config.Bind<float>
                (
                "0. Base Stats",
                "Regen",
                1f,
                "Health reneration scale."
                );
            configMoveSpeed = Config.Bind<float>
                (
                "0. Base Stats",
                "Move Speed",
                7f,
                "Base movement speed."
                );
            configAttackSpeed = Config.Bind<float>
                (
                "0. Base Stats",
                "Attack Speed",
                1f,
                "Base attack speed scale."
                );
            configLunarSkills = Config.Bind<bool>
                (
                "L. Lunar Item Skills",
                "Enable Classic Lunar Item Skills",
                false,
                "Enables the old skills Void Reaver used before Heretic was released."
                );
            /*configLunarPrimaryScale = Config.Bind<float>
                (
                "X. Lunar Item Skills",
                "Hungering Gaze Scale",
                0.5f,
                "How much Void Reaver's Hungering Gaze scales off the regular lunar item version. A value of 1 would be the same as holding one of those items."
                );
            configLunarUtilityScale = Config.Bind<float>
                (
                "X. Lunar Item Skills",
                "Shadowfade Scale",
                0.5f,
                "How much Void Reaver's Shadowfade scales off the regular lunar item version. A value of 1 would be the same as holding one of those items."
                );*/
            /*configAltPrimaryStock = Config.Bind<int>
                (
                "Alt Primary",
                "Void Sweep Bullet Count",
                5,
                "Bullets per-shot."
                );*/
            configPrimaryDamage = Config.Bind<float>
                (
                "1. Primary",
                "Void Impulse Damage Scale",
                1f,
                "Damage scale."
                );
            configPrimaryBullets = Config.Bind<int>
                (
                "1. Primary",
                "Void Impulse Bullet Count",
                3,
                "The starting number of bullets."
                );
            configAltPrimaryDamage = Config.Bind<float>
                (
                "1a. Alt Primary",
                "Void Sweep Damage Scale",
                1f,
                "Damage scale."
                );
            configAltPrimaryHSpread = Config.Bind<float>
                (
                "1a. Alt Primary",
                "Void Sweep Horizontal Spread",
                1f,
                "Horizontal spread scale."
                );
            configSecondaryDamage = Config.Bind<float>
                (
                "2. Secondary",
                "Void Bombs Damage Scale",
                1f,
                "Explosion damage per bomb."
                );
            configSecondaryCooldown = Config.Bind<float>
                (
                "2. Secondary",
                "Void Bombs Cooldown",
                5f,
                "Secondary skill cooldown (in seconds)."
                );
            configSecondaryStock = Config.Bind<int>
                (
                "2. Secondary",
                "Void Bombs Stock",
                6,
                "How many void bombs spawn per skill use."
                );
            configSecondaryRadius = Config.Bind<float>
                (
                "2. Secondary",
                "Void Bombs Spread",
                12f,
                "Bomb placement radius."
                );
            configSpecialDamage = Config.Bind<float>
                (
                "4. Special",
                "Reave Damage Scale",
                1f,
                "Explosion damage scale."
                );
            configSpecialCooldown = Config.Bind<float>
                (
                "4. Special",
                "Reave Cooldown",
                30f,
                "Special skill cooldown (in seconds)."
                );
            configSpecialSelfDamage = Config.Bind<float>
                (
                "4. Special",
                "Reave Self Damage Percent",
                0.5f,
                "How much HP is removed on explosion (0.1 = 10%, 0.5 = 50%, 1 = 100%)"
                );
            configSpecialProtection = Config.Bind<bool>
                (
                "4. Special",
                "Reave Protection",
                true,
                "Enable invincibility while in exploding animation."
                );

            voidPrimaryProjectile = Addressables.LoadAssetAsync<GameObject>(key: "RoR2/Base/LunarSkillReplacements/LunarNeedleProjectile.prefab").WaitForCompletion().InstantiateClone("FubukiMods/VoidPrimary", true);//"RoR2/DLC1/VoidSurvivor/VoidSurvivorBlaster1Projectile.prefab"
            voidPrimaryProjectile.GetComponent<ProjectileController>().ghostPrefab = Addressables.LoadAssetAsync<GameObject>(key: "RoR2/DLC1/VoidSurvivor/VoidSurvivorBlaster1Ghost.prefab").WaitForCompletion();
            voidPrimaryProjectile.GetComponent<ProjectileImpactExplosion>().explosionEffect = Addressables.LoadAssetAsync<GameObject>(key: "RoR2/Base/Nullifier/NullifierBombProjectile.prefab").WaitForCompletion();
            voidPrimaryProjectile.GetComponent<ProjectileImpactExplosion>().lifetimeAfterImpact = 0.2f;
            voidPrimaryProjectile.GetComponent<ProjectileImpactExplosion>().blastDamageCoefficient = 1f;
            ContentAddition.AddProjectile(voidPrimaryProjectile);

            voidSecondaryProjectile = Addressables.LoadAssetAsync<GameObject>(key: "RoR2/Base/Nullifier/NullifierPreBombProjectile.prefab").WaitForCompletion().InstantiateClone("FubukiMods/VoidSecondary");
            voidSecondaryProjectile.GetComponent<ProjectileImpactExplosion>().blastProcCoefficient = 1f;
            voidSecondaryProjectile.GetComponent<ProjectileImpactExplosion>().blastDamageCoefficient = 1f;
            voidSecondaryProjectile.GetComponent<ProjectileController>().procCoefficient = 1;
            voidSecondaryProjectile.GetComponent<ProjectileDamage>().damageType = DamageType.Nullify;
            voidSecondaryProjectile.GetComponent<ProjectileImpactExplosion>().lifetime = 0.75f;
            voidSecondaryProjectile.GetComponent<ProjectileImpactExplosion>().lifetimeRandomOffset = 0.25f;
            ContentAddition.AddProjectile(voidSecondaryProjectile);

            voidSpecialProjectile = Addressables.LoadAssetAsync<GameObject>(key: "RoR2/Base/Nullifier/NullifierDeathBombProjectile.prefab").WaitForCompletion().InstantiateClone("FubukiMods/VoidSpecial", true);//"RoR2/DLC1/VoidSurvivor/VoidSurvivorBlaster1Projectile.prefab"
            voidSpecialProjectile.GetComponent<ProjectileExplosion>().blastAttackerFiltering = RoR2.AttackerFiltering.NeverHitSelf;
            voidSpecialProjectile.GetComponent<ProjectileExplosion>().blastDamageCoefficient = 1f;
            voidSpecialProjectile.GetComponent<ProjectileExplosion>().blastProcCoefficient = 1f;
            voidSpecialProjectile.GetComponent<ProjectileExplosion>().totalDamageMultiplier = 1f;
            voidSpecialProjectile.GetComponent<ProjectileExplosion>().blastRadius *= 0.75f;
            voidSpecialProjectile.GetComponent<ProjectileDamage>().damage = 1f;
            voidSpecialProjectile.GetComponent<ProjectileDamage>().damageColorIndex = RoR2.DamageColorIndex.Void;
            voidSpecialProjectile.GetComponent<ProjectileDamage>().damageType = RoR2.DamageType.LunarSecondaryRootOnHit;
            voidSpecialProjectile.GetComponent<ProjectileImpactExplosion>().lifetime = 2.5f;
            ContentAddition.AddProjectile(voidSpecialProjectile);


            Modules.Survivors.Init();

            /*On.EntityStates.NullifierMonster.DeathState.OnEnter += (orig, self) =>
            {
                if (self.outer.GetComponent<CharacterBody>().baseNameToken != "Void Reaver")
                {
                    orig(self);
                }
                else
                {
                    //;
                    //typeof(EntityStates.GenericCharacterDeath).GetMethodCached("OnEnter").Invoke(self, null);
                    //base.OnEnter();
                }    
            };*/

            /*bool defaultRetrieved = false;
            float defaultDERadius = 0;
            float defaultDEDuration = 0;
            On.EntityStates.NullifierMonster.DeathState.OnEnter += (orig, self) =>
            {
                if (defaultRetrieved == false)
                {
                    defaultDERadius = self.GetFieldValue<float>("deathExplosionRadius");
                    defaultDEDuration = EntityStates.NullifierMonster.DeathState.duration;
                    defaultRetrieved = true;
                }
                if (self.outer.GetComponent<CharacterBody>().isPlayerControlled)
                {
                    
                    self.SetFieldValue<float>("deathExplosionRadius", 0f);
                    self.SetFieldValue<float>("duration", 0.01f);
                }
                else
                {
                    self.SetFieldValue<float>("deathExplosionRadius", defaultDERadius);
                    self.SetFieldValue<float>("duration", defaultDEDuration);
                }
                orig(self);
            };*/
        }

    }
    /*public class MainComponent : MonoBehaviour
    {
        public CharacterBody myBody;
        public int weaponType;
        public bool[] bools;
        public int[] ints;
        public float[] floats;

        public void Awake()
        {
            myBody = base.GetComponent<CharacterBody>();
        }
        public void Update()
        {
            //voxelSprite.transform.position = base.transform.position;
        }
        public void FixedUpdate()
        {
            var cModel = myBody.modelLocator.modelTransform.GetComponent<CharacterModel>();
            if (cModel.invisibilityCount == 0)
            {
                cModel.invisibilityCount++;
            }
        }
    }*/
}