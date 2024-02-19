using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Prefixes;

public class Epic : ModPrefix
{
	private readonly byte _power;

	public new virtual PrefixCategory Category => PrefixCategory.Custom;

	public override float RollChance(Item item)
	{
		return 1.25f;
	}

	public override bool CanRoll(Item item)
	{
		return true;
	}

	public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
	{
		damageMult += 0.18f;
		critBonus += 6;
		knockbackMult += 0.17f;
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		ModContent.PrefixType<Epic>();
		return false;
	}

	public override void Apply(Item item)
	{
		item.GetGlobalItem<GlobalItemList>().awesome = (int)this._power;
	}

	public override void ModifyValue(ref float valueMult)
	{
		_ = this._power;
		valueMult = 1.5f;
	}
}
