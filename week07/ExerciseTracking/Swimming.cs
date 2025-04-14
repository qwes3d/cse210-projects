using System;
using System.Collections.Generic;


class Swimming : Activity
{
    private int laps;  // Laps in the pool

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance() => (laps * 50) / 1000.0;  // Distance in km (50 meters per lap)

    public override double GetSpeed() => (GetDistance() / DurationMinutes) * 60;  // Speed in kph

    public override double GetPace() => DurationMinutes / GetDistance();  // Pace in min per km
}
