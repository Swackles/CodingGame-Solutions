using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
  static void Main(string[] args)
  {
    int count = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
    if (count == 0)
    {
      Console.WriteLine(0);
      return;
    }

    string[] tempetures = Console.ReadLine().Split(' ');
    int[] tempeturesInt = Array.ConvertAll(tempetures, s => int.Parse(s));
    int[] positiveNumber = tempeturesInt.Where(n => n >= 0).ToArray();
    int[] negativeNumber = tempeturesInt.Where(n => n < 0).ToArray();

    Array.Sort(positiveNumber);
    Array.Sort(negativeNumber);
    if (positiveNumber.Length == 0)
    {
      Console.WriteLine(negativeNumber.Last());
      return;
    }
    else if (negativeNumber.Length == 0)
    {
      Console.WriteLine(positiveNumber[0]);
      return;
    }

    if ((0 - positiveNumber[0]) >= (0 + negativeNumber.Last()))
    {
      Console.WriteLine(positiveNumber[0]);
    }
    else
    {
      Console.WriteLine(negativeNumber[0]);
    }
  }
}