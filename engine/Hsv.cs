namespace Raskraska.Engine;

public class Hsv
{  
    public int H
    {
        get {return _h;}
        set 
        {
            _h = value;
            if (value > 360)
                _h = 360;
            if (value < 0)
                _h = 0;
        }
    }
    public int S
    {
        get {return _s;}
        set 
        {
            _s = value;
            if (value > 100)
                _s = 100;
            if (value < 0)
                _s = 0;
        }
    }
    public int V
    {
        get {return _v;}
        set 
        {
            _v = value;
            if (value > 100)
                _v = 100;
            if (value < 0)
                _v = 0;
        }
    }

    private int _h;
    private int _s;
    private int _v;

    public Hsv()
    {
        H = 0;
        S = 0;
        V = 0;
    }

    public Hsv(int h, int s, int v)
    {
        H = h;
        S = s;
        V = v;
    }

    public override string ToString()
    {
        return "HSV " + "[" + H + ", " + S + ", " + V +"]";
    }
}