namespace ProblemOtd20140416
{
  using System;
  using System.Linq;

  /// <summary>
  /// Duplicate Numbers / http://www.problemotd.com/problem/duplicate-numbers/
  //Hopefully while filling out your taxes you didn't run in to any issues with duplicate numbers. However, if you did now is your chance to make up for it. For today's problem you'll be passed in an array of integers and asked to identify all the duplicate numbers.
  //For a bonus solve it in under O(n^2) without making use of a set/hash (unless you want to implement your own :)).
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      Random random = new Random();
      int[] intArray = new int[100];

      // Give me 100 numbers between 0 and 50. Some will be duplicated, hopefully not all of them. :)
      for (int index = 0; index < 100; index++)
      {
        intArray[index] = random.Next(50);
      }

      // Give me a distinct list of numbers that occur in the array more then once
      foreach (int index in intArray.Where(index => intArray.Count(checkInt => checkInt == index) > 1).Distinct())
      {
         Console.WriteLine(index + " is duplicated");
      }

      Console.WriteLine("Finished press enter to exit");
      Console.ReadLine();
    }
  }
}
