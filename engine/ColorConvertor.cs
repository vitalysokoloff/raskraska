using System.Drawing;
using System.Runtime.CompilerServices;

namespace Raskraska.Engine;

public class ColorConverter
{
    private Dictionary<string, string> _colorNames;
    
    public ColorConverter()
    {
        _colorNames = new Dictionary<string, string>()
        {
            {"aliceblue", "#f0f8ff"},
            {"antiquewhite", "#faebd7"},
            {"qua", "#00ffff"},
            {"aquamarine", "#7fffd4"},
            {"azure", "#f0ffff"},
            {"beige", "#f5f5dc"},
            {"bisque", "#ffe4c4"},
            {"black", "#000000"},
            {"blanchedalmond", "#ffebcd"},
            {"blue", "#0000ff"},
            {"blueviolet", "#8a2be2"},
            {"brown", "#a52a2a"},
            {"burlywood", "#deb887"},
            {"cadetblue", "#5f9ea0"},
            {"chartreuse", "#7fff00"},
            {"chocolate", "#d2691e"},
            {"coral", "#ff7f50"},
            {"cornflowerblue", "#6495ed"},
            {"cornsilk", "#fff8dc"},
            {"crimson", "#dc143c"},
            {"cyan", "#00ffff"},
            {"darkblue", "#00008b"},
            {"darkcyan", "#008b8b"},
            {"darkgoldenrod", "#b8860b"},
            {"darkgray", "#a9a9a9"},
            {"darkgreen", "#006400"},
            {"darkgrey", "#a9a9a9"},
            {"darkkhaki", "#bdb76b"},
            {"darkmagenta", "#8b008b"},
            {"darkolivegreen", "#556b2f"},
            {"darkorange", "#ff8c00"},
            {"darkorchid", "#9932cc"},
            {"darkred", "#8b0000"},
            {"darksalmon", "#e9967a"},
            {"darkseagreen", "#8fbc8f"},
            {"darkslateblue", "#483d8b"},
            {"darkslategray", "#2f4f4f"},
            {"darkslategrey", "#2f4f4f"},
            {"darkturquoise", "#00ced1"},
            {"darkviolet", "#9400d3"},
            {"deeppink", "#ff1493"},
            {"deepskyblue", "#00bfff"},
            {"dimgray", "#696969"},
            {"dimgrey", "#696969"},
            {"dodgerblue", "#1e90ff"},
            {"firebrick", "#b22222"},
            {"floralwhite", "#fffaf0"},
            {"forestgreen", "#228b22"},
            {"fuchsia", "#ff00ff"},
            {"gainsboro", "#dcdcdc"},
            {"ghostwhite", "#f8f8ff"},
            {"gold", "#ffd700"},
            {"goldenrod", "#daa520"},
            {"gray", "#808080"},
            {"green", "#008000"},
            {"greenyellow", "#adff2f"},
            {"grey", "#808080"},
            {"honeydew", "#f0fff0"},
            {"hotpink", "#ff69b4"},
            {"indianred", "#cd5c5c"},
            {"indigo", "#4b0082"},
            {"ivory", "#fffff0"},
            {"khaki", "#f0e68c"},
            {"lavender", "#e6e6fa"},
            {"lavenderblush", "#fff0f5"},
            {"lawngreen", "#7cfc00"},
            {"lemonchiffon", "#fffacd"},
            {"lightblue", "#add8e6"},
            {"lightcoral", "#f08080"},
            {"lightcyan", "#e0ffff"},
            {"lightgoldenrodyellow", "#fafad2"},
            {"lightgray", "#d3d3d3"},
            {"lightgreen", "#90ee90"},
            {"lightgrey", "#d3d3d3"},
            {"lightpink", "#ffb6c1"},
            {"lightsalmon", "#ffa07a"},
            {"lightseagreen", "#20b2aa"},
            {"lightskyblue", "#87cefa"},
            {"lightslategray", "#778899"},
            {"lightslategrey", "#778899"},
            {"lightsteelblue", "#b0c4de"},
            {"lightyellow", "#ffffe0"},
            {"lime", "#00ff00"},
            {"limegreen", "#32cd32"},
            {"linen", "#faf0e6"},
            {"magenta", "#ff00ff"},
            {"maroon", "#800000"},
            {"mediumaquamarine", "#66cdaa"},
            {"mediumblue", "#0000cd"},
            {"mediumorchid", "#ba55d3"},
            {"mediumpurple", "#9370db"},
            {"mediumseagreen", "#3cb371"},
            {"mediumslateblue", "#7b68ee"},
            {"mediumspringgreen", "#00fa9a"},
            {"mediumturquoise", "#48d1cc"},
            {"mediumvioletred", "#c71585"},
            {"midnightblue", "#191970"},
            {"mintcream", "#f5fffa"},
            {"mistyrose", "#ffe4e1"},
            {"moccasin", "#ffe4b5"},
            {"navajowhite", "#ffdead"},
            {"navy", "#000080"},
            {"oldlace", "#fdf5e6"},
            {"olive", "#808000"},
            {"olivedrab", "#6b8e23"},
            {"orange", "#ffa500"},
            {"orangered", "#ff4500"},
            {"orchid", "#da70d6"},
            {"palegoldenrod", "#eee8aa"},
            {"palegreen", "#98fb98"},
            {"paleturquoise", "#afeeee"},
            {"palevioletred", "#db7093"},
            {"papayawhip", "#ffefd5"},
            {"peachpuff", "#ffdab9"},
            {"peru", "#cd853f"},
            {"pink", "#ffc0cb"},
            {"plum", "#dda0dd"},
            {"powderblue", "#b0e0e6"},
            {"purple", "#800080"},
            {"red", "#ff0000"},
            {"rosybrown", "#bc8f8f"},
            {"royalblue", "#4169e1"},
            {"saddlebrown", "#8b4513"},
            {"salmon", "#fa8072"},
            {"sandybrown", "#f4a460"},
            {"seagreen", "#2e8b57"},
            {"seashell", "#fff5ee"},
            {"sienna", "#a0522d"},
            {"silver", "#c0c0c0"},
            {"skyblue", "#87ceeb"},
            {"slateblue", "#6a5acd"},
            {"slategray", "#708090"},
            {"slategrey", "#708090"},
            {"snow", "#fffafa"},
            {"springgreen", "#00ff7f"},
            {"steelblue", "#4682b4"},
            {"tan", "#d2b48c"},
            {"teal", "#008080"},
            {"thistle", "#d8bfd8"},
            {"tomato", "#ff6347"},
            {"turquoise", "#40e0d0"},
            {"violet", "#ee82ee"},
            {"wheat", "#f5deb3"},
            {"white", "#ffffff"},
            {"whitesmoke", "#f5f5f5"},
            {"yellow", "#ffff00"},
            {"yellowgreen", "#9acd32"}
        };
    }

    /// <summary>
    /// Костылёк.
    /// Я не понял документацию по Svg net.
    /// Что там нужно делать с SvgColourServer, чтобы
    /// получить System.Drawing.Color
    /// </summary>
    public Color RgbToColor(string color)
    {
        Color answer = Color.FromArgb(255, 0, 0, 0);
        color = color.ToLower();

        if (_colorNames.Keys.Contains(color))
            color = _colorNames[color];

        if (color.Length > 0)
            if (color[0] == '#')
            {
                int R = Int32.Parse("" + color[1] + color[2], System.Globalization.NumberStyles.HexNumber);
                int G = Int32.Parse("" + color[3] + color[4], System.Globalization.NumberStyles.HexNumber);
                int B = Int32.Parse("" + color[5] + color[6], System.Globalization.NumberStyles.HexNumber);
                answer = Color.FromArgb(255, R, G, B);
            }

        return answer;
    }

    public Color HsvToColor(Hsv origin)
    {
        Color answer = new Color();

        float v = origin.V / (float)100;
        float s = origin.S / (float)100;
        
        float c = v * s;
        float x = c * (1 - Math.Abs(((origin.H / 60) % 2) - 1));
        float m = v - c;

        float r = 0, g = 0, b = 0;

        if (origin.H < 60 & origin.H >= 0)
        {
            r = c;
            g = x;
            b = 0;
        }
        if (origin.H < 120 & origin.H >= 60)
        {
            r = x;
            g = c;
            b = 0;
        }
        if (origin.H < 180 & origin.H >= 120)
        {
            r = 0;
            g = c;
            b = x;
        }
        if (origin.H < 240 & origin.H >= 180)
        {
            r = 0;
            g = x;
            b = c;
        }
        if (origin.H < 300 & origin.H >= 240)
        {
            r = x;
            g = 0;
            b = c;
        }
        if (origin.H < 360 & origin.H >= 300)
        {
            r = c;
            g = 0;
            b = x;
        }

        answer = Color.FromArgb(255, (int)((r + m) * 255), (int)((g + m) * 255), (int)((b + m) * 255));

        return answer;
    }

    public Hsv ColorToHsv(Color origin)
    {
        Hsv answer = new Hsv();

        float r = origin.R / (float)255;
        float g = origin.G / (float)255;
        float b = origin.B / (float)255;

        float max = Math.Max(r, Math.Max(g, b));
        float min = Math.Min(r, Math.Min(g, b));
        float delta = max - min;

        //H
        if (delta == 0)
        {
            answer.H = 0;
        }
        else if (max == r)
        {
            answer.H = (int)(60 * (((g - b) / delta) %6));
        }
        else if (max == g)
        {
            answer.H = (int)(60 * (((b - r) / delta) + 2));
        }
        else if (max == b)
        {
            answer.H = (int)(60 * (((r - g) / delta) + 4));
        }

        //S
        if (max == 0)
        {
            answer.S = 0;
        }
        else
        {
            answer.S = (int)(delta / max * 100);
        }

        //V
        answer.V = (int)(max * 100);

        return answer;
    }

    public Color HslToColor(Hsl origin)
    {
        Color answer = new Color();

        float l = origin.L / (float)100;
        float s = origin.S / (float)100;
        
        float c = (1 - Math.Abs(2 * l - 1)) * s;
        float x = c * (1 - Math.Abs(((origin.H / 60) % 2) - 1));
        float m = l - c / 2;

        float r = 0, g = 0, b = 0;

        if (origin.H < 60 & origin.H >= 0)
        {
            r = c;
            g = x;
            b = 0;
        }
        if (origin.H < 120 & origin.H >= 60)
        {
            r = x;
            g = c;
            b = 0;
        }
        if (origin.H < 180 & origin.H >= 120)
        {
            r = 0;
            g = c;
            b = x;
        }
        if (origin.H < 240 & origin.H >= 180)
        {
            r = 0;
            g = x;
            b = c;
        }
        if (origin.H < 300 & origin.H >= 240)
        {
            r = x;
            g = 0;
            b = c;
        }
        if (origin.H < 360 & origin.H >= 300)
        {
            r = c;
            g = 0;
            b = x;
        }

        answer = Color.FromArgb(255, (int)((r + m) * 255), (int)((g + m) * 255), (int)((b + m) * 255));

        return answer;
    }

    public Hsl ColorToHsl(Color origin)
    {
        Hsl answer = new Hsl();

        float r = origin.R / (float)255;
        float g = origin.G / (float)255;
        float b = origin.B / (float)255;

        float max = Math.Max(r, Math.Max(g, b));
        float min = Math.Min(r, Math.Min(g, b));
        float delta = max - min;

        //H
        if (delta == 0)
        {
            answer.H = 0;
        }
        else if (max == r)
        {
            answer.H = (int)(60 * (((g - b) / delta) %6));
        }
        else if (max == g)
        {
            answer.H = (int)(60 * (((b - r) / delta) + 2));
        }
        else if (max == b)
        {
            answer.H = (int)(60 * (((r - g) / delta) + 4));
        }

        float l = (max + min) / 2;

        //S
        if (delta == 0)
        {
            answer.S = 0;
        }
        else
        {
            answer.S = (int)(delta / (1 - Math.Abs(2 * l - 1))) * 100;
        }  

        //L
        answer.L = (int)(l * 100);     

        return answer;
    }
}