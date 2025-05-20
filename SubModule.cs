using HarmonyLib;
using System.Linq;
using TaleWorlds.MountAndBlade;
using static DisableRandomColors.Utilities.Logger;

namespace DisableRandomColors
{
	public class SubModule : MBSubModuleBase
	{
		Harmony Harmony;

		protected override void OnSubModuleLoad()
		{
			base.OnSubModuleLoad();
			Harmony = new Harmony("DisableRandomColors");
			Harmony.PatchAll();
		}

		protected override void OnBeforeInitialModuleScreenSetAsRoot()
		{
			Log($"DisableRandomColors - Applied {Harmony.GetPatchedMethods().Count()} patches", LogLevel.Information);
		}
	}
}