using static System.Console;

// ZADANIE 1

/*

Запрограммируйте класс Money (объект класса оперирует 
одной валютой) для работы с деньгами.
В классе должны быть предусмотрены поле для хранения 
целой части денег (доллары, евро, гривны и т.д.) и поле
для хранения копеек (центы, евроценты, копейки и т.д.).
Реализовать методы для вывода суммы на экран, 
задания значений для частей.
На базе класса Money создать класс Product для работы
с продуктом или товаром. Реализовать метод, 
позволяющий уменьшить цену на заданное число.
Для каждого из классов реализовать необходимые
методы и поля.

*/

Merchandise test = new Merchandise("test", '$', 12, 55);

test.print();

test.loose_price("5.95");

test.print();

test.loose_price("7.48");

test.print();

// ZADANIE 2

/*

Создать базовый класс «Устройство» и производные
классы «Чайник», «Микроволновка», «Автомобиль», «Пароход». 
С помощью конструктора установить имя каждого
устройства и его характеристики.
Реализуйте для каждого из классов методы:
■ Sound — издает звук устройства (пишем текстом в
консоль);
■ Show — отображает название устройства;
■ Desc — отображает описание устройства.

*/

// KLASSI ZADANIYA 1

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

public class Merchandise : Money
{
    string _name;

    public Merchandise(string name, char sign, int whole, int fract) : base(sign, whole, fract)
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

// KLASSY ZADANIYA 2

public class Device
{
    protected string _name;
    protected string _desc;

    public Device(string name, string desc)
    {
        _name = name;
        _desc = desc;
    }
}

public class Teapot : Device
{
    public Teapot(string name, string desc) : base(name, desc) { }

    public void Sound()
    {
        WriteLine("Typical Teapot sound");
    }

    public void Show()
    {
        WriteLine(_name);
    }

    public void Desc()
    {
        WriteLine(_desc);
    }
}