using System;

namespace NiEditorApplication.Editor
{
    public enum Locale
    {
        UnitedStates,
        GreatBritain,
        Germany
    }

    public static class LocaleExtensions
    {
        public static string Code(this Locale @this)
        {
            switch (@this)
            {
                case Locale.UnitedStates:
                    return UnitedStates;
                case Locale.GreatBritain:
                    return GreatBritain;
                case Locale.Germany:
                    return Germany;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@this), @this, null);
            }
        }

        private const string UnitedStates = "en_US";

        private const string GreatBritain = "en_GB";

        private const string Germany = "de_DE";
    }
}