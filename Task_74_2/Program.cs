/*
*   Задача 74
    4 друга должны посетить 12 пабов, в котором выпить по британской пинте пенного напитка. 
    До каждого бара идти примерно 15-20 минут, каждый пьет пинту за 15 минут. 
    У первого друга лимит выпитого 1.1 литра, у второго 1.5, у третьего 2.2 литра, у 4 - 3.3 литра, это их максимум. 
    Необходимо выяснить, до скольки баров смогут дойти каждый из друзей(Пройденное расстояние (в барах)), пока не упадет. 
    И сколько всего времени будет потрачено на выпивку.

    Решениеи в сприменениеим рекурсии
*/

/// Максимальное количество пабов.
const int maxPubs = 12;

/// Время прохода к бару.
const int yardTime = 20;

/// Время выпивания пинты.
const int drinkTime = 15;

/// Британская пинта = ~0,57 литра.
const double pintValue = 0.57;

/// Всего друзей.
const int friendCount = 4;

/// Лимиты употребления пива.
double[] beerLimit = { 1.1, 1.5, 2.2, 3.3 };

/// Возвращает строковое представление времени в часах и минутах
///     minutes - время в минутах 
string MinuteToHour(int minutes)
{
    string result = String.Empty; ;

    if (minutes > 59)
    {
        result += (minutes / 60) + " hour(s) ";
    }

    return result += (minutes % 60) + " minute(s)";
}

/// поиск алкогольных возможностей конкретного из друзей
///     pubNo - паб, который посещает
///     yardTime - время дойти до бара 
///     drinkTime - время на выпить пиво
///     beerLimit - предел выпиваемого алкоголя
string Drinking(double beerLimit, int pubNo = 0, int timePassed = 0, double beerDrinked = 0.0)
{
    beerDrinked += pintValue;
    timePassed += yardTime + drinkTime;
    pubNo++;

    if (beerDrinked > beerLimit)
    {
        return $"{pubNo} pubs, {MinuteToHour(timePassed)}";
    }
    else if (pubNo == maxPubs)
    {
        return $"{pubNo} pubs, {MinuteToHour(timePassed)} and may to continue";
    }
    else
    {
        return Drinking(beerLimit, pubNo, timePassed, beerDrinked);
    }
}

/// Main body.

Console.WriteLine($"Total {maxPubs} pubs");
for(int i=0; i<friendCount; i++)
{
    Console.WriteLine($"Friend {i+1}: {Drinking(beerLimit[i])}");
}