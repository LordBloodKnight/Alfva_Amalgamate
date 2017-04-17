using System;
using System.Threading;
using AlfvaAmalgamate.Floats;
using AlfvaAmalgamate.Arrays;
using AlfvaAmalgamate.MathExtends;

/// <summary>
/// Holds general collection useable for integer based data types.
/// </summary>
namespace AlfvaAmalgamate.Integers
{
    /// <summary>
    /// Holds extensions for integer based data types.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// the highest power of 2 value a <see cref="byte"/> can hold.
        /// </summary>
        public const byte HighestBytePow2 = byte.MaxValue ^ (byte.MaxValue >> 1);

        /// <summary>
        /// The lowest power of 2 value a <see cref="´byte"/> can hold.
        /// </summary>
        public const byte LowestBytePow2 = 1;

        /// <summary>
        /// the highest power of 2 value a <see cref="sbyte"/> can hold.
        /// </summary>
        public const sbyte HighestSBytePow2 = sbyte.MaxValue ^ (sbyte.MaxValue >> 1);

        /// <summary>
        /// The lowest power of 2 value a <see cref="sbyte"/> can hold.
        /// </summary>
        public const sbyte LowestSBytePow2 = HighestSBytePow2 * -1;

        /// <summary>
        /// the highest power of 2 value a <see cref="short"/> can hold.
        /// </summary>
        public const short HighestShortPow2 = short.MaxValue ^ (short.MaxValue >> 1);

        /// <summary>
        /// The lowest power of 2 value a <see cref="short"/> can hold.
        /// </summary>
        public const short LowestShortPow2 = HighestShortPow2 * -1;

        /// <summary>
        /// the highest power of 2 value a <see cref="ushort"/> can hold.
        /// </summary>
        public const ushort HighestUShortPow2 = ushort.MaxValue ^ (ushort.MaxValue >> 1);

        /// <summary>
        /// The lowest power of 2 value a <see cref="ushort"/> can hold.
        /// </summary>
        public const ushort LowestUShortPow2 = 1;

        /// <summary>
        /// The highest power of 2 value an <see cref="int"/> can hold.
        /// </summary>
        public const int HighestIntPow2 = int.MaxValue ^ (int.MaxValue >> 1);

        /// <summary>
        /// The lowest power of 2 value an <see cref="int"/> can hold.
        /// </summary>
        public const int LowestIntPow2 = HighestIntPow2 * -1;

        /// <summary>
        /// The highest power of 2 value an <see cref="uint"/> can hold.
        /// </summary>
        public const uint HighestUIntPow2 = uint.MaxValue ^ (uint.MaxValue >> 1);

        /// <summary>
        /// The lowest power of 2 value an <see cref="uint"/> can hold.
        /// </summary>
        public const uint LowestUIntPow2 = 1;

        /// <summary>
        /// The highest power of 2 value an <see cref="long"/> can hold.
        /// </summary>
        public const long HighestLongPow2 = long.MaxValue ^ (long.MaxValue >> 1);

        /// <summary>
        /// The lowest power of 2 value an <see cref="long"/> can hold.
        /// </summary>
        public const long LowestLongPow2 = HighestLongPow2 * -1L;

        /// <summary>
        /// The highest power of 2 value an <see cref="ulong"/> can hold.
        /// </summary>
        public const ulong HighestULongPow2 = ulong.MaxValue ^ (ulong.MaxValue >> 1);

        /// <summary>
        /// The lowest power of 2 value an <see cref="ulong"/> can hold.
        /// </summary>
        public const ulong LowestULongPow2 = 1UL;

        /// <summary>
        /// Rounds the value specific to the wanted <see cref="RoundingType"/>.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="result">The rounded result value.</param>
        /// <param name="howToRound">How to round the value?</param>
        /// <param name="checkedCalculation">If true all possible exceptions are enabled.</param>
        /// <returns>The rounded value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value to round is <see cref="float.NaN"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value is not in the splited integer of a <see cref="byte"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given <see cref="RoundingType"/> is not a valid <see cref="RoundingType"/>!</exception>
        public static void RoundSpecific(float value, out byte result, RoundingType howToRound = RoundingType.Truncate, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (float.IsNaN(value))
                {
                    throw new ArgumentOutOfRangeException("The value to round is Not a Number!");
                }
                if (value < byte.MinValue || value > byte.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("The value is not in the range of a byte!");
                }
            }
            float tempResult = FloatExtensions.RoundSpecific(value, howToRound);
            if (float.IsNaN(tempResult) || tempResult > byte.MaxValue)
            {
                result = byte.MaxValue;
            }
            else if (tempResult < byte.MinValue)
            {
                result = byte.MinValue;
            }
            else
            {
                result = (byte)tempResult;
            }
        }

        /// <summary>
        /// Rounds the value specific to the wanted <see cref="RoundingType"/>.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="result">The rounded result value.</param>
        /// <param name="howToRound">How to round the value?</param>
        /// <param name="checkedCalculation">If true all possible exceptions are enabled.</param>
        /// <returns>The rounded value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value to round is <see cref="double.NaN"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value is not in the range of a <see cref="byte"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given <see cref="RoundingType"/> is not a valid <see cref="RoundingType"/>!</exception>
        public static void RoundSpecific(double value, out byte result, RoundingType howToRound = RoundingType.Truncate, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (double.IsNaN(value))
                {
                    throw new ArgumentOutOfRangeException("The value to round is Not a Number!");
                }
                if (value < byte.MinValue || value > byte.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("The value is not in the range of a byte!");
                }
            }
            double tempResult = FloatExtensions.RoundSpecific(value, howToRound);
            if (double.IsNaN(tempResult) || tempResult > byte.MaxValue)
            {
                result = byte.MaxValue;
            }
            else if (tempResult < byte.MinValue)
            {
                result = byte.MinValue;
            }
            else
            {
                result = (byte)tempResult;
            }
        }

        /// <summary>
        /// Rounds the value specific to the wanted <see cref="RoundingType"/>.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="result">The rounded result value.</param>
        /// <param name="howToRound">How to round the value?</param>
        /// <param name="checkedCalculation">If true all possible exceptions are enabled.</param>
        /// <returns>The rounded value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value is not in the range of a <see cref="byte"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given <see cref="RoundingType"/> is not a valid <see cref="RoundingType"/>!</exception>
        public static void RoundSpecific(decimal value, out byte result, RoundingType howToRound = RoundingType.Truncate, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (value < byte.MinValue || value > byte.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("The value is not in the range of a byte!");
                }
            }
            decimal tempResult = FloatExtensions.RoundSpecific(value, howToRound);
            if (tempResult > byte.MaxValue)
            {
                result = byte.MaxValue;
            }
            else if (tempResult < byte.MinValue)
            {
                result = byte.MinValue;
            }
            else
            {
                result = (byte)tempResult;
            }
        }

        /// <summary>
        /// Rounds the value specific to the wanted <see cref="RoundingType"/>.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="result">The rounded result value.</param>
        /// <param name="howToRound">How to round the value?</param>
        /// <param name="checkedCalculation">If true all possible exceptions are enabled.</param>
        /// <exception cref="ArgumentOutOfRangeException">The value to round is <see cref="float.NaN"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value is not in the range of a <see cref="int"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given <see cref="RoundingType"/> is not a valid <see cref="RoundingType"/>!</exception>
        public static void RoundSpecific(float value, out int result, RoundingType howToRound = RoundingType.Truncate, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (float.IsNaN(value))
                {
                    throw new ArgumentOutOfRangeException("The value to round is Not a Number!");
                }
                if (value < int.MinValue || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("The value is not in the range of a byte!");
                }
            }
            float tempResult = FloatExtensions.RoundSpecific(value, howToRound);
            if (float.IsNaN(tempResult) || tempResult > int.MaxValue)
            {
                result = int.MaxValue;
            }
            else if (tempResult < int.MinValue)
            {
                result = int.MinValue;
            }
            else
            {
                result = (int)tempResult;
            }
        }

        /// <summary>
        /// Rounds the value specific to the wanted <see cref="RoundingType"/>.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="result">The rounded result value.</param>
        /// <param name="howToRound">How to round the value?</param>
        /// <param name="checkedCalculation">If true all possible exceptions are enabled.</param>
        /// <returns>The rounded value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value to round is <see cref="double.NaN"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The value is not in the range of a <see cref="int"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given <see cref="RoundingType"/> is not a valid <see cref="RoundingType"/>!</exception>
        public static void RoundSpecific(double value, out int result, RoundingType howToRound = RoundingType.Truncate, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (double.IsNaN(value))
                {
                    throw new ArgumentOutOfRangeException("The value to round is Not a Number!");
                }
                if (value < int.MinValue || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("The value is not in the range of a byte!");
                }
            }
            double tempResult = FloatExtensions.RoundSpecific(value, howToRound);
            if (double.IsNaN(tempResult) || tempResult > int.MaxValue)
            {
                result = int.MaxValue;
            }
            else if (tempResult < int.MinValue)
            {
                result = int.MinValue;
            }
            else
            {
                result = (int)tempResult;
            }
        }

        /// <summary>
        /// Rounds the value specific to the wanted <see cref="RoundingType"/>.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="result">The rounded result value.</param>
        /// <param name="howToRound">How to round the value?</param>
        /// <param name="checkedCalculation">If true all possible exceptions are enabled.</param>
        /// <returns>The rounded value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The value is not in the range of a <see cref="int"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given <see cref="RoundingType"/> is not a valid <see cref="RoundingType"/>!</exception>
        public static void RoundSpecific(decimal value, out int result, RoundingType howToRound = RoundingType.Truncate, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (value < int.MinValue || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("The value is not in the range of a byte!");
                }
            }
            decimal tempResult = FloatExtensions.RoundSpecific(value, howToRound);
            if (tempResult > int.MaxValue)
            {
                result = int.MaxValue;
            }
            else if (tempResult < int.MinValue)
            {
                result = int.MinValue;
            }
            else
            {
                result = (int)tempResult;
            }
        }

        /// <summary>
        /// Powers the given <see cref="ulong"/> with the given power.<para />
        /// Be aware that powering an <see cref="ulong"/> can fastly produce an <see cref="OverflowException"/> because <see cref="ulong"/> is limited in range.
        /// </summary>
        /// <param name="toPower">The <see cref="ulong"/> to power.</param>
        /// <param name="power">The power.</param>
        /// <returns>Powered <see cref="ulong"/> value.</returns>
        /// <error><OverflowException>The given <see cref="ulong"/> produced an <see cref="OverflowException"/> because the power were to high!</OverflowException></error>
        public static ulong Pow(this ulong toPower, byte power)
        {
            if (power == 0)
            {
                toPower = 1UL;
            }
            else
            {
                ulong powerFactor = toPower;
                int originalPower = power;
                if (power > 0)
                {
                    power--;
                }
                try
                {
                    while (power != 0)
                    {
                        toPower *= powerFactor;
                        if (power > 0)
                        {
                            power--;
                        }
                    }
                }
                catch (OverflowException)
                {
                    throw new OverflowException("The given ulong produced an OverflowException because the power were to high!");
                }
            }
            return toPower;
        }

        /// <summary>
        /// Remaps a <see cref="SByte"/> from the InputRange to the OutputRange.
        /// </summary>
        /// <param name="value">The value to remap.</param>
        /// <param name="minIn">The minimal input range.</param>
        /// <param name="maxIn">The maximal input range.</param>
        /// <param name="minOut">The minimal output range.</param>
        /// <param name="maxOut">The maximal output range.</param>
        /// <param name="remappedValue">The remapped value.</param>
        /// <param name="checkedCalculation">If true than all possible exceptions are enabled.</param>
        /// <remarks>Be aware that remapping integer based values as a high precision lose!<para />
        /// If the input value is outside of the input range the result output is also outside of the output range!<para />
        /// The remap function is -> result = <paramref name="minOut"/> + (<paramref name="value"/> - <paramref name="minIn"/>) * (<paramref name="maxOut"/> - <paramref name="minOut"/>) / (<paramref name="maxIn"/> - <paramref name="minIn"/>)</remarks>
        /// <exception cref="DivideByZeroException">The input range is equal 0 so the result would be infinite!</exception>
        /// <exception cref="ArithmeticException">The result is outside of the <see cref="SByte"/> range!</exception>
        public static void Remap(SByte value, SByte minIn, SByte maxIn, SByte minOut, SByte maxOut, out SByte remappedValue, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if ((minIn == maxIn))
                {
                    throw new DivideByZeroException("The input range is equal 0 so the result would be infinite!");
                }
            }
            // minOut + (value - minIn) * (maxOut - minOut) / (maxIn - minIn);
            Int32 result = minOut + (value - minIn) * (maxOut - minIn) / (maxIn - minIn);
            try
            {
                value = Convert.ToSByte(result);
            }
            catch (OverflowException)
            {
                if (checkedCalculation)
                {
                    throw new ArithmeticException("The result is outside of the Byte range!");
                }
                else
                {
                    if (result < 0)
                    {
                        value = SByte.MinValue;
                    }
                    else
                    {
                        value = SByte.MaxValue;
                    }
                }
            }
            remappedValue = value;
        }

        /// <summary>
        /// Remaps a <see cref="Int16"/> from the InputRange to the OutputRange.
        /// </summary>
        /// <param name="value">The value to remap.</param>
        /// <param name="minIn">The minimal input range.</param>
        /// <param name="maxIn">The maximal input range.</param>
        /// <param name="minOut">The minimal output range.</param>
        /// <param name="maxOut">The maximal output range.</param>
        /// <param name="remappedValue">The remapped value.</param>
        /// <param name="checkedCalculation">If true than all possible exceptions are enabled.</param>
        /// <remarks>Be aware that remapping integer based values as a high precision lose!<para />
        /// If the input value is outside of the input range the result output is also outside of the output range!<para />
        /// The remap function is -> result = <paramref name="minOut"/> + (<paramref name="value"/> - <paramref name="minIn"/>) * (<paramref name="maxOut"/> - <paramref name="minOut"/>) / (<paramref name="maxIn"/> - <paramref name="minIn"/>)</remarks>
        /// <exception cref="DivideByZeroException">The input range is equal 0 so the result would be infinite!</exception>
        /// <exception cref="ArithmeticException">The result is outside of the <see cref="Int16"/> range!</exception>
        public static void Remap(Int16 value, Int16 minIn, Int16 maxIn, Int16 minOut, Int16 maxOut, out Int16 remappedValue, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if ((minIn == maxIn))
                {
                    throw new DivideByZeroException("The input range is equal 0 so the result would be infinite!");
                }
            }
            // minOut + (value - minIn) * (maxOut - minOut) / (maxIn - minIn);
            Int32 result = minOut + (value - minIn) * (maxOut - minIn) / (maxIn - minIn);
            try
            {
                value = Convert.ToInt16(result);
            }
            catch (OverflowException)
            {
                if (checkedCalculation)
                {
                    throw new ArithmeticException("The result is outside of the In16 range!");
                }
                else
                {
                    if (result < 0)
                    {
                        value = Int16.MinValue;
                    }
                    else
                    {
                        value = Int16.MaxValue;
                    }
                }
            }
            remappedValue = value;
        }

        /// <summary>
        /// Remaps a <see cref="Int32"/> from the InputRange to the OutputRange.
        /// </summary>
        /// <param name="value">The value to remap.</param>
        /// <param name="minIn">The minimal input range.</param>
        /// <param name="maxIn">The maximal input range.</param>
        /// <param name="minOut">The minimal output range.</param>
        /// <param name="maxOut">The maximal output range.</param>
        /// <param name="remappedValue">The remapped value.</param>
        /// <param name="checkedCalculation">If true than all possible exceptions are enabled.</param>
        /// <remarks>Be aware that remapping integer based values as a high precision lose!<para />
        /// If the input value is outside of the input range the result output is also outside of the output range!<para />
        /// The remap function is -> result = <paramref name="minOut"/> + (<paramref name="value"/> - <paramref name="minIn"/>) * (<paramref name="maxOut"/> - <paramref name="minOut"/>) / (<paramref name="maxIn"/> - <paramref name="minIn"/>)</remarks>
        /// <exception cref="DivideByZeroException">The input range is equal 0 so the result would be infinite!</exception>
        /// <exception cref="ArithmeticException">The result is outside of the <see cref="Int32"/> range!</exception>
        public static void Remap(Int32 value, Int32 minIn, Int32 maxIn, Int32 minOut, Int32 maxOut, out Int32 remappedValue, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if ((minIn == maxIn))
                {
                    throw new DivideByZeroException("The input range is equal 0 so the result would be infinite!");
                }
            }
            // minOut + (value - minIn) * (maxOut - minOut) / (maxIn - minIn);
            Int64 result = minOut + ((Int64)value - minIn) * ((Int64)maxOut - minIn) / ((Int64)maxIn - minIn);
            try
            {
                value = Convert.ToInt32(result);
            }
            catch (OverflowException)
            {
                if (checkedCalculation)
                {
                    throw new ArithmeticException("The result is outside of the Int32 range!");
                }
                else
                {
                    if (result < 0L)
                    {
                        value = Int32.MinValue;
                    }
                    else
                    {
                        value = Int32.MaxValue;
                    }
                }
            }
            remappedValue = value;
        }

        /// <summary>
        /// Gets the closest power of 2 from the <paramref name="targetValue"/>.
        /// </summary>
        /// <param name="targetValue">The target value to which it is wanted to search the nearest neighbors of power of 2.</param>
        /// <param name="exponentIterationMinimal">The minimal exponent that that is allowed has the power of 2.</param>
        /// <param name="checkedCalculation">If true exceptions can be thrown.</param>
        /// <returns>The power of 2 that is the nearest power of 2 to the <paramref name="targetValue"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given <paramref name="targetValue"/> is to high or low so the nearest pow of 2 is also to high or low for an <see cref="int"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The exponentIterationMinimal is already to high to get a valid power of 2 value!</exception>
        public static int ClosestPowerOfTwo(int targetValue, uint exponentIterationMinimal = 1, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (targetValue > (HighestIntPow2 | (HighestIntPow2 >> 1)) || targetValue < (HighestIntPow2 | (HighestIntPow2 >> 1) * -1))
                {
                    throw new ArgumentOutOfRangeException("The given targetValue is to high or low so the nearest pow of 2 is also to high or low for an int!");
                }
                if ((exponentIterationMinimal > int.MaxValue) || (1 << (int)exponentIterationMinimal) < 1)
                {
                    throw new ArgumentOutOfRangeException("The exponentIterationMinmal is already to high to get a valid power of 2 value!");
                }
            }
            int internalExponentIterationMinimal = (int)exponentIterationMinimal;
            if ((1 << internalExponentIterationMinimal) < targetValue)
            {
                while ((1 << internalExponentIterationMinimal) < targetValue)
                {
                    internalExponentIterationMinimal++;
                    if ((1 << internalExponentIterationMinimal) < 1)
                    {
                        break;
                    }
                }
                int upperBoundary;
                int bottomBondary;
                if (internalExponentIterationMinimal < 2)
                {
                    if (internalExponentIterationMinimal > 0 && !(2 < (targetValue + 1)))
                    {
                        internalExponentIterationMinimal--;
                    }
                }
                else
                {
                    upperBoundary = 1 << (internalExponentIterationMinimal - 1);
                    bottomBondary = 1 << (internalExponentIterationMinimal - 2);
                    if (!(upperBoundary < (targetValue + bottomBondary)))
                    {
                        internalExponentIterationMinimal--;
                    }
                }
            }
            return 1 << internalExponentIterationMinimal;
        }

        /// <summary>
        /// Gets the closest power of 2 from the <paramref name="targetValue"/>.
        /// </summary>
        /// <param name="targetValue">The target value to which it is wanted to search the nearest neighbors of power of 2.</param>
        /// <param name="exponent">The exponent of the nearest power of 2 neighbor to the <paramref name="targetValue"/>.</param>
        /// <param name="exponentIterationMinimal">The minimal exponent that that is allowed has the power of 2.</param>
        /// <param name="checkedCalculation">If true exceptions can be thrown.</param>
        /// <returns>The power of 2 that is the nearest power of 2 to the <paramref name="targetValue"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given <paramref name="targetValue"/> is to high or low so the nearest pow of 2 is also to high or low for an <see cref="int"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The exponentIterationMinimal is already to high to get a valid power of 2 value!</exception>
        public static int ClosestPowerOfTwo(int targetValue, out uint exponent, uint exponentIterationMinimal = 1, bool checkedCalculation = false)
        {
            if (checkedCalculation)
            {
                if (targetValue > (HighestIntPow2 | (HighestIntPow2 >> 1)) || targetValue < (HighestIntPow2 | (HighestIntPow2 >> 1) * -1))
                {
                    throw new ArgumentOutOfRangeException("The given targetValue is to high or low so the nearest pow of 2 is also to high or low for an int!");
                }
                if ((exponentIterationMinimal > int.MaxValue) || (1 << (int)exponentIterationMinimal) < 1)
                {
                    throw new ArgumentOutOfRangeException("The exponentIterationMinmal is already to high to get a valid power of 2 value!");
                }
            }
            int internalExponentIterationMinimal = (int)exponentIterationMinimal;
            if ((1 << internalExponentIterationMinimal) < targetValue)
            {
                while ((1 << internalExponentIterationMinimal) < targetValue)
                {
                    internalExponentIterationMinimal++;
                    if ((1 << internalExponentIterationMinimal) < 1)
                    {
                        break;
                    }
                }
                int upperBoundary;
                int bottomBondary;
                if (internalExponentIterationMinimal < 2)
                {
                    if (internalExponentIterationMinimal > 0 && !(2 < (targetValue + 1)))
                    {
                        internalExponentIterationMinimal--;
                    }
                }
                else
                {
                    upperBoundary = 1 << (internalExponentIterationMinimal - 1);
                    bottomBondary = 1 << (internalExponentIterationMinimal - 2);
                    if (!(upperBoundary < (targetValue + bottomBondary)))
                    {
                        internalExponentIterationMinimal--;
                    }
                }
            }
            exponent = (uint)internalExponentIterationMinimal;
            return 1 << internalExponentIterationMinimal;
        }

        /// <summary>
        /// Compares the given splited value with the own splited value.
        /// </summary>
        /// <typeparam name="RangeValueType">A <see cref="Type"/> that can store a splited value. (Only positive values!)</typeparam>
        /// <param name="self">Own splited integer.</param>
        /// <param name="other">Range to compare to.</param>
        /// <returns>Which value is higher. Equaly a <see cref="IComparable{T}"/> but compares every element descending as long every element is equaly.</returns>
        /// <remarks>Be aware that this <see cref="TypeSplitValueCompareTo{T}(T[], T[])"/> is not thread safe! This is a special SplitedIntegerCompareTo that supports all <see cref="IComparable{T}"/> <see cref="Type"/>s!</remarks>
        public static int TypeSplitedValueCompareTo<RangeValueType>(this RangeValueType[] self, RangeValueType[] other) where RangeValueType : IComparable<RangeValueType>
        {
            int result = 0;
            if (other == null)
            {
                if (self.Length > 0 && self[0].CompareTo(default(RangeValueType)) > 0)
                {
                    result = 1;
                }
            }
            else if (self.Length == 0 && other.Length == 0)
            {
                result = 0;
            }
            else
            {
                int currentValueExponent;
                if (self.Length > other.Length)
                {
                    currentValueExponent = self.Length - 1;
                    while (currentValueExponent >= other.Length)
                    {
                        if (self[0].CompareTo(default(RangeValueType)) > 0)
                        {
                            result = 1;
                        }
                    }
                }
                else
                {
                    currentValueExponent = other.Length - 1;
                    while (currentValueExponent >= self.Length)
                    {
                        if (other[currentValueExponent].CompareTo(default(RangeValueType)) > 0)
                        {
                            result = -1;
                        }
                    }
                }
                while (currentValueExponent > 0 && result == 0)
                {
                    result = self[currentValueExponent].CompareTo(other[currentValueExponent]);
                    currentValueExponent--;
                }
            }
            // do work
            return result;
        }

        /// <summary>
        /// Compares the given splited integer with the own splited integer.
        /// </summary>
        /// <param name="self">Own splited integer.</param>
        /// <param name="other">Range to compare to.</param>
        /// <param name="arrayLockNeeded">Are the given <see cref="Array"/>s needed to be locked and cloned before using them?</param>
        /// <param name="ignoreThreadingAccess">If true and any given <see cref="Byte"/> <see cref="Array"/> is locked it will be calculated as it would be null else an <see cref="TimeoutException"/> gets thrown on the same event.</param>
        /// <returns>Which value is higher. Equaly a <see cref="IComparable{T}"/> but compares every element descending as long every element is equaly.</returns>
        /// <remarks>Integer based value splited integers can't never be negative so don't try building an extensions method for a signed integer based value <see cref="Type"/>!</remarks>
        /// <exception cref="TimeoutException">The any of both parameters is already locked and so it is unavailable!</exception>
        public static int SplitedIntegerCompareTo(this Byte[] self, Byte[] other, bool arrayLockNeeded = false, bool ignoreThreadingAccess = true)
        {
            // prepare work
            Byte[] selfCopy;
            Byte[] otherCopy;
            if (arrayLockNeeded)
            {
                bool lockGot = false;
                try
                {
                    Monitor.TryEnter(self, 1, ref lockGot);
                    if (lockGot)
                    {
                        selfCopy = self.Clone() as Byte[];
                    }
                    else
                    {
                        if (ignoreThreadingAccess)
                        {
                            selfCopy = null;
                        }
                        else
                        {
                            throw new TimeoutException("The self parameter is already locked and so it is unavailable!");
                        }
                    }
                }
                finally
                {
                    if (lockGot)
                    {
                        Monitor.Exit(self);
                        lockGot = false;
                    }
                }
                try
                {
                    lockGot = Monitor.TryEnter(other);
                    if (lockGot)
                    {
                        if (other == null)
                        {
                            otherCopy = null;
                        }
                        else
                        {
                            otherCopy = other.Clone() as Byte[];
                        }
                    }
                    else
                    {
                        if (ignoreThreadingAccess)
                        {
                            otherCopy = null;
                        }
                        else
                        {
                            throw new TimeoutException("The other parameter is already locked and so it is unavailable!");
                        }
                    }
                }
                finally
                {
                    if (lockGot)
                    {
                        Monitor.Exit(other);
                        lockGot = false;
                    }
                }
            }
            else
            {
                selfCopy = self;
                otherCopy = other;
            }
            // do work
            return selfCopy.TypeSplitedValueCompareTo(otherCopy);
        }

        /// <summary>
        /// Compares the given splited integer with the own splited integer.
        /// </summary>
        /// <param name="self">Own splited integer.</param>
        /// <param name="other">Range to compare to.</param>
        /// <param name="arrayLockNeeded">Are the given <see cref="Array"/>s needed to be locked and cloned before using them?</param>
        /// <param name="ignoreThreadingAccess">If true and any given <see cref="UInt16"/> <see cref="Array"/> is locked it will be calculated as it would be null else an <see cref="TimeoutException"/> gets thrown on the same event.</param>
        /// <returns>Which value is higher. Equaly a <see cref="IComparable{T}"/> but compares every element descending as long every element is equaly.</returns>
        /// <remarks>Integer based value splited integers can't never be negative so don't try building an extensions method for a signed integer based value <see cref="Type"/>!</remarks>
        /// <exception cref="TimeoutException">The any of both parameters is already locked and so it is unavailable!</exception>
        public static int SplitedIntegerCompareTo(this UInt16[] self, UInt16[] other, bool arrayLockNeeded = false, bool ignoreThreadingAccess = true)
        {
            // prepare work
            UInt16[] selfCopy;
            UInt16[] otherCopy;
            if (arrayLockNeeded)
            {
                bool lockGot = false;
                try
                {
                    Monitor.TryEnter(self, 1, ref lockGot);
                    if (lockGot)
                    {
                        selfCopy = self.Clone() as UInt16[];
                    }
                    else
                    {
                        if (ignoreThreadingAccess)
                        {
                            selfCopy = null;
                        }
                        else
                        {
                            throw new TimeoutException("The self parameter is already locked and so it is unavailable!");
                        }
                    }
                }
                finally
                {
                    if (lockGot)
                    {
                        Monitor.Exit(self);
                        lockGot = false;
                    }
                }
                try
                {
                    lockGot = Monitor.TryEnter(other);
                    if (lockGot)
                    {
                        if (other == null)
                        {
                            otherCopy = null;
                        }
                        else
                        {
                            otherCopy = other.Clone() as UInt16[];
                        }
                    }
                    else
                    {
                        if (ignoreThreadingAccess)
                        {
                            otherCopy = null;
                        }
                        else
                        {
                            throw new TimeoutException("The other parameter is already locked and so it is unavailable!");
                        }
                    }
                }
                finally
                {
                    if (lockGot)
                    {
                        Monitor.Exit(other);
                        lockGot = false;
                    }
                }
            }
            else
            {
                selfCopy = self;
                otherCopy = other;
            }
            // do work
            return selfCopy.TypeSplitedValueCompareTo(otherCopy);
        }

        /// <summary>
        /// Compares the given splited integer with the own splited integer.
        /// </summary>
        /// <param name="self">Own splited integer.</param>
        /// <param name="other">Range to compare to.</param>
        /// <param name="arrayLockNeeded">Are the given <see cref="Array"/>s needed to be locked and cloned before using them?</param>
        /// <param name="ignoreThreadingAccess">If true and any given <see cref="UInt32"/> <see cref="Array"/> is locked it will be calculated as it would be null else an <see cref="TimeoutException"/> gets thrown on the same event.</param>
        /// <returns>Which value is higher. Equaly a <see cref="IComparable{T}"/> but compares every element descending as long every element is equaly.</returns>
        /// <remarks>Integer based value splited integers can't never be negative so don't try building an extensions method for a signed integer based value <see cref="Type"/>!</remarks>
        /// <exception cref="TimeoutException">The any of both parameters is already locked and so it is unavailable!</exception>
        public static int SplitedIntegerCompareTo(this UInt32[] self, UInt32[] other, bool arrayLockNeeded = false, bool ignoreThreadingAccess = true)
        {
            // prepare work
            UInt32[] selfCopy;
            UInt32[] otherCopy;
            if (arrayLockNeeded)
            {
                bool lockGot = false;
                try
                {
                    Monitor.TryEnter(self, 1, ref lockGot);
                    if (lockGot)
                    {
                        selfCopy = self.Clone() as UInt32[];
                    }
                    else
                    {
                        if (ignoreThreadingAccess)
                        {
                            selfCopy = null;
                        }
                        else
                        {
                            throw new TimeoutException("The self parameter is already locked and so it is unavailable!");
                        }
                    }
                }
                finally
                {
                    if (lockGot)
                    {
                        Monitor.Exit(self);
                        lockGot = false;
                    }
                }
                try
                {
                    lockGot = Monitor.TryEnter(other);
                    if (lockGot)
                    {
                        if (other == null)
                        {
                            otherCopy = null;
                        }
                        else
                        {
                            otherCopy = other.Clone() as UInt32[];
                        }
                    }
                    else
                    {
                        if (ignoreThreadingAccess)
                        {
                            otherCopy = null;
                        }
                        else
                        {
                            throw new TimeoutException("The other parameter is already locked and so it is unavailable!");
                        }
                    }
                }
                finally
                {
                    if (lockGot)
                    {
                        Monitor.Exit(other);
                        lockGot = false;
                    }
                }
            }
            else
            {
                selfCopy = self;
                otherCopy = other;
            }
            // do work
            return selfCopy.TypeSplitedValueCompareTo(otherCopy);
        }

        /// <summary>
        /// Compares the given splited integer with the own splited integer.
        /// </summary>
        /// <param name="self">Own splited integer.</param>
        /// <param name="other">Range to compare to.</param>
        /// <param name="arrayLockNeeded">Are the given <see cref="Array"/>s needed to be locked and cloned before using them?</param>
        /// <param name="ignoreThreadingAccess">If true and any given <see cref="UInt64"/> <see cref="Array"/> is locked it will be calculated as it would be null else an <see cref="TimeoutException"/> gets thrown on the same event.</param>
        /// <returns>Which value is higher. Equaly a <see cref="IComparable{T}"/> but compares every element descending as long every element is equaly.</returns>
        /// <remarks>Integer based value splited integers can't never be negative so don't try building an extensions method for a signed integer based value <see cref="Type"/>!</remarks>
        /// <exception cref="TimeoutException">The any of both parameters is already locked and so it is unavailable!</exception>
        public static int SplitedIntegerCompareTo(this UInt64[] self, UInt64[] other, bool arrayLockNeeded = false, bool ignoreThreadingAccess = true)
        {
            // prepare work
            UInt64[] selfCopy;
            UInt64[] otherCopy;
            if (arrayLockNeeded)
            {
                bool lockGot = false;
                try
                {
                    Monitor.TryEnter(self, 1, ref lockGot);
                    if (lockGot)
                    {
                        selfCopy = self.Clone() as UInt64[];
                    }
                    else
                    {
                        if (ignoreThreadingAccess)
                        {
                            selfCopy = null;
                        }
                        else
                        {
                            throw new TimeoutException("The self parameter is already locked and so it is unavailable!");
                        }
                    }
                }
                finally
                {
                    if (lockGot)
                    {
                        Monitor.Exit(self);
                        lockGot = false;
                    }
                }
                try
                {
                    lockGot = Monitor.TryEnter(other);
                    if (lockGot)
                    {
                        if (other == null)
                        {
                            otherCopy = null;
                        }
                        else
                        {
                            otherCopy = other.Clone() as UInt64[];
                        }
                    }
                    else
                    {
                        if (ignoreThreadingAccess)
                        {
                            otherCopy = null;
                        }
                        else
                        {
                            throw new TimeoutException("The other parameter is already locked and so it is unavailable!");
                        }
                    }
                }
                finally
                {
                    if (lockGot)
                    {
                        Monitor.Exit(other);
                        lockGot = false;
                    }
                }
            }
            else
            {
                selfCopy = self;
                otherCopy = other;
            }
            // do work
            return selfCopy.TypeSplitedValueCompareTo(otherCopy);
        }
    }
}