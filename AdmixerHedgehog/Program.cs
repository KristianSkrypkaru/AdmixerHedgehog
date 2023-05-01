namespace AdmixerHedgehog
{
    internal class Program
    {
        public static void Main()
        {
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

                Console.WriteLine($"Necessary number of meetings: {result}");
            }
        }
        public static int MinimumMeetings(int[] hedgehogPopulation, int desiredColor)
        {
            int totalMeetings = 0;
            int sameColorMeetings = 0;
            int sameColor = hedgehogPopulation[desiredColor];

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

            if (sameColor == hedgehogPopulation[0] && sameColor == hedgehogPopulation[1] && sameColor == hedgehogPopulation[2])
            {
                return -1;
            }

            if (sameColorMeetings >= sameColor)
            {
                return -1;
            }

            totalMeetings += sameColorMeetings;
            int neededEncounters = (totalMeetings + 1) / 2;
            return neededEncounters;
        }
    }
}