using System;
using System.Collections.Generic;

abstract class Activity
{
    // Shared attributes
    private DateTime activityDate;
    private int durationMinutes;

    public Activity(DateTime date, int minutes)
    {
        activityDate = date;
        durationMinutes = minutes;
    }

    public DateTime ActivityDate => activityDate;
    public int DurationMinutes => durationMinutes;

    // Abstract methods for derived classes to implement
    public abstract double GetDistance();  // Returns distance
    public abstract double GetSpeed();     // Returns speed (mph or kph)
    public abstract double GetPace();      // Returns pace (min per mile or min per km)

    // Method to get the summary of the activity
    public virtual string GetSummary()
    {
        return $"{ActivityDate:dd MMM yyyy} {this.GetType().Name} ({DurationMinutes} min) - " +
               $"Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}