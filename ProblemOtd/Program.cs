namespace ProblemOtd20140401
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  //Load Balancer / http://www.problemotd.com/problem/load-balancer/
  //That one side project you've been working on for years has finally taken off and now you need to think about load balancing. To handle the additional load you scale from 1 to 4 servers. Your servers have different specs so they can each handle a different amount of requests. You realize you need some load balancing software to handle this so you set off to build some.
  //Server 1: 357 requests
  //Server 2: 651 requests
  //Server 3: 101 requests
  //Server 4: 230 requests
  //Requests always fill based on which server is most empty (current requests/total capacity). You can decide how to handle ties. Unfortunately, since today is April Fool's Day, someone introduced a bug into your code which is causing an issue with removing requests from each servers' queue. A request is removed from a random server after every 10 requests made to the load balencer. Eventually you won't be able to handle all the traffic you're getting and when this happens simply print out "Happy April Fools" and you're done.
  class Program
  {
    private static List<WebServer> WebServers = new List<WebServer>();
    private static long RequestsAdded;

    static void Main(string[] args)
    {
      WebServers.Add(new WebServer(357));
      WebServers.Add(new WebServer(651));
      WebServers.Add(new WebServer(101));
      WebServers.Add(new WebServer(230));

      try
      {
        while (1 == 1)
        {
          AddRequest();
          RequestsAdded++;

          if (RequestsAdded > 1 && (RequestsAdded - 1) % 10 == 0)
          {
            Random random = new Random();
            List<WebServer> usedWebServers = WebServers.Where(server => server.Usage > 0).ToList();
            usedWebServers[random.Next(0, usedWebServers.Count() - 1)].RemoveRequest();
          }

          PrintStatus();
        }
      }
      catch
      {
        Console.WriteLine("Happy April Fools");
      }

      Console.WriteLine("Finished press enter to exit");
      Console.ReadLine();
    }

    private static void AddRequest()
    {
      double minUsage = WebServers.Min(server => server.Usage);
      WebServer webServer = WebServers.First(server => server.Usage == minUsage);
      webServer.AddRequest();
    }

    private static void PrintStatus()
    {
      foreach (WebServer webServer in WebServers)
      {
        Console.WriteLine(string.Format("{0} / {1}", webServer.CurrentRequests, webServer.MaxRequests));
      }

      Console.WriteLine();
    }

    private class WebServer
    {
      public WebServer(int maxRequests)
      {
        this.MaxRequests = maxRequests;
      }

      public double CurrentRequests { get; private set; }
      public double MaxRequests { get; private set; }
      public double Usage
      {
        get
        {
          return CurrentRequests / MaxRequests;
        }
      }

      public void AddRequest()
      {
        if (this.CurrentRequests + 1 > this.MaxRequests)
        {
          throw new Exception("Server Full, can't take any more requests");
        }

        this.CurrentRequests++;
      }

      public void RemoveRequest()
      {
        if (CurrentRequests <= 0)
        {
          throw new Exception("Server doesn't have any requests to remove");
        }

        this.CurrentRequests--;
      }
    }
  }
}
