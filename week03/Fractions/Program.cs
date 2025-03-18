using System;
public class Fraction
{
    // Attributes for the top (numerator) and bottom (denominator)
    private int numerator; // top
    private int denominator; // bottom

    // Constructor to initialize the numerator and denominator
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        this.numerator = numerator; // top
        this.denominator = denominator; // bottom
    }

    // Getters and Setters for numerator and denominator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    public int Denominator
    {
        get { return denominator; }
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            denominator = value;
        }
    }

    // Method to represent the fraction as a string
    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to get the decimal representation of the fraction
    public double ToDecimal()
    {
        return (double)numerator / denominator;
    }
}
class Program
{
    static void Main()
    {
        // Creating a fraction
        Fraction fraction = new Fraction(3, 4);
        Console.WriteLine($"Fraction: {fraction}");  // Output: Fraction: 3/4
        Console.WriteLine($"Decimal: {fraction.ToDecimal()}");  // Output: Decimal: 0.75

        // Setting new values for the fraction
        fraction.Numerator = 5;
        fraction.Denominator = 8;
        Console.WriteLine($"Updated Fraction: {fraction}");  // Output: Updated Fraction: 5/8
        Console.WriteLine($"Updated Decimal: {fraction.ToDecimal()}");  // Output: Updated Decimal: 0.625
    }
}
