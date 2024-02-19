using SpearOverhaul.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.GlobalStuff;

public class GlobalEnemy : GlobalNPC
{
    public override bool InstancePerEntity => true;

    protected override bool CloneNewInstances => true;

    public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
    {
        if (projectile.type == Mod.Find<ModProjectile>("ThrownSpear").Type)
        {
            _ = Main.player[Main.myPlayer];
        }
        if (npc.HasBuff<BloodDebuff>())
        {
            modifiers.ScalingBonusDamage += 0.2f;
        }
    }

    public override void OnKill(NPC npc)
    {
        _ = Main.player[Main.myPlayer];
    }
}
