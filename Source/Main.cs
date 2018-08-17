// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

using Harmony;
using HugsLib;
using RimWorld;

namespace ElectricUpgrades
{
    [HarmonyPatch(typeof(CompPowerPlantSolar))]
    [HarmonyPatch("DesiredPowerOutput", PropertyMethod.Getter)]
    public class Patch : ModBase
    {
        private string _modIdentifier = "ElectricUpgrades";
        
        public override string ModIdentifier
        {
            get { return _modIdentifier; }
        }

        [HarmonyPostfix]
        public static void Postfix(ref CompPowerPlantSolar __instance, ref float __result)
        {
            var basePowerConsumption = -__instance.Props.basePowerConsumption;
            __result = __result * basePowerConsumption;
        }

    }
}