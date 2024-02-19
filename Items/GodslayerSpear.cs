using Microsoft.Xna.Framework;
using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class GodslayerSpear : ModItem
{
    private int hits;

    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("The Godslayer");
        // base.Tooltip.SetDefault("'Contains the power of the gods'\nCreates explosions of golden light on impact\nSecondary spears are thrown forward from the central spear\nInflicts ichor");
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.CloneDefaults(280);
        base.Item.damage = 142;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.crit = 20;
        base.Item.useTime = 21;
        base.Item.useAnimation = 21;
        base.Item.knockBack = 13f;
        base.Item.value = 250000;
        base.Item.rare = 9;
        base.Item.shoot = base.Mod.Find<ModProjectile>("GodslayerSpearSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 7.25f;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("GodslayerSpearSpear").Type] < 1;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_012e: Unknown result type (might be due to invalid IL or missing references)
        float spearSpeed = player.GetModPlayer<GlobalPlayer>().spearSpeed;
        int spearDamage = player.GetModPlayer<GlobalPlayer>().spearDamage;
        Projectile.NewProjectile(source, position, new Vector2(velocity.X * 1.5f + spearSpeed, velocity.Y * 1.5f + spearSpeed).RotatedByRandom(MathHelper.ToRadians(25f)), base.Mod.Find<ModProjectile>("GodslayerSpearThrown").Type, spearDamage, knockback, player.whoAmI);
        Projectile.NewProjectile(source, position, new Vector2(velocity.X * 1.5f + spearSpeed, velocity.Y * 1.5f + spearSpeed).RotatedByRandom(MathHelper.ToRadians(-25f)), base.Mod.Find<ModProjectile>("GodslayerSpearThrown").Type, spearDamage, knockback, player.whoAmI);
        Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20f));
        Projectile.NewProjectile(source, position, perturbedSpeed, base.Mod.Find<ModProjectile>("GodslayerSpearSpear").Type, damage, knockback, player.whoAmI);
        SoundEngine.PlaySound(in SoundID.Item73, position);
        return true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(null, "KingSpear");
        recipe.AddIngredient(null, "MarbleSpear");
        recipe.AddIngredient(null, "PaladinSpear");
        recipe.AddIngredient(520, 15);
        recipe.AddIngredient(3261, 10);
        recipe.AddIngredient(3458, 5);
        recipe.AddTile(412);
        recipe.Register();
    }
}
