using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ModLoader;

namespace SpearOverhaul.Prefixes;

public class Pointy : ModPrefix
{
	private readonly byte _power;

	public override PrefixCategory Category => PrefixCategory.Melee;

	public override float RollChance(Item item)
	{
		return 2.5f;
	}

	public override bool CanRoll(Item item)
	{
		return true;
	}

	public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
	{
		damageMult += 0.15f;
		critBonus += 2;
	}

	public override bool IsLoadingEnabled(Mod mod)
	{
		ModContent.PrefixType<Pointy>();
		return false;
	}

	public override void Apply(Item item)
	{
		item.GetGlobalItem<GlobalItemList>().awesome = (int)this._power;
	}

	public override void ModifyValue(ref float valueMult)
	{
		_ = this._power;
		valueMult = 1.25f;
	}
}
