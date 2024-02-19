using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class MarbleSpear : ModItem
{
    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Victory");
        // base.Tooltip.SetDefault("Slams enemies with marble explosions on impact, dealing area damage");
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.CloneDefaults(280);
        base.Item.damage = 25;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.useTime = 25;
        base.Item.useAnimation = 25;
        base.Item.knockBack = 7.5f;
        base.Item.value = 38000;
        base.Item.rare = 4;
        base.Item.crit = 8;
        base.Item.shoot = base.Mod.Find<ModProjectile>("MarbleSpearSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 6f;
        base.Item.noMelee = true;
        base.Item.noUseGraphic = true;
        base.Item.useStyle = 5;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_000b: Unknown result type (might be due to invalid IL or missing references)
        SoundEngine.PlaySound(in SoundID.Item1, position);
        return true;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("MarbleSpearSpear").Type] < 1;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(null, "SpearHead");
        recipe.AddIngredient(19, 12);
        recipe.AddIngredient(173, 35);
        recipe.AddIngredient(86, 3);
        recipe.AddIngredient(3066, 25);
        recipe.AddTile(16);
        recipe.Register();
        Recipe recipe2 = base.CreateRecipe();
        recipe2.AddIngredient(null, "SpearHead");
        recipe2.AddIngredient(19, 12);
        recipe2.AddIngredient(173, 35);
        recipe2.AddIngredient(1329, 3);
        recipe2.AddIngredient(3066, 25);
        recipe2.AddTile(16);
        recipe2.Register();
    }
}
