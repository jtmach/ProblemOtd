namespace ProblemOtd20140408
{
  using System;
  using System.Collections.Generic;
  using System.IO;

  /// <summary>
  /// Where To Eat? / http://www.problemotd.com/problem/where-to-eat/
  //In my first couple of years in college I used to eat out a lot. One of the first programs I made in college was for my buddies and I to pick a place to eat. It's was a rather simple program. Took in a list of places to eat from a text file and chose one randomly.
  //I think it's about time for a slight upgrade though. Today's problem will be to implement the random food picker program and to also make sure that the same place isn't selected twice in a row. This means that your program will need to remember what it chose the last time it ran. Either via text file, HTML5 localstorage, database, etc.
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      string fileLocation;
      if (args.Length == 0)
      {
        Console.WriteLine("You must specify a file with your restaurant choices.");
        fileLocation = Console.ReadLine();
      }
      else
      {
        fileLocation = args[0];
      }

      FileInfo fileInfo = new FileInfo(fileLocation);

      if (!fileInfo.Exists)
      {
        Console.WriteLine("The file you specified does not exist.");
      }
      else
      {
        List<Restaurant> choices = GetChoices(fileInfo);
        if (choices.Count == 0)
        {
          Console.WriteLine("The file you specified does not contain any restaurants.");
        }
        else
        {
          Restaurant randomRestaurant = GetRandomRestaurant(choices);
          while (randomRestaurant.AteAtLastTime)
          { // If we ate at the chosen restaurant last time get another random choice
            randomRestaurant = GetRandomRestaurant(choices);
          }

          Console.WriteLine("You should eat at " + randomRestaurant.Name);
          WriteResults(fileInfo, choices, randomRestaurant);
        }
      }

      Console.WriteLine("Finished, press enter to exit");
      Console.ReadLine();
    }

    private static List<Restaurant> GetChoices(FileInfo file)
    {
      List<Restaurant> choices = new List<Restaurant>();
      StreamReader streamReader = new StreamReader(file.FullName);
      while (!streamReader.EndOfStream)
      {
        string choice = streamReader.ReadLine();
        choices.Add(choice.EndsWith("*") ? new Restaurant(choice.Substring(0, choice.Length - 1), true) : new Restaurant(choice));
      }
      streamReader.Close();

      return choices;
    }

    private static Restaurant GetRandomRestaurant(List<Restaurant> choices)
    {
      Random random = new Random();
      return choices[random.Next(0, choices.Count)];
    }

    private static void WriteResults(FileInfo file, List<Restaurant> choices, Restaurant chosenRestaurant)
    {
      StreamWriter streamWriter = new StreamWriter(file.FullName);
      foreach (Restaurant choice in choices)
      {
        streamWriter.WriteLine(choice.Name + (choice == chosenRestaurant ? "*" : ""));
      }
      streamWriter.Flush();
      streamWriter.Close();
    }

    private class Restaurant
    {
      public Restaurant(string name)
      {
        this.Name = name;
        this.AteAtLastTime = false;
      }

      public Restaurant(string name, bool ateAtLastTime)
      {
        this.Name = name;
        this.AteAtLastTime = ateAtLastTime;
      }

      public string Name { get; private set; }
      public bool AteAtLastTime { get; private set; }
    }
  }
}
