using System.Drawing;

namespace Raskraska.Engine;

public class PaletteColor
{
    public string Name;
    public string Description;
    public Color Color;

    public PaletteColor(string name, Color color, string description)
    {
        Name = name;
        Color = color;
        Description = description;
    }
}