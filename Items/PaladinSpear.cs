using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class PaladinSpear : ModItem
{
    private int hits;

    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Paladin's Naginata");
        // base.Tooltip.SetDefault("Right-click to throw a returning spear\nThrown spear goes through tiles\nHeals on critical hits\nInflicts ichor");
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.CloneDefaults(280);
        base.Item.damage = 88;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.crit = 12;
        base.Item.useTime = 20;
        base.Item.useAnimation = 20;
        base.Item.knockBack = 9.5f;
        base.Item.value = 120000;
        base.Item.rare = 8;
        base.Item.shoot = base.Mod.Find<ModProjectile>("PaladinSpearSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 6.25f;
    }

    public override bool AltFunctionUse(Player player)
    {
        return true;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("PaladinSpearSpear").Type] < 1;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_000b: Unknown result type (might be due to invalid IL or missing references)
        SoundEngine.PlaySound(in SoundID.Item73, position);
        return true;
    }
}
