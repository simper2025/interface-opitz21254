using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Fractional
{
    public class RationalNumber : IEquatable<RationalNumber>, IComparable<RationalNumber>
    {
        int numerator;
        int denominator;

        public RationalNumber(int num, int denom)
        {
            numerator = num;
            denominator = denom;

            var gcd = GreatestCommonDenominator(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
        }

        public override string ToString()
        {
            return numerator + "/" + denominator;
        }

        public bool Equals(RationalNumber? other)
        {
            if (other == null) return false;
            return numerator == other.numerator && denominator == other.denominator;
        }

        public int CompareTo(RationalNumber? other)
        {
            if (other == null) return 1;
            int left = numerator * other.denominator;
            int right = other.numerator * denominator;
            return left.CompareTo(right);
        }

        public override bool Equals(object? obj) => Equals(obj as RationalNumber);

        public override int GetHashCode() => HashCode.Combine(numerator, denominator);

        static int GreatestCommonDenominator(int a, int b)
        {
            if (b == 0)
                return Math.Abs(a);
            else
                return GreatestCommonDenominator(b, a % b);
        }
    }
}
