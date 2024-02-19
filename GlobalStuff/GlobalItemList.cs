using Microsoft.Xna.Framework;
using SpearOverhaul.SpearProjectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.GlobalStuff;

public class GlobalItemList : GlobalItem
{
    public float awesome;

    private int hits;

    public override bool InstancePerEntity => true;

    protected override bool CloneNewInstances => true;


    public override void SetDefaults(Item item)
    {
        _ = Main.player[Main.myPlayer];
        if (ItemID.Sets.Spears[item.type])
        {
            item.autoReuse = true;
        }
        if (item.type == ItemID.Spear)
        {
            item.damage = 11;
        }
        if (item.type == ItemID.TitaniumTrident)
        {
            item.damage = 48;
        }
        if (item.type == ItemID.AdamantiteGlaive)
        {
            item.damage = 47;
        }
        if (item.type == ItemID.CobaltNaginata)
        {
            item.damage = 34;
        }
        if (item.type == ItemID.PalladiumPike)
        {
            item.damage = 36;
        }
        if (item.type == ItemID.MythrilHalberd)
        {
            item.damage = 40;
        }
        if (item.type == ItemID.OrichalcumHalberd)
        {
            item.damage = 42;
        }
        if (item.type == ItemID.RichMahoganyHelmet)
        {
            item.defense = 2;
            item.rare = 1;
        }
        if (item.type == ItemID.RichMahoganyBreastplate)
        {
            item.defense = 3;
            item.rare = 1;
        }
        if (item.type == ItemID.RichMahoganyGreaves)
        {
            item.defense = 2;
            item.rare = 1;
        }
    }

    public override bool CanUseItem(Item item, Player player)
    {
        if (ItemID.Sets.Spears[item.type] && item.type == ItemID.Spear)
        {
            return player.ownedProjectileCounts[ModContent.ProjectileType<SpearSpear>()] < 1;
        }
        return true;
    }

    public override void UpdateEquip(Item item, Player player)
    {
        if (item.type == ItemID.RichMahoganyHelmet)
        {
            player.GetDamage(DamageClass.Melee) += 0.05f;
        }
        if (item.type == ItemID.RichMahoganyBreastplate)
        {
            player.GetModPlayer<GlobalPlayer>().spearDamage += (int)Math.Ceiling((double)((float)player.GetModPlayer<GlobalPlayer>().spearDamage * 0.05f));
        }
        if (item.type == ItemID.RichMahoganyGreaves)
        {
            player.moveSpeed += 0.05f;
        }
    }

    public override bool AltFunctionUse(Item item, Player player)
    {
        if (ItemID.Sets.Spears[item.type])
        {
            return true;
        }
        return base.AltFunctionUse(item, player);
    }

    public override string IsArmorSet(Item head, Item body, Item legs)
    {
        if (body.type == ItemID.RichMahoganyBreastplate && head.type == ItemID.RichMahoganyHelmet && legs.type == ItemID.RichMahoganyGreaves)
        {
            return "Rich";
        }
        return "";
    }

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        _ = Main.LocalPlayer;
        if (item.type == ItemID.RichMahoganyHelmet)
        {
            TooltipLine line3 = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Defense" && x.Mod == "Terraria");
            if (line3 != null)
            {
                line3.Text = "2 defense\n5% increased melee damage";
            }
        }
        if (item.type == ItemID.RichMahoganyBreastplate)
        {
            TooltipLine line2 = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Defense" && x.Mod == "Terraria");
            if (line2 != null)
            {
                line2.Text = "3 defense\n5% increased melee damage";
            }
        }
        if (item.type == ItemID.RichMahoganyGreaves)
        {
            TooltipLine line = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "Defense" && x.Mod == "Terraria");
            if (line != null)
            {
                line.Text = "2 defense\n5% increased movement speed";
            }
        }
    }

    public override void UpdateArmorSet(Player player, string set)
    {
        if (set == "Rich")
        {
            player.setBonus = "2 defense\nMelee attacks may poison enemies";
            player.GetModPlayer<GlobalPlayer>().richArmor = true;
            player.statDefense++;
        }
    }

    public override void HoldItem(Item item, Player player)
    {
        if (item.type == ItemID.Spear)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 4;
        }
        if (item.type == base.Mod.Find<ModItem>("WoodenPike").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 2;
        }
        if (item.type == base.Mod.Find<ModItem>("BramblePartisan").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 15;
        }
        if (item.type == base.Mod.Find<ModItem>("ReinforcedPike").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 12;
        }
        if (item.type == base.Mod.Find<ModItem>("HunterSpear").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 21;
        }
        if (item.type == base.Mod.Find<ModItem>("DemonSpear").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 24;
        }
        if (item.type == base.Mod.Find<ModItem>("CrimsonSpear").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 22;
        }
        if (item.type == base.Mod.Find<ModItem>("FrozenSpear").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 11;
        }
        if (item.type == base.Mod.Find<ModItem>("MoltenJabber").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 30;
        }
        if (item.type == base.Mod.Find<ModItem>("MarbleSpear").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 25;
        }
        if (item.type == base.Mod.Find<ModItem>("ShadowLance").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 44;
        }
        if (item.type == base.Mod.Find<ModItem>("CactusSpike").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 6;
        }
        if (item.type == base.Mod.Find<ModItem>("CrystalCrusher").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 41;
        }
        if (item.type == base.Mod.Find<ModItem>("KingSpear").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 56;
        }
        if (item.type == base.Mod.Find<ModItem>("ElementalSpear").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 38;
        }
        if (item.type == base.Mod.Find<ModItem>("GodslayerSpear").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 151;
        }
        if (item.type == base.Mod.Find<ModItem>("PaladinSpear").Type)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 87;
        }
        if (item.type == ItemID.Trident)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 8;
        }
        if (item.type == ItemID.Gungnir)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 55;
        }
        if (item.type == ItemID.AdamantiteGlaive)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 44;
        }
        if (item.type == ItemID.ChlorophytePartisan)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 54;
        }
        if (item.type == ItemID.CobaltNaginata)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 32;
        }
        if (item.type == ItemID.DarkLance)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 31;
        }
        if (item.type == ItemID.MushroomSpear)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 101;
        }
        if (item.type == ItemID.MythrilHalberd)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 39;
        }
        if (item.type == ItemID.NorthPole)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 101;
        }
        if (item.type == ItemID.ObsidianSwordfish)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 76;
        }
        if (item.type == ItemID.OrichalcumHalberd)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 40;
        }
        if (item.type == ItemID.PalladiumPike)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 37;
        }
        if (item.type == ItemID.Swordfish)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 19;
        }
        if (item.type == ItemID.TheRottedFork)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 12;
        }
        if (item.type == ItemID.TitaniumTrident)
        {
            player.GetModPlayer<GlobalPlayer>().bonusSpearDamage = 46;
        }
        if (ItemID.Sets.Spears[item.type])
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 1;
            }
            else
            {
                item.useStyle = 5;
            }
        }
    }

    public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (ItemID.Sets.Spears[item.type])
        {
            if (player.GetModPlayer<GlobalPlayer>().crystalArmor)
            {
                this.hits++;
                if (this.hits == 5)
                {
                    this.hits = 0;
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * 3f, velocity.Y * 3f), 521, damage, knockback, player.whoAmI);
                }
            }
            if (player.GetModPlayer<GlobalPlayer>().tribalArmor && ItemID.Sets.Spears[item.type])
            {
                knockback *= 1.2f;
            }
            float spearSpeed = player.GetModPlayer<GlobalPlayer>().spearSpeed;
            int spearDamage = player.GetModPlayer<GlobalPlayer>().spearDamage;
            spearDamage += damage;
            if (player.altFunctionUse == 2)
            {
                bool shoot = true;
                if (item.type == base.Mod.Find<ModItem>("ShadowLance").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("DarkflameSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("CactusSpike").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("CactusSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("BramblePartisan").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("BramblePartisanThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("DemonSpear").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("DemonSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("CrimsonSpear").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("CrimsonSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("FrozenSpear").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("FrozenSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("WoodenPike").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("WoodenSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("ReinforcedPike").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("ReinforcedSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("HunterSpear").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("HunterSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("MoltenJabber").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("MoltenSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("MarbleSpear").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("MarbleSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("CrystalCrusher").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("CrystalSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("KingSpear").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("KingSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("ElementalSpear").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("ElementalSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("GodslayerSpear").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("GodslayerSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == base.Mod.Find<ModItem>("PaladinSpear").Type)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (2.75f + spearSpeed), velocity.Y * (2.75f + spearSpeed)), base.Mod.Find<ModProjectile>("PaladinSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 406)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("AdamantiteSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 1228)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("ChlorophyteSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 537)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("CobaltSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 274)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("DarkLanceSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 550)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("GungnirSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 756)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("MushroomSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 390)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("MythrilSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 1947)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("NorthPoleSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 2331)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("ObsidianSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 1193)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("OrichalcumSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 1186)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("PalladiumSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 280)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("SpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 802)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("RottedSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 1200)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("TitaniumSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                if (item.type == 277)
                {
                    Projectile.NewProjectile(source, position, new Vector2(velocity.X * (1.75f + spearSpeed), velocity.Y * (1.75f + spearSpeed)), base.Mod.Find<ModProjectile>("TridentSpearThrown").Type, spearDamage, knockback / 2f, player.whoAmI);
                    shoot = false;
                }
                return shoot;
            }
            if (item.type == ItemID.Spear)
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<SpearSpear>(), damage, knockback, player.whoAmI);
                item.autoReuse = true;
                return false;
            }
        }
        return true;
    }
}
