using System;

namespace TheoryForMyLectures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Каква е разликата между Dependency Injection и Dependency Inversion (много любим въпрос по интервюта)   - Dependency Inversion e принципа, който казва че зависимостите трябва да получаваме отвън, а Dependency Injection е начина по който го правим, това е конкретната имплементация Dependency Inversion!!! Dependency Inversion най-много се използва за тестване, ако нямаме Dependency Injection е много трудно да си тестваме кода - това е най-голямата полза, а също и това че прави кода по-абстрактен и по-лесен са екстендване впоследствие. Просто това което ще ползваме искаме да ни се подава отвън (чрез конструктора (construktor Injection) или чрез параметри на метода(method Injection)). Хубаво е да правим абстреакции когато инжектираме, но не е задължително.

            //GivenShouldWhen pattern използва Даков за именуване на тестовете - много популярна практика за именуване на тестове(да го погледна)

            //Какво е Poor man's Dependency Inversion - 

            //Mocking - 
        }
    }
}
