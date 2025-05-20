using HarmonyLib;
using System.Linq;
using TaleWorlds.MountAndBlade;
// Important: using static import forces the YSBCaptain assembly to be loaded during JIT. Without, patching will fail.
using static DisableRandomColors.Utilities.Logger;

namespace DisableRandomColors
{
	public class SubModule : MBSubModuleBase
	{
		protected override void OnSubModuleLoad()
		{
			base.OnSubModuleLoad();

			var harmony = new Harmony("DisableRandomColors");
			harmony.PatchAll();
			Log($"Applied {harmony.GetPatchedMethods().Count()} patches for DisableRandomColors", LogLevel.Information);
		}
	}
}