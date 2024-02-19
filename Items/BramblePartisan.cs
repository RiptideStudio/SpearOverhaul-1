using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Items;

public class BramblePartisan : ModItem
{
    private int num;

    public override void SetStaticDefaults()
    {
        // base.DisplayName.SetDefault("Bramble Partisan");
        // base.Tooltip.SetDefault("Releases a stinger every third strike\nHas a chance to poison enemies");
        ItemID.Sets.Spears[Type] = true;
    }

    public override void SetDefaults()
    {
        base.Item.damage = 17;
        base.Item.DamageType = DamageClass.Melee;
        base.Item.width = 40;
        base.Item.height = 40;
        base.Item.useTime = 25;
        base.Item.useAnimation = 25;
        base.Item.knockBack = 5.5f;
        base.Item.value = 12500;
        base.Item.rare = 3;
        base.Item.shoot = base.Mod.Find<ModProjectile>("BramblePartisanSpear").Type;
        base.Item.UseSound = SoundID.Item1;
        base.Item.autoReuse = true;
        base.Item.shootSpeed = 5f;
        base.Item.noMelee = true;
        base.Item.noUseGraphic = true;
        base.Item.useStyle = 5;
    }

    public override bool CanUseItem(Player player)
    {
        return player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("BramblePartisanSpear").Type] < 1;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        //IL_0025: Unknown result type (might be due to invalid IL or missing references)
        this.num++;
        if (this.num == 3)
        {
            SoundEngine.PlaySound(in SoundID.Item17, position);
            position = new Vector2(position.X + velocity.X, position.Y + velocity.Y);
            int proj = Projectile.NewProjectile(source, position, velocity * 2f, 55, damage, knockback / 2f, player.whoAmI);
            Main.projectile[proj].friendly = true;
            Main.projectile[proj].hostile = false;
            Main.projectile[proj].penetrate = 2;
            this.num = 0;
        }
        return true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = base.CreateRecipe();
        recipe.AddIngredient(null, "SpearHead");
        recipe.AddIngredient(620, 18);
        recipe.AddIngredient(331, 8);
        recipe.AddIngredient(209, 5);
        recipe.AddIngredient(210);
        recipe.AddTile(16);
        recipe.Register();
    }
}
