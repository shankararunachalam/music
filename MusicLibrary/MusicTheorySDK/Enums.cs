using System.ComponentModel;
using System.Reflection;

namespace MusicTheorySDK
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }

    public enum Notes
    {
        C,
        [Description("C#")]
        CSharp,
        D,
        [Description("D#")]
        DSharp,
        E,
        F,
        [Description("F#")]
        FSharp,
        G,
        [Description("G#")]
        GSharp,
        A,
        [Description("A#")]
        ASharp,
        B
    }

    public enum Intervals
    {
        PerfectUnison,
        DiminishedSecond,
        MinorSecond,
        AugmentedUnison,
        MajorSecond,
        DiminishedThird,
        MinorThird,
        AugmentedSecond,
        MajorThird,
        DiminishedFourth,
        PerfectFourth,
        AugmentedThird,
        DiminishedFifth,
        AugmentedFourth,
        PerfectFifth,
        DiminishedSixth,
        MinorSixth,
        AugmentedFifth,
        MajorSixth,
        DiminishedSeventh,
        MinorSeventh,
        AugmentedSixth,
        MajorSeventh,
        DiminishedOctave,
        PerfectOctave,
        AugmentedSeventh
    }

    public enum Scales
    {
        Major,
        Minor
    }
}
