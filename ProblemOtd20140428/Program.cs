namespace ProblemOtd20140428
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;

  class Program
  {
    public static string PreviousChoices = "";
    public enum Choice { rock = 0, paper = 1, scissors = 2 }

    static void Main(string[] args)
    {
      ReadLog();
      Choice aiChoice = GetAiChoice();
      Console.WriteLine("Enter your choice?");
      string command = Console.ReadLine().ToLower();

      while (command != "exit")
      {
        switch (command)
        {
          case "rock":
            DidAiWin(Choice.rock, aiChoice);
            break;
          case "paper":
            DidAiWin(Choice.paper, aiChoice);
            break;
          case "scissors":
            DidAiWin(Choice.scissors, aiChoice);
            break;
          case "lizard":
          case "spock":
            Console.WriteLine("Very funny, please try again.");
            break;
          default:
            Console.WriteLine("Invalid choice, please try again.");
            break;
        }

        aiChoice = GetAiChoice();
        Console.WriteLine("Enter your choice?");
        command = Console.ReadLine().ToLower();
      }

      WriteLog();
      Console.WriteLine("Finished press enter to exit");
      Console.ReadLine();
    }

    public static bool DidAiWin(Choice playerChoice, Choice aiChoice)
    {
      PreviousChoices += (int)playerChoice;

      if (playerChoice == aiChoice)
      {
        Console.WriteLine(string.Format("You picked {0}, AI picked {1}, it's a draw", playerChoice, aiChoice));
        return false;
      }

      if (playerChoice > aiChoice && !(playerChoice == Choice.scissors && aiChoice == Choice.rock))
      {
        Console.WriteLine(string.Format("You picked {0}, AI picked {1}, you won", playerChoice, aiChoice));
        return false;
      }

      Console.WriteLine(string.Format("You picked {0}, AI picked {1}, you lost.", playerChoice, aiChoice));
      return true;
    }

    public static Choice GetWinner(Choice probablePlayerChoice)
    {
      if (probablePlayerChoice == Choice.scissors)
      {
        return Choice.rock;
      }

      return probablePlayerChoice + 1;
    }

    public static Choice GetAiChoice()
    {
      if (PreviousChoices.Count() <= 2)
      {
        return Choice.rock;
      }

      //Find what the player choose last, and then figure out what they usually chose next
      Dictionary<Choice, int> choiceCount = new Dictionary<Choice, int>();
      choiceCount.Add(Choice.paper, 0);
      choiceCount.Add(Choice.rock, 0);
      choiceCount.Add(Choice.scissors, 0);
      char lastChoice = PreviousChoices[PreviousChoices.Length - 1];
      for (int index = PreviousChoices.Count() - 2; index >= 0; index--)
      {
        if (PreviousChoices[index] == lastChoice)
        {
          switch ((Choice)(int.Parse(PreviousChoices[index + 1].ToString())))
          {
            case Choice.rock:
              choiceCount[Choice.rock]++;
              break;
            case Choice.paper:
              choiceCount[Choice.paper]++;
              break;
            case Choice.scissors:
              choiceCount[Choice.scissors]++;
              break;
          }
        }
      }

      return GetWinner(choiceCount.First(choice => choice.Value == choiceCount.Values.Max()).Key);
    }

    public static void ReadLog()
    {
      if (new FileInfo("History.txt").Exists)
      {
        StreamReader streamReader = new StreamReader("History.txt");
        PreviousChoices = streamReader.ReadToEnd();
        streamReader.Close();
      }
    }

    public static void WriteLog()
    {
      StreamWriter streamWriter = new StreamWriter("History.txt");
      streamWriter.Write(PreviousChoices);
      streamWriter.Flush();
      streamWriter.Close();
    }
  }
}
