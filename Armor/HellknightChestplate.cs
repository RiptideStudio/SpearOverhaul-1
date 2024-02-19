using System;
using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Body })]
public class HellknightChestplate : ModItem
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Hellknight Chestpiece");
		// base.Tooltip.SetDefault("7% increased critical strike chance\n5% increased damage");
	}

	public override void SetDefaults()
	{
		base.Item.width = 18;
		base.Item.height = 18;
		base.Item.value = 35000;
		base.Item.rare = 3;
		base.Item.defense = 9;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetModPlayer<GlobalPlayer>().spearDamage += (int)Math.Ceiling((double)((float)player.GetModPlayer<GlobalPlayer>().spearDamage * 0.05f));
		player.GetCritChance(DamageClass.Generic) += 7f;
		player.GetDamage(DamageClass.Generic) += 0.05f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = base.CreateRecipe();
		recipe.AddIngredient(175, 20);
		recipe.AddIngredient(225, 5);
		recipe.AddTile(16);
		recipe.Register();
	}
}
