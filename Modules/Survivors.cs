using R2API;
using RoR2;
using RoR2.Skills;
using System;
using UnityEngine;
using EntityStates;
using R2API.Utils;
using UnityEngine.Networking;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;

namespace FubukiMods.Modules
{
    internal class Survivors
    {
        internal static void Init()
        {


            //GameObject gameObject = myCharacter.GetComponent<ModelLocator>().modelBaseTransform.gameObject;
            //gameObject.transform.localScale = Vector3.one * 3f;
            //gameObject.transform.Translate(new Vector3(0, 4, 0));
            //myCharacter.GetComponent<CharacterBody>().aimOriginTransform.position *= 2f;//.Translate(new Vector3(0, 0, 0));
            /*myCharacter.GetComponent<CharacterBody>().bodyFlags = CharacterBody.BodyFlags.ImmuneToExecutes;
            foreach (KinematicCharacterController.KinematicCharacterMotor behaviour in myCharacter.GetComponentsInChildren<KinematicCharacterController.KinematicCharacterMotor>())
            { behaviour.SetCapsuleDimensions(behaviour.Capsule.radius * 0.4f, behaviour.Capsule.height * 0.4f, 1.25f); }*/
            //myCharacter.GetComponent<CameraTargetParams>().cameraParams.standardLocalCameraPos *= 3f; //Resources.Load<GameObject>("Prefabs/CharacterBodies/CommandoBody").GetComponent<CameraTargetParams>().cameraParams.standardLocalCameraPos;
            //myCharacter.GetComponent<CameraTargetParams>().cameraParams.pivotVerticalOffset = 2f;
            //GameObject dispObject = Resources.Load<GameObject>("prefabs/characterdisplays/LoaderDisplay").InstantiateClone("Loader2Display");
            //dispObject.transform.localScale = Vector3.one * 3f;
            //dispObject.GetComponent<Animator>().speed = 0.4f;
            //dispObject.AddComponent<NetworkIdentity>();

            //SKINS//
            /*GameObject model = myCharacter.GetComponentInChildren<ModelLocator>().modelTransform.gameObject;
            CharacterModel characterModel = model.GetComponent<CharacterModel>();
            ModelSkinController skinController = model.GetComponent<ModelSkinController>();
            ChildLocator childLocator = model.GetComponent<ChildLocator>();
            SkinnedMeshRenderer mainRenderer = Reflection.GetFieldValue<SkinnedMeshRenderer>(characterModel, "mainSkinnedMeshRenderer");
            LoadoutAPI.SkinDefInfo skinDefInfo = default(LoadoutAPI.SkinDefInfo);
            skinDefInfo.BaseSkins = Array.Empty<SkinDef>();
            skinDefInfo.GameObjectActivations = Array.Empty<SkinDef.GameObjectActivation>();
            skinDefInfo.Icon = LoadoutAPI.CreateSkinIcon
            (
                new Color(0.5f, 0.5f, 0.5f),
                new Color(0.5f, 0.5f, 0.5f),
                new Color(0.5f, 0.5f, 0.5f),
                new Color(0.5f, 0.5f, 0.5f)
            );
            skinDefInfo.MeshReplacements = new SkinDef.MeshReplacement[0];
            skinDefInfo.ProjectileGhostReplacements = new SkinDef.ProjectileGhostReplacement[0];
            skinDefInfo.MinionSkinReplacements = new SkinDef.MinionSkinReplacement[0];
            {
                new SkinDef.MeshReplacement
                {
                    renderer = mainRenderer,
                    mesh = mainRenderer.sharedMesh
                };
            };
            skinDefInfo.Name = "skinLilHereticDefault";
            skinDefInfo.NameToken = "skinLilHereticDefault";
            skinDefInfo.RendererInfos = characterModel.baseRendererInfos;
            skinDefInfo.RootObject = model;
            SkinDef defaultSkin = LoadoutAPI.CreateNewSkinDef(skinDefInfo);
            skinController.skins = new SkinDef[1]
            {
                defaultSkin,
            };*/
            //END SKINS//


            //myBody.AddComponent<PixcraftComponent>();
            //baseDamage = 12f; baseMaxHealth = 160f; baseArmor = 12f; baseRegen = 1f; baseMoveSpeed = 7f; baseAttackSpeed = 1f;*/

            /*SkillDef[] skillDefs = new SkillDef[16];
            {
                //LoadoutAPI.AddSkill(typeof(Skills.ProjectileSkill));
                ContentAddition.AddEntityState<Skills.ProjectileSkill>(out var myState);
                SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();
                mySkillDef.activationState = new SerializableEntityStateType(typeof(Skills.ProjectileSkill));
                mySkillDef.activationStateMachineName = "Weapon";
                mySkillDef.baseMaxStock = 12;
                mySkillDef.baseRechargeInterval = 1f;
                mySkillDef.beginSkillCooldownOnSkillEnd = true;
                mySkillDef.canceledFromSprinting = false;
                mySkillDef.cancelSprintingOnActivation = true;
                mySkillDef.dontAllowPastMaxStocks = false;
                mySkillDef.forceSprintDuringState = false;
                mySkillDef.fullRestockOnAssign = true;
                mySkillDef.interruptPriority = InterruptPriority.Any;
                mySkillDef.isCombatSkill = true;
                mySkillDef.mustKeyPress = false;
                mySkillDef.rechargeStock = mySkillDef.baseMaxStock;
                mySkillDef.requiredStock = 1;
                mySkillDef.stockToConsume = 1;
                mySkillDef.skillDescriptionToken = "Fire a bullet.";
                mySkillDef.skillName = "TEST_BULLET_SKILL";
                mySkillDef.skillNameToken = "Bullet";
                //mySkillDef.icon = spritePrimary;
                skillDefs[0] = mySkillDef;
            }

            ContentAddition.AddSkillDef(skillDefs[0]);

            SkillLocator skillLocator = myBody.GetComponent<SkillLocator>();
            SkillFamily skillFamily0 = skillLocator.primary.skillFamily;
            SkillFamily skillFamily1 = skillLocator.secondary.skillFamily;
            SkillFamily skillFamily2 = skillLocator.utility.skillFamily;
            SkillFamily skillFamily3 = skillLocator.special.skillFamily;

            skillFamily0.variants[0] = new SkillFamily.Variant
            {
                skillDef = skillDefs[1],
                viewableNode = new ViewablesCatalog.Node(skillDefs[1].skillNameToken, false, null)
            };
            skillFamily1.variants[0] = new SkillFamily.Variant
            {
                skillDef = skillDefs[0],
                viewableNode = new ViewablesCatalog.Node(skillDefs[0].skillNameToken, false, null)
            };
            skillFamily2.variants[0] = new SkillFamily.Variant
            {
                skillDef = skillDefs[0],
                viewableNode = new ViewablesCatalog.Node(skillDefs[0].skillNameToken, false, null)
            };
            skillFamily3.variants[0] = new SkillFamily.Variant
            {
                skillDef = skillDefs[0],
                viewableNode = new ViewablesCatalog.Node(skillDefs[0].skillNameToken, false, null)
            };*/
            {  //Test
                /*var myBody = Tools.CreateBody("TestSurvivor");
                var component = myBody.GetComponent<CharacterBody>();
                component.baseDamage = 12f;
                component.levelDamage = component.baseDamage * 0.2f;
                component.baseCrit = 1f;
                component.levelCrit = 0f;
                component.baseMaxHealth = 100f;
                component.levelMaxHealth = component.baseMaxHealth * 0.3f;
                component.baseMaxShield = 0f;
                component.levelMaxShield = 0f;
                component.baseArmor = 0f;
                component.levelArmor = 0f;
                component.baseRegen = 1f;
                component.levelRegen = component.baseRegen * 0.2f;
                component.baseMoveSpeed = 7f;
                component.levelMoveSpeed = 0f;
                component.baseAcceleration = 80f;
                component.baseJumpCount = 1;
                component.baseJumpPower = 15f;
                component.baseAttackSpeed = 1f;
                component.baseNameToken = "TEST_SURVIVOR";
                //component.crosshairPrefab.GetComponent<LoaderHookCrosshairController>().range = 0;
                //component.preferredPodPrefab = Resources.Load<GameObject>("Prefabs/CharacterBodies/ToolbotBody").GetComponent<CharacterBody>().preferredPodPrefab;
                Color[] colorPalette = new Color[16];
                colorPalette[0] = new Color(0f, 0f, 0f, 0.25f);
                colorPalette[1] = new Color(0f, 0f, 0.5f, 1f);
                colorPalette[2] = new Color(1f, 1f, 0.5f, 1f);
                component.portraitIcon = Tools.SpriteFromString("0000001100000000000011221100000000012222221000000012222222210000012222222122100001222222212211101222222222222221122222222222222101222122222211100122221222221000001222211111000000012222221000000000112211000000000012222100000000001222210000000001222222100000", colorPalette).texture;
                ContentAddition.AddBody(myBody);
                { 
                    SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();
                    mySkillDef.activationState = new SerializableEntityStateType(typeof(Skills.ProjectileSkill));
                    mySkillDef.activationStateMachineName = "Weapon";
                    mySkillDef.baseMaxStock = 1;
                    mySkillDef.baseRechargeInterval = 1f;
                    mySkillDef.beginSkillCooldownOnSkillEnd = true;
                    mySkillDef.canceledFromSprinting = false;
                    mySkillDef.cancelSprintingOnActivation = true;
                    mySkillDef.dontAllowPastMaxStocks = false;
                    mySkillDef.forceSprintDuringState = false;
                    mySkillDef.fullRestockOnAssign = true;
                    mySkillDef.interruptPriority = InterruptPriority.Any;
                    mySkillDef.isCombatSkill = true;
                    mySkillDef.mustKeyPress = false;
                    mySkillDef.rechargeStock = mySkillDef.baseMaxStock;
                    mySkillDef.requiredStock = 1;
                    mySkillDef.stockToConsume = 1;
                    mySkillDef.skillDescriptionToken = "Shoots bullet.";
                    mySkillDef.skillName = "BULLET_SKILL";
                    mySkillDef.skillNameToken = "Bullet";
                    mySkillDef.icon = Tools.SpriteFromString("0000000000000000000000000000000000000011100000000001112221110000001222222222110000122222222222100012212212212210001221221221221000122122122122100012212212212210000111110110110000122222100000000012222210000000000111110000000000000000000000000000000000000000", colorPalette);
                    Tools.AddSkill(myBody, mySkillDef, "primary", 0);
                    Tools.AddSkill(myBody, mySkillDef, "secondary", 0);
                    Tools.AddSkill(myBody, mySkillDef, "utility", 0);
                    Tools.AddSkill(myBody, mySkillDef, "special", 0);
                }

                SurvivorDef survivorDef = ScriptableObject.CreateInstance<SurvivorDef>();
                survivorDef.bodyPrefab = myBody;
                survivorDef.descriptionToken = "Description." + Environment.NewLine;
                //var dispObject = Resources.Load<GameObject>("artifactcompound/ArtifactCompoundSquareDisplay").InstantiateClone("DisplayCube");
                //dispObject.AddComponent<PixcraftCreator>();
                survivorDef.displayPrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //survivorDef.displayPrefab.transform.localScale = Vector3.one * 2f;
                survivorDef.primaryColor = new Color(0.5f, 0.5f, 0.5f);
                survivorDef.desiredSortPosition = 44.44f;
                survivorDef.displayNameToken = "Test Survivor";
                ContentAddition.AddSurvivorDef(survivorDef); */
            }//Test

            {  //Void Reaver
                var myBody = Tools.CreateBody("PlayerNullifier", "RoR2/Base/Nullifier/NullifierBody.prefab");
                {  //IDR's
                    /*
                    childName = "Muzzle",
                    localPos = new Vector3(1F, 0.14F, 1F),
                    localAngles = new Vector3(0F, 0F, 0F),
                    localScale = new Vector3(0.8F, 0.8F, 0.8F) 
                    */

                    /*var idrs = myBody.GetComponent<ModelLocator>().modelTransform.GetComponent<CharacterModel>().itemDisplayRuleSet;
                    var i = idrs.keyAssetRuleGroups.Length;
                    while (i > 0)
                    {
                        i--;
                        PrintController.print("Key Asset: " + idrs.keyAssetRuleGroups[i].keyAsset);
                        var ii = idrs.keyAssetRuleGroups[i].displayRuleGroup.rules.Length;
                        while (ii > 0)
                        {
                            ii--;
                            PrintController.print(" - Child Name: " + idrs.keyAssetRuleGroups[i].displayRuleGroup.rules[ii].childName);
                            PrintController.print(" - Position:   " + idrs.keyAssetRuleGroups[i].displayRuleGroup.rules[ii].localPos);
                            PrintController.print(" - Rotation:   " + idrs.keyAssetRuleGroups[i].displayRuleGroup.rules[ii].localAngles);
                            PrintController.print(" - Scale:      " + idrs.keyAssetRuleGroups[i].displayRuleGroup.rules[ii].localScale);
                            PrintController.print(" - Rule Type:  " + idrs.keyAssetRuleGroups[i].displayRuleGroup.rules[ii].ruleType);
                        }
                        idrs.keyAssetRuleGroups.
                    }*/
                    //ItemDisplayRuleSet myRuleSet = ScriptableObject.CreateInstance<ItemDisplayRuleSet>();
                    //List<ItemDisplayRuleSet.KeyAssetRuleGroup> myRules = new List<ItemDisplayRuleSet.KeyAssetRuleGroup>();
                    
                    //var item = Tools.CreateIDR(myRules, Addressables.LoadAssetAsync<ItemDef>(key: "RoR2/Base/CritGlasses/CritGlasses.asset").WaitForCompletion());

                    //myBody.GetComponent<ModelLocator>().modelTransform.GetComponent<CharacterModel>().itemDisplayRuleSet = myRuleSet;
                    //myBody.GetComponent<ModelLocator>().modelTransform.GetComponent<CharacterModel>().itemDisplayRuleSet.GenerateRuntimeValues();

                    //Tools.AddIDR(0, "Muzzle", Vector3.zero, Vector3.zero, Vector3.one);
                    //Tools.AddIDR(1, "Muzzle", Vector3.zero, Vector3.zero, Vector3.one);
                    //Tools.AddIDR(2, "Muzzle", Vector3.zero, Vector3.zero, Vector3.one);
                    //Tools.AddIDR(3, "Muzzle", Vector3.zero, Vector3.zero, Vector3.one);
                    //Tools.AddIDR(4, "Muzzle", Vector3.zero, Vector3.zero, Vector3.one);
                }//IDR's


                GameObject myDisplay = myBody.GetComponent<ModelLocator>().modelBaseTransform.gameObject.InstantiateClone("FubukiMods/PlayerNullifierDisplay");
                myDisplay.AddComponent<NetworkIdentity>();
                GameObject gameObject = myBody.GetComponent<ModelLocator>().modelBaseTransform.gameObject;
                gameObject.transform.localScale = Vector3.one * 0.5f;
                gameObject.transform.Translate(new Vector3(0, 4, 0));
                myBody.GetComponent<CharacterBody>().aimOriginTransform.Translate(new Vector3(0, 0, 0));
                myBody.GetComponent<Interactor>().maxInteractionDistance = 5f;
                myBody.GetComponent<CharacterBody>().bodyFlags = CharacterBody.BodyFlags.ImmuneToExecutes;
                foreach (KinematicCharacterController.KinematicCharacterMotor behaviour in myBody.GetComponentsInChildren<KinematicCharacterController.KinematicCharacterMotor>())
                { behaviour.SetCapsuleDimensions(behaviour.Capsule.radius * 0.4f, behaviour.Capsule.height * 0.4f, 1.25f); }
                //myBody.GetComponent<CameraTargetParams>().cameraParams.standardLocalCameraPos = Resources.Load<GameObject>("Prefabs/CharacterBodies/CrocoBody").GetComponent<CameraTargetParams>().cameraParams.standardLocalCameraPos;
                //myBody.GetComponent<CameraTargetParams>().cameraParams.pivotVerticalOffset = 2f;
                var myCamera = myBody.GetComponent<CameraTargetParams>().cameraParams = new CharacterCameraParams();
                myCamera.data.idealLocalCameraPos = new Vector3(0.0f, 2f, -12f);
                myCamera.data.pivotVerticalOffset = 0f;

                myBody.GetComponent<SetStateOnHurt>().canBeHitStunned = false;
                myBody.GetComponent<CharacterDeathBehavior>().deathState = new SerializableEntityStateType(typeof(Skills.VoidDeath));

                var component = myBody.GetComponent<CharacterBody>();
                component.baseDamage = MainPlugin.configDamage.Value;
                component.levelDamage = component.baseDamage * 0.2f;
                component.baseCrit = 1f;
                component.levelCrit = 0f;
                component.baseMaxHealth = MainPlugin.configMaxHealth.Value;
                component.levelMaxHealth = component.baseMaxHealth * 0.3f;
                component.baseMaxShield = 0f;
                component.levelMaxShield = 0f;
                component.baseArmor = MainPlugin.configArmor.Value;
                component.levelArmor = 0f;
                component.baseRegen = MainPlugin.configRegen.Value;
                component.levelRegen = component.baseRegen * 0.2f;
                component.baseMoveSpeed = MainPlugin.configMoveSpeed.Value;
                component.levelMoveSpeed = 0f;
                component.baseAcceleration = 80f;
                component.baseJumpCount = 1;
                component.baseJumpPower = 15f;
                component.baseAttackSpeed = 1f;
                component.baseNameToken = "Void Reaver";
                //component.crosshairPrefab.GetComponent<LoaderHookCrosshairController>().range = 0;
                //component.preferredPodPrefab = Resources.Load<GameObject>("Prefabs/CharacterBodies/ToolbotBody").GetComponent<CharacterBody>().preferredPodPrefab;
                Color[] colorPalette = new Color[16];
                colorPalette[0] = new Color(0f, 0f, 0f);
                colorPalette[1] = new Color(0.3f, 0f, 0.3f);
                colorPalette[2] = new Color(0.5f, 0f, 0.5f);
                colorPalette[3] = new Color(0.3f, 0f, 0.5f);
                colorPalette[4] = new Color(0.6f, 0.25f, 1f);
                colorPalette[5] = new Color(0.8f, 0.75f, 1f);
                colorPalette[6] = new Color(1f, 1f, 1f);
                colorPalette[7] = new Color(0f, 0.1f, 0.2f);
                colorPalette[8] = new Color(0.6f, 0.7f, 1f);
                colorPalette[9] = new Color(0.5f, 0.5f, 0.7f);
                colorPalette[10] = new Color(0.3f, 0.4f, 0.5f);
                colorPalette[15] = new Color(0f, 0f, 0f, 0f);

                component.portraitIcon = Tools.SpriteFromString("ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff8888888888888888fffffffffffff8882222444444442222888ffffffff88222221110000001112222288fffff8222159549999999999459512228fff822299994499999999994499992228f82255555219999999999991255555228559999991199999999999911999999559956559998999998899999899955659915566655998888899888889955666551215566665999999999999995666655122155566665599999999995566665551221555566666555555555566666555512221655566666655555566666655561222216666556666666666666655666612282216666666666666666666666661228f882111008886666666688800111288ffff888888fff86666668fff888888ffffffffffffff8000000008fffffffffffffffffff8881110000111888fffffffffffff8881111111111111111888fffffffff811111122222222221111118fffffff89922222222222222222222998fffff89999224222222222222422999a8fff899999922542222222245229999aa8ff899995992245422224542299999aa8fff8999566992442222442999999aa8fffff89956659922422422999999aa8fffff889995665999222299999999aa88fff822199955999999999999999aa1228f824221999999999999999999aa122428", colorPalette, true).texture;

                ContentAddition.AddBody(myBody);
                {
                    ContentAddition.AddEntityState<Skills.VoidPrimary>(out _);
                    SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();
                    mySkillDef.activationState = new SerializableEntityStateType(typeof(Skills.VoidPrimary));
                    mySkillDef.activationStateMachineName = "Weapon";
                    mySkillDef.baseMaxStock = 1;
                    mySkillDef.baseRechargeInterval = 1f;
                    mySkillDef.beginSkillCooldownOnSkillEnd = true;
                    mySkillDef.canceledFromSprinting = false;
                    mySkillDef.cancelSprintingOnActivation = true;
                    mySkillDef.dontAllowPastMaxStocks = false;
                    mySkillDef.forceSprintDuringState = false;
                    mySkillDef.fullRestockOnAssign = true;
                    mySkillDef.interruptPriority = InterruptPriority.Any;
                    mySkillDef.isCombatSkill = true;
                    mySkillDef.mustKeyPress = false;
                    mySkillDef.rechargeStock = mySkillDef.baseMaxStock;
                    mySkillDef.requiredStock = 1;
                    mySkillDef.stockToConsume = 0;
                    mySkillDef.skillDescriptionToken = "Fire 3 void pearls in quick succession that hit twice for <style=cIsDamage>2x" + Math.Floor(MainPlugin.configPrimaryDamage.Value * 50) + "% damage</style>. <style=cIsUtility>Number of pearls increases</style> with <style=cIsUtility>attack speed</style>.";
                    mySkillDef.skillName = "VOID_PRIMARY";
                    mySkillDef.skillNameToken = "Void Impulse";
                    mySkillDef.icon = Tools.SpriteFromString("7777777070000000777777777777770007777777777770007700000000777777777700112207777000111112262777771000011122000777000000001112227701101101112266270000011111226627011220000112227711226207000007700012207000777777000007777777700000777777777777007777777770700000", colorPalette);
                    Tools.AddSkill(myBody, mySkillDef, "primary", 0);
                }
                {
                    ContentAddition.AddEntityState<Skills.VoidAltPrimary>(out _);
                    SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();
                    mySkillDef.activationState = new SerializableEntityStateType(typeof(Skills.VoidAltPrimary));
                    mySkillDef.activationStateMachineName = "Weapon";
                    mySkillDef.baseMaxStock = 1;
                    mySkillDef.baseRechargeInterval = 1f;
                    mySkillDef.beginSkillCooldownOnSkillEnd = true;
                    mySkillDef.canceledFromSprinting = false;
                    mySkillDef.cancelSprintingOnActivation = true;
                    mySkillDef.dontAllowPastMaxStocks = false;
                    mySkillDef.forceSprintDuringState = false;
                    mySkillDef.fullRestockOnAssign = true;
                    mySkillDef.interruptPriority = InterruptPriority.Any;
                    mySkillDef.isCombatSkill = true;
                    mySkillDef.mustKeyPress = false;
                    mySkillDef.rechargeStock = mySkillDef.baseMaxStock;
                    mySkillDef.requiredStock = 1;
                    mySkillDef.stockToConsume = 0;
                    mySkillDef.skillDescriptionToken = "Fire 5 void pearls in a line that hit twice for <style=cIsDamage>2x" + Math.Floor(MainPlugin.configAltPrimaryDamage.Value * 50) + "% damage</style>.";
                    mySkillDef.skillName = "VOID_ALT_PRIMARY";
                    mySkillDef.skillNameToken = "Void Sweep";
                    mySkillDef.icon = Tools.SpriteFromString("7777770112477000777001122227777000112111000025771100000002222277000111122000077711100077700022210000000001222261111111212111222100000000000001171110000000777777000111111112217777700012222462770000077011266277111122227712217012224664277777000124666627770000", colorPalette);
                    Tools.AddSkill(myBody, mySkillDef, "primary", 1);
                }
                if (MainPlugin.configLunarSkills.Value == true)
                {
                    ContentAddition.AddEntityState<Skills.VoidLunarPrimary>(out _);
                    SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();
                    mySkillDef.activationState = new SerializableEntityStateType(typeof(Skills.VoidLunarPrimary));
                    mySkillDef.activationStateMachineName = "Weapon";
                    mySkillDef.baseMaxStock = 6;//(int)Math.Round(12 * MainPlugin.configLunarPrimaryScale.Value);
                    mySkillDef.baseRechargeInterval = 1f;//2f * MainPlugin.configLunarPrimaryScale.Value;
                    mySkillDef.beginSkillCooldownOnSkillEnd = true;
                    mySkillDef.canceledFromSprinting = false;
                    mySkillDef.cancelSprintingOnActivation = true;
                    mySkillDef.dontAllowPastMaxStocks = false;
                    mySkillDef.forceSprintDuringState = false;
                    mySkillDef.fullRestockOnAssign = true;
                    mySkillDef.interruptPriority = InterruptPriority.Skill;
                    mySkillDef.isCombatSkill = true;
                    mySkillDef.mustKeyPress = false;
                    mySkillDef.rechargeStock = mySkillDef.baseMaxStock;
                    mySkillDef.requiredStock = 1;
                    mySkillDef.stockToConsume = 1;
                    mySkillDef.skillDescriptionToken = "Fire a flurry of tracking shards that <style=cIsDamage>detonate</style> after a delay, dealing <style=cIsDamage>120% damage</style>. Hold up to " + mySkillDef.baseMaxStock + " charges that reload after " + (Math.Floor(mySkillDef.baseRechargeInterval * 10) / 10) + " second(s).";
                    mySkillDef.skillName = "VOID_ALT_PRIMARY";
                    mySkillDef.skillNameToken = "Hungering Gaze";
                    mySkillDef.icon = Tools.SpriteFromString("0117102002111111100172000177777771102200177777773431020017357777555410013446477724370345666654370220710345666654200111000464437702100000005301777771114100100011177734643011100027745666541771031277346432777745717771402777355577177711777777457777777777777773", colorPalette);
                    Tools.AddSkill(myBody, mySkillDef, "primary", 2);
                }
                {
                    ContentAddition.AddEntityState<Skills.VoidSecondary>(out _);
                    SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();
                    mySkillDef.activationState = new SerializableEntityStateType(typeof(Skills.VoidSecondary));
                    mySkillDef.activationStateMachineName = "Weapon";
                    mySkillDef.baseMaxStock = 1;
                    mySkillDef.baseRechargeInterval = MainPlugin.configSecondaryCooldown.Value;
                    mySkillDef.beginSkillCooldownOnSkillEnd = true;
                    mySkillDef.canceledFromSprinting = true;
                    mySkillDef.cancelSprintingOnActivation = true;
                    mySkillDef.dontAllowPastMaxStocks = false;
                    mySkillDef.forceSprintDuringState = false;
                    mySkillDef.fullRestockOnAssign = true;
                    mySkillDef.interruptPriority = InterruptPriority.Skill;
                    mySkillDef.isCombatSkill = true;
                    mySkillDef.mustKeyPress = true;
                    mySkillDef.rechargeStock = mySkillDef.baseMaxStock;
                    mySkillDef.requiredStock = 1;
                    mySkillDef.stockToConsume = 1;
                    mySkillDef.skillDescriptionToken = "Summon a cluster of bombs that deal <style=cIsDamage>" + MainPlugin.configSecondaryStock.Value + "x" + Math.Floor(300 * MainPlugin.configSecondaryDamage.Value) + "% damage</style>. 3 consecutive hits will <style=cIsUtility>nullify</style> subjects. <style=cIsUtility>Attack Speed</style> will <style=cIsUtility>increase number of bombs</style> and <style=cIsUtility>slightly increase placement radius</style>.";
                    mySkillDef.skillName = "VOID_SECONDARY";
                    mySkillDef.skillNameToken = "Undertow";
                    mySkillDef.icon = Tools.SpriteFromString("7770307700770007777030770077000777704077007703077770407733770307777040705507030777705074554704077770507744770407777050777770050070056500777356530356665307743434305666503777444740356530477777007453435477000044777555770033445577777770030445567777770040445566", colorPalette);
                    Tools.AddSkill(myBody, mySkillDef, "secondary", 0);
                }
                {
                    ContentAddition.AddEntityState<Skills.VoidUtility>(out _);
                    SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();
                    mySkillDef.activationState = new SerializableEntityStateType(typeof(Skills.VoidUtility));
                    mySkillDef.activationStateMachineName = "Body";
                    mySkillDef.baseMaxStock = 1;
                    mySkillDef.baseRechargeInterval = 4f;
                    mySkillDef.beginSkillCooldownOnSkillEnd = true;
                    mySkillDef.canceledFromSprinting = false;
                    mySkillDef.cancelSprintingOnActivation = false;
                    mySkillDef.dontAllowPastMaxStocks = false;
                    mySkillDef.forceSprintDuringState = true;
                    mySkillDef.fullRestockOnAssign = true;
                    mySkillDef.interruptPriority = InterruptPriority.PrioritySkill;
                    mySkillDef.isCombatSkill = false;
                    mySkillDef.mustKeyPress = false;
                    mySkillDef.rechargeStock = mySkillDef.baseMaxStock;
                    mySkillDef.requiredStock = 1;
                    mySkillDef.stockToConsume = 1;
                    mySkillDef.skillDescriptionToken = "Temporarily slip into the void, becoming <style=cIsUtility>intangible</style> and recovering <style=cIsHealing>10% health</style>.";
                    mySkillDef.skillName = "VOID_UTILITY";
                    mySkillDef.skillNameToken = "Dive";
                    mySkillDef.icon = Tools.SpriteFromString("0000000000333300700703303355543007777073554445437777073544566453777777344566645377777344455545307463735454444300754773444455300043773444453300003773344533700000773344337707300073343377004530003443770777340000433777773370000033777777700770003777777777770000", colorPalette);
                    Tools.AddSkill(myBody, mySkillDef, "utility", 0);
                }
                if (MainPlugin.configLunarSkills.Value == true)
                {
                    ContentAddition.AddEntityState<Skills.VoidLunarUtility>(out _);
                    SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();
                    mySkillDef.activationState = new SerializableEntityStateType(typeof(Skills.VoidLunarUtility));
                    mySkillDef.activationStateMachineName = "Body";
                    mySkillDef.baseMaxStock = 1;
                    mySkillDef.baseRechargeInterval = 3f; //Math.Min(6f * MainPlugin.configLunarUtilityScale.Value, 6f);
                    mySkillDef.beginSkillCooldownOnSkillEnd = true;
                    mySkillDef.canceledFromSprinting = false;
                    mySkillDef.cancelSprintingOnActivation = false;
                    mySkillDef.dontAllowPastMaxStocks = false;
                    mySkillDef.forceSprintDuringState = false;
                    mySkillDef.fullRestockOnAssign = true;
                    mySkillDef.interruptPriority = InterruptPriority.PrioritySkill;
                    mySkillDef.isCombatSkill = false;
                    mySkillDef.mustKeyPress = false;
                    mySkillDef.rechargeStock = mySkillDef.baseMaxStock;
                    mySkillDef.requiredStock = 1;
                    mySkillDef.stockToConsume = 1;
                    mySkillDef.skillDescriptionToken = "Fade away, becoming <style=cIsUtility>intangible</style> for 1.5 seconds and gaining <style=cIsUtility>130% movement speed</style>. <style=cIsHealing>Heal for " + (Math.Floor(25f * 5f) / 10f) + "% of your maximum health</style>.";
                    //mySkillDef.skillDescriptionToken = "Fade away, becoming <style=cIsUtility>intangible</style> for " + (3f * MainPlugin.configLunarUtilityScale.Value) + " seconds and gaining <style=cIsUtility>130% movement speed</style>. <style=cIsHealing>Heal for " + (Math.Floor(25f * MainPlugin.configLunarUtilityScale.Value * 10f) / 10f) + "% of your maximum health</style>.";
                    mySkillDef.skillName = "VOID_UTILITY";
                    mySkillDef.skillNameToken = "Shadowfade";
                    mySkillDef.icon = Tools.SpriteFromString("7117771000011177100177711110001701111773113220011710133200233200710143355204110071004654456000001000556444550001100254554645001710050444444001371045500444405337710250004000237771025400054023777710000405021117777332250200000177771000000000177777711101001177", colorPalette);
                    Tools.AddSkill(myBody, mySkillDef, "utility", 1);
                }
                {
                    ContentAddition.AddEntityState<Skills.VoidSpecial>(out _);
                    SkillDef mySkillDef = ScriptableObject.CreateInstance<SkillDef>();
                    mySkillDef.activationState = new SerializableEntityStateType(typeof(Skills.VoidSpecial));
                    mySkillDef.activationStateMachineName = "Body";
                    mySkillDef.baseMaxStock = 1;
                    mySkillDef.baseRechargeInterval = MainPlugin.configSpecialCooldown.Value;
                    mySkillDef.beginSkillCooldownOnSkillEnd = true;
                    mySkillDef.canceledFromSprinting = false;
                    mySkillDef.cancelSprintingOnActivation = true;
                    mySkillDef.dontAllowPastMaxStocks = false;
                    mySkillDef.forceSprintDuringState = false;
                    mySkillDef.fullRestockOnAssign = true;
                    mySkillDef.interruptPriority = InterruptPriority.PrioritySkill;
                    mySkillDef.isCombatSkill = true;
                    mySkillDef.mustKeyPress = false;
                    mySkillDef.rechargeStock = mySkillDef.baseMaxStock;
                    mySkillDef.requiredStock = 1;
                    mySkillDef.stockToConsume = 1;
                    mySkillDef.skillDescriptionToken = "Sacrifice <style=cIsHealth>" + Math.Floor(MainPlugin.configSpecialSelfDamage.Value * 100) + "% of your health</style>, and deal <style=cIsDamage>" + Math.Floor(MainPlugin.configSpecialDamage.Value * 6000) + "% damage in a blast</style> to any nearby test subjects.";
                    mySkillDef.skillName = "VOID_SPECIAL";
                    mySkillDef.skillNameToken = "Reave";
                    mySkillDef.icon = Tools.SpriteFromString("2245656625654642242552652465265445254254225425444524221000442544452400100012242454020510015201255244001000124425500100000011010554010000000101245422100000021245542201111112024545240020101224542525242020242554254524524245255414564562625626521246456564564642", colorPalette);
                    Tools.AddSkill(myBody, mySkillDef, "special", 0);
                }

                SurvivorDef survivorDef = ScriptableObject.CreateInstance<SurvivorDef>();
                survivorDef.bodyPrefab = myBody;
                survivorDef.descriptionToken = "Void Reaver is a funny purple crab. <style=cSub>\r\n\r\n < ! > The number of bullets fired with Void Darts increases or decreases based on your attack speed, while the duration of the attack remains the same.\r\n\r\n < ! > Void Reaver excels at mid-ranged combat. Keep enemies at bay with Capture's bombs and their natural debuff.\r\n\r\n < ! > Veil will break enemy line-of-sight, so use it to your advantage when trying to get out of a bad situation.\r\n\r\n < ! > When you're surrounded by enemies, use Reave and then quickly use Veil to regenerate some of your lost health and escape the chaos." + Environment.NewLine;
                //dispObject.AddComponent<PixcraftCreator>();
                survivorDef.displayPrefab = myDisplay;
                survivorDef.displayPrefab.transform.localScale = Vector3.one * 0.3f;
                survivorDef.primaryColor = new Color(0.5f, 0.5f, 0.5f);
                survivorDef.desiredSortPosition = 44.44f;
                survivorDef.displayNameToken = "Void Reaver";
                ContentAddition.AddSurvivorDef(survivorDef);
            }//Void Reaver

            On.EntityStates.GhostUtilitySkillState.OnEnter += (orig, self) =>
            {
                orig(self);
                if (self.GetFieldValue<float>("duration") == 0)
                {
                    self.SetFieldValue<float>("duration", 1.5f);
                }
            };
            On.RoR2.Skills.LunarPrimaryReplacementSkill.GetRechargeInterval += LunarPrimaryReplacementSkill_GetRechargeInterval;
            On.RoR2.Skills.LunarPrimaryReplacementSkill.GetMaxStock += LunarPrimaryReplacementSkill_GetMaxStock;
            On.RoR2.Skills.LunarPrimaryReplacementSkill.GetRechargeStock += LunarPrimaryReplacementSkill_GetRechargeStock;
        }
        private static int LunarPrimaryReplacementSkill_GetRechargeStock(On.RoR2.Skills.LunarPrimaryReplacementSkill.orig_GetRechargeStock orig, LunarPrimaryReplacementSkill self, GenericSkill skillSlot)
        {
            var result = orig(self, skillSlot);
            if (result > 6) { return result; }
            else { return 6; }
        }

        private static int LunarPrimaryReplacementSkill_GetMaxStock(On.RoR2.Skills.LunarPrimaryReplacementSkill.orig_GetMaxStock orig, LunarPrimaryReplacementSkill self, GenericSkill skillSlot)
        {
            var result = orig(self, skillSlot);
            if (result > 6) { return result; }
            else { return 6; }
        }
        private static float LunarPrimaryReplacementSkill_GetRechargeInterval(On.RoR2.Skills.LunarPrimaryReplacementSkill.orig_GetRechargeInterval orig, LunarPrimaryReplacementSkill self, GenericSkill skillSlot)
        {
            var result = orig(self, skillSlot);
            if (result > 1) { return result; }
            else { return 1f; }
        }
    }
}
