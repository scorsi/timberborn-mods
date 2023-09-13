#nullable enable

using System;
using System.Reflection;
using HarmonyLib;

namespace Scorsi.PermaDay
{
    public static class ReflexionAccessor
    {
        private static Type? __sun;
        public static Type Sun => __sun ??= AccessTools.TypeByName("Timberborn.SkySystem.Sun");

        private static FieldInfo? __sun_sun;
        public static FieldInfo Sun_light => __sun_sun ??= AccessTools.Field(Sun, "_sun");

        private static MethodInfo? __sun_DayStageColors;
        public static MethodInfo Sun_DayStageColors => __sun_DayStageColors ??= AccessTools.Method(Sun, "DayStageColors", new[] { DayStage });

        private static MethodInfo? __sun_UpdateColors;
        public static MethodInfo Sun_UpdateColors => __sun_UpdateColors ??= AccessTools.Method(Sun, "UpdateColors",new[] { DayStageTransition });

        private static MethodInfo? __sun_RotateSunWithCamera;
        public static MethodInfo Sun_RotateSunWithCamera => __sun_RotateSunWithCamera ??= AccessTools.Method(Sun, "RotateSunWithCamera", new[] { DayStageTransition });
        
        private static Type? __dayStage;
        public static Type DayStage => __dayStage ??= AccessTools.TypeByName("Timberborn.SkySystem.DayStage");

        private static object? __dayStage_Day;
        public static object DayStage_Day => __dayStage_Day ??= AccessTools.Field(DayStage, "Day").GetValue(null);

        private static Type? __dayStageColors;
        public static Type DayStageColors => __dayStageColors ??= AccessTools.TypeByName("Timberborn.SkySystem.DayStageColors");

        private static PropertyInfo? __dayStageColors_SunColor;
        public static PropertyInfo DayStageColors_SunColor => __dayStageColors_SunColor ??= AccessTools.Property(DayStageColors, "SunColor");

        private static PropertyInfo? __dayStageColors_SunIntensity;
        public static PropertyInfo DayStageColors_SunIntensity => __dayStageColors_SunIntensity ??= AccessTools.Property(DayStageColors, "SunIntensity");

        private static PropertyInfo? __dayStageColors_ShadowStrength;
        public static PropertyInfo DayStageColors_ShadowStrength => __dayStageColors_ShadowStrength ??= AccessTools.Property(DayStageColors, "ShadowStrength");

        private static PropertyInfo? __dayStageColors_AmbientSkyColor;
        public static PropertyInfo DayStageColors_AmbientSkyColor => __dayStageColors_AmbientSkyColor ??= AccessTools.Property(DayStageColors, "AmbientSkyColor");

        private static PropertyInfo? __dayStageColors_AmbientEquatorColor;
        public static PropertyInfo DayStageColors_AmbientEquatorColor => __dayStageColors_AmbientEquatorColor ??= AccessTools.Property(DayStageColors, "AmbientEquatorColor");

        private static PropertyInfo? __dayStageColors_AmbientGroundColor;
        public static PropertyInfo DayStageColors_AmbientGroundColor => __dayStageColors_AmbientGroundColor ??= AccessTools.Property(DayStageColors, "AmbientGroundColor");

        private static PropertyInfo? __dayStageColors_ReflectionsIntensity;
        public static PropertyInfo DayStageColors_ReflectionsIntensity => __dayStageColors_ReflectionsIntensity ??= AccessTools.Property(DayStageColors, "ReflectionsIntensity");

        private static PropertyInfo? __dayStageColors_DroughtFog;
        public static PropertyInfo DayStageColors_DroughtFog => __dayStageColors_DroughtFog ??= AccessTools.Property(DayStageColors, "DroughtFog");

        private static PropertyInfo? __dayStageColors_SunXAngle;
        public static PropertyInfo DayStageColors_SunXAngle => __dayStageColors_SunXAngle ??= AccessTools.Property(DayStageColors, "SunXAngle");
        
        private static PropertyInfo? __dayStageColors_TemperateWeatherFog;
        public static PropertyInfo DayStageColors_TemperateWeatherFog => __dayStageColors_TemperateWeatherFog ??= AccessTools.Property(DayStageColors, "TemperateWeatherFog");

        private static Type? __dayStageTransition;
        public static Type DayStageTransition => __dayStageTransition ??= AccessTools.TypeByName("Timberborn.SkySystem.DayStageTransition");

        private static Type? __fogSettings;
        public static Type FogSettings => __fogSettings ??= AccessTools.TypeByName("Timberborn.SkySystem.FogSettings");

        private static PropertyInfo? __fogSettings_FogColor;
        public static PropertyInfo FogSettings_FogColor => __fogSettings_FogColor ??= AccessTools.Property(FogSettings, "FogColor");

        private static PropertyInfo? __fogSettings_FogDensity;
        public static PropertyInfo FogSettings_FogDensity => __fogSettings_FogDensity ??= AccessTools.Property(FogSettings, "FogDensity");
    }
}