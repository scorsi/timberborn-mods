using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace Scorsi.PermaDay
{
    public class Patches
    {
        [HarmonyPatch]
        public class Sun_UpdateColors
        {
            public static MethodInfo TargetMethod() => ReflexionAccessor.Sun_UpdateColors;

            private static object _lastInstance;

            public static bool Prefix(object __instance, object dayStageTransition)
            {
                // TODO: handle drought

                if (_lastInstance == __instance)
                {
                    return false;
                }

                _lastInstance = __instance;

                var light = (Light)ReflexionAccessor.Sun_light.GetValue(__instance);
                var dayStageColors = ReflexionAccessor.Sun_DayStageColors.Invoke(__instance, new[] { ReflexionAccessor.DayStage_Day });
                var fog = ReflexionAccessor.DayStageColors_TemperateWeatherFog.GetValue(dayStageColors);

                light.color = (Color)ReflexionAccessor.DayStageColors_SunColor.GetValue(dayStageColors);
                light.intensity = (float)ReflexionAccessor.DayStageColors_SunIntensity.GetValue(dayStageColors);
                light.shadowStrength = (float)ReflexionAccessor.DayStageColors_ShadowStrength.GetValue(dayStageColors);
                RenderSettings.ambientSkyColor = (Color)ReflexionAccessor.DayStageColors_AmbientSkyColor.GetValue(dayStageColors);
                RenderSettings.ambientEquatorColor = (Color)ReflexionAccessor.DayStageColors_AmbientEquatorColor.GetValue(dayStageColors);
                RenderSettings.ambientGroundColor = (Color)ReflexionAccessor.DayStageColors_AmbientGroundColor.GetValue(dayStageColors);
                RenderSettings.reflectionIntensity = (float)ReflexionAccessor.DayStageColors_ReflectionsIntensity.GetValue(dayStageColors);
                RenderSettings.fogColor = (Color)ReflexionAccessor.FogSettings_FogColor.GetValue(fog);
                RenderSettings.fogDensity = (float)ReflexionAccessor.FogSettings_FogDensity.GetValue(fog);

                return false;
            }
        }

        [HarmonyPatch]
        public class Sun_RotateSunWithCamera
        {
            public static MethodInfo TargetMethod() => ReflexionAccessor.Sun_RotateSunWithCamera;

            private static object _lastInstance;

            public static bool Prefix(object __instance, object dayStageTransition)
            {
                if (_lastInstance == __instance)
                {
                    return false;
                }

                _lastInstance = __instance;

                var light = (Light)ReflexionAccessor.Sun_light.GetValue(__instance);
                var dayStageColors = ReflexionAccessor.Sun_DayStageColors.Invoke(__instance, new[] { ReflexionAccessor.DayStage_Day });

                light.transform.localRotation = Quaternion.Euler((float)ReflexionAccessor.DayStageColors_SunXAngle.GetValue(dayStageColors), 240f, 0);

                return false;
            }
        }
    }
}