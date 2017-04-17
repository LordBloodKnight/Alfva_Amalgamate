using System.Collections;
using System;

/// <summary>
/// Holds general collection useable for bit based data types.
/// </summary>
namespace AlfvaAmalgamate.Bits
{
    /// <summary>
    /// Holds extensions for bit based data types.
    /// </summary>
    public static class BitExtensions
    {
        /// <summary>
        /// Converts the <see cref="bool"/> to an <see cref="Byte"/>.
        /// </summary>
        /// <param name="toConvert">The <see cref="bool"/> to convert.</param>
        /// <param name="result">The <see cref="bool"/> as <see cref="Byte"/>.</param>
        /// <param name="maximize">Convert to the maximal and minimal values in <see cref="Byte"/> or to 1 and 0?</param>
        public static void ConvertTo(this bool toConvert, out Byte result, bool maximize = false)
        {
            if (maximize)
            {
                if (toConvert)
                {
                    result = Byte.MaxValue;
                }
                else
                {
                    result = Byte.MinValue;
                }
            }
            else
            {
                if (toConvert)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
        }

        /// <summary>
        /// Converts the <see cref="bool"/> to an <see cref="SByte"/>.
        /// </summary>
        /// <param name="toConvert">The <see cref="bool"/> to convert.</param>
        /// <param name="result">The <see cref="bool"/> as <see cref="SByte"/>.</param>
        /// <param name="maximize">Convert to the maximal and minimal values in <see cref="SByte"/> or to 1 and 0?</param>
        public static void ConvertTo(this bool toConvert, out SByte result, bool maximize = false)
        {
            if (maximize)
            {
                if (toConvert)
                {
                    result = SByte.MaxValue;
                }
                else
                {
                    result = SByte.MinValue;
                }
            }
            else
            {
                if (toConvert)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
        }

        /// <summary>
        /// Converts the <see cref="bool"/> to an <see cref="Int16"/>.
        /// </summary>
        /// <param name="toConvert">The <see cref="bool"/> to convert.</param>
        /// <param name="result">The <see cref="bool"/> as <see cref="Int16"/>.</param>
        /// <param name="maximize">Convert to the maximal and minimal values in <see cref="Int16"/> or to 1 and 0?</param>
        public static void ConvertTo(this bool toConvert, out Int16 result, bool maximize = false)
        {
            if (maximize)
            {
                if (toConvert)
                {
                    result = Int16.MaxValue;
                }
                else
                {
                    result = Int16.MinValue;
                }
            }
            else
            {
                if (toConvert)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
        }

        /// <summary>
        /// Converts the <see cref="bool"/> to an <see cref="UInt16"/>.
        /// </summary>
        /// <param name="toConvert">The <see cref="bool"/> to convert.</param>
        /// <param name="result">The <see cref="bool"/> as <see cref="UInt16"/>.</param>
        /// <param name="maximize">Convert to the maximal and minimal values in <see cref="UInt16"/> or to 1 and 0?</param>
        public static void ConvertTo(this bool toConvert, out UInt16 result, bool maximize = false)
        {
            if (maximize)
            {
                if (toConvert)
                {
                    result = UInt16.MaxValue;
                }
                else
                {
                    result = UInt16.MinValue;
                }
            }
            else
            {
                if (toConvert)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
        }

        /// <summary>
        /// Converts the <see cref="bool"/> to an <see cref="Int32"/>.
        /// </summary>
        /// <param name="toConvert">The <see cref="bool"/> to convert.</param>
        /// <param name="result">The <see cref="bool"/> as <see cref="Int32"/>.</param>
        /// <param name="maximize">Convert to the maximal and minimal values in <see cref="Int32"/> or to 1 and 0?</param>
        public static void ConvertTo(this bool toConvert, out Int32 result, bool maximize = false)
        {
            if (maximize)
            {
                if (toConvert)
                {
                    result = Int32.MaxValue;
                }
                else
                {
                    result = Int32.MinValue;
                }
            }
            else
            {
                if (toConvert)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
        }

        /// <summary>
        /// Converts the <see cref="bool"/> to an <see cref="UInt32"/>.
        /// </summary>
        /// <param name="toConvert">The <see cref="bool"/> to convert.</param>
        /// <param name="result">The <see cref="bool"/> as <see cref="UInt32"/>.</param>
        /// <param name="maximize">Convert to the maximal and minimal values in <see cref="UInt32"/> or to 1 and 0?</param>
        public static void ConvertTo(this bool toConvert, out UInt32 result, bool maximize = false)
        {
            if (maximize)
            {
                if (toConvert)
                {
                    result = UInt32.MaxValue;
                }
                else
                {
                    result = UInt32.MinValue;
                }
            }
            else
            {
                if (toConvert)
                {
                    result = 1U;
                }
                else
                {
                    result = 0U;
                }
            }
        }

        /// <summary>
        /// Converts the <see cref="bool"/> to an <see cref="Int64"/>.
        /// </summary>
        /// <param name="toConvert">The <see cref="bool"/> to convert.</param>
        /// <param name="result">The <see cref="bool"/> as <see cref="Int64"/>.</param>
        /// <param name="maximize">Convert to the maximal and minimal values in <see cref="Int64"/> or to 1 and 0?</param>
        public static void ConvertTo(this bool toConvert, out Int64 result, bool maximize = false)
        {
            if (maximize)
            {
                if (toConvert)
                {
                    result = Int64.MaxValue;
                }
                else
                {
                    result = Int64.MinValue;
                }
            }
            else
            {
                if (toConvert)
                {
                    result = 1L;
                }
                else
                {
                    result = 0L;
                }
            }
        }

        /// <summary>
        /// Converts the <see cref="bool"/> to an <see cref="UInt64"/>.
        /// </summary>
        /// <param name="toConvert">The <see cref="bool"/> to convert.</param>
        /// <param name="result">The <see cref="bool"/> as <see cref="UInt64"/>.</param>
        /// <param name="maximize">Convert to the maximal and minimal values in <see cref="UInt64"/> or to 1 and 0?</param>
        public static void ConvertTo(this bool toConvert, out UInt64 result, bool maximize = false)
        {
            if (maximize)
            {
                if (toConvert)
                {
                    result = UInt64.MaxValue;
                }
                else
                {
                    result = UInt64.MinValue;
                }
            }
            else
            {
                if (toConvert)
                {
                    result = 1UL;
                }
                else
                {
                    result = 0UL;
                }
            }
        }

        /// <summary>
        /// Converts the <see cref="bool"/> to an <see cref="Single"/>.
        /// </summary>
        /// <param name="toConvert">The <see cref="bool"/> to convert.</param>
        /// <param name="result">The <see cref="bool"/> as <see cref="Single"/>.</param>
        /// <param name="maximize">Convert to the maximal and minimal values in <see cref="Single"/> or to 1F and 0F?</param>
        public static void ConvertTo(this bool toConvert, out Single result, bool maximize = false)
        {
            if (maximize)
            {
                if (toConvert)
                {
                    result = Single.MaxValue;
                }
                else
                {
                    result = Single.MinValue;
                }
            }
            else
            {
                if (toConvert)
                {
                    result = 1F;
                }
                else
                {
                    result = 0F;
                }
            }
        }

        /// <summary>
        /// Converts the <see cref="bool"/> to an <see cref="Double"/>.
        /// </summary>
        /// <param name="toConvert">The <see cref="bool"/> to convert.</param>
        /// <param name="result">The <see cref="bool"/> as <see cref="Double"/>.</param>
        /// <param name="maximize">Convert to the maximal and minimal values in <see cref="Double"/> or to 1D and 0D?</param>
        public static void ConvertTo(this bool toConvert, out Double result, bool maximize = false)
        {
            if (maximize)
            {
                if (toConvert)
                {
                    result = Double.MaxValue;
                }
                else
                {
                    result = Double.MinValue;
                }
            }
            else
            {
                if (toConvert)
                {
                    result = 1D;
                }
                else
                {
                    result = 0D;
                }
            }
        }

        /// <summary>
        /// Counts active bits in the <see cref="Byte"/>.<para/>
        /// Sparse bit counting.
        /// </summary>
        /// <param name="bitField">The <see cref="Byte"/> that gives the bits.</param>
        /// <returns>The number of active bits.</returns>
        public static Int32 CountBits(this Byte bitField)
        {
            Int32 tempBitField = bitField;
            return tempBitField.CountBits();
        }

        /// <summary>
        /// Counts active bits in the <see cref="SByte"/>.<para/>
        /// Sparse bit counting.
        /// </summary>
        /// <param name="bitField">The <see cref="SByte"/> that gives the bits.</param>
        /// <returns>The number of active bits.</returns>
        public static Int32 CountBits(this SByte bitField)
        {
            Int32 tempBitField = bitField;
            return tempBitField.CountBits();
        }

        /// <summary>
        /// Counts active bits in the <see cref="Int16"/>.<para/>
        /// Sparse bit counting.
        /// </summary>
        /// <param name="bitField">The <see cref="Int16"/> that gives the bits.</param>
        /// <returns>The number of active bits.</returns>
        public static Int32 CountBits(this Int16 bitField)
        {
            Int32 tempBitField = bitField;
            return tempBitField.CountBits();
        }

        /// <summary>
        /// Counts active bits in the <see cref="UInt16"/>.<para/>
        /// Sparse bit counting.
        /// </summary>
        /// <param name="bitField">The <see cref="UInt16"/> that gives the bits.</param>
        /// <returns>The number of active bits.</returns>
        public static Int32 CountBits(this UInt16 bitField)
        {
            Int32 tempBitField = bitField;
            return tempBitField.CountBits();
        }

        /// <summary>
        /// Counts active bits in the <see cref="Int32"/>.<para/>
        /// Sparse bit counting.
        /// </summary>
        /// <param name="bitField">The <see cref="Int32"/> that gives the bits.</param>
        /// <returns>The number of active bits.</returns>
        public static Int32 CountBits(this Int32 bitField)
        {
            Int32 count = 0;
            if (bitField < 0)
            {
                bitField &= Int32.MaxValue;
                count++;
            }
            while (bitField != 0)
            {
                count++;
                bitField &= (bitField - 1);
            }
            return count;
        }

        /// <summary>
        /// Counts active bits in the <see cref="Int64"/>.<para/>
        /// Sparse bit counting.
        /// </summary>
        /// <param name="bitField">The <see cref="Int64"/> that gives the bits.</param>
        /// <returns>The number of active bits.</returns>
        public static Int32 CountBits(this Int64 bitField)
        {
            Int32 count = 0;
            if (bitField < 0)
            {
                bitField &= Int64.MaxValue;
                count++;
            }
            while (bitField != 0)
            {
                count++;
                bitField &= (bitField - 1L);
            }
            return count;
        }

        /// <summary>
        /// Counts active bits in the <see cref="UInt64"/>.<para/>
        /// Sparse bit counting.
        /// </summary>
        /// <param name="bitField">The <see cref="UInt64"/> that gives the bits.</param>
        /// <returns>The number of active bits.</returns>
        public static Int32 CountBits(this UInt64 bitField)
        {
            Int32 count = 0;
            while (bitField != 0)
            {
                count++;
                bitField &= (bitField - 1UL);
            }
            return count;
        }

        /// <summary>
        /// Gets the position of the lowest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="lowestBitPosition">The position of the lowest true bit. If all bits are falls -1 is returned!</param>
        public static void LowestBitPosition(this Byte bitField, out sbyte lowestBitPosition)
        {
            if (bitField == 0)
            {
                lowestBitPosition = -1;
            }
            else
            {
                lowestBitPosition = 8;
                while (bitField > 0)
                {
                    lowestBitPosition--;
                    unchecked
                    {
                        bitField <<= 1;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the position of the highest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="highestBitPosition">The position of the highest true bit. If all bits are falls -1 is returned!</param>
        public static void HighestBitPosition(this Byte bitField, out sbyte highestBitPosition)
        {
            highestBitPosition = -1;
            while (bitField > 0)
            {
                highestBitPosition++;
                bitField >>= 1;
            }
        }

        /// <summary>
        /// Gets the position of the lowest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="lowestBitPosition">The position of the lowest true bit. If all bits are false -1 is returned!</param>
        public static void LowestBitPosition(this SByte bitField, out sbyte lowestBitPosition)
        {
            if (bitField == 0)
            {
                lowestBitPosition = -1;
            }
            else
            {
                if (bitField < 0)
                {
                    lowestBitPosition = 7;
                    bitField |= SByte.MaxValue;
                }
                else
                {
                    lowestBitPosition = 8;
                }
                while (bitField > 0)
                {
                    lowestBitPosition--;
                    unchecked
                    {
                        bitField <<= 1;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the position of the highest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="highestBitPosition">The position of the highest true bit. If all bits are false -1 is returned!</param>
        public static void HighestBitPosition(this SByte bitField, out sbyte highestBitPosition)
        {
            if (bitField < 0)
            {
                highestBitPosition = 7;
            }
            else
            {
                highestBitPosition = -1;
                while (bitField > 0)
                {
                    highestBitPosition++;
                    bitField >>= 1;
                }
            }
        }

        /// <summary>
        /// Gets the position of the lowest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="lowestBitPosition">The position of the lowest true bit. If all bits are false -1 is returned!</param>
        public static void LowestBitPosition(this UInt16 bitField, out sbyte lowestBitPosition)
        {
            if (bitField == 0)
            {
                lowestBitPosition = -1;
            }
            else
            {
                lowestBitPosition = 16;
                while (bitField > 0)
                {
                    lowestBitPosition--;
                    unchecked
                    {
                        bitField <<= 1;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the position of the highest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="highestBitPosition">The position of the highest true bit. If all bits are false -1 is returned!</param>
        public static void HighestBitPosition(this UInt16 bitField, out sbyte highestBitPosition)
        {
            highestBitPosition = -1;
            while (bitField > 0)
            {
                highestBitPosition++;
                bitField >>= 1;
            }
        }

        /// <summary>
        /// Gets the position of the lowest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="lowestBitPosition">The position of the lowest true bit. If all bits are false -1 is returned!</param>
        public static void LowestBitPosition(this Int16 bitField, out sbyte lowestBitPosition)
        {
            if (bitField == 0)
            {
                lowestBitPosition = -1;
            }
            else
            {
                if (bitField < 0)
                {
                    lowestBitPosition = 15;
                    bitField |= Int16.MaxValue;
                }
                else
                {
                    lowestBitPosition = 16;
                }
                while (bitField > 0)
                {
                    lowestBitPosition--;
                    unchecked
                    {
                        bitField <<= 1;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the position of the highest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="highestBitPosition">The position of the highest true bit. If all bits are false -1 is returned!</param>
        public static void HighestBitPosition(this Int16 bitField, out sbyte highestBitPosition)
        {
            if (bitField < 0)
            {
                highestBitPosition = 15;
            }
            else
            {
                highestBitPosition = -1;
                while (bitField > 0)
                {
                    highestBitPosition++;
                    bitField >>= 1;
                }
            }
        }

        /// <summary>
        /// Gets the position of the lowest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="lowestBitPosition">The position of the lowest true bit. If all bits are false -1 is returned!</param>
        public static void LowestBitPosition(this UInt32 bitField, out sbyte lowestBitPosition)
        {
            if (bitField == 0)
            {
                lowestBitPosition = -1;
            }
            else
            {
                lowestBitPosition = 32;
                while (bitField > 0)
                {
                    lowestBitPosition--;
                    bitField <<= 1;
                }
            }
        }

        /// <summary>
        /// Gets the position of the highest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="highestBitPosition">The position of the highest true bit. If all bits are false -1 is returned!</param>
        public static void HighestBitPosition(this UInt32 bitField, out sbyte highestBitPosition)
        {
            highestBitPosition = -1;
            while (bitField > 0)
            {
                highestBitPosition++;
                bitField >>= 1;
            }
        }

        /// <summary>
        /// Gets the position of the lowest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="lowestBitPosition">The position of the lowest true bit. If all bits are false -1 is returned!</param>
        public static void LowestBitPosition(this Int32 bitField, out sbyte lowestBitPosition)
        {
            if (bitField == 0)
            {
                lowestBitPosition = -1;
            }
            else
            {
                if (bitField < 0)
                {
                    lowestBitPosition = 31;
                    bitField |= Int32.MaxValue;
                }
                else
                {
                    lowestBitPosition = 32;
                }
                while (bitField > 0)
                {
                    lowestBitPosition--;
                    unchecked
                    {
                        bitField <<= 1;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the position of the highest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="highestBitPosition">The position of the highest true bit. If all bits are false -1 is returned!</param>
        public static void HighestBitPosition(this Int32 bitField, out sbyte highestBitPosition)
        {
            if (bitField < 0)
            {
                highestBitPosition = 31;
            }
            else
            {
                highestBitPosition = -1;
                while (bitField > 0)
                {
                    highestBitPosition++;
                    bitField >>= 1;
                }
            }
        }

        /// <summary>
        /// Gets the position of the lowest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="lowestBitPosition">The position of the lowest true bit. If all bits are false -1 is returned!</param>
        public static void LowestBitPosition(this UInt64 bitField, out sbyte lowestBitPosition)
        {
            if (bitField == 0)
            {
                lowestBitPosition = -1;
            }
            else
            {
                lowestBitPosition = 64;
                while (bitField > 0)
                {
                    lowestBitPosition--;
                    unchecked
                    {
                        bitField <<= 1;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the position of the highest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="highestBitPosition">The position of the highest true bit. If all bits are false -1 is returned!</param>
        public static void HighestBitPosition(this UInt64 bitField, out sbyte highestBitPosition)
        {
            highestBitPosition = -1;
            while (bitField > 0)
            {
                highestBitPosition++;
                bitField >>= 1;
            }
        }

        /// <summary>
        /// Gets the position of the lowest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="lowestBitPosition">The position of the lowest true bit. If all bits are false -1 is returned!</param>
        public static void LowestBitPosition(this Int64 bitField, out sbyte lowestBitPosition)
        {
            if (bitField == 0)
            {
                lowestBitPosition = -1;
            }
            else
            {
                if (bitField < 0)
                {
                    lowestBitPosition = 31;
                    bitField |= Int64.MaxValue;
                }
                else
                {
                    lowestBitPosition = 32;
                }
                while (bitField > 0)
                {
                    lowestBitPosition--;
                    unchecked
                    {
                        bitField <<= 1;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the position of the highest bit that is true.
        /// </summary>
        /// <param name="bitField">The bit field there the lowest bit is in.</param>
        /// <param name="highestBitPosition">The position of the highest true bit. If all bits are false -1 is returned!</param>
        public static void HighestBitPosition(this Int64 bitField, out sbyte highestBitPosition)
        {
            if (bitField < 0)
            {
                highestBitPosition = 63;
            }
            else
            {
                highestBitPosition = -1;
                while (bitField > 0)
                {
                    highestBitPosition++;
                    bitField >>= 1;
                }
            }
        }

        /// <summary>
        /// Creates a simple <see cref="Byte"/> bit-mask for usage of masking.
        /// </summary>
        /// <param name="onesAmount">Amout of ones.</param>
        /// <param name="mask">The result <see cref="Byte"/> bit-mask.</param>
        public static void CreateSimpleMask(this byte onesAmount, out Byte mask)
        {
            if (onesAmount > 7)
            {
                mask = Byte.MaxValue;
            }
            else if (onesAmount < 1)
            {
                mask = Byte.MinValue;
            }
            else
            {
                mask = (Byte)((1 << onesAmount) - 1);
            }
        }

        /// <summary>
        /// Creates a simple <see cref="SByte"/> bit-mask for usage of masking.
        /// </summary>
        /// <param name="onesAmount">Amout of ones.</param>
        /// <param name="mask">The result <see cref="SByte"/> bit-mask.</param>
        public static void CreateSimpleMask(this byte onesAmount, out SByte mask)
        {
            if (onesAmount > 7)
            {
                mask = SByte.MinValue;
            }
            else if (onesAmount == 7)
            {
                mask = SByte.MaxValue;
            }
            else if (onesAmount < 1)
            {
                mask = 0;
            }
            else
            {
                mask = (SByte)((1 << onesAmount) - 1);
            }
        }

        /// <summary>
        /// Creates a simple <see cref="UInt16"/> bit-mask for usage of masking.
        /// </summary>
        /// <param name="onesAmount">Amout of ones.</param>
        /// <param name="mask">The result <see cref="UInt16"/> bit-mask.</param>
        public static void CreateSimpleMask(this byte onesAmount, out UInt16 mask)
        {
            if (onesAmount > 15)
            {
                mask = UInt16.MaxValue;
            }
            else if (onesAmount < 1)
            {
                mask = UInt16.MinValue;
            }
            else
            {
                mask = (UInt16)((1 << onesAmount) - 1);
            }
        }

        /// <summary>
        /// Creates a simple <see cref="Int16"/> bit-mask for usage of masking.
        /// </summary>
        /// <param name="onesAmount">Amout of ones.</param>
        /// <param name="mask">The result <see cref="Int16"/> bit-mask.</param>
        public static void CreateSimpleMask(this byte onesAmount, out Int16 mask)
        {
            if (onesAmount > 15)
            {
                mask = Int16.MinValue;
            }
            else if (onesAmount == 15)
            {
                mask = Int16.MaxValue;
            }
            else if (onesAmount < 1)
            {
                mask = 0;
            }
            else
            {
                mask = (Int16)((1 << onesAmount) - 1);
            }
        }

        /// <summary>
        /// Creates a simple <see cref="UInt32"/> bit-mask for usage of masking.
        /// </summary>
        /// <param name="onesAmount">Amout of ones.</param>
        /// <param name="mask">The result <see cref="UInt32"/> bit-mask.</param>
        public static void CreateSimpleMask(this byte onesAmount, out UInt32 mask)
        {
            if (onesAmount > 31)
            {
                mask = UInt32.MaxValue;
            }
            else if (onesAmount < 1)
            {
                mask = UInt32.MinValue;
            }
            else
            {
                mask = ((1U << onesAmount) - 1U);
            }
        }

        /// <summary>
        /// Creates a simple <see cref="Int32"/> bit-mask for usage of masking.
        /// </summary>
        /// <param name="onesAmount">Amout of ones.</param>
        /// <param name="mask">The result <see cref="Int32"/> bit-mask.</param>
        public static void CreateSimpleMask(this byte onesAmount, out Int32 mask)
        {
            if (onesAmount > 31)
            {
                mask = Int32.MinValue;
            }
            else if (onesAmount == 31)
            {
                mask = Int32.MaxValue;
            }
            else if (onesAmount < 1)
            {
                mask = 0;
            }
            else
            {
                mask = ((1 << onesAmount) - 1);
            }
        }

        /// <summary>
        /// Creates a simple <see cref="UInt64"/> bit-mask for usage of masking.
        /// </summary>
        /// <param name="onesAmount">Amout of ones.</param>
        /// <param name="mask">The result <see cref="UInt64"/> bit-mask.</param>
        public static void CreateSimpleMask(this byte onesAmount, out UInt64 mask)
        {
            if (onesAmount > 63)
            {
                mask = UInt64.MaxValue;
            }
            else if (onesAmount < 1)
            {
                mask = UInt64.MinValue;
            }
            else
            {
                mask = (1UL << onesAmount) - 1UL;
            }
        }

        /// <summary>
        /// Creates a simple <see cref="Int64"/> bit-mask for usage of masking.
        /// </summary>
        /// <param name="onesAmount">Amout of ones.</param>
        /// <param name="mask">The result <see cref="Int64"/> bit-mask.</param>
        public static void CreateSimpleMask(this byte onesAmount, out Int64 mask)
        {
            if (onesAmount > 63)
            {
                mask = Int64.MinValue;
            }
            else if (onesAmount == 63)
            {
                mask = Int64.MaxValue;
            }
            else if (onesAmount < 1)
            {
                mask = 0L;
            }
            else
            {
                mask = ((1L << onesAmount) - 1L);
            }
        }

        /// <summary>
        /// Counts the true bits in a <see cref="BitArray"/>.
        /// </summary>
        /// <param name="bitArray">The <see cref="BitArray"/> where the bits needs to be counted.</param>
        /// <returns>Count of bits which are true.</returns>
        public static Int32 GetCardinality(BitArray bitArray)
        {
            Int32 resultCount = 0;
            if (bitArray != null && bitArray.Length > 0)
            {
                Int32[] ints = new Int32[(bitArray.Count >> 5) + 1];

                bitArray.CopyTo(ints, 0);

                // fix for not truncated bits in last integer that may have been set to true with SetAll()
                ints[ints.Length - 1] &= ~(-1 << (bitArray.Count % 32));

                resultCount = GetCardinality(ints)[0];
            }
            return resultCount;
        }

        /// <summary>
        /// Counts the true bits in a Byte <see cref="Array"/>.
        /// </summary>
        /// <param name="bitArray">The Byte <see cref="Array"/> where the bits needs to be counted.</param>
        /// <returns>Count of bits which are true.</returns>
        public static Int32[] GetCardinality(Byte[] bitArray)
        {
            Int32[] resultCountArray = new Int32[1];
            resultCountArray[0] = 0;
            if (bitArray != null && bitArray.Length > 0)
            {
                //Reserve data space
                Int32[] ints;
                if ((bitArray.Length % 4) > 0)
                {
                    ints = new Int32[(bitArray.Length / 4) + 1];
                }
                else
                {
                    ints = new Int32[bitArray.Length / 4];
                }

                //Convert internal to Int32[] type
                int currentByte = 0;
                while (currentByte < bitArray.Length)
                {
                    ints[currentByte / 4] = bitArray[currentByte] << ((currentByte % 4) * 8);
                    currentByte++;
                }
                resultCountArray = GetCardinality(ints);
            }
            return resultCountArray;

        }

        /// <summary>
        /// Counts the true bits in an Int32 <see cref="Array"/>.
        /// </summary>
        /// <param name="bitArray">The Int32 <see cref="Array"/> where the bits needs to be counted.</param>
        /// <returns>Count of bits which are true.</returns>
        public static Int32[] GetCardinality(Int32[] bitArray)
        {
            Int32[] resultCountArray = new Int32[1];
            resultCountArray[0] = 0;
            if (bitArray != null && bitArray.Length > 0)
            {
                //Reserve data space
                if (bitArray.Length / 67108863 > 0)
                {
                    resultCountArray = new Int32[2];
                }
                else
                {
                    resultCountArray = new Int32[1];
                }


                //count
                for (Int32 i = 0; i < bitArray.Length; i++)
                {

                    Int32 c = bitArray[i];

                    // magic (http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel)
                    unchecked
                    {
                        c = c - ((c >> 1) & 0x55555555);
                        c = (c & 0x33333333) + ((c >> 2) & 0x33333333);
                        c = ((c + (c >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
                    }

                    if (Int32.MaxValue - resultCountArray[0] - c <= 0)
                    {
                        resultCountArray[1]++;
                        resultCountArray[0] += (Int32.MinValue + 1) + c;
                    }
                    else
                    {
                        resultCountArray[0] += c;
                    }
                }
            }
            return resultCountArray;
        }

        /// <summary>
        /// Converts a <see cref="Byte"/> <see cref="Array"/> to a <see cref="BitArray"/>.<para />
        /// The true length gives the maximal amount of bits that are getting converted.
        /// </summary>
        /// <param name="toConvert">The <see cref="Byte"/> <see cref="Array"/> that gets converted.</param>
        /// <param name="trueLength">The number of bits that are getting converted maximal.</param>
        /// <returns>The <see cref="Byte"/> <see cref="Array"/> as <see cref="BitArray"/>.
        /// <error><ArgumentOutOfRangeException><see cref="BitArray"/> like any other <see cref="Array"/> doesn't support a negative length value!</ArgumentOutOfRangeException></error></returns>
        public static BitArray ToBitArray(this Byte[] toConvert, int trueLength)
        {
            if (trueLength < 0)
            {
                throw new ArgumentOutOfRangeException("trueLength", "BitArray as any other array doesn't support a megative length value!");
            }
            BitArray result = null;
            if (toConvert != null)
            {
                result = new BitArray(toConvert);
                if (result.Count > trueLength)
                {
                    result.Length = trueLength;
                }
            }
            return result;
        }

        /// <summary>
        /// Converts a <see cref="BitArray"/> to a byte array.
        /// </summary>
        /// <param name="toConvert">The <see cref="BitArray"/> that gets converted.</param>
        /// <returns>The <see cref="BitArray"/> as <see cref="Byte"/> <see cref="Array"/>.</returns>
        public static Byte[] ToByteArray(this BitArray toConvert)
        {
            Byte[] result = null;
            if (toConvert != null)
            {
                int numberOfBytes = toConvert.Count / 8;
                if (toConvert.Count % 8 != 0)
                {
                    numberOfBytes++;
                }
                result = new Byte[numberOfBytes];
                int bitIndex = 0;
                int byteIndex = 0;
                byte bitPos = 0;
                while (bitIndex < toConvert.Count)
                {
                    if (toConvert[bitIndex])
                    {
                        result[byteIndex] |= (Byte)(1 << (7 - bitPos));
                    }
                    bitPos++;
                    if (bitPos > 7)
                    {
                        bitIndex = 0;
                        byteIndex++;
                    }
                    bitIndex++;
                }
            }
            return result;
        }
    }
}