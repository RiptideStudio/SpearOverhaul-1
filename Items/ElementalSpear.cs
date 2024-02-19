using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class ElementalSpear : ModItem
{
    private int shots;

    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Elemental Thrasher");
        // base.Tooltip.SetDefault("Jabs and throws incredibly fast\nCasts a fireball every third thrust\nCasts a beam of ice every fifth thrust\nInflicts frostburn and lights enemies ablaze");
        Main.RegisterItemAnimation(base.Item.type, new DrawAnimationVertical(6, 4));
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.damage = 68;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.useTime = 15;
        base.Item.useAnimation = 15;
        base.Item.knockBack = 9f;
        base.Item.value = 100000;
        base.Item.rare = 8;
        base.Item.shoot = base.Mod.Find<ModProjectile>("ElementalSpearSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 7f;
        base.Item.noMelee = true;
        base.Item.noUseGraphic = true;
        base.Item.useStyle = 5;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("ElementalSpearSpear").Type] < 1;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_00f1: Unknown result type (might be due to invalid IL or missing references)
        this.shots++;
        if (this.shots == 3)
        {
            int proj = Projectile.NewProjectile(source, position, velocity * 2f, 258, damage, knockback, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].timeLeft = 300;
        }
        if (this.shots == 5)
        {
            Projectile.NewProjectile(source, position, velocity, 118, damage, knockback, player.whoAmI);
            this.shots = 0;
        }
        Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20f));
        Projectile.NewProjectile(source, position, perturbedSpeed, base.Mod.Find<ModProjectile>("ElementalSpearSpear").Type, damage * 2, knockback, player.whoAmI);
        SoundEngine.PlaySound(in SoundID.Item73, position);
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(null, "MoltenJabber");
        recipe.AddIngredient(null, "FrozenSpear");
        recipe.AddIngredient(null, "CrystalSpearHead");
        recipe.AddIngredient(1508, 2);
        recipe.AddIngredient(547, 5);
        recipe.AddIngredient(548, 5);
        recipe.AddIngredient(549, 5);
        recipe.AddTile(134);
        recipe.Register();
    }
}
