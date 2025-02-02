namespace Raskraska.Engine;

public class Hsl
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
    public int L
    {
        get {return _l;}
        set 
        {
            _l = value;
            if (value > 100)
                _l = 100;
            if (value < 0)
                _l = 0;
        }
    }

    private int _h;
    private int _s;
    private int _l;

    public Hsl()
    {
        H = 0;
        S = 0;
        L = 0;
    }

    public Hsl(int h, int s, int l)
    {
        H = h;
        S = s;
        L = l;
    }

    public override string ToString()
    {
        return "HSL " + "[" + H + ", " + S + ", " + L +"]";
    }
}