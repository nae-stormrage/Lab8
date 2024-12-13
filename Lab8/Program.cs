class ЭВМ
{
    public ЭВМ(string НЗ, string ЦП, int ОЗУ, int ПЗУ)
    {
        Название = НЗ; Центральный_Процессор = ЦП; Оперативная_Память = ОЗУ; Хранилище = ПЗУ;
    }

    public ЭВМ()
    {
        Название = "нет данных"; Центральный_Процессор = ""; Оперативная_Память = 0; Хранилище = 0;
    }

    public string Название, Центральный_Процессор;
    public int Оперативная_Память, Хранилище;

    public virtual string Описание
    {
        get { return Название + ": " + Центральный_Процессор + ", RAM: " + Оперативная_Память + "ГБ, " + "Хранилище: " + Хранилище + "ГБ"; }
    }
}

class Мобильный: ЭВМ
{
    public Мобильный()
        :base()
    {
        Батарея = Батареи.Нет_Батареи;
    }

    public Мобильный(string НЗ, string ЦП, int ОЗУ, int ПЗУ, Батареи БТ)
        :base(НЗ, ЦП, ОЗУ, ПЗУ)
    {
        Батарея = БТ;
    }

    public Батареи Батарея;

    public override string Описание
    {
        get { return base.Описание + ", Батарея: " + Батарея.ToString(); }
    }
}

class Планшет : Мобильный
{
    public Планшет()
        :base()
    {
        Стилус = Стилусы.Нет_Стилуса;
    }

    public Планшет(string НЗ, string ЦП, int ОЗУ, int ПЗУ, Батареи БТ, Стилусы СТ)
        :base(НЗ, ЦП, ОЗУ, ПЗУ, БТ)
    {
        Стилус = СТ;
    }

    public Стилусы Стилус;

    public override string Описание
    {
        get { return base.Описание + ", Стилус: " + Стилус.ToString(); }
    }
}

class Ноутбук : Мобильный
{
    public Ноутбук()
        : base()
    {
        Диагональ = Диагонали.Нет_Диагонали;
    }

    public Ноутбук(string НЗ, string ЦП, int ОЗУ, int ПЗУ, Батареи БТ, Диагонали ДГ)
        : base(НЗ, ЦП, ОЗУ, ПЗУ, БТ)
    {
        Диагональ = ДГ;
    }

    public Диагонали Диагональ;

    public override string Описание
    {
        get { return base.Описание + ", Диагональ: " + Диагональ.ToString(); }
    }
}

class Стационарный : ЭВМ
{
    public Стационарный()
        : base()
    {
        Тип_Корпуса = Типы_Корпусов.Нет_Типа_Корпуса;
    }

    public Стационарный(string НЗ, string ЦП, int ОЗУ, int ПЗУ, Типы_Корпусов ТК)
        : base(НЗ, ЦП, ОЗУ, ПЗУ)
    {
        Тип_Корпуса = ТК;
    }

    public Типы_Корпусов Тип_Корпуса;

    public override string Описание
    {
        get { return base.Описание + ", Тип Корпуса: " + Тип_Корпуса.ToString(); }
    }
}

public enum Батареи
{
    Маленькая,
    Средняя,
    Большая,
    Нет_Батареи
}

public enum Стилусы
{
    Magic_Pencil_Pro,
    Samsung_Pen_S24,
    Espada_STA,
    Нет_Стилуса
}

public enum Диагонали
{
    Маленькая,
    Средняя,
    Большая,
    Нет_Диагонали
}

public enum Типы_Корпусов
{
    Mini_Tower,
    Mid_Tower,
    Full_Tower,
    Нет_Типа_Корпуса
}

class Program
{
    static void Main(string[] args)
    {
        ЭВМ[] mas = new ЭВМ[5];

        mas[0] = new ЭВМ("MSI Forge 100M", "Intel Core i3-10100F", 16, 1024);
        mas[1] = new Мобильный("MacBook Air 15", "M1 Max", 16, 512, Батареи.Средняя);
        mas[2] = new Планшет("Samsung Galaxy Tab S10 Ultra", "MediaTek Dimensity 9300", 16, 1024, Батареи.Большая, Стилусы.Samsung_Pen_S24);
        mas[3] = new Ноутбук("ASUS ROG STRIX G18", "Intel Core I7-13650HX", 32, 1024, Батареи.Большая, Диагонали.Большая);
        mas[4] = new Стационарный("Lenovo Legion T7", "Intel Core I7-14700KF", 32, 2048, Типы_Корпусов.Mid_Tower);

        for (int i = 0; i < mas.Length; i++)
        {
            Console.WriteLine(">>>>>>>>>>      " + mas[i].GetType().Name);
            Console.WriteLine(mas[i].Описание);
            Console.WriteLine("\n");
        }
    }
}