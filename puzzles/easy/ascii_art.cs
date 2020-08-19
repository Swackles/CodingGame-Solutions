using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
  static void Main(string[] args)
  {
    int width = int.Parse(Console.ReadLine());
    int height = int.Parse(Console.ReadLine());
    List<char> word = Console.ReadLine().ToUpper().ToCharArray().ToList();
    List<string> solution = new List<string>();

    for (int i = 0; i < height; i++)
    {
      string asciiLine = Console.ReadLine();
      string line = "";

      word.ForEach(character =>
      {
        List<char> alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?".ToCharArray().ToList();
        int letterPos = alphabet.IndexOf(character);

        if (letterPos == -1) { letterPos = alphabet.IndexOf('?'); }

        line += asciiLine.Substring(width * letterPos, width);
      });

      solution.Add(line);
    }

    solution.ForEach((row) =>
    {
      Console.WriteLine(row);
    });
  }
}