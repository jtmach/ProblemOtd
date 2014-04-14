namespace ProblemOtd20140403
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// Work Schedule / http://www.problemotd.com/problem/work-schedule/
  //Our side project is doing well and we need to hire a few security guards to keep our sweet new office space secure. It won't take more than one to secure the office. Instead of juggling schedule requests for this position you write a program to handle it for you. Below are the names of the security guards and their requested schedules for tomorrow. Write a program so that one security guard is always on duty. Feel free to adjust the input format as needed since this is your program after all.
  //Jack: ['0000-200', 500-1200]
  //Jackie: ['0000-600', '800-1300']
  //Marty: ['400-600', '1100-1600', '1700-2359']
  //Ronald: ['600-1200', '1300-1800', '1900-2359']
  //Ke$ha: ['1600-2359']
  //Tim: ['500-1200', '1530-1900', '2000-2300']
  //Snoo: ['700-900']
  //Some peoples shift may need to be cut short or start early but the times listed are the only hours they can work between (minimum 59min work shift).
  //For some fun bonus challenges optimize so that the most amount of people can work or the fewest amount of people can work.
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      List<Worker> workers = LoadWorkers();

      DateTime dayFilledUntil = new DateTime(2014, 4, 4, 0, 0, 0);
      while (dayFilledUntil < new DateTime(2014, 4, 4, 23, 59, 0))
      {
        Schedule schedule = GetAvailableWorker(workers, dayFilledUntil);
        if (schedule == null)
        {
          Console.WriteLine("No workers available for shift starting at " + dayFilledUntil.Hour.ToString("00") + ":" + dayFilledUntil.Minute.ToString("00"));
          break;
        }

        dayFilledUntil = schedule.EndTime;
        Console.WriteLine(string.Format("{0} scheduled from {1}:{2} to {3}:{4}", schedule.AvailableWorker.Name, schedule.StartTime.Hour.ToString("00"), schedule.StartTime.Minute.ToString("00"), schedule.EndTime.Hour.ToString("00"), schedule.EndTime.Minute.ToString("00")));
      }

      Console.WriteLine("Finished press enter to exit");
      Console.ReadLine();
    }

    private static Schedule GetAvailableWorker(List<Worker> workers, DateTime startTime)
    {
      List<Schedule> availableWorkers = new List<Schedule>();
      foreach (Worker worker in workers)
      {
        //Find workers that are availble to work at the starttime
        foreach (Worker.AvailableHours hours in worker.AvailableSchedule.Where(availSched => availSched.AvailableStart <= startTime))
        {
          Schedule schedule = new Schedule(worker, hours);
          schedule.StartTime = startTime;
          schedule.EndTime = hours.AvailableEnd;
          availableWorkers.Add(schedule);
        }
      }

      // Prefer workers that can work the longest
      Schedule longestAvailableWorker = availableWorkers.OrderBy(wrkr => wrkr.StartTime - wrkr.EndTime).FirstOrDefault();
      return longestAvailableWorker;
    }

    private static List<Worker> LoadWorkers()
    {
      Worker jack = new Worker("Jack");
      jack.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014,4,4,0,0,0),new DateTime(2014,4,4,2,0,0)));
      jack.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014,4,4,5,0,0),new DateTime(2014,4,4,12,0,0)));
      Worker jackie = new Worker("Jackie");
      jackie.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014,4,4,0,0,0),new DateTime(2014,4,4,6,0,0)));
      jackie.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014,4,4,8,0,0),new DateTime(2014,4,4,13,0,0)));
      Worker marty = new Worker("Marty");
      marty.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014,4,4,4,0,0),new DateTime(2014,4,4,6,0,0)));
      marty.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014,4,4,11,0,0),new DateTime(2014,4,4,16,0,0)));
      marty.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014,4,4,17,0,0),new DateTime(2014,4,4,23,59,0)));
      Worker ronald = new Worker("Ronald");
      ronald.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014,4,4,6,0,0),new DateTime(2014,4,4,12,0,0)));
      ronald.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014,4,4,13,0,0),new DateTime(2014,4,4,18,0,0)));
      ronald.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014,4,4,19,0,0),new DateTime(2014,4,4,23,59,0)));
      Worker kesha = new Worker("Ke$ha");
      kesha.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014,4,4,16,0,0), new DateTime(2014,4,4,23,59,0)));
      Worker tim = new Worker("Tim");
      tim.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014, 4, 4, 5, 0, 0), new DateTime(2014, 4, 4, 12, 0, 0)));
      tim.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014, 4, 4, 15, 30, 0), new DateTime(2014, 4, 4, 19, 0, 0)));
      tim.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014, 4, 4, 20, 0, 0), new DateTime(2014, 4, 4, 23, 0, 0)));
      Worker snoo = new Worker("Snoo");
      snoo.AvailableSchedule.Add(new Worker.AvailableHours(new DateTime(2014, 4, 4, 7, 0, 0), new DateTime(2014, 4, 4, 9, 0, 0)));

      List<Worker> workers = new List<Worker>();
      workers.Add(jack);
      workers.Add(jackie);
      workers.Add(marty);
      workers.Add(ronald);
      workers.Add(kesha);
      workers.Add(tim);
      workers.Add(snoo);

      return workers;
    }

    private class Schedule
    {
      public Schedule(Worker worker, Worker.AvailableHours availableHours)
      {
        this.AvailableHours = availableHours;
        this.AvailableWorker = worker;
      }

      public Worker AvailableWorker { get; private set; }
      public Worker.AvailableHours AvailableHours { get; private set; }
      public DateTime StartTime { get; set; }
      public DateTime EndTime { get; set; }
    }

    private class Worker
    {
      public Worker(string name)
      {
        this.AvailableSchedule = new List<AvailableHours>();
        this.Name = name;
      }

      public List<AvailableHours> AvailableSchedule { get; private set; }
      public string Name { get; private set; }

      public class AvailableHours
      {
        public AvailableHours(DateTime availableStart, DateTime availableEnd)
        {
          this.AvailableStart = availableStart;
          this.AvailableEnd = availableEnd;
        }

        public DateTime AvailableStart { get; private set; }
        public DateTime AvailableEnd { get; private set; }
        public TimeSpan ShiftLength
        {
          get
          {
            return AvailableStart - AvailableEnd;
          }
        }
      }
    }
  }
}
