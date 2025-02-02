using System.Drawing;
using ClosedXML.Excel;
using Svg;

namespace Raskraska.Engine;

public class Core
{
    public string OutDirectory
    {
        get {return _outDirectory;}
        set {_outDirectory = value;}
    }
    public string PalettesDirectory
    {
        get {return _palettesDirectory;}
        set {_palettesDirectory = value;}
    }
    public string TmpSvgDirectory
    {
        get {return _tmpSvgName;}
        set {_tmpSvgName = value;}
    }
    public string[] PaletteNames
    {
        get {return _palettes.Keys.ToArray();}
    }
    public string CurrentPalette
    {
        get {return _currentPalette;}
        set {_currentPalette = value;}
    }
    public int StrokeColor
    {
        get {return _strokeColor;}
        set {_strokeColor = value;}
    }
    public int StrokeThick
    {
        get {return _strokThick;}
        set {_strokThick = value;}
    }   
    public SvgDocument Document
    {
        get {return _svgDocument;}
    }
    public int ConvertedObjectsCount
    {
        get {return _convertedObjectsCount;}
    }
    public int ObjectsCount
    {
        get {return _objectsCount;}
    }    

    private string _outDirectory;
    private string _palettesDirectory;
    private string _tmpSvgName;
    private Dictionary<string, List<PaletteColor>> _palettes;
    private string _currentPalette;
    private SvgDocument _svgDocument;
    private int _convertedObjectsCount;
    private int _objectsCount;
    private int _strokeColor;
    private int _strokThick;

    public Core()
    {
        _outDirectory = "out";
        _palettesDirectory = "palettes";
        _tmpSvgName = "tmp.svg";
        _currentPalette = "";
        LoadPalettes();
    }

    public void OpenSvg(string path)
    {
        _svgDocument = SvgDocument.Open(path);
    }

    public void ToPaletteColors(CompareType type)
    {
        if (_palettes.Keys.Contains(_currentPalette))
        {
            Comparator comparator = new Comparator(_palettes[_currentPalette]);
            SvgElementCollection collection = _svgDocument.Children;
            ColorConverter converter = new ColorConverter();
            _convertedObjectsCount = 0;
            _objectsCount = collection.Count;
            
            for (int i = 0; i < collection.Count; i++)
            {
                SvgElement element = collection.ElementAt(i);
                element.Stroke = SvgColourServer.None;

                if (element.Fill == SvgColourServer.None)
                {
                    element.Fill = new SvgColourServer(Color.Black);
                }
                else
                {
                element.Fill = new SvgColourServer(comparator.CalculateColor(
                    converter.RgbToColor(element.Fill.ToString()), type
                    ));
                }
                _convertedObjectsCount++;
            }

            Console.WriteLine("Преобразованный фал сохранён по пути: " + _outDirectory + "\\" + _tmpSvgName);
            _svgDocument.Write(_outDirectory + "\\" + _tmpSvgName);
        
        }
        else
        {
            Console.WriteLine("Данной палитры не существует!");
        }        
    }

    private void LoadPalettes()
    {
        Console.WriteLine("[[Load palettes]]");
        _palettes = new Dictionary<string, List<PaletteColor>>();
        string [] files = Directory.GetFiles(_palettesDirectory);

        for (int i = 0; i < files.Length; i++)
        {
            string name = files[i];
            Console.WriteLine("[" + name + "] - " + (i+1) + "\\" + files.Length);
            List<PaletteColor> colors = new List<PaletteColor>();
            using (IXLWorkbook wb = new XLWorkbook(name))
            {
                IXLRows rows = wb.Worksheets.First().Rows();                
                
                for (int j = 0; j < rows.Count(); j++)
                {
                    IXLRow row = rows.ElementAt(j);
                    IXLCells cells = row.Cells();
                    string colorName = cells.ElementAt(0).Value.ToString();
                    System.Drawing.Color color = cells.ElementAt(1).Style.Fill.BackgroundColor.Color;
                    string colorDesc = cells.ElementAt(2).Value.ToString();
                    colors.Add(new PaletteColor(colorName, color, colorDesc));
                    Console.WriteLine(colorName + "\t" + colorDesc);
                }
            }            
            _palettes.Add(name, colors);
        }
        _currentPalette = files[0];
        Console.WriteLine("Done. Palettes count - " + files.Length);
    }
}