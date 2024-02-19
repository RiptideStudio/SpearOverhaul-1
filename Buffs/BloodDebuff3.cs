using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Buffs;

public class BloodDebuff3 : ModBuff
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
		npc.lifeRegen -= 10;
	}
}
