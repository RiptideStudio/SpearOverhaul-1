using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Buffs;

public class GodArmorBuff : ModBuff
{
	private int time;

	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Titan's Blessing");
		// base.Description.SetDefault("Defense increased by 30\nMelee damage increased by 15%");
		Main.buffNoSave[base.Type] = true;
		Main.buffNoTimeDisplay[base.Type] = false;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.GetDamage(DamageClass.Melee) += 0.15f;
		player.statDefense += 30;
	}
}
