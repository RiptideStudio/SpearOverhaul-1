using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.GlobalStuff;

public class GlobalPlayer : ModPlayer
{
    public int spearDamage = 5;

    public int bonusSpearDamage;

    public float spearSpeed;

    public int timer;

    public int bleedDamage = 10;

    public bool spearHome = true;

    public int spearPenetrate = 1;

    public bool hellArmor;

    public bool tribalArmor;

    public bool richArmor = true;

    public bool crystalArmor;

    public bool hellGlove;

    public bool godGlove;

    public bool godArmor;

    public override void ResetEffects()
    {
        this.spearDamage = 5 + this.bonusSpearDamage;
        this.spearSpeed = 0f;
        this.tribalArmor = false;
        this.hellArmor = false;
        this.spearHome = true;
        this.richArmor = false;
        this.crystalArmor = false;
        this.godGlove = false;
        this.hellGlove = false;
        this.godArmor = false;
        this.spearPenetrate = 1;
    }

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (this.godArmor)
        {
            base.Player.immuneTime += 60;
            if (!base.Player.HasBuff(Mod.Find<ModBuff>("GodArmorDebuff").Type))
            {
                base.Player.AddBuff(Mod.Find<ModBuff>("GodArmorBuff").Type, 600, quiet: false);
                base.Player.AddBuff(Mod.Find<ModBuff>("GodArmorDebuff").Type, 1800, quiet: false);
            }
        }
    }

    public override void PreUpdate()
    {
        if (this.hellArmor)
        {
            if (base.Player.velocity.X != 0f)
            {
                if (base.Player.direction == 1)
                {
                    int num371 = Dust.NewDust(new Vector2(base.Player.position.X - 12f, base.Player.position.Y), base.Player.width, base.Player.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num371].velocity *= 1f;
                    Main.dust[num371].noGravity = true;
                }
                else
                {
                    int num373 = Dust.NewDust(new Vector2(base.Player.position.X + 12f, base.Player.position.Y), base.Player.width, base.Player.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                    Main.dust[num373].velocity *= 1f;
                    Main.dust[num373].noGravity = true;
                }
            }
            if (base.Player.velocity.Y != 0f)
            {
                int num375 = Dust.NewDust(new Vector2(base.Player.position.X, base.Player.position.Y), base.Player.width, base.Player.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num375].velocity *= 1f;
                Main.dust[num375].noGravity = true;
            }
        }
        if (this.crystalArmor)
        {
            if (base.Player.velocity.X != 0f)
            {
                if (base.Player.direction == 1)
                {
                    int num377 = Dust.NewDust(new Vector2(base.Player.position.X - 12f, base.Player.position.Y), base.Player.width, base.Player.height, 173, 0f, 0f, 100, default(Color), 1.25f);
                    Main.dust[num377].velocity *= 1f;
                    Main.dust[num377].noGravity = true;
                }
                else
                {
                    int num378 = Dust.NewDust(new Vector2(base.Player.position.X + 12f, base.Player.position.Y), base.Player.width, base.Player.height, 179, 0f, 0f, 100, default(Color), 1.25f);
                    Main.dust[num378].velocity *= 1f;
                    Main.dust[num378].noGravity = true;
                }
            }
            if (base.Player.velocity.Y != 0f)
            {
                int num376 = Dust.NewDust(new Vector2(base.Player.position.X, base.Player.position.Y), base.Player.width, base.Player.height, 173, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num376].velocity *= 1f;
                Main.dust[num376].noGravity = true;
            }
        }
        if (!this.godArmor)
        {
            return;
        }
        if (base.Player.velocity.X != 0f)
        {
            if (base.Player.direction == 1)
            {
                int num374 = Dust.NewDust(new Vector2(base.Player.position.X - 12f, base.Player.position.Y), base.Player.width, base.Player.height, 57, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num374].velocity *= 1f;
                Main.dust[num374].noGravity = true;
            }
            else
            {
                int num372 = Dust.NewDust(new Vector2(base.Player.position.X + 12f, base.Player.position.Y), base.Player.width, base.Player.height, 228, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num372].velocity *= 1f;
                Main.dust[num372].noGravity = true;
            }
        }
        if (base.Player.velocity.Y != 0f)
        {
            int num370 = Dust.NewDust(new Vector2(base.Player.position.X, base.Player.position.Y), base.Player.width, base.Player.height, 57, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num370].velocity *= 1f;
            Main.dust[num370].noGravity = true;
        }
    }
}
