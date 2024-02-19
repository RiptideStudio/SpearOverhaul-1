using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class KingSpear : ModItem
{
    private int hits;

    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Midas's Spear");
        // base.Tooltip.SetDefault("Releases a bolt of ichor\nThrown spears defy gravity, ricochet off walls and pierce more enemies\nHas a chance to inflict ichor\nHas an incredibly high critical-strike ratio");
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.CloneDefaults(280);
        base.Item.damage = 62;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.crit = 24;
        base.Item.useTime = 24;
        base.Item.useAnimation = 24;
        base.Item.knockBack = 9f;
        base.Item.value = 50000;
        base.Item.rare = 7;
        base.Item.shoot = base.Mod.Find<ModProjectile>("KingSpearSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 5.75f;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("KingSpearSpear").Type] < 1;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_000b: Unknown result type (might be due to invalid IL or missing references)
        SoundEngine.PlaySound(in SoundID.Item1, position);
        return true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(null, "HunterSpear");
        recipe.AddIngredient(null, "CrystalSpearHead");
        recipe.AddIngredient(1225, 10);
        recipe.AddIngredient(522, 15);
        recipe.AddTile(134);
        recipe.Register();
        Recipe recipe2 = base.CreateRecipe();
        recipe2.AddIngredient(null, "HunterSpear");
        recipe2.AddIngredient(null, "CrystalSpearHead");
        recipe2.AddIngredient(1225, 10);
        recipe2.AddIngredient(1332, 15);
        recipe2.AddTile(134);
        recipe2.Register();
    }
}
