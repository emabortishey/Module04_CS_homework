using static System.Console;

Merchant test = new Merchant("test", '$', 12, 55);

test.print();

test.loose_price("5.95");

test.print();

public class Money
{
    protected char _sign;
    protected int _whole;
    protected int _fract;
    

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
                _fract = value - (100 * value / 100);
            }
        }
    }

    public virtual void print()
    {
        WriteLine($"{_whole}.{_fract} {_sign}");
    }
}

public class Merchant : Money
{
    string _name;

    public Merchant(string name, char sign, int whole, int fract) : base(sign, whole, fract)
    {
        _name = name;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public override void print()
    {
        WriteLine($"Название продукта: {_name}");

        base.print();
    }

    public void rise_price(string price)
    {
        if (price.IndexOf('.') != -1)
        {
            char[] whole_p = new char[char.MaxValue], fract_p = new char[char.MaxValue];

            price.CopyTo(0, whole_p, 0, price.IndexOf('.'));
            price.CopyTo(price.IndexOf('.') + 1, fract_p, 0, price.Length - price.IndexOf('.')-1);

            _whole += int.Parse(whole_p);

            if ((_fract + int.Parse(fract_p)) >= 100) 
            {
                _whole += (_fract + int.Parse(fract_p)) / 100;

                _fract = (_fract + int.Parse(fract_p)) - (((_fract + int.Parse(fract_p)) / 100) * 100);
            }
            else
            {
                _fract += int.Parse(fract_p);
            }
        }
        else
        {
            char[] whole_p = new char[char.MaxValue];
            price.CopyTo(0, whole_p, 0, price.Length - 1);

            _whole += int.Parse(whole_p);
        }
    }

    public void loose_price(string price)
    {
        if (price.IndexOf('.') != -1)
        {
            char[] whole_m = new char[char.MaxValue], fract_m = new char[char.MaxValue];

            price.CopyTo(0, whole_m, 0, price.IndexOf('.'));
            price.CopyTo(price.IndexOf('.') + 1, fract_m, 0, price.Length - price.IndexOf('.') - 1);

            _whole -= int.Parse(whole_m);

            if ((_fract - int.Parse(fract_m)) <= 0)
            {
                _whole -= 1;

                _fract = 100 + (_fract - int.Parse(fract_m));
            }
            else
            {
                _fract -= int.Parse(fract_m);
            }
        }
        else
        {
            char[] whole_m = new char[char.MaxValue];
            price.CopyTo(0, whole_m, 0, price.Length - 1);

            _whole -= int.Parse(whole_m);
        }
    }
}