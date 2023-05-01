namespace AdmixerHedgehog
{
    internal class Program
    {
        public static void Main()
        {
            /* 
             В методі Main ми свторюємо масив initialPopulation - тобто початкову популяцію їжачків.
             Далі ми вручну задаємо кілільсть для кожного кольорового виду їжачків.
             Також вручну задаємо значення бажаного кольору desiredColor.
             Змінна result в собі містить використання методу MinimumMeetings.
             Після чого виводимо результат на консоль.
             Це все було поміщенов цикл while, для зручності перевірки роботи консльної програми.
             Додав умовну конструкцію if, якщо змінна result дорівнює -1, ми виходимо з циклу,
             в інакшому випадку ми продовжуємо тестувати програму.
            */
            while (true)
            {
                int[] initialPopulation = new int[3];
                Console.Write("Enter the number of red hedgehogs: ");
                initialPopulation[0] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the number of green hedgehogs: ");
                initialPopulation[1] = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the number of blue hedgehogs: ");
                initialPopulation[2] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the desired color: red = 0; green = 1; blue = 2.");
                int desiredColor = Convert.ToInt32(Console.ReadLine());

                int result = MinimumMeetings(initialPopulation, desiredColor);

                if (result == -1)
                {
                    Console.WriteLine($"Necessary number of meetings: {result}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Necessary number of meetings: {result}");
                }

            }
        }

        /* 
         Mетод MinimumMeetings два параметри: цілий масив hedgehogPopulation, 
         що представляє початкову популяцію їжачків кожного кольору,
         та ціле число desiredColor, що представляє колір, яким хочуть стати всі їжачки. 
         Метод вираховує мінімальну кількість зустрічей, необхідну для зміни всіх їжачків
         на бажаний колір, і повертає це значення. Якщо неможливо змінити всіх їжачків 
         на бажаний колір, метод повертає -1.
        */

        public static int MinimumMeetings(int[] hedgehogPopulation, int desiredColor)
        {
         /* 
          Перше, що робить метод - це ініціалізує три змінні: totalMeetings, sameColorMeetings і sameColor.
          totalMeetings буде використовуватися для відстеження загальної кількості зустрічей, 
          необхідних для зміни всіх їжачків на бажаний колір. 
          sameColorMeetings буде використовуватися для відстеження кількості зустрічей, 
          які відбулися б, якби зустрілися їжачки одного кольору. 
          sameColor - це кількість їжачків бажаного кольору в початковій популяції.
         */
            int totalMeetings = 0;
            int sameColorMeetings = 0;
            int sameColor = hedgehogPopulation[desiredColor];

         /* 
          Mетод циклічно перебирає кожен елемент масиву популяції. 
          Якщо колір їжачка збігається з шуканим кольором, 
          то метод додає кількість їжачків до змінної sameColorMeetings. 
          Якщо колір їжачка відрізняється від бажаного кольору, 
          то метод додає кількість їжачків до змінної totalMeetings.
         */

            for (int i = 0; i < hedgehogPopulation.Length; i++)
            {
                if (hedgehogPopulation[i] == sameColor && i != desiredColor)
                {
                    sameColorMeetings += hedgehogPopulation[i];
                }
                else if (i != desiredColor)
                {
                    totalMeetings += hedgehogPopulation[i];
                }
            }

            /* 
             Після циклу метод перевіряє, чи всі їжачки спочатку мають однаковий колір,
             порівнюючи змінну sameColor з кожним елементом масиву популяції. 
             Якщо всі вони однакові, то метод повертає -1, оскільки немає потреби у зустрічах.
            */

            if (sameColor == hedgehogPopulation[0] && 
                sameColor == hedgehogPopulation[1] && 
                sameColor == hedgehogPopulation[2])
            {
                return -1;
            }

            /* 
             Далі метод перевіряє, чи можливо змінити всіх їжачків на потрібний колір. 
             Якщо загальна кількість зустрічей, необхідних для зміни їжачків одного кольору, 
             більша або дорівнює кількості їжачків потрібного кольору, 
             то змінити всіх їжачків на потрібний колір неможливо, і метод повертає -1.
            */

            if (sameColorMeetings >= sameColor)
            {
                return -1;
            }

            /* 
            Mетод обчислює кількість зустрічей, необхідних для того, щоб змінити всі їжачки на бажаний колір. 
            Для цього він додає змінну sameColorMeetings до змінної totalMeetings, ділить на 2
            (оскільки на кожній зустрічі зустрічаються два їжачки) і округляє до найближчого 
            цілого числа за допомогою цілочисельного ділення. Це значення повертається методом
           */

            totalMeetings += sameColorMeetings;
            int neededEncounters = (totalMeetings + 1) / 2;
            return neededEncounters;
        }
    }
}