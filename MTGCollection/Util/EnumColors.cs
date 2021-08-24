using System.ComponentModel;

namespace MTGCollection.Util
{
    public enum EnumColors
    {
        [Description("R")]
        Red,
        [Description("U")]
        Blue,
        [Description("B")]
        Black,
        [Description("G")]
        Green,
        [Description("W")]
        White,
        Colorless,
        Multicolor
    }
}

