/*
*   Задача 74
    4 друга должны посетить 12 пабов, в котором выпить по британской пинте пенного напитка. 
    До каждого бара идти примерно 15-20 минут, каждый пьет пинту за 15 минут. 
    У первого друга лимит выпитого 1.1 литра, у второго 1.5, у третьего 2.2 литра, у 4 - 3.3 литра, это их максимум. 
    Необходимо выяснить, до скольки баров смогут дойти каждый из друзей(Пройденное расстояние (в барах)), пока не упадет. 
    И сколько всего времени будет потрачено на выпивку.

    Прямое решение
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

/// Посещено баров
int[] pubsVisited = { 0, 0, 0, 0 };

/// Количество выпитого пива.
double[] beerDrinked = { 0.0, 0.0, 0.0, 0.0 };

/// Лимиты употребления пива.
double[] beerLimit = { 1.1, 1.5, 2.2, 3.3 };

/// Время затраченное на веселье.
int[] timePassed = { 0, 0, 0, 0 };

/// Состояние друзей:
///     true - на ногах, может бухать
///     false - вечеринка окончена
bool[] status = { true, true, true, true };


/// Возвращает строковое представление времени в часах и минутах
///     minutes - время в минутах 
string MinuteToHour(int minutes)
{
    string result = String.Empty;;

    if(minutes > 59)
    {
        result += (minutes / 60) + " hour(s) ";
    }

    return result += (minutes % 60) + " minute(s)";
}


/// Main body.
Console.WriteLine($"Total {maxPubs} pubs");

for (int i = 0; i < maxPubs; i++)
{
    for (int k = 0; k < friendCount; k++)
    {
        if (status[k])
        {
            pubsVisited[k]++;
            beerDrinked[k] += pintValue;
            timePassed[k] += drinkTime + yardTime;
            if (beerDrinked[k] > beerLimit[k])
                status[k] = false;
        }
    }
}

for (int i = 0; i < friendCount; i++)
{
    Console.WriteLine($"Friend {i + 1}: {pubsVisited[i]} pubs, {MinuteToHour(timePassed[i])}");
}