namespace ClassLibrary.Fraction;
using ClassLibrary.Fraction.Interface;

public partial class Fraction : IFraction
{
    public int numerator { get; set; } = 0;

    private int _denominator = 1;

    public int denominator { get => _denominator; set => _denominator = value == 0 ? 1 : value; }

    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    public Fraction(Fraction? other)
    {
        if (other == null) { throw new ArgumentNullException(nameof(other), "The fraction cannot be null."); }

        this.numerator = other.numerator;
        this._denominator = other._denominator;
    }

    public string simplify()
    {
        int gcd = _GCD(numerator, _denominator);

        numerator /= gcd;
        _denominator /= gcd;

        return getFraction();
    }

    public string getFraction() => $"{numerator} / {_denominator}";
    public double toDouble() => (double)(numerator / _denominator);
}
