/* 
*   Задача 73
    Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
    так чтобы в одной группе все числа в группе друг на друга не делились? 
    Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰. Например, для N = 50, M получается 6

    Группа 1: 1
    Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
    Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
    Группа 4: 8 12 18 20 27 28 30 42 44 45 50
    Группа 5: 7 16 24 36 40
    Группа 6: 5 32 48

    Группа 1: 1
    Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
    Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
    Группа 4: 8 12 18 20 27 28 30 42 44 45 50
    Группа 5: 16 24 36 40
    Группа 6: 32 48

    P.S. N должно быть  > 0
    Формирование групп доступно 2-я способами
*/

/// порядковый номер для начала отсчета групп
const int startGroupNo = 1;

/// Получение целочисленного значения от пользователя с консоли.
///     message - сообщение, выводимое пользователю
long InputInt(string message)
{
    Console.Write(message);
    return Convert.ToInt64(Console.ReadLine());
}

/// Рекурсивный поиск и отображение числовых групп, согласно условия. Поиск "с конца".
/// Числа, переданные в группу из исходного массива удаляются, исходный массив изменяет размер. 
///     array - массив чисел, по которому происходит поиск
///     groupNo - номер выводимой группы
void FindUnicalGroupsFirst(long[] array, int groupNo)
{
    if (array.Length == 0)
        return;

    long[] groupLine = { array[array.Length - 1] };
    array = DeleteItem(array, array.Length - 1);

    for (long i = array.Length - 1; i >= 0; i--)
    {
        bool divided = false;
        for (long j = 0; j < groupLine.Length; j++)
        {
            divided = (array[i] % groupLine[j] == 0 || groupLine[j] % array[i] == 0);
            if (divided)
            {
                break;
            }
        }

        if (!divided)
        {
            groupLine = AddItem(groupLine, array[i]);
            array = DeleteItem(array, i);
        }
    }

    PrintGroupLine(groupNo, groupLine);
    FindUnicalGroupsFirst(array, groupNo + 1);
}

/// Вывод группы чисел на экран
///     groupNo - номер группы
///     line - массив группы чисел 
void PrintGroupLine(int groupNo, long[] line)
{
    Console.Write($"Group {groupNo}: ");
    Console.WriteLine(String.Join(" ", line));
}

/// Рекурсивный поиск и отображение числовых групп, согласно условия. Поиск "с начала".
/// в исходном массиве числа, переданные в группу заменяются на 0 
///     array - массив чисел, по которому происходит поиск
///     groupNo - номер выводимой группы
///     founded - количество использованных чисел исходного массива (для выхода из рекурсии) 
///               по умолчанию - 0
void FindUnicalGroupsSecond(long[] array, int groupNo, int founded = 0)
{
    if (founded == array.Length)
        return;

    long[] groupLine = { };

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] > 0)
        {
            if (groupLine.Length == 0)
            {
                groupLine = AddItem(groupLine, array[i]);
                array[i] = 0;
                founded++;
            }
            else
            {
                bool divided = false;
                for (int j = 0; j < groupLine.Length; j++)
                {
                    divided = (array[i] % groupLine[j] == 0 || groupLine[j] % array[i] == 0);
                    if (divided)
                    {
                        break;
                    }
                }

                if (!divided)
                {
                    groupLine = AddItem(groupLine, array[i]);
                    array[i] = 0;
                    founded++;
                }
            }

        }
    }

    PrintGroupLine(groupNo, groupLine);
    FindUnicalGroupsSecond(array, groupNo + 1, founded);
}



/// Удаление указанного элемента из массива. Возвращает массив нового размера.
/// Если удаляемая позиция за пределами индексов массива, будет удален последний элемент.
///     array - массив для удаления элемента
///     itemPosition - позиция удаляемого элемента
long[] DeleteItem(long[] array, long itemPosition)
{
    for (long j = itemPosition; j < array.Length - 1; j++)
    {
        array[j] = array[j + 1];
    }
    Array.Resize(ref array, array.Length - 1);

    return array;
}

/// Добавление нового элемента в массив. Возвращает новый массив
///     array - массив для добавления
///     value - добавляемое значение
long[] AddItem(long[] array, long value)
{
    Array.Resize(ref array, array.Length + 1);
    array[array.Length - 1] = value;

    return array;
}


/// Main body.
long maxNumber = InputInt("Input number: ");

if (maxNumber <= 0)
{
    Console.WriteLine("Wrong number!");
}
else
{
    long[] digitsFirst = new long[maxNumber];
    long[] digitsSecond = new long[maxNumber];

    for (int i = 0; i < maxNumber; i++)
    {
        digitsFirst[i] = digitsSecond[i] = i + 1;
    }

    FindUnicalGroupsFirst(digitsFirst, startGroupNo);
    Console.WriteLine();
    FindUnicalGroupsSecond(digitsSecond, startGroupNo);
}