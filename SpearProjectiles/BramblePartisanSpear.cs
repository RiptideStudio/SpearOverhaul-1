//using Microsoft.Xna.Framework;
//using SpearOverhaul.GlobalStuff;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

namespace SpearOverhaul.SpearProjectiles;
public class BramblePartisanSpear : SpearBase
{
    protected override float HoldoutRangeMax => base.HoldoutRangeMax;
}
//public class BramblePartisanSpear : ModProjectile
//{
//    private int num;

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
//        // base.DisplayName.SetDefault("BramblePartisanSpear");
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

//    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
//    {
//        if (Main.rand.Next(0, 3) == 1)
//        {
//            target.AddBuff(20, 180);
//        }
//    }

//    public override void AI()
//    {
//        if (Main.rand.NextBool(2))
//        {
//            Dust dust = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 46, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 200, default(Color), 1.2f);
//            dust.velocity += base.Projectile.velocity * 0.3f;
//            dust.velocity *= 0.2f;
//        }
//        if (Main.rand.NextBool(3))
//        {
//            Dust dust2 = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 44, 0f, 0f, 254, default(Color), 0.3f);
//            dust2.velocity += base.Projectile.velocity * 0.5f;
//            dust2.velocity *= 0.5f;
//        }
//        Player projOwner = Main.player[base.Projectile.owner];
//        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, reverseRotation: true);
//        base.Projectile.direction = projOwner.direction;
//        projOwner.heldProj = base.Projectile.whoAmI;
//        projOwner.itemTime = projOwner.itemAnimation;
//        base.Projectile.position.X = ownerMountedCenter.X - ((float)(base.Projectile.width / 2) - base.Projectile.velocity.X);
//        base.Projectile.position.Y = ownerMountedCenter.Y - ((float)(base.Projectile.height / 2) - base.Projectile.velocity.Y);
//        if (!projOwner.frozen)
//        {
//            if (this.movementFactor == 0f)
//            {
//                this.movementFactor = 1f;
//                base.Projectile.netUpdate = true;
//            }
//            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 4)
//            {
//                this.movementFactor -= 0.2f;
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

//        GlobalProj.SpearHoming(Projectile, 5f);
//        base.Projectile.rotation = base.Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
//        if (base.Projectile.spriteDirection == -1)
//        {
//            base.Projectile.rotation -= MathHelper.ToRadians(90f);
//        }
//    }
//}
