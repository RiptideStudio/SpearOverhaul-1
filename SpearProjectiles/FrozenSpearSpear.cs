//using Microsoft.Xna.Framework;
//using SpearOverhaul.GlobalStuff;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Terraria;

namespace SpearOverhaul.SpearProjectiles;

public class FrozenSpearSpear : SpearBase
{
    protected override float HoldoutRangeMax => base.HoldoutRangeMax;

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (Main.rand.Next(0, 3) == 1)
        {
            target.AddBuff(44, 120);
        }
    }

    public override bool PreAI()
    {
        Dust dust = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 135, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 200, default(Color), 1.2f);
        dust.velocity = base.Projectile.velocity / 2f;
        dust.noGravity = true;
        Dust dust2 = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 135, 0f, 0f, 254, default(Color), 0.3f);
        dust2.velocity = base.Projectile.velocity / 2f;
        dust2.noGravity = true;
        Player projOwner = Main.player[base.Projectile.owner];
        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, reverseRotation: true);
        base.Projectile.direction = projOwner.direction;
        projOwner.heldProj = base.Projectile.whoAmI;
        projOwner.itemTime = projOwner.itemAnimation;
        base.Projectile.position.X = ownerMountedCenter.X - ((float)(base.Projectile.width / 2) - base.Projectile.velocity.X);
        base.Projectile.position.Y = ownerMountedCenter.Y - ((float)(base.Projectile.height / 2) - base.Projectile.velocity.Y);
        return base.PreAI();
    }
}

//public class FrozenSpearSpear : ModProjectile
//{
//    public float movementFactor
//    {
//        get
//        {
//            return base.Projectile.ai[0] - 0.75f;
//        }
//        set
//        {
//            base.Projectile.ai[0] = value;
//        }
//    }

//    public override void SetStaticDefaults()
//    {
//        // base.DisplayName.SetDefault("Frozen Spear");
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
//            target.AddBuff(44, 120);
//        }
//    }

//    public override void AI()
//    {
//        Dust dust = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 135, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 200, default(Color), 1.2f);
//        dust.velocity = base.Projectile.velocity / 2f;
//        dust.noGravity = true;
//        Dust dust2 = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 135, 0f, 0f, 254, default(Color), 0.3f);
//        dust2.velocity = base.Projectile.velocity / 2f;
//        dust2.noGravity = true;
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
//            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
//            {
//                this.movementFactor -= 0.21f;
//            }
//            else
//            {
//                this.movementFactor += 1.5f;
//            }
//        }
//        base.Projectile.position += base.Projectile.velocity * this.movementFactor;
//        if (projOwner.itemAnimation == 0)
//        {
//            base.Projectile.Kill();
//        }

//        GlobalProj.SpearHoming(Projectile, 3.5f);
//        base.Projectile.rotation = base.Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
//        if (base.Projectile.spriteDirection == -1)
//        {
//            base.Projectile.rotation -= MathHelper.ToRadians(90f);
//        }
//    }
//}
