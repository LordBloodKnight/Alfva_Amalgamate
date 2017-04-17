using System.Runtime.InteropServices;
using System;
using AlfvaAmalgamate.MathExtends;

/// <summary>
/// Holds general collection useable for float based data types.
/// </summary>
namespace AlfvaAmalgamate.Floats
{
    /// <summary>
    /// Holds extensions for float based data types.
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// Are the machine constants not ready to use?
        /// </summary>
        private static bool _NotCalculatedMachineConstants = true;

        /// <summary>
        /// Calcualates the Machine constants for all float based types.
        /// </summary>
        private static void CalculateMachineConstants()
        {
            // Calcuate MachineEpsilonF
            {
                float nextEpsilon = _MachineEpsilonF;
                while (nextEpsilon > 0F)
                {
                    _MachineEpsilonF = nextEpsilon;
                    nextEpsilon /= 2F;
                }
            }
            // Calculate MaxBeforeInfinityF and MinBeforeInfinityF
            {
                // Max
                float nextBeforeInfinity = _MachineMaxBeforeInfinityF;
                float previousBeforeInfinity = 0F;
                while (!float.IsNaN(nextBeforeInfinity) && !float.IsInfinity(nextBeforeInfinity) && nextBeforeInfinity > previousBeforeInfinity)
                {
                    if (nextBeforeInfinity * 2F > previousBeforeInfinity * 2F)
                    {
                        _MachineMaxBeforeInfinityF = nextBeforeInfinity;
                    }
                    previousBeforeInfinity = nextBeforeInfinity;
                    nextBeforeInfinity *= 2F;
                }
                // Adding the mantisse to the Max
                nextBeforeInfinity = _MachineMaxBeforeInfinityF;
                while (nextBeforeInfinity >= _MachineEpsilonF)
                {
                    if (!float.IsInfinity(nextBeforeInfinity + _MachineMaxBeforeInfinityF))
                    {
                        _MachineMaxBeforeInfinityF += nextBeforeInfinity;
                        _MaschineMaxBeforeInfinityMantisseOnlyF += nextBeforeInfinity;
                    }
                    nextBeforeInfinity /= 2F;
                }
                // Min
                nextBeforeInfinity = _MachineMinBeforeInfinityF;
                previousBeforeInfinity = 0F;
                while (!float.IsNaN(nextBeforeInfinity) && !float.IsInfinity(nextBeforeInfinity) && nextBeforeInfinity < previousBeforeInfinity)
                {
                    if (nextBeforeInfinity * 2F < previousBeforeInfinity * 2F)
                    {
                        _MachineMinBeforeInfinityF = nextBeforeInfinity;
                    }
                    previousBeforeInfinity = nextBeforeInfinity;
                    nextBeforeInfinity *= 2F;
                }
                nextBeforeInfinity = _MachineMinBeforeInfinityF;
                while (nextBeforeInfinity <= -_MachineEpsilonF)
                {
                    if (!float.IsInfinity(nextBeforeInfinity + _MachineMinBeforeInfinityF))
                    {
                        _MachineMinBeforeInfinityF += nextBeforeInfinity;
                    }
                    nextBeforeInfinity /= 2F;
                }
            }
            // Calcuate MachineEpsilonD
            {
                double nextEpsilon = _MachineEpsilonF;
                while (nextEpsilon > 0D)
                {
                    _MachineEpsilonD = nextEpsilon;
                    nextEpsilon /= 2D;
                }
            }
            // Calculate MaxBeforeInfinityD and MinBeforeInfinityD
            {
                // Max
                double nextBeforeInfinity = _MachineMaxBeforeInfinityD;
                double previousBeforeInfinity = 0D;
                while (!double.IsNaN(nextBeforeInfinity) && !double.IsInfinity(nextBeforeInfinity) && nextBeforeInfinity > previousBeforeInfinity)
                {
                    if (nextBeforeInfinity * 2D > previousBeforeInfinity * 2D)
                    {
                        _MachineMaxBeforeInfinityD = nextBeforeInfinity;
                    }
                    previousBeforeInfinity = nextBeforeInfinity;
                    nextBeforeInfinity *= 2D;
                }
                // Adding the mantisse to the Max
                nextBeforeInfinity = _MachineMaxBeforeInfinityD;
                while (nextBeforeInfinity >= _MachineEpsilonF)
                {
                    if (!double.IsInfinity(nextBeforeInfinity + _MachineMaxBeforeInfinityD))
                    {
                        _MachineMaxBeforeInfinityD += nextBeforeInfinity;
                        _MaschineMaxBeforeInfinityMantisseOnlyD += nextBeforeInfinity;
                    }
                    nextBeforeInfinity /= 2D;
                }
                // Min
                nextBeforeInfinity = _MachineMinBeforeInfinityD;
                previousBeforeInfinity = 0D;
                while (!double.IsNaN(nextBeforeInfinity) && !double.IsInfinity(nextBeforeInfinity) && nextBeforeInfinity < previousBeforeInfinity)
                {
                    if (nextBeforeInfinity * 2D < previousBeforeInfinity * 2D)
                    {
                        _MachineMinBeforeInfinityD = nextBeforeInfinity;
                    }
                    previousBeforeInfinity = nextBeforeInfinity;
                    nextBeforeInfinity *= 2D;
                }
                nextBeforeInfinity = _MachineMinBeforeInfinityD;
                while (nextBeforeInfinity <= -_MachineEpsilonF)
                {
                    if (!double.IsInfinity(nextBeforeInfinity + _MachineMinBeforeInfinityD))
                    {
                        _MachineMinBeforeInfinityD += nextBeforeInfinity;
                    }
                    nextBeforeInfinity /= 2D;
                }
            }
            _NotCalculatedMachineConstants = false;
        }

        /// <summary>
        /// This is the Machine <see cref="float.Epsilon"/>.<para />
        /// This may be different to <see cref="float.Epsilon"/> depending one the Machine!<para />
        /// It gets initalized once by calling the get <see cref="MachineEpsilonF"/> accessor!
        /// </summary>
        private static float _MachineEpsilonF = 1F;
        /// <summary>
        /// Gets the Machine epsilon for <see cref="float"/>'s.
        /// </summary>
        /// <value><see cref="_MachineEpsilonF"/></value>
        /// <remarks>The first call is very slow so you should call it directly after system start!</remarks>
        public static float MachineEpsilonF
        {
            get
            {
                if (_NotCalculatedMachineConstants)
                {
                    CalculateMachineConstants();
                }
                return _MachineEpsilonF;
            }
        }

        /// <summary>
        /// This is the Machine <see cref="double.Epsilon"/>.<para />
        /// This may be different to <see cref="double.Epsilon"/> depending one the Machine!<para />
        /// It gets initalized once by calling the get <see cref="MachineEpsilonD"/> accessor!
        /// </summary>
        private static double _MachineEpsilonD = 1D;
        /// <summary>
        /// Gets the Machine epsilon for <see cref="double"/>'s.
        /// </summary>
        /// <value><see cref="_MachineEpsilonD"/></value>
        /// <remarks>The first call is very slow so you should call it directly after system start!</remarks>
        public static double MachineEpsilonD
        {
            get
            {
                if (_NotCalculatedMachineConstants)
                {
                    CalculateMachineConstants();
                }
                return _MachineEpsilonD;
            }
        }

        /// <summary>
        /// This is the Machine <see cref="float.MaxValue"/>.<para />
        /// This may be different to <see cref="float.MaxValue"/> depending one the Machine!<para />
        /// It gets initalized once by calling the get <see cref="MachineMaxBeforeInfinityF"/> accessor!
        /// </summary>
        private static float _MachineMaxBeforeInfinityF = 1F;
        /// <summary>
        /// Gets the Machine <see cref="float.MaxValue"/> value before it gets infitely.
        /// </summary>
        /// <value><see cref="_MachineMaxBeforeInfinityF"/></value>
        /// <remarks>The first call is very slow so you should call it directly after system start!</remarks>
        public static float MachineMaxBeforeInfinityF
        {
            get
            {
                if (_NotCalculatedMachineConstants)
                {
                    CalculateMachineConstants();
                }
                return _MachineMaxBeforeInfinityF;
            }
        }

        /// <summary>
        /// This is the Machine <see cref="float.MaxValue"/> the mantisse part only.<para />
        /// This may be different to <see cref="float.MaxValue"/> the mantisse part only is depending one the Machine!<para />
        /// It gets initalized once by calling the get <see cref="MaschineMaxBeforeInfinityMantisseOnlyF"/> accessor!
        /// </summary>
        private static float _MaschineMaxBeforeInfinityMantisseOnlyF = 0F;
        /// <summary>
        /// Gets the Machine <see cref="float.MaxValue"/> the mantisse part only value before it gets infitely.
        /// </summary>
        /// <value><see cref="_MachineMaxBeforeInfinityF"/></value>
        /// <remarks>The first call is very slow so you should call it directly after system start!</remarks>
        public static float MaschineMaxBeforeInfinityMantisseOnlyF
        {
            get
            {
                if (_NotCalculatedMachineConstants)
                {
                    CalculateMachineConstants();
                }
                return _MaschineMaxBeforeInfinityMantisseOnlyF;
            }
        }

        /// <summary>
        /// This is the Machine <see cref="float.MinValue"/>.<para />
        /// This may be different to <see cref="float.MinValue"/> depending one the Machine!<para />
        /// It gets initalized once by calling the get <see cref="MachineMinBeforeInfinityF"/> accessor!
        /// </summary>
        public static float _MachineMinBeforeInfinityF = -1F;
        /// <summary>
        /// Gets the Machine <see cref="float.MinValue"/> value before it gets infitely.
        /// </summary>
        /// <value><see cref="_MachineMinBeforeInfinityF"/></value>
        /// <remarks>The first call is very slow so you should call it directly after system start!</remarks>
        public static float MachineMinBeforeInfinityF
        {
            get
            {
                if (_NotCalculatedMachineConstants)
                {
                    CalculateMachineConstants();
                }
                return _MachineMinBeforeInfinityF;
            }
        }

        /// <summary>
        /// This is the Machine <see cref="double.MaxValue"/>.<para />
        /// This may be different to <see cref="double.MaxValue"/> depending one the Machine!<para />
        /// It gets initalized once by calling the get <see cref="MachineMaxBeforeInfinityD"/> accessor!
        /// </summary>
        private static double _MachineMaxBeforeInfinityD = 1D;
        /// <summary>
        /// Gets the Machine <see cref="double.MaxValue"/> value before it gets infitely.
        /// </summary>
        /// <value><see cref="_MachineMaxBeforeInfinityF"/></value>
        /// <remarks>The first call is very slow so you should call it directly after system start!</remarks>
        public static double MachineMaxBeforeInfinityD
        {
            get
            {
                if (_NotCalculatedMachineConstants)
                {
                    CalculateMachineConstants();
                }
                return _MachineMaxBeforeInfinityD;
            }
        }

        /// <summary>
        /// This is the Machine <see cref="double.MaxValue"/> the mantisse part only.<para />
        /// This may be different to <see cref="double.MaxValue"/> the mantisse part only is depending one the Machine!<para />
        /// It gets initalized once by calling the get <see cref="MaschineMaxBeforeInfinityMantisseOnlyD"/> accessor!
        /// </summary>
        private static double _MaschineMaxBeforeInfinityMantisseOnlyD = 0D;
        /// <summary>
        /// Gets the Machine <see cref="double.MaxValue"/> the mantisse part only value before it gets infitely.
        /// </summary>
        /// <value><see cref="_MachineMaxBeforeInfinityF"/></value>
        /// <remarks>The first call is very slow so you should call it directly after system start!</remarks>
        public static double MaschineMaxBeforeInfinityMantisseOnlyD
        {
            get
            {
                if (_NotCalculatedMachineConstants)
                {
                    CalculateMachineConstants();
                }
                return _MaschineMaxBeforeInfinityMantisseOnlyD;
            }
        }

        /// <summary>
        /// This is the Machine <see cref="double.MinValue"/>.<para />
        /// This may be different to <see cref="double.MinValue"/> depending one the Machine!<para />
        /// It gets initalized once by calling the get <see cref="MachineMinBeforeInfinityD"/> accessor!
        /// </summary>
        public static double _MachineMinBeforeInfinityD = -1D;
        /// <summary>
        /// Gets the Machine <see cref="double.MinValue"/> value before it gets infitely.
        /// </summary>
        /// <value><see cref="_MachineMinBeforeInfinityF"/></value>
        /// <remarks>The first call is very slow so you should call it directly after system start!</remarks>
        public static double MachineMinBeforeInfinityD
        {
            get
            {
                if (_NotCalculatedMachineConstants)
                {
                    CalculateMachineConstants();
                }
                return _MachineMinBeforeInfinityF;
            }
        }

        /// <summary>
        /// Is the given <see cref="float"/> machinaly positive infinitely?
        /// </summary>
        /// <param name="f">The <see cref="float"/> to check machinaly positive infinity for.</param>
        /// <returns>The maschimal positive infinity state of the given <see cref="float"/>.</returns>
        public static bool IsMachinePositiveInfinity(float f)
        {
            if (f > MachineMaxBeforeInfinityF)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Is the given <see cref="float"/> machinaly negative infinitely?
        /// </summary>
        /// <param name="f">The <see cref="float"/> to check machinaly negative infinity for.</param>
        /// <returns>The maschimal negative infinity state of the given <see cref="float"/>.</returns>
        public static bool IsMachineNegativeInfinity(float f)
        {
            if (f < MachineMinBeforeInfinityF)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Is the given <see cref="float"/> machinaly infinitely?
        /// </summary>
        /// <param name="f">The <see cref="float"/> to check machinaly infinity for.</param>
        /// <returns>The maschimal infinity state of the given <see cref="float"/>.</returns>
        public static bool IsMachineInfinity(float f)
        {
            if (IsMachinePositiveInfinity(f))
            {
                return true;
            }
            if (IsMachineNegativeInfinity(f))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Is the given <see cref="float"/> <see cref="float.NaN"/> or machinaly infinitely?
        /// </summary>
        /// <param name="f">The <see cref="float"/> to check <see cref="float.NaN"/> and machinaly infinity for.</param>
        /// <returns>The <see cref="float.NaN"/> and machinaly infinity state of the given <see cref="float"/>.</returns>
        public static bool IsNaNOrInfinity(float f)
        {
            if (float.IsNaN(f))
            {
                return true;
            }
            if (IsMachineInfinity(f))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Is the given <see cref="double"/> machinaly positive infinitely?
        /// </summary>
        /// <param name="d">The <see cref="double"/> to check machinaly positive infinity for.</param>
        /// <returns>The maschimal infinity state of the given <see cref="double"/>.</returns>
        public static bool IsMachinePositiveInfinity(double d)
        {
            if (d > MachineMaxBeforeInfinityD)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Is the given <see cref="double"/> machinaly negative infinitely?
        /// </summary>
        /// <param name="d">The <see cref="double"/> to check machinaly negative infinity for.</param>
        /// <returns>The maschimal infinity state of the given <see cref="double"/>.</returns>
        public static bool IsMachineNegativeInfinity(double d)
        {
            if (d < MachineMinBeforeInfinityD)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Is the given <see cref="double"/> machinaly infinitely?
        /// </summary>
        /// <param name="d">The <see cref="double"/> to check machinaly infinity for.</param>
        /// <returns>The maschimal infinity state of the given <see cref="double"/>.</returns>
        public static bool IsMachineInfinity(double d)
        {
            if (IsMachinePositiveInfinity(d))
            {
                return true;
            }
            if (IsMachineNegativeInfinity(d))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Is the given <see cref="double"/> <see cref="double.NaN"/> or machinaly infinitely?
        /// </summary>
        /// <param name="f">The <see cref="double"/> to check <see cref="double.NaN"/> and machinaly infinity for.</param>
        /// <returns>The <see cref="double.NaN"/> and machinaly infinity state of the given <see cref="double"/>.</returns>
        public static bool IsNaNOrInfinity(double d)
        {
            if (double.IsNaN(d))
            {
                return true;
            }
            if (IsMachineInfinity(d))
            {
                return true;
            }
            return false;
        }

        // For more information why this function exist try using the online float converter -> https://www.h-schmidt.net/FloatConverter/IEEE754de.html .
        /// <summary>
        /// Are both <paramref name="a"/> and <see cref="b"/> equal in the given tolerance <paramref name="kEpsilon"/>?
        /// </summary>
        /// <param name="a">The first <see cref="float"/> to check equality with.</param>
        /// <param name="b">The second <see cref="float"/> to check equality with.</param>
        /// <param name="kEpsilon">The tolerance allowed for both <see cref="float"/>'s to be accepted as equal.</param>
        /// <param name="relativeEpsilon">If true than the <paramref name="kEpsilon"/> is interpreted as percentage and gets multiplied by the largest of the given <see cref="float"/>s that are getting checked for equality.</param>
        /// <param name="checkedCaclulation">If true exceptions are allowed.</param>
        /// <remarks>If <paramref name="kEpsilon"/> is smaller/equal 0F the <see cref="MachineEpsilonF"/> gets used instead!</remarks>
        /// <returns>True if the are equal in the given toleracne else false.</returns>
        /// <exception cref="ArithmeticException">The given <paramref name="kEpsilon"/> is <see cref="float.IsNaN(float)"/> and therefore unuseable as a tolerance value!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given <paramref name="kEpsilon"/> is <see cref="float.IsInfinity(float)"/> and therefore unuseable as a toleracne value!</exception>
        public static bool Approximately(float a, float b, float kEpsilon = -1F, bool relativeEpsilon = false, bool checkedCaclulation = false)
        {
            bool result = false;
            // If both float's have one of the stats equal they are equal!
            if (float.IsNaN(a) && float.IsNaN(b) || IsMachineNegativeInfinity(a) == IsMachineNegativeInfinity(b) || IsMachinePositiveInfinity(a) == IsMachinePositiveInfinity(b))
            {
                result = true;
            }
            else if (!(float.IsNaN(a) || float.IsNaN(b)))
            {
                if (checkedCaclulation)
                {
                    if (float.IsNaN(kEpsilon))
                    {
                        throw new ArithmeticException("The given kEpsilon is Not a Number and therefore unuseable as a tolerance value!");
                    }
                    if (IsMachineInfinity(kEpsilon))
                    {
                        throw new ArgumentOutOfRangeException("The given kEpsilon is infinitely and therefore unuseable as a toleracne value!");
                    }
                }
                if (kEpsilon <= 0F)
                {
                    kEpsilon = MachineEpsilonF;
                }
                else if (relativeEpsilon && kEpsilon > 1F)
                {
                    kEpsilon = 1F;
                }
                // Parts of the source code used can be found on https://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/ by brucedawson.
                // Parts that doesn't can be found there are not from there!
                // Calculate the difference.
                float diff = Math.Abs(a - b);
                // Are both given float's equal in the given kEpsilon range?
                if (relativeEpsilon)
                {
                    a = Math.Abs(a);
                    b = Math.Abs(b);
                    // Find the largest
                    float largest;
                    if (b > a)
                    {
                        largest = b;
                    }
                    else
                    {
                        largest = a;
                    }
                    if (diff <= largest * kEpsilon)
                    {
                        result = true;
                    }
                }
                else
                {
                    if (diff <= kEpsilon)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        // For more information why this function exist try using the online float converter -> https://www.h-schmidt.net/FloatConverter/IEEE754de.html .
        /// <summary>
        /// Are both <paramref name="a"/> and <see cref="b"/> equal in the given tolerance <paramref name="kEpsilon"/>?
        /// </summary>
        /// <param name="a">The first <see cref="double"/> to check equality with.</param>
        /// <param name="b">The second <see cref="double"/> to check equality with.</param>
        /// <param name="kEpsilon">The tolerance allowed for both <see cref="double"/>'s to be accepted as equal.</param>
        /// <param name="checkedCaclulation">If true exceptions are allowed.</param>
        /// <remarks>If <paramref name="kEpsilon"/> is smaller 0F the <see cref="MachineEpsilonD"/> gets used instead!</remarks>
        /// <returns>True if the are equal in the given toleracne else false.</returns>
        /// <exception cref="ArithmeticException">The given <paramref name="kEpsilon"/> is <see cref="double.IsNaN(double)"/> and therefore unuseable as a tolerance value!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given <paramref name="kEpsilon"/> is <see cref="double.IsInfinity(double)"/> and therefore unuseable as a toleracne value!</exception>
        public static bool Approximately(double a, double b, double kEpsilon = -1F, bool relativeEpsilon = true, bool checkedCaclulation = false)
        {
            bool result = false;
            // If both float's have one of the stats equal they are equal!
            if ((double.IsNaN(a) & double.IsNaN(b)) || (IsMachineNegativeInfinity(a) & IsMachineNegativeInfinity(b)) || (IsMachinePositiveInfinity(a) & IsMachinePositiveInfinity(b)))
            {
                result = true;
            }
            else if (!(double.IsNaN(a) || double.IsNaN(b)))
            {
                if (checkedCaclulation)
                {
                    if (double.IsNaN(kEpsilon))
                    {
                        throw new ArithmeticException("The given kEpsilon is Not a Number and therefore unuseable as a tolerance value!");
                    }
                    if (IsMachineInfinity(kEpsilon))
                    {
                        throw new ArgumentOutOfRangeException("The given kEpsilon is infinitely and therefore unuseable as a toleracne value!");
                    }
                }
                if (kEpsilon < 0F)
                {
                    kEpsilon = MachineEpsilonD;
                }
                else if (relativeEpsilon && kEpsilon > 1F)
                {
                    kEpsilon = 1F;
                }
                // Source code below can be found on https://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/ by brucedawson.
                // Calculate the difference.
                double diff = Math.Abs(a - b);
                // Are both given float's equal in the given kEpsilon range?
                if (relativeEpsilon)
                {
                    a = Math.Abs(a);
                    b = Math.Abs(b);
                    // Find the largest
                    double largest;
                    if (b > a)
                    {
                        largest = b;
                    }
                    else
                    {
                        largest = a;
                    }
                    if (diff <= largest * kEpsilon)
                    {
                        result = true;
                    }
                }
                else
                {
                    if (diff <= kEpsilon)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Rounds the value specific to the wanted <see cref="RoundingType"/>.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="howToRound">How to round the value?</param>
        /// <returns>The rounded value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given <see cref="RoundingType"/> is not a valid <see cref="RoundingType"/>!</exception>
        public static float RoundSpecific(float value, RoundingType howToRound = RoundingType.Truncate)
        {
            switch (howToRound)
            {
                case RoundingType.Truncate:
                    return (float)Math.Truncate(value);
                case RoundingType.Ceiling:
                    return (float)Math.Ceiling(value);
                case RoundingType.Round:
                    return (float)Math.Round(value);
                default:
                    throw new ArgumentOutOfRangeException("The given RoundingType is not a valid RoundingType!");
            }
        }

        /// <summary>
        /// Rounds the value specific to the wanted <see cref="RoundingType"/>.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="howToRound">How to round the value?</param>
        /// <returns>The rounded value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given <see cref="RoundingType"/> is not a valid <see cref="RoundingType"/>!</exception>
        public static double RoundSpecific(double value, RoundingType howToRound = RoundingType.Truncate)
        {
            switch (howToRound)
            {
                case RoundingType.Truncate:
                    return Math.Truncate(value);
                case RoundingType.Ceiling:
                    return Math.Ceiling(value);
                case RoundingType.Round:
                    return Math.Round(value);
                default:
                    throw new ArgumentOutOfRangeException("The given RoundingType is not a valid RoundingType!");
            }
        }

        // decimal is not a float based type so I should move it into the DecimalExtensions class.
        /// <summary>
        /// Rounds the value specific to the wanted <see cref="RoundingType"/>.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="howToRound">How to round the value?</param>
        /// <returns>The rounded value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given <see cref="RoundingType"/> is not a valid <see cref="RoundingType"/>!</exception>
        public static decimal RoundSpecific(decimal value, RoundingType howToRound = RoundingType.Truncate)
        {
            switch (howToRound)
            {
                case RoundingType.Truncate:
                    return Math.Truncate(value);
                case RoundingType.Ceiling:
                    return Math.Ceiling(value);
                case RoundingType.Round:
                    return Math.Round(value);
                default:
                    throw new ArgumentOutOfRangeException("The given RoundingType is not a valid RoundingType!");
            }
        }

        /// <summary>
        /// Remaps a <see cref="float"/> from the InputRange to the OutputRange.
        /// </summary>
        /// <param name="value">The value to remap.</param>
        /// <param name="minIn">The minimal input range.</param>
        /// <param name="maxIn">The maximal input range.</param>
        /// <param name="minOut">The minimal output range.</param>
        /// <param name="maxOut">The maximal output range.</param>
        /// <param name="checkedCalculation">If true than all possible exceptions are enabled.</param>
        /// <remarks>If the input value is outside of the input range the result output is also outside of the output range!<para />
        /// The remap function is -> result = <paramref name="minOut"/> + (<paramref name="maxOut"/> - <paramref name="minOut"/>) * ((<paramref name="value"/> - <paramref name="minIn"/>) / (<paramref name="maxIn"/> - <paramref name="minIn"/>))</remarks>
        /// <returns>A remapped <see cref="float"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Remap is unable to remap with <see cref="float"/>s that are <see cref="float.NaN"/>!</exception>
        /// <exception cref="DivideByZeroException">The input range is equal 0 so the result would be infinite!</exception>
        /// <exception cref="ArithmeticException">The result is <see cref="float.NaN"/>!</exception>
        public static float Remap(float value, float minIn, float maxIn, float minOut, float maxOut, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (float.IsNaN(value) || float.IsNaN(minIn) || float.IsNaN(maxIn) || float.IsNaN(minOut) || float.IsNaN(maxOut))
                {
                    throw new ArgumentOutOfRangeException("Remap is unable to remap with floats that are Not a Number!");
                }
                if (Math.Abs(maxIn - minIn) == 0F)
                {
                    throw new DivideByZeroException("The input range is equal 0 so the result output would be infinite!");
                }
            }
            if (checkedCalculation)
            {
                float resultToCheck = minOut + (maxOut - minOut) * ((value - minIn) / (maxIn - minIn));
                if (float.IsNaN(resultToCheck))
                {
                    throw new ArithmeticException("The result is Not a Number!");
                }
                return resultToCheck;
            }
            else
            {
                return minOut + (maxOut - minOut) * ((value - minIn) / (maxIn - minIn));
            }
        }

        /// <summary>
        /// Remaps a <see cref="double"/> from the InputRange to the OutputRange.
        /// </summary>
        /// <param name="value">The value to remap.</param>
        /// <param name="minIn">The minimal input range.</param>
        /// <param name="maxIn">The maximal input range.</param>
        /// <param name="minOut">The minimal output range.</param>
        /// <param name="maxOut">The maximal output range.</param>
        /// <param name="checkedCalculation">If true than all possible exceptions are enabled.</param>
        /// <remarks>If the input value is outside of the input range the result output is also outside of the output range!<para />
        /// The remap function is -> result = <paramref name="minOut"/> + (<paramref name="maxOut"/> - <paramref name="minOut"/>) * ((<paramref name="value"/> - <paramref name="minIn"/>) / (<paramref name="maxIn"/> - <paramref name="minIn"/>))</remarks>
        /// <returns>A remapped <see cref="double"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Remap is unable to remap with <see cref="double"/>s that are <see cref="double.NaN"/>!</exception>
        /// <exception cref="DivideByZeroException">The input range is equal 0 so the result would be infinite!</exception>
        /// <exception cref="ArithmeticException">The result is <see cref="double.NaN"/>!</exception>
        public static double Remap(double value, double minIn, double maxIn, double minOut, double maxOut, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (double.IsNaN(value) || double.IsNaN(minIn) || double.IsNaN(maxIn) || double.IsNaN(minOut) || double.IsNaN(maxOut))
                {
                    throw new ArgumentOutOfRangeException("Remap is unable to remap with doubles that are Not a Number!");
                }
                if (Math.Abs(maxIn - minIn) == 0D)
                {
                    throw new DivideByZeroException("The input range is equal 0 so the result output would be infinite!");
                }
            }
            if (checkedCalculation)
            {
                double resultToCheck = minOut + (maxOut - minOut) * ((value - minIn) / (maxIn - minIn));
                if (double.IsNaN(resultToCheck))
                {
                    throw new ArithmeticException("The result is Not a Number!");
                }
                return resultToCheck;
            }
            else
            {
                return minOut + (maxOut - minOut) * ((value - minIn) / (maxIn - minIn));
            }
        }


        /// <summary>
        /// Gets a clamped version of the given <paramref name="value"/> between 0F and 1F.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <remarks>If the given <paramref name="value"/> is <see cref="float.NaN"/> than this is returned!</remarks>
        /// <returns>The clamped version of the given <paramref name="value"/>.</returns>
        public static float Clamp01(float value)
        {
            if (float.IsNaN(value))
            {
                return value;
            }
            else if (value >= 1F)
            {
                return 1F;
            }
            else if (value < MachineEpsilonF)
            {
                return 0F;
            }
            return value;
        }

        /// <summary>
        /// Gets a clamped version of the given <paramref name="value"/> between 0F and 1F.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <remarks>If the given <paramref name="value"/> is <see cref="double.NaN"/> than this is returned!</remarks>
        /// <returns>The clamped version of the given <paramref name="value"/>.</returns>
        public static double Clamp01(double value)
        {
            if (double.IsNaN(value))
            {
                return value;
            }
            else if (value >= 1F)
            {
                return 1F;
            }
            else if (value < MachineEpsilonD)
            {
                return 0F;
            }
            return value;
        }

        /// <summary>
        /// Gets a clamped version of the given <paramref name="value"/> between smallest limit and biggest limit.
        /// </summary>
        /// <param name="firstIntervalLimit">The first interval limiter.</param>
        /// <param name="secondIntervalLimit">The second interval limiter.</param>
        /// <param name="value">The value to clamp.</param>
        /// <remarks>If the given <paramref name="value"/> is <see cref="float.NaN"/> than this is returned!</remarks>
        /// <returns>The clamped version of the given <paramref name="value"/>.</returns>
        public static float Clamp(float firstIntervalLimit, float secondIntervalLimit, float value)
        {
            if (float.IsNaN(value))
            {

            }
            else if (new ComparableFloat(firstIntervalLimit).IntValue == new ComparableFloat(secondIntervalLimit).IntValue)
            {
                value = firstIntervalLimit;
            }
            else
            {
                if (!Approximately(firstIntervalLimit, secondIntervalLimit) && firstIntervalLimit > secondIntervalLimit)
                {
                    float tempExchanger = firstIntervalLimit;
                    firstIntervalLimit = secondIntervalLimit;
                    secondIntervalLimit = tempExchanger;
                }
                if (value < firstIntervalLimit)
                {
                    value = firstIntervalLimit;
                }
                else if (value > secondIntervalLimit)
                {
                    value = secondIntervalLimit;
                }
            }
            return value;
        }

        /// <summary>
        /// Gets a clamped version of the given <paramref name="value"/> between smallest limit and biggest limit.
        /// </summary>
        /// <param name="firstIntervalLimit">The first interval limiter.</param>
        /// <param name="secondIntervalLimit">The second interval limiter.</param>
        /// <param name="value">The value to clamp.</param>
        /// <remarks>If the given <paramref name="value"/> is <see cref="double.NaN"/> than this is returned!</remarks>
        /// <returns>The clamped version of the given <paramref name="value"/>.</returns>
        public static double Clamp(double firstIntervalLimit, double secondIntervalLimit, double value)
        {
            if (double.IsNaN(value))
            {

            }
            else if (new ComparableDouble(firstIntervalLimit).LongValue == new ComparableDouble(secondIntervalLimit).LongValue)
            {
                value = firstIntervalLimit;
            }
            else
            {
                if (!Approximately(firstIntervalLimit, secondIntervalLimit) && firstIntervalLimit > secondIntervalLimit)
                {
                    double tempExchanger = firstIntervalLimit;
                    firstIntervalLimit = secondIntervalLimit;
                    secondIntervalLimit = tempExchanger;
                }
                if (value < firstIntervalLimit)
                {
                    value = firstIntervalLimit;
                }
                else if (value > secondIntervalLimit)
                {
                    value = secondIntervalLimit;
                }
            }
            return value;
        }

        /// <summary>
        /// Calculates 1F - <paramref name="rhs"/>.
        /// </summary>
        /// <param name="rhs">The value that will be subtracted.</param>
        /// <returns>The one minus of the given <see cref="float"/>.</returns>
        public static float OneMinus(float rhs)
        {
            return 1F - rhs;
        }

        /// <summary>
        /// Calculates 1F - <paramref name="rhs"/>.
        /// </summary>
        /// <param name="rhs">The value that will be subtracted.</param>
        /// <returns>The one minus of the given <see cref="double"/>.</returns>
        public static double OneMinus(double rhs)
        {
            return 1D - rhs;
        }

        /// <summary>
        /// Lerps between the <paramref name="start"/> and <paramref name="end"/> at the given <paramref name="percentagePosition"/>.
        /// </summary>
        /// <param name="start">The value for the 0F percentage.</param>
        /// <param name="end">The value for the 100F percentage.</param>
        /// <param name="percentagePosition">The percentage normaly between 0F and 1F.</param>
        /// <remarks>The mathematical function is (<paramref name="start"/> * (1F - <paramref name="percentagePosition"/>)) + (<paramref name="end"/> * <paramref name="percentagePosition"/>).<para />
        /// Because of the not limited <paramref name="percentagePosition"/> this method can be usefull for other effects.</remarks>
        /// <returns>The lerped result.</returns>
        public static float Lerp(float start, float end, float percentagePosition)
        {
            return start * (OneMinus(percentagePosition)) + (end * percentagePosition);
        }

        /// <summary>
        /// More precisely <paramref name="percentagePosition"/> version of <see cref="Lerp(float, float, float)"/>.
        /// </summary>
        /// <param name="start">The value for the 0F percentage.</param>
        /// <param name="end">The value for the 100F percentage.</param>
        /// <param name="percentagePosition">The percentage normaly between 0F and 1F.</param>
        /// <remarks>The mathematical function is (<paramref name="start"/> * (1F - <paramref name="percentagePosition"/>)) + (<paramref name="end"/> * <paramref name="percentagePosition"/>).<para />
        /// Because of the not limited <paramref name="percentagePosition"/> this method can be usefull for other effects.</remarks>
        /// <returns>The lerped result.</returns>
        public static float Lerp(float start, float end, double percentagePosition)
        {
            return (float)(start * (OneMinus(percentagePosition)) + (end * percentagePosition));
        }

        /// <summary>
        /// Lerps between the <paramref name="start"/> and <paramref name="end"/> at the given <paramref name="percentagePosition"/>.
        /// </summary>
        /// <param name="start">The value for the 0F percentage.</param>
        /// <param name="end">The value for the 100F percentage.</param>
        /// <param name="percentagePosition">The percentage normaly between 0F and 1F.</param>
        /// <remarks>The mathematical function is (<paramref name="start"/> * (1F - <paramref name="percentagePosition"/>)) + (<paramref name="end"/> * <paramref name="percentagePosition"/>).<para />
        /// Because of the not limited <paramref name="percentagePosition"/> this method can be usefull for other effects.</remarks>
        /// <returns>The lerped result.</returns>
        public static double Lerp(double start, double end, double percentagePosition)
        {
            return start * (OneMinus(percentagePosition)) + (end * percentagePosition);
        }

        /// <summary>
        /// Gets the percentage used to lerp between <paramref name="start"/> and <paramref name="end"/>.
        /// </summary>
        /// <param name="start">The value one the 0F percentage.</param>
        /// <param name="end">The value one the 100F percentage.</param>
        /// <param name="lerpResult">The result of a <see cref="Lerp(float, float, float)"/>.</param>
        /// <returns>The percentage of interpolation range and result..</returns>
        public static float InverseLerp(float start, float end, float lerpResult)
        {
            float maxDistance;
            float minDistance;
            if (start < end)
            {
                maxDistance = end;
                minDistance = start;
            }
            else
            {
                maxDistance = start;
                minDistance = end;
            }
            return ((lerpResult - minDistance) / (maxDistance - minDistance));
        }

        /// <summary>
        /// Gets the percentage used to lerp between <paramref name="start"/> and <paramref name="end"/>.
        /// </summary>
        /// <param name="start">The value one the 0F percentage.</param>
        /// <param name="end">The value one the 100F percentage.</param>
        /// <param name="lerpResult">The result of a <see cref="Lerp(double, double, double)"/>.</param>
        /// <returns>The percentage of interpolation range and result..</returns>
        public static double InverseLerp(double start, double end, double lerpResult)
        {
            double maxDistance;
            double minDistance;
            if (start < end)
            {
                maxDistance = end;
                minDistance = start;
            }
            else
            {
                maxDistance = start;
                minDistance = end;
            }
            return ((lerpResult - minDistance) / (maxDistance - minDistance));
        }

        /// <summary>
        /// Constant to multiply radians with to get degrees.
        /// </summary>
        public const float RadToDegF = 57.295779513082320876798154814105F;

        /// <summary>
        /// Constant to multiply radians with to get degrees.
        /// </summary>
        public const double RadToDegD = 57.295779513082320876798154814105D;

        /// <summary>
        /// Constant to multiply degrees with to get radians.
        /// </summary>
        public const float DegToRadF = 0.01745329251994329576923690768489F;

        /// <summary>
        /// Constant to multiply degrees with to get radians.
        /// </summary>
        public const double DegToRadD = 0.01745329251994329576923690768489D;

        /// <summary>
        /// Converts the given radians/degrees to the other representation type.
        /// </summary>
        /// <param name="toConvert">The value to convert to degrees/radians.</param>
        /// <param name="returnDegOrRad">The conversation direction: <see cref="true"/> = RadToDeg; <see cref="false"/> = DegToRad .</param>
        /// <remarks>This converts the given <paramref name="toConvert"/> fast by multiplying it with the needed converter constant.</remarks>
        /// <returns>The converted value.</returns>
        public static float RadDegConverterFast(float toConvert, bool returnDegOrRad = false)
        {
            if (returnDegOrRad)
            {
                toConvert *= RadToDegF;
            }
            else
            {
                toConvert *= DegToRadF;
            }
            return toConvert;
        }

        /// <summary>
        /// Converts the given radians/degrees to the other representation type.
        /// </summary>
        /// <param name="toConvert">The value to convert to degrees/radians.</param>
        /// <param name="returnDegOrRad">The conversation direction: <see cref="true"/> = RadToDeg; <see cref="false"/> = DegToRad .</param>
        /// <remarks>This converts the given <paramref name="toConvert"/> slow by multiplying it with the needed converter value that gets calculated one need.</remarks>
        /// <returns>The converted value.</returns>
        public static float RadDegConverterSlow(float toConvert, bool returnDegOrRad = false)
        {
            if (returnDegOrRad)
            {
                toConvert *= (float)(toConvert * (180D / Math.PI));
            }
            else
            {
                toConvert *= (float)(toConvert * (Math.PI / 180D));
            }
            return toConvert;
        }

        /// <summary>
        /// Converts the given radians/degrees to the other representation type.
        /// </summary>
        /// <param name="toConvert">The value to convert to degrees/radians.</param>
        /// <param name="returnDegOrRad">The conversation direction: <see cref="true"/> = RadToDeg; <see cref="false"/> = DegToRad .</param>
        /// <remarks>This converts the given <paramref name="toConvert"/> fast by multiplying it with the needed converter constant.</remarks>
        /// <returns>The converted value.</returns>
        public static double RadDegConverterFast(double toConvert, bool returnDegOrRad = false)
        {
            if (returnDegOrRad)
            {
                toConvert *= RadToDegD;
            }
            else
            {
                toConvert *= DegToRadD;
            }
            return toConvert;
        }

        /// <summary>
        /// Converts the given radians/degrees to the other representation type.
        /// </summary>
        /// <param name="toConvert">The value to convert to degrees/radians.</param>
        /// <param name="returnDegOrRad">The conversation direction: <see cref="true"/> = RadToDeg; <see cref="false"/> = DegToRad .</param>
        /// <remarks>This converts the given <paramref name="toConvert"/> slow by multiplying it with the needed converter value that gets calculated one need.</remarks>
        /// <returns>The converted value.</returns>
        public static double RadDegConverterSlow(double toConvert, bool returnDegOrRad = false)
        {
            if (returnDegOrRad)
            {
                toConvert *= toConvert * (180D / Math.PI);
            }
            else
            {
                toConvert *= toConvert * (Math.PI / 180D);
            }
            return toConvert;
        }

        /// <summary>
        /// Gets the closest power of 2 from the <paramref name="targetValue"/>.
        /// </summary>
        /// <param name="targetValue">The target value to which it is wanted to search the nearest neighbors of power of 2.</param>
        /// <param name="exponentIterationMinimal">The minimal exponent that that is allowed has the power of 2.</param>
        /// <param name="checkedCalculation">If true exceptions can be thrown.</param>
        /// <returns>The power of 2 that is the nearest power of 2 to the <paramref name="targetValue"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given <paramref name="targetValue"/> is <see cref="float.IsInfinity(float)"/> or <see cref="float.NaN"/> and can't be near a power of 2 value!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The exponentIterationMinimal is already to high to get a valid power of 2 value!</exception>
        public static float ClosestPowerOfTwo(float targetValue, uint exponentIterationMinimal = 1, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (IsNaNOrInfinity(targetValue))
                {
                    throw new ArgumentOutOfRangeException("The given targetValue is infinitely or Not a Number and can't be near a power of 2 value!");
                }
                if (IsNaNOrInfinity(Math.Pow(2, exponentIterationMinimal)))
                {
                    throw new ArgumentOutOfRangeException("The exponentIterationMinmal is already to high to get a valid power of 2 value!");
                }
            }
            if ((Math.Pow(2D, exponentIterationMinimal) < targetValue))
            {
                while (Math.Pow(2D, exponentIterationMinimal) < targetValue)
                {
                    exponentIterationMinimal++;
                    if (IsNaNOrInfinity(Math.Pow(2D, exponentIterationMinimal)))
                    {
                        break;
                    }
                }
                double upperBoundary;
                double bottomBondary;
                if (exponentIterationMinimal < 2)
                {
                    if (exponentIterationMinimal > 0 && !Approximately(2D, targetValue, 0.5D, false))
                    {
                        exponentIterationMinimal--;
                    }
                }
                else
                {
                    upperBoundary = Math.Pow(2D, exponentIterationMinimal - 1);
                    bottomBondary = Math.Pow(2D, exponentIterationMinimal - 2);
                    if (Approximately(upperBoundary, targetValue, bottomBondary, false))
                    {
                        exponentIterationMinimal--;
                    }
                }
            }
            return (float)Math.Pow(2D, exponentIterationMinimal);
        }

        /// <summary>
        /// Gets the closest power of 2 from the <paramref name="targetValue"/>.
        /// </summary>
        /// <param name="targetValue">The target value to which it is wanted to search the nearest neighbors of power of 2.</param>
        /// <param name="exponentIterationMinimal">The minimal exponent that that is allowed has the power of 2.</param>
        /// <param name="checkedCalculation">If true exceptions can be thrown.</param>
        /// <returns>The power of 2 that is the nearest power of 2 to the <paramref name="targetValue"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given <paramref name="targetValue"/> is <see cref="double.IsInfinity(float)"/> or <see cref="double.NaN"/> and can't be near a power of 2 value!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The exponentIterationMinimal is already to high to get a valid power of 2 value!</exception>
        public static double ClosestPowerOfTwo(double targetValue, uint exponentIterationMinimal = 1, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (IsNaNOrInfinity(targetValue))
                {
                    throw new ArgumentOutOfRangeException("The given targetValue is infinitely or Not a Number and can't be near a power of 2 value!");
                }
                if (IsNaNOrInfinity(Math.Pow(2, exponentIterationMinimal)))
                {
                    throw new ArgumentOutOfRangeException("The exponentIterationMinmal is already to high to get a valid power of 2 value!");
                }
            }
            if ((Math.Pow(2D, exponentIterationMinimal) < targetValue))
            {
                while (Math.Pow(2D, exponentIterationMinimal) < targetValue)
                {
                    exponentIterationMinimal++;
                    if (IsNaNOrInfinity(Math.Pow(2D, exponentIterationMinimal)))
                    {
                        break;
                    }
                }
                double upperBoundary;
                double bottomBondary;
                if (exponentIterationMinimal < 2)
                {
                    if (exponentIterationMinimal > 0 && !Approximately(2D, targetValue, 0.5D, false))
                    {
                        exponentIterationMinimal--;
                    }
                }
                else
                {
                    upperBoundary = Math.Pow(2D, exponentIterationMinimal - 1);
                    bottomBondary = Math.Pow(2D, exponentIterationMinimal - 2);
                    if (Approximately(upperBoundary, targetValue, bottomBondary, false))
                    {
                        exponentIterationMinimal--;
                    }
                }
            }
            return Math.Pow(2D, exponentIterationMinimal);
        }

        /// <summary>
        /// Gets the closest power of 2 from the <paramref name="targetValue"/>.
        /// </summary>
        /// <param name="targetValue">The target value to which it is wanted to search the nearest neighbors of power of 2.</param>
        /// <param name="exponent">The exponent of the nearest power of 2 neighbor to the <paramref name="targetValue"/>.</param>
        /// <param name="exponentIterationMinimal">The minimal exponent that that is allowed has the power of 2.</param>
        /// <param name="checkedCalculation">If true exceptions can be thrown.</param>
        /// <returns>The power of 2 that is the nearest power of 2 to the <paramref name="targetValue"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given <paramref name="targetValue"/> is <see cref="float.IsInfinity(float)"/> or <see cref="float.NaN"/> and can't be near a power of 2 value!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The exponentIterationMinimal is already to high to get a valid power of 2 value!</exception>
        public static float ClosestPowerOfTwo(float targetValue, out uint exponent, uint exponentIterationMinimal = 1, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (IsNaNOrInfinity(targetValue))
                {
                    throw new ArgumentOutOfRangeException("The given targetValue is infinitely or Not a Number and can't be near a power of 2 value!");
                }
                if (IsNaNOrInfinity(Math.Pow(2, exponentIterationMinimal)))
                {
                    throw new ArgumentOutOfRangeException("The exponentIterationMinmal is already to high to get a valid power of 2 value!");
                }
            }
            if ((Math.Pow(2D, exponentIterationMinimal) < targetValue))
            {
                while (Math.Pow(2D, exponentIterationMinimal) < targetValue)
                {
                    exponentIterationMinimal++;
                    if (IsNaNOrInfinity(Math.Pow(2D, exponentIterationMinimal)))
                    {
                        break;
                    }
                }
                double upperBoundary;
                double bottomBondary;
                if (exponentIterationMinimal < 2)
                {
                    if (exponentIterationMinimal > 0 && !Approximately(2D, targetValue, 0.5D, false))
                    {
                        exponentIterationMinimal--;
                    }
                }
                else
                {
                    upperBoundary = Math.Pow(2D, exponentIterationMinimal - 1);
                    bottomBondary = Math.Pow(2D, exponentIterationMinimal - 2);
                    if (Approximately(upperBoundary, targetValue, bottomBondary, false))
                    {
                        exponentIterationMinimal--;
                    }
                }
            }
            exponent = exponentIterationMinimal;
            return (float)Math.Pow(2D, exponentIterationMinimal);
        }

        /// <summary>
        /// Gets the closest power of 2 from the <paramref name="targetValue"/>.
        /// </summary>
        /// <param name="targetValue">The target value to which it is wanted to search the nearest neighbors of power of 2.</param>
        /// <param name="exponent">The exponent of the nearest power of 2 neighbor to the <paramref name="targetValue"/>.</param>
        /// <param name="exponentIterationMinimal">The minimal exponent that that is allowed has the power of 2.</param>
        /// <param name="checkedCalculation">If true exceptions can be thrown.</param>
        /// <returns>The power of 2 that is the nearest power of 2 to the <paramref name="targetValue"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given <paramref name="targetValue"/> is <see cref="double.IsInfinity(float)"/> or <see cref="double.NaN"/> and can't be near a power of 2 value!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The exponentIterationMinimal is already to high to get a valid power of 2 value!</exception>
        public static double ClosestPowerOfTwo(double targetValue, out uint exponent, uint exponentIterationMinimal = 1, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (IsNaNOrInfinity(targetValue))
                {
                    throw new ArgumentOutOfRangeException("The given targetValue is infinitely or Not a Number and can't be near a power of 2 value!");
                }
                if (IsNaNOrInfinity(Math.Pow(2, exponentIterationMinimal)))
                {
                    throw new ArgumentOutOfRangeException("The exponentIterationMinmal is already to high to get a valid power of 2 value!");
                }
            }
            if ((Math.Pow(2D, exponentIterationMinimal) < targetValue))
            {
                while (Math.Pow(2D, exponentIterationMinimal) < targetValue)
                {
                    exponentIterationMinimal++;
                    if (IsNaNOrInfinity(Math.Pow(2D, exponentIterationMinimal)))
                    {
                        break;
                    }
                }
                double upperBoundary;
                double bottomBondary;
                if (exponentIterationMinimal < 2)
                {
                    if (exponentIterationMinimal > 0 && !Approximately(2D, targetValue, 0.5D, false))
                    {
                        exponentIterationMinimal--;
                    }
                }
                else
                {
                    upperBoundary = Math.Pow(2D, exponentIterationMinimal - 1);
                    bottomBondary = Math.Pow(2D, exponentIterationMinimal - 2);
                    if (Approximately(upperBoundary, targetValue, bottomBondary, false))
                    {
                        exponentIterationMinimal--;
                    }
                }
            }
            exponent = exponentIterationMinimal;
            return Math.Pow(2D, exponentIterationMinimal);
        }
    }

    //http://stackoverflow.com/a/8618145 by NathanAldenSr
    /// <summary>
    /// Safely converts a <see cref="float"/> to an <see cref="int"/> for floating-point comparisons.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ComparableFloat : IEquatable<ComparableFloat>, IEquatable<float>, IEquatable<int>, IComparable<ComparableFloat>, IComparable<float>, IComparable<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparableFloat"/> class.
        /// </summary>
        /// <param name="floatValue">The <see cref="float"/> value to be converted to an <see cref="int"/>.</param>
        public ComparableFloat(float floatValue)
            : this()
        {
            FloatValue = floatValue;
        }

        /// <summary>
        /// Gets the floating-point value as a bitwise <see cref="int"/>.
        /// </summary>
        [FieldOffset(0)]
        public readonly int IntValue;

        /// <summary>
        /// Gets the floating-point value.
        /// </summary>
        [FieldOffset(0)]
        public readonly float FloatValue;

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(ComparableFloat other)
        {
            return other.IntValue == IntValue;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(float other)
        {
            return IntValue == new ComparableFloat(other).IntValue;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(int other)
        {
            return IntValue == other;
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(ComparableFloat other)
        {
            return IntValue.CompareTo(other.IntValue);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(float other)
        {
            return IntValue.CompareTo(new ComparableFloat(other).IntValue);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(int other)
        {
            return IntValue.CompareTo(other);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (obj.GetType() != typeof(ComparableFloat))
            {
                return false;
            }
            return Equals((ComparableFloat)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="Int32"/> that is the hash code for this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return IntValue;
        }

        /// <summary>
        /// Implicitly converts from a <see cref="ComparableFloat"/> to an <see cref="int"/>.
        /// </summary>
        /// <param name="value">A <see cref="ComparableFloat"/>.</param>
        /// <returns>An <see cref="int"/> representation of the floating-point value.</returns>
        public static implicit operator int (ComparableFloat value)
        {
            return value.IntValue;
        }

        /// <summary>
        /// Implicitly converts from a <see cref="ComparableFloat"/> to a <see cref="float"/>.
        /// </summary>
        /// <param name="value">A <see cref="ComparableFloat"/>.</param>
        /// <returns>The floating-point value.</returns>
        public static implicit operator float (ComparableFloat value)
        {
            return value.FloatValue;
        }

        /// <summary>
        /// Determines if two <see cref="ComparableFloat"/> instances have the same <see cref="int"/> representation.
        /// </summary>
        /// <param name="left">A <see cref="ComparableFloat"/>.</param>
        /// <param name="right">A <see cref="ComparableFloat"/>.</param>
        /// <returns>true if the two <see cref="ComparableFloat"/> have the same <see cref="int"/>representation; otherwise, false.</returns>
        public static bool operator ==(ComparableFloat left, ComparableFloat right)
        {
            return left.IntValue == right.IntValue;
        }

        /// <summary>
        /// Determines if two <see cref="ComparableFloat"/> instances have different <see cref="int"/> representations.
        /// </summary>
        /// <param name="left">A <see cref="ComparableFloat"/>.</param>
        /// <param name="right">A <see cref="ComparableFloat"/>.</param>
        /// <returns>true if the two <see cref="ComparableFloat"/> have different <see cref="int"/> representations; otherwise, false.</returns>
        public static bool operator !=(ComparableFloat left, ComparableFloat right)
        {
            return !(left == right);
        }
    }

    /// <summary>
    /// Safely converts a <see cref="double"/> to a <see cref="long"/> for floating-point comparisons.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct ComparableDouble : IEquatable<ComparableDouble>, IEquatable<double>, IEquatable<long>, IComparable<ComparableDouble>, IComparable<double>, IComparable<long>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparableDouble"/> class.
        /// </summary>
        /// <param name="doubleValue">The <see cref="double"/> value to be converted to a <see cref="long"/>.</param>
        public ComparableDouble(double doubleValue)
            : this()
        {
            DoubleValue = doubleValue;
        }

        /// <summary>
        /// Gets the double-point value as a <see cref="long"/>.
        /// </summary>
        [FieldOffset(0)]
        public readonly long LongValue;

        /// <summary>
        /// Gets the double-point value.
        /// </summary>
        [FieldOffset(0)]
        public readonly double DoubleValue;

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(ComparableDouble other)
        {
            return other.LongValue == LongValue;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(double other)
        {
            return LongValue == new ComparableDouble(other).LongValue;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(long other)
        {
            return LongValue == other;
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(ComparableDouble other)
        {
            return LongValue.CompareTo(other.LongValue);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(double other)
        {
            return LongValue.CompareTo(new ComparableDouble(other).LongValue);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(long other)
        {
            return LongValue.CompareTo(other);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (obj.GetType() != typeof(ComparableDouble))
            {
                return false;
            }
            return Equals((ComparableDouble)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="Int32"/> that is the hash code for this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return LongValue.GetHashCode();
        }

        /// <summary>
        /// Implicitly converts from a <see cref="ComparableDouble"/> to an <see cref="int"/>.
        /// </summary>
        /// <param name="value">A <see cref="ComparableDouble"/>.</param>
        /// <returns>An integer representation of the floating-point value.</returns>
        public static implicit operator long (ComparableDouble value)
        {
            return value.LongValue;
        }

        /// <summary>
        /// Implicitly converts from a <see cref="ComparableDouble"/> to a <see cref="float"/>.
        /// </summary>
        /// <param name="value">A <see cref="ComparableDouble"/>.</param>
        /// <returns>The floating-point value.</returns>
        public static implicit operator double (ComparableDouble value)
        {
            return value.DoubleValue;
        }

        /// <summary>
        /// Determines if two <see cref="ComparableDouble"/> instances have the same <see cref="long"/> representation.
        /// </summary>
        /// <param name="left">A <see cref="ComparableDouble"/>.</param>
        /// <param name="right">A <see cref="ComparableDouble"/>.</param>
        /// <returns>true if the two <see cref="ComparableDouble"/> have the same <see cref="long"/> representation; otherwise, false.</returns>
        public static bool operator ==(ComparableDouble left, ComparableDouble right)
        {
            return left.LongValue == right.LongValue;
        }

        /// <summary>
        /// Determines if two <see cref="ComparableDouble"/> instances have different <see cref="long"/> representations.
        /// </summary>
        /// <param name="left">A <see cref="ComparableDouble"/>.</param>
        /// <param name="right">A <see cref="ComparableDouble"/>.</param>
        /// <returns>true if the two <see cref="ComparableDouble"/> have different <see cref="long"/> representations; otherwise, false.</returns>
        public static bool operator !=(ComparableDouble left, ComparableDouble right)
        {
            return !(left == right);
        }
    }
}