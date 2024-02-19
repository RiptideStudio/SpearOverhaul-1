using SpearOverhaul.GlobalStuff;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Armor;

[AutoloadEquip(new EquipType[] { EquipType.Body })]
public class GodslayerChestplate : ModItem
{
    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Godslayer's Shawl");
        // base.Tooltip.SetDefault("12% increased critical strike chance\n8% increased damage\nMax life increased by 20");
    }

    public override void SetDefaults()
    {
        base.Item.width = 18;
        base.Item.height = 18;
        base.Item.value = 110000;
        base.Item.rare = 8;
        base.Item.defense = 28;
    }

    public override void UpdateEquip(Player player)
    {
        player.GetModPlayer<GlobalPlayer>().spearDamage += (int)Math.Ceiling((double)((float)player.GetModPlayer<GlobalPlayer>().spearDamage * 0.08f));
        player.statLifeMax2 += 20;
        player.GetDamage(DamageClass.Generic) += 0.08f;
        player.GetCritChance(DamageClass.Generic) += 12f;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(null, "CrystalChestplate");
        recipe.AddIngredient(3261, 15);
        recipe.AddTile(412);
        recipe.Register();
    }
}
