using HarmonyLib;
using Timberborn.SkySystem;
using UnityEngine;

namespace Scorsi.PermaDay
{
    public class Patches
    {
        [HarmonyPatch(typeof(Sun), nameof(Sun.UpdateColors), typeof(DayStageTransition))]
        [HarmonyPrefix]
        public static bool Sun_UpdateColors_Prefix(Sun __instance, DayStageTransition dayStageTransition)
        {
            var light = __instance._sun;
            var dayStageColors = __instance.DayStageColors(DayStage.Day);
            var fog = dayStageColors.TemperateWeatherFog;

            light.color = dayStageColors.SunColor;
            light.intensity = dayStageColors.SunIntensity;
            light.shadowStrength = dayStageColors.ShadowStrength;
            RenderSettings.ambientSkyColor = dayStageColors.AmbientSkyColor;
            RenderSettings.ambientEquatorColor = dayStageColors.AmbientEquatorColor;
            RenderSettings.ambientGroundColor = dayStageColors.AmbientGroundColor;
            RenderSettings.reflectionIntensity = dayStageColors.ReflectionsIntensity;
            RenderSettings.fogColor = fog.FogColor;
            RenderSettings.fogDensity = fog.FogDensity;

            return false;
        }

        [HarmonyPatch(typeof(Sun), nameof(Sun.RotateSunWithCamera), typeof(DayStageTransition))]
        public static bool Sun_RotateSunWithCamera(Sun __instance, DayStageTransition dayStageTransition)
        {
            var light = __instance._sun;
            var dayStageColors = __instance.DayStageColors(DayStage.Day);

            light.transform.localRotation = Quaternion.Euler(dayStageColors.SunXAngle, 240f, 0);

            return false;
        }
    }
}