using System;
using System.Collections.Generic;


class Running : Activity
{
    private double distance;  // Distance in miles

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;

    public override double GetSpeed() => (distance / DurationMinutes) * 60;  // Speed in mph

    public override double GetPace() => DurationMinutes / distance;  // Pace in min per mile
}

