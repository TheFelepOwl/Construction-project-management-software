using System;

// Клас для перевірки валідності географічних координат
public class GeoDataValidator
{
    private readonly double minLatitude;
    private readonly double maxLatitude;
    private readonly double minLongitude;
    private readonly double maxLongitude;

    // Конструктор, який ініціалізує мінімальні та максимальні значення широти та довготи
    public GeoDataValidator(double minLatitude, double maxLatitude, double minLongitude, double maxLongitude)
    {
        this.minLatitude = minLatitude;
        this.maxLatitude = maxLatitude;
        this.minLongitude = minLongitude;
        this.maxLongitude = maxLongitude;
    }

    // Метод для перевірки валідності координат
    public bool ValidateCoordinates(double latitude, double longitude)
    {
        // Перевірка чи координати потрапляють в визначений діапазон
        if (latitude >= minLatitude && latitude <= maxLatitude &&
            longitude >= minLongitude && longitude <= maxLongitude)
        {
            return true; // Якщо координати валідні, повертаємо true
        }
        else
        {
            return false; // Якщо координати недійсні, повертаємо false
        }
    }
}

// Клас для перевірки валідності даних від датчиків
public class SensorDataValidator
{
    private readonly double minValue;
    private readonly double maxValue;

    // Конструктор, який ініціалізує мінімальне та максимальне значення датчика
    public SensorDataValidator(double minValue, double maxValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
    }

    // Метод для перевірки валідності даних від датчика
    public bool ValidateData(string sensorType, double data)
    {
        // Перевірка типу датчика та відповідність даних встановленим критеріям
        switch (sensorType)
        {
            case "moisture": // Перевірка для датчика вологості
                if (data >= 0 && data <= 100) // Вологість в процентах
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "temperature": // Перевірка для датчика температури
                if (data >= -273.15 && data <= 100) // Температура в градусах Цельсія
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "light": // Перевірка для датчика освітленості
                if (data >= 0 && data <= 100000) // Світло в люменах
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                return false; // Повертаємо false, якщо тип датчика не відомий
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання GeoDataValidator
        GeoDataValidator geoValidator = new GeoDataValidator(0, 90, -180, 180);
        double latitude = 45.678;
        double longitude = -123.456;
        if (geoValidator.ValidateCoordinates(latitude, longitude))
        {
            Console.WriteLine("Координати валiднi");
        }
        else
        {
            Console.WriteLine("Координати недiйснi");
        }

        // Приклад використання SensorDataValidator
        SensorDataValidator sensorValidator = new SensorDataValidator(0, 100);
        string sensorType = "moisture";
        double dataValue = 75;
        if (sensorValidator.ValidateData(sensorType, dataValue))
        {
            Console.WriteLine("Данi вiд датчика валiднi");
        }
        else
        {
            Console.WriteLine("Данi вiд датчика недiйснi");
        }
    }
}
