using System;
using System.Collections.Generic;

class Player
{
    static void Main(string[] args)
    {
        while (true)
        {
            List<int> mountains = new List<int>();
            int maxVal = -1;
            for (int i = 0; i < 8; i++)
            {   
                int heigth = int.Parse(Console.ReadLine());
                mountains.Add(heigth);

                if (maxVal < heigth) maxVal = heigth;
            }

            Console.WriteLine(mountains.IndexOf(maxVal));
        }
    }
}