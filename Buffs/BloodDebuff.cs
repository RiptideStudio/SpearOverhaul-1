using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Buffs;

public class BloodDebuff : ModBuff
{
	private int time;

	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Bleeding");
		// base.Description.SetDefault("Enemy life regeneration reduced");
		Main.buffNoSave[base.Type] = true;
		Main.buffNoTimeDisplay[base.Type] = false;
	}

	public override void Update(NPC npc, ref int buffIndex)
	{
		_ = Main.player[Main.myPlayer];
		npc.lifeRegen -= 5;
		int num370 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 5, 0f, 0f, 100, default(Color), 1.5f);
		Main.dust[num370].velocity *= 1.4f;
		Main.dust[num370].noGravity = true;
	}
}
