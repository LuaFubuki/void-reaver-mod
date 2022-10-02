using R2API;
using R2API.Utils;
using RoR2;
using RoR2.Skills;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;

namespace FubukiMods.Modules
{
    internal static class Tools
    {
        internal static int Hex2Num(string hex)
        {
            int val = 0;
            hex = hex.ToUpper();
            if (hex == "1") { val = 1; }
            else if (hex == "2") { val = 2; }
            else if (hex == "3") { val = 3; }
            else if (hex == "4") { val = 4; }
            else if (hex == "5") { val = 5; }
            else if (hex == "6") { val = 6; }
            else if (hex == "7") { val = 7; }
            else if (hex == "8") { val = 8; }
            else if (hex == "9") { val = 9; }
            else if (hex == "A") { val = 10; }
            else if (hex == "B") { val = 11; }
            else if (hex == "C") { val = 12; }
            else if (hex == "D") { val = 13; }
            else if (hex == "E") { val = 14; }
            else if (hex == "F") { val = 15; }
            return val;
        }
        internal static string Num2Hex(int num)
        {
            string val = "0";
            if (num == 1) { val = "1"; }
            else if (num == 2) { val = "2"; }
            else if (num == 3) { val = "3"; }
            else if (num == 4) { val = "4"; }
            else if (num == 5) { val = "5"; }
            else if (num == 6) { val = "6"; }
            else if (num == 7) { val = "7"; }
            else if (num == 8) { val = "8"; }
            else if (num == 9) { val = "9"; }
            else if (num == 10) { val = "A"; }
            else if (num == 11) { val = "B"; }
            else if (num == 12) { val = "C"; }
            else if (num == 13) { val = "D"; }
            else if (num == 14) { val = "E"; }
            else if (num == 15) { val = "F"; }
            return val;
        }
        public static Sprite SpriteFromString(string texture, Color[] palette, bool Flipped = false)
        {
            int size = (int)Math.Floor(Math.Pow(texture.Length, 0.5f));
            Texture2D tex = new Texture2D(size, size, TextureFormat.RGBA32, false);
            tex.filterMode = FilterMode.Point;
            tex.wrapMode = TextureWrapMode.Clamp;
            int ix = 0;
            int iy = 0;
            int i = 0;
            while (iy < size)
            {
                ix = 0;
                while (ix < size)
                {
                    if (!Flipped)
                    {
                        tex.SetPixel(size - 1 - ix, iy, palette[Hex2Num(texture.Substring(i, 1))]);
                    }
                    else
                    {
                        tex.SetPixel(ix, size - 1 - iy, palette[Hex2Num(texture.Substring(i, 1))]);
                    }
                    i++;
                    ix++;
                }
                iy++;
            }
            tex.Apply();
            Sprite sprite = Sprite.Create(tex, new Rect(size, size, -size, -size), new Vector2(size * 0.5f, size * 0.5f), size);
            return sprite;
        }
        internal static GameObject VoxelSprite(string texture, Color[] palette, Transform rootTransform)
        {
            var root = new GameObject();
            root.transform.parent = rootTransform;
            root.transform.localPosition = new Vector3(0f, 0f, 0f);
            root.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            int ix = -4;
            int iy = -4;
            int i = 0;
            while (iy < 4)
            {
                ix = -4;
                while (ix < 4)
                {
                    //tex.SetPixel(ix, iy, palette[Hex2Num(texture.Substring(i, 1))]);
                    if (Hex2Num(texture.Substring(i, 1)) != 0)
                    {
                        var vox = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        vox.GetComponent<MeshRenderer>().material.shader = Resources.Load<Shader>("Shaders/Deferred/HGStandard");
                        vox.transform.parent = root.transform;
                        vox.transform.localPosition = new Vector3(-ix - 0.5f, -iy, 0f);
                        vox.transform.localScale = new Vector3(1f, 1f, 1f);
                        vox.transform.localRotation = Quaternion.identity;
                        vox.GetComponent<Renderer>().material.color = palette[Hex2Num(texture.Substring(i, 1))];
                        vox.gameObject.layer = LayerIndex.noCollision.intVal;
                    }
                    i++;
                    ix++;
                }
                iy++;
            }
            return root;
        }
        internal static GameObject CreateBody(string BodyName, string BodyDirectory = "RoR2/Base/Commando/CommandoBody.prefab")
        {
            GameObject Body;
            var existingBody = Addressables.LoadAssetAsync<GameObject>(key: BodyDirectory).WaitForCompletion();
            //myBody = existingBody.InstantiateClone("FubukiMods/" + BodyName);
            Body = PrefabAPI.InstantiateClone(existingBody, "FubukiMods/" + BodyName);
            //myCharacter.AddComponent<PixcraftComponent>();
            foreach (GenericSkill skill in Body.GetComponentsInChildren<GenericSkill>())
            {
                UnityEngine.Object.DestroyImmediate(skill);
            }
            SkillLocator skillLocator = Body.GetComponent<SkillLocator>();
            skillLocator.SetFieldValue<GenericSkill[]>("allSkills", new GenericSkill[0]);
            {
                skillLocator.primary = Body.AddComponent<GenericSkill>();
                SkillFamily newFamily = ScriptableObject.CreateInstance<SkillFamily>();
                newFamily.variants = new SkillFamily.Variant[1];
                //LoadoutAPI.AddSkillFamily(newFamily);
                ContentAddition.AddSkillFamily(newFamily);
                skillLocator.primary.SetFieldValue("_skillFamily", newFamily);
            }
            {
                skillLocator.secondary = Body.AddComponent<GenericSkill>();
                SkillFamily newFamily = ScriptableObject.CreateInstance<SkillFamily>();
                newFamily.variants = new SkillFamily.Variant[1];
                //LoadoutAPI.AddSkillFamily(newFamily);
                ContentAddition.AddSkillFamily(newFamily);
                skillLocator.secondary.SetFieldValue("_skillFamily", newFamily);
            }
            {
                skillLocator.utility = Body.AddComponent<GenericSkill>();
                SkillFamily newFamily = ScriptableObject.CreateInstance<SkillFamily>();
                newFamily.variants = new SkillFamily.Variant[1];
                //LoadoutAPI.AddSkillFamily(newFamily);
                ContentAddition.AddSkillFamily(newFamily);
                skillLocator.utility.SetFieldValue("_skillFamily", newFamily);
            }
            {
                skillLocator.special = Body.AddComponent<GenericSkill>();
                SkillFamily newFamily = ScriptableObject.CreateInstance<SkillFamily>();
                newFamily.variants = new SkillFamily.Variant[1];
                //LoadoutAPI.AddSkillFamily(newFamily);
                ContentAddition.AddSkillFamily(newFamily);
                skillLocator.special.SetFieldValue("_skillFamily", newFamily);
            }
            return Body;
        }
        internal static bool CreateIDR(List<ItemDisplayRuleSet.KeyAssetRuleGroup> ItemDisplayRules, RoR2.ItemDef Item)
        {
            ItemDisplayRules.Add(new ItemDisplayRuleSet.KeyAssetRuleGroup
            {
                keyAsset = Item,
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = null,
                            childName = "Muzzle",
                            localPos = new Vector3(0F, 0.2091F, -0.3642F),
                            localAngles = new Vector3(0F, 0F, 0F),
                            localScale = new Vector3(0.15F, 0.15F, 0.15F),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            return true;
        }
        internal static void AddIDR(String AttachPoint, Vector3 Position, Vector3 Rotation, Vector3 Scale)
        {
            /*PrintController.print("Attempting to add IDR:");
            var idrs = CharacterBody.GetComponent<ModelLocator>().modelTransform.GetComponent<CharacterModel>().itemDisplayRuleSet.keyAssetRuleGroups;
            var length = idrs.Length;
            Array.Resize(ref idrs, length + 1);
            PrintController.print("Resized array...");
            idrs[length].keyAsset = Item;
            var newDisplayRule = new ItemDisplayRule();
            newDisplayRule.childName = AttachPoint;
            newDisplayRule.localPos = Position;
            newDisplayRule.localAngles = Rotation;
            newDisplayRule.localScale = Scale;
            var oldDisplayRule = idrs[length - 1].displayRuleGroup.rules[0];
            PrintController.print("Configured IDR...");
            idrs[length].displayRuleGroup.AddDisplayRule(oldDisplayRule);
            PrintController.print("Success! Created IDR: " + idrs[length].keyAsset);*/
        }
        internal static bool AddSkill(GameObject Body, SkillDef SkillDef, string Slot = "primary", int Variant = 0)
        {
            ContentAddition.AddSkillDef(SkillDef);
            SkillLocator skillLocator = Body.GetComponent<SkillLocator>();
            skillLocator.SetFieldValue<GenericSkill[]>("allSkills", new GenericSkill[0]);
            GenericSkill currentSlot;
            if (Slot.ToLower() == "primary")
            {
                currentSlot = skillLocator.primary;
            }
            else if (Slot.ToLower() == "secondary")
            {
                currentSlot = skillLocator.secondary;
            }
            else if (Slot.ToLower() == "utility")
            {
                currentSlot = skillLocator.utility;
            }
            else if (Slot.ToLower() == "special")
            {
                currentSlot = skillLocator.special;
            }
            else
            {
                MonoBehaviour.print("[FUBUKI ERROR:] Unrecognized slot.");
                return false;
            }

            if (Variant == 0)
            {
                SkillFamily skillFamily = currentSlot.skillFamily;
                skillFamily.variants[0] = new SkillFamily.Variant
                {
                    skillDef = SkillDef,
                    viewableNode = new ViewablesCatalog.Node(SkillDef.skillName + "_TEST", false, null),
                };
                MonoBehaviour.print("Skill Added: " + Slot + " - " + SkillDef.skillName);
                return true;
            }
            else
            {
                SkillFamily skillFamily = currentSlot.skillFamily;
                Array.Resize(ref skillFamily.variants, skillFamily.variants.Length + 1);
                skillFamily.variants[Variant] = new SkillFamily.Variant
                {
                    skillDef = SkillDef,
                    viewableNode = new ViewablesCatalog.Node(SkillDef.skillName + "_TEST", false, null),
                };
                MonoBehaviour.print("Alt Skill Added: " + Slot + " - " + SkillDef.skillName);
                return true;
            }
        }
    }
}
