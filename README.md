# C#.Семинар 10. HomeWork

## Рекурсия продолжение

### Задача 73

Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, так чтобы в одной группе все числа в группе друг на друга не делились? Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰.
Например, для N = 50, M получается 6

*Группа 1: 1*

*Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47*

*Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49*

*Группа 4: 8 12 18 20 27 28 30 42 44 45 50*

*Группа 5: 7 16 24 36 40*

*Группа 6: 5 32 48*


*Группа 1: 1*

*Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47*

*Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49*

*Группа 4: 8 12 18 20 27 28 30 42 44 45 50*

*Группа 5: 16 24 36 40*

*Группа 6: 32 48*

Разбивка по группам 2мя способами

**_Скриншот выполнения_**

!["Task_73"](/ScreenShots/Task_73.png "Скриншот задачи 73")


---

### Задача 74*

4 друга должны посетить 12 пабов, в котором выпить по британской пинте пенного напитка. До каждого бара идти примерно 15-20 минут, каждый пьет пинту за 15 минут. У первого друга лимит выпитого 1.1 литра, у второго 1.5, у третьего 2.2 литра, у 4 - 3.3 литра, это их максимум. Необходимо выяснить, до скольки баров смогут дойти каждый из друзей(Пройденное расстояние (в барах)), пока не упадет. И сколько всего времени будет потрачено на выпивку.

Два способа решения. (Task_74 - в лоб. Task_74_2 - с рекурсией)

**_Скриншоты выполнения_**

!["Task_74"](/ScreenShots/Task_74.png "Скриншот задачи 74")
!["Task_74-2"](/ScreenShots/Task_74_2.png "Скриншот задачи 74-2")

---
