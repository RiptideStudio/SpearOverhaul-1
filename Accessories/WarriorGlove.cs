using System;
using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Accessories;

public class WarriorGlove : ModItem
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Tribal Gauntlet");
		// base.Tooltip.SetDefault("12% increased melee damage\nSlightly increases spear size\n15% increased spear velocity\nThrown spear penetration increased by 1");
	}

	public override void SetDefaults()
	{
		base.Item.width = 24;
		base.Item.height = 28;
		base.Item.value = 0;
		base.Item.rare = 3;
		base.Item.value = 20000;
		base.Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool showVisual)
	{
		player.GetModPlayer<GlobalPlayer>().spearSpeed += 0.25f;
		player.GetDamage(DamageClass.Melee) += 0.12f;
		player.ghostFrame = 1;
		player.ghostFade = 2.1f;
		player.GetModPlayer<GlobalPlayer>().spearDamage += (int)Math.Ceiling((double)((float)player.GetModPlayer<GlobalPlayer>().spearDamage * 0.12f));
	}

	public override void AddRecipes()
	{
		Recipe recipe = base.CreateRecipe();
		recipe.AddIngredient(null, "TribalGlove");
		recipe.AddIngredient(86, 5);
		recipe.AddIngredient(620, 15);
		recipe.AddIngredient(210, 2);
		recipe.AddIngredient(259, 3);
		recipe.AddTile(16);
		recipe.Register();
		Recipe recipe2 = base.CreateRecipe();
		recipe2.AddIngredient(null, "TribalGlove");
		recipe2.AddIngredient(1329, 5);
		recipe2.AddIngredient(620, 15);
		recipe2.AddIngredient(210, 2);
		recipe2.AddIngredient(259, 3);
		recipe2.AddTile(16);
		recipe2.Register();
	}
}
