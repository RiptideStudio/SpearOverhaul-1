using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class CrimsonSpear : ModItem
{
    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Crimson Carnage");
        // base.Tooltip.SetDefault("Casts a blast of blood energy each time the spear is thrusted");
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.CloneDefaults(280);
        base.Item.damage = 22;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.useTime = 23;
        base.Item.useAnimation = 23;
        base.Item.knockBack = 6.5f;
        base.Item.value = 15000;
        base.Item.rare = 3;
        base.Item.shoot = base.Mod.Find<ModProjectile>("CrimsonSpearSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 5.5f;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("CrimsonSpearSpear").Type] < 1;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(null, "SpearHead");
        recipe.AddIngredient(1257, 12);
        recipe.AddIngredient(1329, 3);
        recipe.AddTile(16);
        recipe.Register();
    }
}
