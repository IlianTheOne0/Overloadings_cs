namespace ClassLibrary.Fraction;
using ClassLibrary.Fraction.Interface;

public partial class Fraction
{
    public static IFraction operator +(Fraction left, Fraction right) => add(left, right);
    public static IFraction operator -(Fraction left, Fraction right) => subtract(left, right);
    public static IFraction operator *(Fraction left, Fraction right) => multiply(left, right);
    public static IFraction operator /(Fraction left, Fraction right) => divide(left, right);

    public static bool operator ==(Fraction? left, Fraction? right)
    {
        if (left is null && right is null) { return true; }
        if (left is null || right is null) { return false; }
        return left.Equals(right);
    }

    public static bool operator !=(Fraction? left, Fraction? right) => !(left == right);

    public override bool Equals(object? obj)
    {
        if (obj is Fraction other) { return this.numerator * other._denominator == this._denominator * other.numerator; }
        return false;
    }

    public override int GetHashCode() => HashCode.Combine(numerator, _denominator);
}