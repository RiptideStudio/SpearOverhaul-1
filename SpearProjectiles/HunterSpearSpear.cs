//using Microsoft.Xna.Framework;
//using SpearOverhaul.GlobalStuff;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

namespace SpearOverhaul.SpearProjectiles;
public class HunterSpearSpear : SpearBase
{
    protected override float HoldoutRangeMax => 102;
}
//public class HunterSpearSpear : ModProjectile
//{
//    private int yy;

//    public float movementFactor
//    {
//        get
//        {
//            return base.Projectile.ai[0] - 1.25f;
//        }
//        set
//        {
//            base.Projectile.ai[0] = value;
//        }
//    }

//    public override void SetStaticDefaults()
//    {
//        // base.DisplayName.SetDefault("HunterSpearSpear");
//        ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 5;
//        ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
//    }

//    public override void SetDefaults()
//    {
//        base.Projectile.width = 24;
//        base.Projectile.height = 24;
//        base.Projectile.aiStyle = 19;
//        base.Projectile.penetrate = -1;
//        base.Projectile.scale = 1.25f;
//        base.Projectile.alpha = 0;
//        base.Projectile.hide = true;
//        base.Projectile.ownerHitCheck = true;
//        base.Projectile.DamageType = DamageClass.Melee;
//        base.Projectile.tileCollide = false;
//        base.Projectile.friendly = true;
//        base.Projectile.timeLeft = 60;
//    }

//    public override void AI()
//    {
//        Player projOwner = Main.player[base.Projectile.owner];
//        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, reverseRotation: true);
//        base.Projectile.direction = projOwner.direction;
//        projOwner.heldProj = base.Projectile.whoAmI;
//        projOwner.itemTime = projOwner.itemAnimation;
//        _ = (double)base.Projectile.ai[1] * 3.0;
//        this.yy++;
//        base.Projectile.position.X = ownerMountedCenter.X - (float)(base.Projectile.width / 2);
//        base.Projectile.position.Y = ownerMountedCenter.Y - (float)(base.Projectile.height / 2);
//        base.Projectile.ai[1] += 1f;
//        if (!projOwner.frozen)
//        {
//            if (this.movementFactor == 0f)
//            {
//                this.movementFactor = 2.6f;
//                base.Projectile.netUpdate = true;
//            }
//            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
//            {
//                this.movementFactor -= 0.125f;
//            }
//            else
//            {
//                this.movementFactor += 2.3f;
//            }
//        }
//        base.Projectile.position += base.Projectile.velocity * this.movementFactor;
//        if (projOwner.itemAnimation == 0)
//        {
//            base.Projectile.Kill();
//        }

//        GlobalProj.SpearHoming(Projectile, 3.6f);
//        base.Projectile.rotation = base.Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
//        if (base.Projectile.spriteDirection == -1)
//        {
//            base.Projectile.rotation -= MathHelper.ToRadians(90f);
//        }
//    }
//}
