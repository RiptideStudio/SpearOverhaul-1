using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class WoodenPike : ModItem
{
    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Wooden Pike");
        // base.Tooltip.SetDefault("Thrown spears cause enemies to bleed\nBleeding enemies take 20% more damage from projectiles, including spears");
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.damage = 6;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.useTime = 35;
        base.Item.useAnimation = 35;
        base.Item.knockBack = 5f;
        base.Item.useStyle = 5;
        base.Item.value = 100;
        base.Item.rare = 0;
        base.Item.shoot = base.Mod.Find<ModProjectile>("WoodenPikeSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 3f;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.noMelee = true;
        base.Item.noUseGraphic = true;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("WoodenPikeSpear").Type] < 1;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddRecipeGroup("Wood", 12);
        recipe.AddTile(18);
        recipe.Register();
    }
}
