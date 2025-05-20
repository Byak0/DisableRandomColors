using HarmonyLib;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View.Screens;

namespace DisableRandomColors.Patch
{
	[HarmonyPatch(typeof(MissionScreen))]
	public class Patch_MissionScreen
	{
		// Using full method name (including interface's name) otherwise Harmony will not find it
		[HarmonyPatch("TaleWorlds.MountAndBlade.IMissionListener.OnEquipItemsFromSpawnEquipment")]
		[HarmonyPrefix]
		public static bool Prefix(Agent agent, Agent.CreationType creationType)
		{
			// Prevent color randomization
			typeof(Agent).GetProperty(nameof(Agent.RandomizeColors)).SetValue(agent, false);

			return true;
		}
	}
}
