//using Microsoft.Xna.Framework;
//using SpearOverhaul.GlobalStuff;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Terraria;

namespace SpearOverhaul.SpearProjectiles;
public class DarkflameSpearSpear : SpearBase
{
    protected override float HoldoutRangeMax => 170;
    private int timer = 0;

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        _ = Main.player[Projectile.owner];
        if (Main.rand.Next(0, 2) == 1)
        {
            target.AddBuff(24, 120);
        }
    }

    public override bool PreAI()
    {
        timer++;
        Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 65, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 1f, 0, default(Color), 1.2f);
        dust.velocity += Projectile.velocity;
        dust.noGravity = true;
        dust.scale = Main.rand.Next(150, 216) * 0.013f;
        Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 65, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 1f, 0, default(Color), 1.2f);
        dust2.velocity += Projectile.velocity;

        if (timer % 6 == 0)
        {
            int proj = Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center.X + Projectile.velocity.X * timer, Projectile.Center.Y + Projectile.velocity.Y * timer, 0f, 0f, 45, Projectile.damage, 0f, Projectile.whoAmI);
            Main.projectile[proj].timeLeft = 90;
            Main.projectile[proj].scale = 0.75f;
        }

        return base.PreAI();
    }
}
//public class DarkflameSpearSpear : ModProjectile
//{
//    private bool jab;

//    private int timer = 9;

//    private bool moveBack;

//    public float movementFactor
//    {
//        get
//        {
//            return Projectile.ai[0] - 1.4f;
//        }
//        set
//        {
//            Projectile.ai[0] = value;
//        }
//    }

//    public override void SetStaticDefaults()
//    {
//        // DisplayName.SetDefault("Darkflame Spear");
//        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
//        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
//    }

//    public override void SetDefaults()
//    {
//        Projectile.width = 28;
//        Projectile.height = 24;
//        Projectile.aiStyle = 19;
//        Projectile.penetrate = -1;
//        Projectile.scale = 1.25f;
//        Projectile.alpha = 0;
//        Projectile.hide = true;
//        Projectile.ownerHitCheck = true;
//        Projectile.DamageType = DamageClass.Melee;
//        Projectile.tileCollide = false;
//        Projectile.friendly = true;
//        Projectile.timeLeft = 60;
//    }

//    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
//    {
//        _ = Main.player[Projectile.owner];
//        if (Main.rand.Next(0, 2) == 1)
//        {
//            target.AddBuff(24, 120);
//        }
//        jab = true;
//    }

//    public override void AI()
//    {
//        timer++;
//        Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 65, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 1f, 0, default(Color), 1.2f);
//        dust.velocity += Projectile.velocity;
//        dust.noGravity = true;
//        dust.scale = Main.rand.Next(150, 216) * 0.013f;
//        Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.height, Projectile.width, 65, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 1f, 0, default(Color), 1.2f);
//        dust2.velocity += Projectile.velocity;
//        Player projOwner = Main.player[Projectile.owner];
//        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, reverseRotation: true);
//        Projectile.direction = projOwner.direction;
//        projOwner.heldProj = Projectile.whoAmI;
//        projOwner.itemTime = projOwner.itemAnimation;
//        Projectile.position.X = ownerMountedCenter.X - ((Projectile.width / 2) + Projectile.velocity.X * 8f);
//        Projectile.position.Y = ownerMountedCenter.Y - ((Projectile.height / 2) + Projectile.velocity.Y * 8f);
//        dust2.noGravity = true;
//        if (timer % 10 == 0)
//        {
//            int proj = Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center.X + Projectile.velocity.X * timer, Projectile.Center.Y + Projectile.velocity.Y * timer, 0f, 0f, 45, Projectile.damage, 0f, projOwner.whoAmI);
//            Main.projectile[proj].timeLeft = 90;
//            Main.projectile[proj].scale = 0.75f;
//        }
//        if (!projOwner.frozen)
//        {
//            if (movementFactor == 0f)
//            {
//                movementFactor = 1f;
//                Projectile.netUpdate = true;
//            }
//            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
//            {
//                movementFactor -= 0.22f;
//                moveBack = true;
//            }
//            else
//            {
//                movementFactor += 2.55f + Projectile.scale / 1f;
//            }
//        }
//        Projectile.position += Projectile.velocity * movementFactor;
//        if (projOwner.itemAnimation == 0)
//        {
//            Projectile.Kill();
//        }

//        GlobalProj.SpearHoming(Projectile, 5.5f);
//        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
//        if (Projectile.spriteDirection == -1)
//        {
//            Projectile.rotation -= MathHelper.ToRadians(90f);
//        }
//    }
//}
