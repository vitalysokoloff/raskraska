using System.Drawing;
using System.Drawing.Drawing2D;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using Raskraska.Editor;
using Raskraska.Engine;

namespace Raskraska;
public class App
{
    private Core _core;
    public App()
    {
        _core = new Core();
    }

    public void Start()
    {
        _core.OpenSvg("test.svg");
        _core.SaveAsNumbers();    
        
        Thread drawing = new Thread(new ThreadStart(Draw));
        Thread updating = new Thread(new ThreadStart(Update)); 
        KeysController controller = new KeysController();
        controller.KeyEvent += KeyControl;
        Thread listening = new Thread(new ThreadStart(controller.Listen));

        drawing.Start();
        updating.Start();
        listening.Start();
    }
    public void Draw()
    {

    }
    public void Update(){}
    public void KeyControl(ConsoleKey key){ }
}