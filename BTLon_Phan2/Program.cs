using System;
using System.Collections.Generic;

public class Activity
{
    public int StartTime { get; set; }
    public int EndTime { get; set; }
}

public class Program
{
    public static List<int> GreedyActivitySelector(List<Activity> activities)
    {
        List<int> selectedActivities = new List<int>();
        activities.Sort((a, b) => a.EndTime.CompareTo(b.EndTime));

        selectedActivities.Add(0);
        int prevEnd = activities[0].EndTime;

        for (int i = 1; i < activities.Count; i++)
        {
            if (activities[i].StartTime >= prevEnd)
            {
                selectedActivities.Add(i);
                prevEnd = activities[i].EndTime;
            }
        }

        return selectedActivities;
    }

    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Activity { StartTime = 1, EndTime = 4 },
            new Activity { StartTime = 3, EndTime = 5 },
            new Activity { StartTime = 0, EndTime = 6 },
            new Activity { StartTime = 5, EndTime = 7 },
            new Activity { StartTime = 3, EndTime = 9 },
            new Activity { StartTime = 5, EndTime = 9 },
            new Activity { StartTime = 6, EndTime = 10 },
            new Activity { StartTime = 8, EndTime = 11 },
            new Activity { StartTime = 8, EndTime = 12 },
            new Activity { StartTime = 2, EndTime = 14 },
            new Activity { StartTime = 12, EndTime = 16 }
        };

        List<int> selectedActivities = GreedyActivitySelector(activities);

        Console.WriteLine("Selected activities:");
        foreach (int index in selectedActivities)
        {
            Console.WriteLine($"Activity {index}");
        }
        Console.ReadKey();
    }
}