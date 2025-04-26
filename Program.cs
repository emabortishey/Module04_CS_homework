using static System.Console;

public class Money
{
    char _sign;
    int _whole;
    int _fract;

    public Money(char sign, int whole, int fract)
    {
        _sign = sign;
        _whole = whole;
        _fract = fract;
    }

    public char Sign
    {
        get { return _sign; }
        set { _sign = value; }
    }

    public int Whole
    {
        get { return _whole; }
        set { _whole = value; }
    }

    public int Fractional
    {
        get { return _fract; }
        set 
        {
            if (value < 100 && value > 0)
            {
                _fract = value;
            }
            else if (value > 100)
            {
                _whole += value / 100;
                _fract = value - 100;
            }
        }
    }
}