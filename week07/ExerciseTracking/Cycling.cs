using System;
using System.Collections.Generic;


class Cycling : Activity
{
    private double speed;  // Speed in mph

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * DurationMinutes) / 60;  // Distance in miles

    public override double GetSpeed() => speed;  // Return the speed in mph

    public override double GetPace() => 60 / speed;  // Pace in min per mile
}
