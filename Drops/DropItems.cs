using Terraria;
using Terraria.ModLoader;

namespace WizardMod.Drops;

public class DropItems : GlobalNPC
{
	public override void OnKill(NPC npc)
	{
		if (npc.type == 113)
		{
			Item.NewItem(npc.GetSource_Death(), npc.getRect(), base.Mod.Find<ModItem>("SpearEmblem").Type);
		}
		if (npc.type == 290 && Main.rand.Next(0, 100) > 20)
		{
			Item.NewItem(npc.GetSource_Death(), npc.getRect(), base.Mod.Find<ModItem>("PaladinSpear").Type);
		}
	}
}
