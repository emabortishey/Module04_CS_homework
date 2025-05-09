﻿using static System.Console;

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

// создание обьекта класса и испытание изменения его стоимости
// а также последующий вывод для проверки результата

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

// т.к. в задании ничего не требовалось
// кроме создания объектов класса,
// я больше ничего и не делала

Teapot teapot = new Teapot("чайник", "делает чай");
Microwave microwave = new Microwave("микроволновка", "делает микроволны");
Car car = new Car("машина", "делает врум врум");
Steamboat steamboat = new Steamboat("пароход", "хз");

// ZADANIE 3

/*

Создать базовый класс «Музыкальный инструмент»
и производные классы «Скрипка», «Тромбон», «Укулеле»,
«Виолончель». С помощью конструктора установить имя
каждого музыкального инструмента и его характеристики.
Реализуйте для каждого из классов методы:
■ Sound — издает звук музыкального инструмента
(пишем текстом в консоль);
■ Show — отображает название музыкального инструмента;
■ Desc — отображает описание музыкального инструмента;
■ History — отображает историю создания музыкального инструмента.

*/

// то же самое что и в предыдущем задании

Violin violin = new Violin("скрипко", "скрипит", "я придумала");
Trombone trombone = new Trombone("тромбон", "хз ваще", "я не придумывала, хз");
Ukulele ukulele = new Ukulele("укулеле", "укулеле", "укулеле");
Violoncelle violoncelle = new Violoncelle("1", "ц", "3");

// ZADANIE 4

/*

Создать абстрактный базовый класс Worker (работника)
с методом Print(). Создайте четыре производных класса:
President, Security, Manager, Engineer. Переопределите метод
Print() для вывода информации, соответствующей
каждому типу работника.

*/

// а тут вообще ничего кроме создания класса и
// переопределения метода не требовалось, поэтомк
// тут я тоже класс даже не испытывала в работе

// KLASSI ZADANIYA 1

public class Money
{
    // знак валюты
    protected char _sign;
    // целая часть
    protected int _whole;
    // дробная
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
            // если было передано значение больше ста,
            // то идёт прибавление перевеса в целую часть
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

    // метод повышения цены
    public void rise_price(string price)
    {
        // если нету точки, то есть разделителя
        // между дробной и целой частью, то значит и
        // самой дробной части нет, поэтому идёт проверка
        // для правильности дальнейших вычислений
        if (price.IndexOf('.') != -1)
        {
            // создаём 2 переменные в виде символьных массивов т.к.
            // метод копирования из строки принимает только массив
            // и сразу задаём им макс. значение на всякий
            char[] whole_p = new char[char.MaxValue], fract_p = new char[char.MaxValue];

            // в целый буфер копируем числа до точки
            price.CopyTo(0, whole_p, 0, price.IndexOf('.'));
            // в дробный после неё и до конца
            price.CopyTo(price.IndexOf('.') + 1, fract_p, 0, price.Length - price.IndexOf('.')-1);

            // в целый просто прибавляем скопированное
            // и конвертированное число с помощью
            // метода парсе, т.к. с конвертом у мя были проблемы
            _whole += int.Parse(whole_p);

            // если текущая дробная часть плюс прибавляемая
            // равняется больше 100, то также идёт перенос
            // излишка в целую часть денег
            if ((_fract + int.Parse(fract_p)) >= 100) 
            {
                _whole += (_fract + int.Parse(fract_p)) / 100;

                _fract = (_fract + int.Parse(fract_p)) - (((_fract + int.Parse(fract_p)) / 100) * 100);
            }
            // если превышения нет, просто прибавляем
            else
            {
                _fract += int.Parse(fract_p);
            }
        }
        // если дробной части нет и вовсе, то
        // просто извлекаем из строки число и прибавляем
        else
        {
           _whole += int.Parse(price.ToCharArray());
        }
    }

    // метод для понижения цены товара
    // (тут всё почти то же самое, поэтому
    // не буду расписывать лишние коммантарии)
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

public class Microwave : Device
{
    public Microwave(string name, string desc) : base(name, desc) { }

    public void Sound()
    {
        WriteLine("Typical Microwave sound");
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

public class Car : Device
{
    public Car(string name, string desc) : base(name, desc) { }

    public void Sound()
    {
        WriteLine("Typical Car sound");
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

public class Steamboat : Device
{
    public Steamboat(string name, string desc) : base(name, desc) { }

    public void Sound()
    {
        WriteLine("Typical Steamboat sound");
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

// KLASSI ZADANIYA 3

public class Musical_tool
{
    protected string _name;
    protected string _desc;
    protected string _creation_hist;

    public Musical_tool(string name, string desc, string creation_hist)
    {
        _name = name;
        _desc = desc;
        _creation_hist = creation_hist;
    }
}

public class Violin : Musical_tool
{
    public Violin(string name, string desc, string creation_hist) : base(name, desc, creation_hist) { }

    public void Sound()
    {
        WriteLine("Typical Violin sound");
    }

    public void Show()
    {
        WriteLine(_name);
    }

    public void Desc()
    {
        WriteLine(_desc);
    }

    public void History()
    {
        WriteLine(_creation_hist);
    }
}

public class Trombone : Musical_tool
{
    public Trombone(string name, string desc, string creation_hist) : base(name, desc, creation_hist) { }

    public void Sound()
    {
        WriteLine("Typical Trombone sound");
    }

    public void Show()
    {
        WriteLine(_name);
    }

    public void Desc()
    {
        WriteLine(_desc);
    }

    public void History()
    {
        WriteLine(_creation_hist);
    }
}

public class Ukulele : Musical_tool
{
    public Ukulele(string name, string desc, string creation_hist) : base(name, desc, creation_hist) { }

    public void Sound()
    {
        WriteLine("Typical Ukulele sound");
    }

    public void Show()
    {
        WriteLine(_name);
    }

    public void Desc()
    {
        WriteLine(_desc);
    }

    public void History()
    {
        WriteLine(_creation_hist);
    }
}

public class Violoncelle : Musical_tool
{
    public Violoncelle(string name, string desc, string creation_hist) : base(name, desc, creation_hist) { }

    public void Sound()
    {
        WriteLine("Typical Violoncelle sound");
    }

    public void Show()
    {
        WriteLine(_name);
    }

    public void Desc()
    {
        WriteLine(_desc);
    }

    public void History()
    {
        WriteLine(_creation_hist);
    }
}

// KLASSI ZADANIYA 4

public abstract class Worker
{
    public abstract void print();
}

public class President : Worker
{
    int _salary;
    string _country;

    public President(int salary, string country)
    {
        _salary = salary;
        _country = country;
    }

    public override void print()
    {
        WriteLine($"President of the country named {_country} has salary about {_salary} dollars.");
    }
}

public class Security : Worker
{
    int _salary;
    string _object;

    public Security(int salary, string objectt)
    {
        _salary = salary;
        _object = objectt;
    }

    public override void print()
    {
        WriteLine($"Security of the object named {_object} has salary about {_salary} dollars.");
    }
}

public class Manager : Worker
{
    int _salary;
    string _company;

    public Manager(int salary, string company)
    {
        _salary = salary;
        _company = company;
    }

    public override void print()
    {
        WriteLine($"Manager of the company named {_company} has salary about {_salary} dollars.");
    }
}

public class Engineer : Worker
{
    int _salary;
    string _class;

    public Engineer(int salary, string classs)
    {
        _salary = salary;
        _class = classs;
    }

    public override void print()
    {
        WriteLine($"Engineer that's having education on {_class} class has salary about {_salary} dollars.");
    }
}