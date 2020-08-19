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
    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
    byte[] characterBytes = encoding.GetBytes(Console.ReadLine());
    string byteString = "";
    foreach (byte character in characterBytes)
    {
      byteString += Convert.ToString(character, 2).PadLeft(7, '0');
    }

    string solution = "";
    char lastNumber = new Char();
    foreach (char bit in byteString)
    {
      if (lastNumber == bit)
      {
        solution += "0";
      }
      else
      {
        solution += " ";
        if (bit == '1')
        {
          solution += "0 0";
        }
        else
        {
          solution += "00 0";
        }
      }
      lastNumber = bit;
    }
    Console.WriteLine(solution.Trim());
  }
}