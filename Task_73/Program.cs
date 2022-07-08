/**
* * Задача 73
*   Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
*   так чтобы в одной группе все числа в группе друг на друга не делились? 
*   Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰. Например, для N = 50, M получается 6
*   
*   Группа 1: 1
*   Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
*   Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
*   Группа 4: 8 12 18 20 27 28 30 42 44 45 50
*   Группа 5: 7 16 24 36 40
*   Группа 6: 5 32 48
*   
*   Группа 1: 1
*   Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
*   Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
*   Группа 4: 8 12 18 20 27 28 30 42 44 45 50
*   Группа 5: 16 24 36 40
*   Группа 6: 32 48
*/

/// порядковый номер для 1й найденной группы
const int startGroupNo = 1;

/// Получение целочисленного значения от пользователя с консоли.
///     message - сообщение, выводимое пользователю
int InputInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}


/// Рекурсивный поиск и отображение числовых групп, согласно условия. Поиск "с конца".
/// из исходного массива числа удаляются, по мере формирования групп
/// исходный массив изменяет размер. 
///     array - массив чисел, по которому происходит поиск
///     groupNo - номер выводимой группы
void FindUnicalGroupsDesc(int[] array, int groupNo)
{
    if (array.Length == 0)
        return;

    int[] groupNum = { array[array.Length - 1] };

    Array.Resize<int>(ref array, array.Length - 1);

    for (int i = array.Length - 1; i >= 0; i--)
    {
        bool divided = false;
        for (int j = 0; j < groupNum.Length; j++)
        {
            divided = (array[i] % groupNum[j] == 0 || groupNum[j] % array[i] == 0);
            if (divided)
            {
                break;
            }
        }

        if (!divided)
        {
            groupNum = AddItem(groupNum, array[i]);
            array = DeleteItem(array, i);
        }
    }

    Console.Write($"Group {groupNo}: ");
    Console.WriteLine(String.Join(" ", groupNum));
    FindUnicalGroupsDesc(array, groupNo + 1);
}

/// Рекурсивный поиск и отображение числовых групп, согласно условия. Поиск "с начала".
/// из исходного массива числа удаляются, по мере формирования групп
/// исходный массив изменяет размер. 
///     array - массив чисел, по которому происходит поиск
///     groupNo - номер выводимой группы
void FindUnicalGroupsAsc(int[] array, int groupNo)
{
    if (array.Length == 0)
        return;

    int[] groupNum = { array[0] };
    array = DeleteItem(array, 0);

    for (int i = 0; i < array.Length; i++)
    {
        bool divided = false;
        for (int j = 0; j < groupNum.Length; j++)
        {
            divided = (array[i] % groupNum[j] == 0 || groupNum[j] % array[i] == 0);
            if (divided)
            {
                break;
            }
        }

        if (!divided)
        {
            groupNum = AddItem(groupNum, array[i]);
            array = DeleteItem(array, i);
        }
    }

    Console.Write($"Group {groupNo}: ");
    Console.WriteLine(String.Join(" ", groupNum));
    FindUnicalGroupsAsc(array, groupNo + 1);
}



/// Удаление указанного элемента из массива. Возвращает массив нового размера.
/// Если удаляемая позиция за пределами индексов массива, будет удален последний элемент.
///     array - массив для удаления элемента
///     itemPosition - позиция удаляемого элемента
int[] DeleteItem(int[] array, int itemPosition)
{
    for (int j = itemPosition; j < array.Length - 1; j++)
    {
        array[j] = array[j + 1];
    }
    Array.Resize(ref array, array.Length - 1);

    return array;
}

/// Добавление нового элемента в массив. Возвращает новый массив
///     array - массив для добавления
///     value - добавляемое значение
int[] AddItem(int[] array, int value)
{
    Array.Resize(ref array, array.Length + 1);
    array[array.Length - 1] = value;

    return array;
}


/// Main body.
int maxNumber = InputInt("Input number: ");
int[] digitsForEnd = new int[maxNumber];
int[] digitsForStart = new int[maxNumber];

for (int i = 0; i < maxNumber; i++)
{
    digitsForEnd[i] = digitsForStart[i] = i + 1;
}

FindUnicalGroupsAsc(digitsForStart, startGroupNo);
Console.WriteLine();
FindUnicalGroupsDesc(digitsForEnd, startGroupNo);
