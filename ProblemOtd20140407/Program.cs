namespace ProblemOtd20140407
{
  using System;

  /// <summary>
  /// Smiley Face / http://www.problemotd.com/problem/smiley-face/
  //Welcome back to another exciting week of Problem of the Day :)
  //Since Mondays are all about smiles we're going to make something that checks for them in a string. The goal for today will be to take in a string and return true or false if the parentheses in the string are closed properly (same number of opening and closing () not including smiley faces).
  //For instance:
  //#True
  //Today (Monday) is a day all about smiles ( :) )
  //#False
  //Weirdly formatted (strings (sometimes :) aren't easy :)) to read))
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      string checkString = "Today (Monday) is a day all about smiles ( :) )";
      Console.WriteLine(checkString);
      Console.WriteLine(CheckParens(checkString));
      checkString = "Weirdly formatted (strings (sometimes :) aren't easy :)) to read))";
      Console.WriteLine(checkString);
      Console.WriteLine(CheckParens(checkString));
      checkString = "Sometimes parenthesis ) may be in the wrong order ( those should fail too :).";
      Console.WriteLine(checkString);
      Console.WriteLine(CheckParens(checkString));

      Console.WriteLine("Finished, press enter to exit");
      Console.ReadLine();
    }

    public static bool CheckParens(string checkString)
    {
      int parenCount = 0;

      checkString = checkString.Replace(":)", "");
      foreach (char c in checkString)
      {
        if (c == '(')
        {
          parenCount++;
        }

        if (c == ')')
        {
          parenCount--;
          if (parenCount < 0)
          { // We have a close paren before an opening
            return false;
          }
        }
      }

      return parenCount == 0;
    }
  }
}
