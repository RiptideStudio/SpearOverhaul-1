using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Legs })]
public class TribalPants : ModItem
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Tribal Pants");
		// base.Tooltip.SetDefault("3% increased melee damage\n7% increased movement speed");
	}

	public override void SetDefaults()
	{
		base.Item.width = 18;
		base.Item.height = 18;
		base.Item.value = 1250;
		base.Item.rare = 2;
		base.Item.defense = 4;
	}

	public override void UpdateEquip(Player player)
	{
		player.moveSpeed += 0.07f;
		player.GetDamage(DamageClass.Melee) += 0.03f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = base.CreateRecipe();
		recipe.AddIngredient(259, 3);
		recipe.AddIngredient(735);
		recipe.AddIngredient(331, 2);
		recipe.AddTile(16);
		recipe.Register();
	}
}
