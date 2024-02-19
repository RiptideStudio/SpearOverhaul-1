using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.GlobalStuff;

public class GlobalProj : GlobalProjectile
{
    private int projectileHits;

    private int time;

    public override bool InstancePerEntity => true;

    protected override bool CloneNewInstances => false;

    public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
    {
        //IL_019f: Unknown result type (might be due to invalid IL or missing references)
        Player player = Main.player[projectile.owner];
        if (player.GetModPlayer<GlobalPlayer>().richArmor && projectile.CountsAsClass(DamageClass.Melee) && Main.rand.Next(0, 3) == 1)
        {
            target.AddBuff(20, 120);
        }
        if (player.GetModPlayer<GlobalPlayer>().hellGlove && projectile.CountsAsClass(DamageClass.Melee) && Main.rand.Next(0, 4) == 1)
        {
            target.AddBuff(24, 60);
        }
        if (!player.GetModPlayer<GlobalPlayer>().hellArmor || !projectile.CountsAsClass(DamageClass.Melee))
        {
            return;
        }
        if (Main.rand.Next(0, 3) == 1)
        {
            target.AddBuff(24, 120);
        }
        if (projectile.extraUpdates != 1)
        {
            Projectile.NewProjectile(projectile.GetSource_Death(), target.Center.X - 12f, target.Center.Y, 0f, 0f, base.Mod.Find<ModProjectile>("ExplosionLarge").Type, 0, 0f, player.whoAmI);
            Player p = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.GetSource_Death(), target.Center.X, target.Center.Y, projectile.velocity.X, projectile.velocity.Y, base.Mod.Find<ModProjectile>("ExplosionBig").Type, projectile.damage / 2, modifiers.Knockback.Base, p.whoAmI);
            SoundEngine.PlaySound(in SoundID.Item14, projectile.position);
            for (int num369 = 0; num369 < 8; num369++)
            {
                int num370 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.GemTopaz, 0f, 0f, 100, default, 1.5f);
                Main.dust[num370].velocity *= 3f;
                Main.dust[num370].noGravity = true;
            }
            for (int num371 = 0; num371 < 5; num371++)
            {
                int num372 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Torch, 0f, 0f, 100, default, 2.5f);
                Main.dust[num372].noGravity = true;
                Main.dust[num372].velocity *= 5f;
                num372 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                Main.dust[num372].velocity = projectile.velocity * 0.5f;
                Main.dust[num372].noGravity = true;
            }
            for (int i = 0; i < 6; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.GemTopaz);
                Main.dust[dust].noGravity = true;
                int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Torch);
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity = projectile.velocity * 0.75f;
            }
        }
    }

    public override void SetDefaults(Projectile projectile)
    {
        Player player = Main.player[Main.myPlayer];
        if (projectile.CountsAsClass(DamageClass.Melee) && projectile.extraUpdates == 1)
        {
            if (player.ghostFade == 2.1f)
            {
                projectile.penetrate++;
                player.ghostFade = 0f;
                if (projectile.penetrate == 0)
                {
                    projectile.penetrate--;
                }
            }
            if (player.ghostFade == 2.2f)
            {
                projectile.penetrate += 2;
                player.ghostFade = 0f;
                if (projectile.penetrate == 0)
                {
                    projectile.penetrate--;
                }
            }
            if (player.ghostFade == 2.3f)
            {
                projectile.penetrate += 3;
                player.ghostFade = 0f;
                if (projectile.penetrate == 0)
                {
                    projectile.penetrate--;
                }
            }
        }
        if (player.ghostFrame == 1)
        {
            projectile.scale += 0.1f;
            player.ghostFrame = 0;
        }
        if (player.ghostFrame == 3)
        {
            projectile.scale += 0.2f;
            player.ghostFrame = 0;
        }
        if (player.ghostFrame == 4)
        {
            projectile.scale += 0.25f;
            player.ghostFrame = 0;
        }
        player.ghostFrame = 0;
    }

    public override void AI(Projectile projectile)
    {
        Player player = Main.player[Main.myPlayer];
        if (player.GetModPlayer<GlobalPlayer>().tribalArmor && projectile.CountsAsClass(DamageClass.Melee) && this.time % 10 == 0)
        {
            int proj = Projectile.NewProjectile(projectile.GetSource_Death(), projectile.Center.X, projectile.Center.Y, 0f, 0f, base.Mod.Find<ModProjectile>("SporeCloud").Type, projectile.damage / 3, 0f, player.whoAmI);
            Main.projectile[proj].scale = 0.75f;
            Main.projectile[proj].alpha = 125;
            Main.projectile[proj].penetrate = 1;
            this.time = 0;
        }
        if (projectile.type == 535)
        {
            projectile.timeLeft -= 5;
        }
        if (player.GetModPlayer<GlobalPlayer>().hellGlove && projectile.CountsAsClass(DamageClass.Melee) && Main.rand.Next(0, 3) == 1)
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X / 2f, projectile.velocity.Y / 2f, 0, default(Color), 1.25f);
            Main.dust[dust].noGravity = true;
        }
        this.time++;
    }

    public static void SpearHoming(Projectile projectile, float num1)
    {
        if (projectile.localAI[1] == 0f)
        {
            AdjustMagnitude(ref projectile.velocity, num1);
            projectile.localAI[1] = 1f;
        }
        Vector2 vector = Vector2.Zero;
        float maxDistance = 200f;
        bool foundTarget = false;
        foreach (var npc in Main.npc)
        {
            bool lineOfSight = Collision.CanHit(Main.player[projectile.owner].Center - new Vector2(projectile.width / 2, projectile.height / 2), projectile.width, projectile.height, npc.position, npc.width, npc.height);
            if (npc.CanBeChasedBy() && (lineOfSight || !projectile.ownerHitCheck))
            {
                Vector2 vector2 = npc.Center - projectile.Center;
                float distance = (float)Math.Sqrt(vector2.X * vector2.X + vector2.Y * vector2.Y);
                if (distance < maxDistance)
                {
                    vector = vector2;
                    maxDistance = distance;
                    foundTarget = true;
                }
            }
        }
        if (foundTarget)
        {
            AdjustMagnitude(ref vector, num1);
            projectile.velocity = (30f * projectile.velocity + vector) / 2f;
            AdjustMagnitude(ref projectile.velocity, num1);
        }
    }

    public static void AdjustMagnitude(ref Vector2 vector, float num1)
    {
        Projectile projectile = Main.projectile[0];
        Player val2 = Main.player[projectile.owner];
        if (!val2.GetModPlayer<GlobalPlayer>().spearHome)
        {
            return;
        }
        for (int i = 3; i < 8 + val2.extraAccessorySlots; i++)
        {
            if (val2.GetModPlayer<GlobalPlayer>().spearHome)
            {
                float num = (float)Math.Sqrt((double)(vector.X * vector.X + vector.Y * vector.Y));
                if (num > 1.5f)
                {
                    vector *= num1 / num;
                }
            }
        }
    }
}
