using System.Drawing;

namespace Raskraska.Engine;

public class Comparator
{
    public Dictionary<string, Color> colors;

    private List<PaletteColor> _palette;

    public Comparator(List<PaletteColor> palette)
    {
        colors = new Dictionary<string, Color>();
        _palette = palette;
    }

    public Color CalculateColor(Color origin, CompareType type)
    {
        if (!colors.Keys.Contains(origin.ToString()))
        {
            int min = int.MaxValue;
            int minIndex = 0;
            if (type == CompareType.Rgb)
            {
                for (int i = 0; i < _palette.Count; i++)
                {
                    int powR = (origin.R - _palette[i].Color.R) * (origin.R - _palette[i].Color.R);
                    int powG = (origin.G - _palette[i].Color.G) * (origin.G - _palette[i].Color.G);
                    int powB = (origin.B - _palette[i].Color.B) * (origin.B - _palette[i].Color.B);
                    int sum = powR + powG + powB;

                    if (min > sum)
                    {
                        min = sum;
                        minIndex = i;
                    }                
                }                
            }
            else if (type == CompareType.Hsv)
            {
                ColorConverter converter = new ColorConverter();
                Hsv originHsv = converter.ColorToHsv(origin);

                for (int i = 0; i < _palette.Count; i++)
                {                    
                    Hsv paletteHsv = converter.ColorToHsv(_palette[i].Color);
                    int powH = (originHsv.H - paletteHsv.H) * (originHsv.H - paletteHsv.H);
                    int powS = (originHsv.S - paletteHsv.S) * (originHsv.S - paletteHsv.S);
                    int powV = (originHsv.V - paletteHsv.V) * (originHsv.V - paletteHsv.V);
                    int sum = powH + +powS + powV;

                    if (min > sum)
                    {
                        min = sum;
                        minIndex = i;
                    }                                  
                } 
            }
            else if (type == CompareType.Grayscale)
            {
                float originGray = 0.299f * origin.R + 0.587f * origin.G + 0.114f * origin.B;
                float floatMin = float.MaxValue;

                for (int i = 0; i < _palette.Count; i++)
                {                    
                    //float paletteGray = 0.299f * _palette[i].Color.R + 0.587f * _palette[i].Color.G + 0.114f * _palette[i].Color.B;
                    float paletteGray = 0.299f * _palette[i].Color.G + 0.587f * _palette[i].Color.R + 0.114f * _palette[i].Color.B;
                    //float paletteGray = _palette[i].Color.R + _palette[i].Color.G + _palette[i].Color.B;
                    float delta = (originGray - paletteGray) * (originGray - paletteGray);

                    if (floatMin > delta)
                    {
                        floatMin = delta;
                        minIndex = i;
                    }                                   
                } 
            }
            else if (type == CompareType.Hsl)
            {
                ColorConverter converter = new ColorConverter();
                Hsl originHsv = converter.ColorToHsl(origin);

                for (int i = 0; i < _palette.Count; i++)
                {                    
                    Hsv paletteHsv = converter.ColorToHsv(_palette[i].Color);
                    int powH = (originHsv.H - paletteHsv.H) * (originHsv.H - paletteHsv.H);
                    int powS = (originHsv.S - paletteHsv.S) * (originHsv.S - paletteHsv.S);
                    int powV = (originHsv.L - paletteHsv.V) * (originHsv.L - paletteHsv.V);
                    int sum = powH + +powS + powV;

                    if (min > sum)
                    {
                        min = sum;
                        minIndex = i;
                    }                          
                } 
            }
            colors.Add(origin.ToString(), _palette[minIndex].Color);
        }
        return colors[origin.ToString()];
    }
}

public enum CompareType
{
    Rgb = 0,
    Hsv = 1,
    Hsl = 2,
    Grayscale = 3
}