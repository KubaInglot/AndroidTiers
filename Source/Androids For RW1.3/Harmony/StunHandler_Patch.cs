using Verse;
using Verse.AI;
using Verse.AI.Group;
using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MOARANDROIDS
{
    internal class StunHandler_Patch

    {
        /*
         * Allow android tiers to be affected by EMP
         */
        [HarmonyPatch(typeof(StunHandler), "AffectedByEMP", MethodType.Getter)]
        public class StunHandler_AffectedByEMP_Patch
        {
            [HarmonyPostfix]
            public static void Listener(StunHandler __instance, ref bool __result)
            {
                Pawn pawn = __instance.parent as Pawn;
                if (pawn != null) {
                    if ((Utils.ExceptionAndroidWithoutSkinList.Contains(pawn.def.defName) ) || Utils.ExceptionAndroidAnimals.Contains(pawn.def.defName))
                    {
                        __result = true;
                    }
                }
            }
        }
    }
}