using System;
using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Accessories;

public class TribalGlove : ModItem
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Feral Glove");
		// base.Tooltip.SetDefault("'Why's the inside warm?'\n7% increased melee damage\n12% increased thrown spear velocity");
	}

	public override void SetDefaults()
	{
		base.Item.width = 24;
		base.Item.height = 28;
		base.Item.value = 0;
		base.Item.rare = 2;
		base.Item.value = 15000;
		base.Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<GlobalPlayer>().spearSpeed += 0.25f;
		player.GetDamage(DamageClass.Melee) += 0.07f;
		player.GetModPlayer<GlobalPlayer>().spearDamage += (int)Math.Ceiling((double)((float)player.GetModPlayer<GlobalPlayer>().spearDamage * 0.09f));
	}

	public override void AddRecipes()
	{
		Recipe recipe = base.CreateRecipe();
		recipe.AddIngredient(620, 12);
		recipe.AddIngredient(331, 5);
		recipe.AddIngredient(259);
		recipe.AddTile(16);
		recipe.Register();
	}
}
