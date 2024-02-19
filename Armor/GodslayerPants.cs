using System;
using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Legs })]
public class GodslayerPants : ModItem
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Godslayer's Pants");
		// base.Tooltip.SetDefault("12% increased melee damage\nGreatly increased mobility\nMax life increased by 20");
	}

	public override void SetDefaults()
	{
		base.Item.width = 18;
		base.Item.height = 18;
		base.Item.value = 60000;
		base.Item.rare = 8;
		base.Item.defense = 22;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetDamage(DamageClass.Melee) += 0.12f;
		player.GetModPlayer<GlobalPlayer>().spearDamage += (int)Math.Ceiling((double)((float)player.GetModPlayer<GlobalPlayer>().spearDamage * 0.1f));
		player.moveSpeed += 0.3f;
		player.runAcceleration += 0.125f;
		player.statLifeMax2 += 20;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		if (body.type == base.Mod.Find<ModItem>("CrystalChestplate").Type)
		{
			return legs.type == base.Mod.Find<ModItem>("CrystalLegs").Type;
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = base.CreateRecipe();
		recipe.AddIngredient(null, "CrystalLegs");
		recipe.AddIngredient(3261, 12);
		recipe.AddTile(412);
		recipe.Register();
	}
}
