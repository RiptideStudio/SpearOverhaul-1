//using Microsoft.Xna.Framework;
//using SpearOverhaul.GlobalStuff;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Terraria;

namespace SpearOverhaul.SpearProjectiles;

public class MoltenJabberSpear : SpearBase
{
    protected override float HoldoutRangeMax => 150;

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        _ = Main.player[base.Projectile.owner];
        if (Main.rand.Next(0, 2) == 1)
        {
            target.AddBuff(24, 120);
        }
    }

    public override bool PreAI()
    {
        Dust dust = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 158, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 200, default(Color), 1.2f);
        dust.velocity += base.Projectile.velocity;
        dust.noGravity = true;
        Dust dust2 = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 6, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 200, default(Color), 1.2f);
        dust2.velocity += base.Projectile.velocity;
        dust2.noGravity = true;
        return base.PreAI();
    }
}

//public class MoltenJabberSpear : ModProjectile
//{
//    private bool jab;

//    private int timer;

//    private bool moveBack;

//    public float movementFactor
//    {
//        get
//        {
//            return base.Projectile.ai[0] - 1.3f;
//        }
//        set
//        {
//            base.Projectile.ai[0] = value;
//        }
//    }

//    public override void SetStaticDefaults()
//    {
//        // base.DisplayName.SetDefault("Molten Spear");
//        ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 5;
//        ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
//    }

//    public override void SetDefaults()
//    {
//        base.Projectile.width = 28;
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
//        _ = Main.player[base.Projectile.owner];
//        if (Main.rand.Next(0, 2) == 1)
//        {
//            target.AddBuff(24, 120);
//        }
//        this.jab = true;
//    }

//    public override void AI()
//    {
//        if (this.jab)
//        {
//            this.timer++;
//        }
//        Dust dust = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 158, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 200, default(Color), 1.2f);
//        dust.velocity += base.Projectile.velocity;
//        dust.noGravity = true;
//        Dust dust2 = Dust.NewDustDirect(base.Projectile.position, base.Projectile.height, base.Projectile.width, 6, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 200, default(Color), 1.2f);
//        dust2.velocity += base.Projectile.velocity;
//        dust2.noGravity = true;
//        Player projOwner = Main.player[base.Projectile.owner];
//        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, reverseRotation: true);
//        base.Projectile.direction = projOwner.direction;
//        projOwner.heldProj = base.Projectile.whoAmI;
//        projOwner.itemTime = projOwner.itemAnimation;
//        base.Projectile.position.X = ownerMountedCenter.X - ((float)(base.Projectile.width / 2) + base.Projectile.velocity.X * 3f);
//        base.Projectile.position.Y = ownerMountedCenter.Y - ((float)(base.Projectile.height / 2) + base.Projectile.velocity.Y * 3f);
//        if (!projOwner.frozen)
//        {
//            if (this.movementFactor == 0f)
//            {
//                this.movementFactor = 1f;
//                base.Projectile.netUpdate = true;
//            }
//            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
//            {
//                this.movementFactor -= 0.22f;
//            }
//            else
//            {
//                this.movementFactor += 3.35f;
//            }
//        }
//        base.Projectile.position += base.Projectile.velocity * this.movementFactor;
//        if (projOwner.itemAnimation == 0)
//        {
//            base.Projectile.Kill();
//        }

//        GlobalProj.SpearHoming(Projectile, 5.33f);
//        base.Projectile.rotation = base.Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
//        if (base.Projectile.spriteDirection == -1)
//        {
//            base.Projectile.rotation -= MathHelper.ToRadians(90f);
//        }
//    }
//}
