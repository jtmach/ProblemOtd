namespace ProblemOtd20140414
{
  using System;
  using System.Collections;

  /// <summary>
  /// Stacks && Queues / Permalink: http://problemotd.com/problem/stacks-queues/
  //Glad you're back for another great week!
  //Today's problem is about combining two common data structures in to one. Your goal is to implement a data structure that can pop and push like a stack and also dequeue and enqueue like a queue. Here is an example of how your data structure should work.
  //store.push(5)
  //> [5]
  //store.enqueue(6)
  //> [5,6]
  //store.push(7)
  //> [7,5,6]
  //store.pop()
  //> 7
  //store.dequeue()
  //> 5
  //Note: pop and dequeue will essentially do the same thing since they always pull from the front of the line. As always, bonus points for efficiency!
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      Quack quack = new Quack();
      quack.Push(5);
      quack.Print();
      quack.Enqueue(6);
      quack.Print();
      quack.Push(7);
      quack.Print();
      Console.WriteLine(quack.Pop());
      quack.Print();
      Console.WriteLine(quack.Dequeue());
      quack.Print();

      Quack2 quack2 = new Quack2();
      quack2.Push(5);
      quack2.Print();
      quack2.Enqueue(6);
      quack2.Print();
      quack2.Push(7);
      quack2.Print();
      Console.WriteLine(quack2.Pop());
      quack2.Print();
      Console.WriteLine(quack2.Dequeue());
      quack2.Print();

      Console.WriteLine("Finished, press enter to exit");
      Console.ReadLine();
    }
  }

  public class Quack2 : Stack
  {
    public int Dequeue()
    {
      return int.Parse(this.Pop().ToString());
    }

    public void Enqueue(int number)
    {
      Array tempArray = this.ToArray();
      this.Clear();
      this.Push(number);
      foreach (object obj in tempArray)
      {
        this.Push(obj);
      }
    }

    public void Print()
    {
      foreach (int number in this.ToArray())
      {
        Console.Write(number + ",");
      }
      Console.WriteLine();
    }
  }

  public class Quack
  {
    private string quack;

    public int Dequeue()
    {
      return this.Pop();
    }

    public void Enqueue(int number)
    {
      quack = quack + number + ",";
    }

    public int Pop()
    {
      if (quack.Length == 0)
      {
        throw new Exception("The Quack does not contain any entries");
      }

      int pos = quack.IndexOf(",");

      if (pos == 0)
      {
        throw new Exception("The Quack does not contain valid entries");
      }

      int number = int.Parse(quack.Substring(0, pos));
      quack = quack.Substring(pos + 1);
      
      return number;
    }

    public void Print()
    {
      Console.WriteLine(quack);
    }

    public void Push(int number)
    {
      quack = number + "," + quack;
    }
  }
}
