using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class CactusSpike : ModItem
{
    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Cactus Spike");
        // base.Tooltip.SetDefault("Has a small chance to poison enemies");
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.damage = 8;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.useTime = 38;
        base.Item.useAnimation = 38;
        base.Item.knockBack = 5.5f;
        base.Item.useStyle = 5;
        base.Item.value = 200;
        base.Item.rare = 1;
        base.Item.shoot = base.Mod.Find<ModProjectile>("CactusSpikeSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 3.5f;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.noMelee = true;
        base.Item.noUseGraphic = true;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("CactusSpikeSpear").Type] < 1;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(276, 12);
        recipe.AddTile(18);
        recipe.Register();
    }
}
