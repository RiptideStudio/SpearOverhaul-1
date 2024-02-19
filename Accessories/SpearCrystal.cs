using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Accessories;

public class SpearCrystal : ModItem
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Kyber Crystal");
		// base.Tooltip.SetDefault("'Contains an incredible amount of latent energy'\nMelee damage and spear velocity increased by 12%\nGreatly increased health regeneration");
	}

	public override void SetDefaults()
	{
		base.Item.width = 24;
		base.Item.height = 28;
		base.Item.value = 0;
		base.Item.rare = 6;
		base.Item.value = 12500;
		base.Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<GlobalPlayer>().spearSpeed += 0.2f;
		player.GetDamage(DamageClass.Melee) += 0.12f;
		player.lifeRegen += 5;
	}

	public override void AddRecipes()
	{
		Recipe recipe = base.CreateRecipe();
		recipe.AddIngredient(502, 3);
		recipe.AddIngredient(520, 5);
		recipe.AddIngredient(521, 5);
		recipe.AddTile(134);
		recipe.Register();
	}
}
