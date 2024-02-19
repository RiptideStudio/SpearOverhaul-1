using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Accessories;

public class SawmillBox : ModItem
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Box o'Saws");
		// base.Tooltip.SetDefault("'Why are there holes in my pockets?'\nIncreased melee damage by 5%\n10% increased thrown spear velocity");
	}

	public override void SetDefaults()
	{
		base.Item.width = 24;
		base.Item.height = 28;
		base.Item.value = 0;
		base.Item.rare = 2;
		base.Item.value = 1250;
		base.Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<GlobalPlayer>().spearSpeed += 0.15f;
		player.GetDamage(DamageClass.Melee) += 0.05f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = base.CreateRecipe();
		recipe.AddIngredient(259, 5);
		recipe.AddRecipeGroup("IronBar", 3);
		recipe.AddIngredient(null, "SpearHead", 3);
		recipe.AddTile(16);
		recipe.Register();
	}
}
