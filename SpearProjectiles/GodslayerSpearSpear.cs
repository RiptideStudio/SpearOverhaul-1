//using Microsoft.Xna.Framework;
//using SpearOverhaul.GlobalStuff;
//using Terraria;
//using Terraria.Audio;
//using Terraria.ID;
//using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.SpearProjectiles;

public class GodslayerSpearSpear : SpearBase
{
    protected override float HoldoutRangeMax => 280;

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        Projectile.NewProjectile(target.GetSource_Death(), target.Center.X - 35f, target.Center.Y - 35f, 0f, 0f, Mod.Find<ModProjectile>("LightExplosion").Type, 0, hit.Knockback, Main.LocalPlayer.whoAmI);
        Projectile.NewProjectile(target.GetSource_Death(), target.Center.X, target.Center.Y, Projectile.velocity.X, Projectile.velocity.Y, Mod.Find<ModProjectile>("Explosion").Type, hit.Damage, hit.Knockback, Main.LocalPlayer.whoAmI);
        SoundEngine.PlaySound(in SoundID.Item89, Projectile.position);
        for (int i = 0; i < 12; i++)
        {
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height * 2, Projectile.width * 2, DustID.GoldFlame, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 200, default, 1.5f);
            dust.velocity = Projectile.velocity * 2f;
            dust.velocity *= 0.5f;
        }
        if (Main.rand.Next(0, 3) == 1)
        {
            target.AddBuff(69, 300);
        }
    }

    public override bool PreAI()
    {
        Dust dust = Dust.NewDustDirect(Projectile.position - new Vector2(Projectile.velocity.X * 5f, Projectile.velocity.Y * 5f), Projectile.height, Projectile.width, DustID.Enchanted_Gold, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 200, default, 1.2f);
        dust.velocity += Projectile.velocity;
        dust.noGravity = true;
        Dust dust2 = Dust.NewDustDirect(Projectile.position - new Vector2(Projectile.velocity.X * 5f, Projectile.velocity.Y * 5f), Projectile.height, Projectile.width, DustID.GoldFlame, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 200, default, 1.6f);
        dust2.velocity += Projectile.velocity;
        dust2.noGravity = true;
        Dust dust3 = Dust.NewDustDirect(Projectile.position - new Vector2(Projectile.velocity.X * 5f, Projectile.velocity.Y * 5f), Projectile.height, Projectile.width, DustID.SpectreStaff, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 200, default, 1.2f);
        dust3.velocity += Projectile.velocity;
        dust3.noGravity = true;
        return base.PreAI();
    }
}
//public class GodslayerSpearSpear : SpearBase
//{
//    private bool jab;

//    private int timer;

//    private bool moveBack;

//    public float movementFactor
//    {
//        get
//        {
//            return Projectile.ai[0];
//        }
//        set
//        {
//            Projectile.ai[0] = value;
//        }
//    }

//    public override void SetStaticDefaults()
//    {
//        // DisplayName.SetDefault("God's Spear");
//        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
//        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
//    }

//    public override void SetDefaults()
//    {
//        Projectile.width = 85;
//        Projectile.height = 85;
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
//        //IL_00e7: Unknown result type (might be due to invalid IL or missing references)
//        Projectile.NewProjectile(target.GetSource_Death(), target.Center.X - 35f, target.Center.Y - 35f, 0f, 0f, Mod.Find<ModProjectile>("LightExplosion").Type, 0, hit.Knockback, Main.LocalPlayer.whoAmI);
//        Projectile.NewProjectile(target.GetSource_Death(), target.Center.X, target.Center.Y, Projectile.velocity.X, Projectile.velocity.Y, Mod.Find<ModProjectile>("Explosion").Type, hit.Damage, hit.Knockback, Main.LocalPlayer.whoAmI);
//        SoundEngine.PlaySound(in SoundID.Item89, Projectile.position);
//        for (int i = 0; i < 12; i++)
//        {
//            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.height * 2, Projectile.width * 2, DustID.GoldFlame, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 200, default, 1.5f);
//            dust.velocity = Projectile.velocity * 2f;
//            dust.velocity *= 0.5f;
//        }
//        if (Main.rand.Next(0, 3) == 1)
//        {
//            target.AddBuff(69, 300);
//        }
//    }

//    public override void AI()
//    {
//        if (this.jab)
//        {
//            this.timer++;
//        }
//        Dust dust = Dust.NewDustDirect(Projectile.position - new Vector2(Projectile.velocity.X * 5f, Projectile.velocity.Y * 5f), Projectile.height, Projectile.width, DustID.Enchanted_Gold, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 200, default, 1.2f);
//        dust.velocity += Projectile.velocity;
//        dust.noGravity = true;
//        Dust dust2 = Dust.NewDustDirect(Projectile.position - new Vector2(Projectile.velocity.X * 5f, Projectile.velocity.Y * 5f), Projectile.height, Projectile.width, DustID.GoldFlame, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 200, default, 1.6f);
//        dust2.velocity += Projectile.velocity;
//        dust2.noGravity = true;
//        Dust dust3 = Dust.NewDustDirect(Projectile.position - new Vector2(Projectile.velocity.X * 5f, Projectile.velocity.Y * 5f), Projectile.height, Projectile.width, DustID.SpectreStaff, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 200, default, 1.2f);
//        dust3.velocity += Projectile.velocity;
//        dust3.noGravity = true;
//        Player projOwner = Main.player[Projectile.owner];
//        Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, reverseRotation: true);
//        Projectile.direction = projOwner.direction;
//        projOwner.heldProj = Projectile.whoAmI;
//        projOwner.itemTime = projOwner.itemAnimation;
//        Projectile.position.X = ownerMountedCenter.X - ((float)(Projectile.width / 2) + Projectile.velocity.X * 3f);
//        Projectile.position.Y = ownerMountedCenter.Y - ((float)(Projectile.height / 2) + Projectile.velocity.Y * 3f);
//        if (!projOwner.frozen)
//        {
//            if (this.movementFactor == 0f)
//            {
//                this.movementFactor = 1f;
//                Projectile.netUpdate = true;
//            }
//            if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
//            {
//                this.movementFactor -= 3.75f;
//            }
//            else
//            {
//                this.movementFactor += 3.75f;
//            }
//        }
//        Projectile.position += Projectile.velocity * this.movementFactor;
//        if (projOwner.itemAnimation == 0)
//        {
//            Projectile.Kill();
//        }

//        GlobalProj.SpearHoming(Projectile, 7.25f);
//        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
//        if (Projectile.spriteDirection == -1)
//        {
//            Projectile.rotation -= MathHelper.ToRadians(90f);
//        }
//    }
//}
