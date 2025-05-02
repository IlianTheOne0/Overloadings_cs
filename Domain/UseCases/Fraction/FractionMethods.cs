namespace ClassLibrary.Fraction;
using ClassLibrary.Fraction.Interface;

public partial class Fraction
{
    private static int _GCD(int a, int b)
    {
        while (b != 0) { int temp = b; b = a % b; a = temp; }
        return a;
    }

    private static void check(IFraction fraction) { if (fraction == null) { throw new ArgumentNullException("The fraction to add cannot be null."); } }

    public static IFraction add(IFraction left, IFraction right)
    {
        check(left); check(right);

        int newNumerator = (((Fraction)left).numerator * ((Fraction)right)._denominator) + (((Fraction)right).numerator * ((Fraction)left)._denominator);
        int newDenominator = ((Fraction)left)._denominator * ((Fraction)right)._denominator;
        
        return new Fraction(newNumerator, newDenominator);
    }

    public static IFraction subtract(IFraction left, IFraction right)
    {
        check(left); check(right);

        int newNumerator = (((Fraction)left).numerator * ((Fraction)right)._denominator) - (((Fraction)right).numerator * ((Fraction)left)._denominator);
        int newDenominator = ((Fraction)left)._denominator * ((Fraction)right)._denominator;

        return new Fraction(newNumerator, newDenominator);
    }

    public static IFraction multiply(IFraction left, IFraction right)
    {
        check(left); check(right);

        int newNumerator = ((Fraction)left).numerator * ((Fraction)right).numerator;
        int newDenominator = ((Fraction)left)._denominator * ((Fraction)right)._denominator;

        return new Fraction(newNumerator, newDenominator);
    }

    public static IFraction divide(IFraction left, IFraction right)
    {
        check(left); check(right);
        if (((Fraction)right).numerator == 0) { throw new DivideByZeroException("Cannot divide by a fraction with a numerator of zero."); }

        int newNumerator = ((Fraction)left).numerator * ((Fraction)right)._denominator;
        int newDenominator = ((Fraction)left)._denominator * ((Fraction)right).numerator;

        return new Fraction(newNumerator, newDenominator);
    }

    public static int compareTo(IFraction left, IFraction right)
    {
        check(left); check(right);

        int leftValue = ((Fraction)left).numerator / ((Fraction)left)._denominator;
        int rightValue = ((Fraction)right).numerator / ((Fraction)right)._denominator;

        return leftValue.CompareTo(rightValue);
    }
}