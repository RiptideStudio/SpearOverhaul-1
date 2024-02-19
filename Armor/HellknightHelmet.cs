using System;
using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Head })]
public class HellknightHelmet : ModItem
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Hellknight Headgear");
		// base.Tooltip.SetDefault("12% increased melee damage\n5% increased melee critical strike chance");
	}

	public override void SetDefaults()
	{
		base.Item.width = 18;
		base.Item.height = 18;
		base.Item.value = 30000;
		base.Item.rare = 3;
		base.Item.defense = 7;
	}

	public override void UpdateArmorSet(Player player)
	{
		player.setBonus = "Spearheads explode on enemy contact";
		player.GetModPlayer<GlobalPlayer>().hellArmor = true;
	}

	public override void UpdateEquip(Player player)
	{
		player.GetDamage(DamageClass.Melee) += 0.12f;
		player.GetCritChance(DamageClass.Melee) += 5f;
		player.GetModPlayer<GlobalPlayer>().spearDamage += (int)Math.Ceiling((double)((float)player.GetModPlayer<GlobalPlayer>().spearDamage * 0.05f));
	}

	public override bool IsArmorSet(Item head, Item body, Item legs)
	{
		if (body.type == base.Mod.Find<ModItem>("HellknightChestplate").Type)
		{
			return legs.type == base.Mod.Find<ModItem>("HellknightLeggings").Type;
		}
		return false;
	}

	public override void AddRecipes()
	{
		Recipe recipe = base.CreateRecipe();
		recipe.AddIngredient(175, 10);
		recipe.AddIngredient(225, 2);
		recipe.AddTile(16);
		recipe.Register();
	}
}
