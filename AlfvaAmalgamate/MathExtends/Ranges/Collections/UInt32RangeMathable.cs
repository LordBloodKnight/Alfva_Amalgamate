using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using ScottGarland;
using AlfvaAmalgamate.MathExtends.Ranges.Generic;
using AlfvaAmalgamate.Integers;

/// <summary>
/// Holds the collection of ranges that can be used with range maths.
/// </summary>
namespace AlfvaAmalgamate.MathExtends.Ranges.Collections
{
    /// <summary>
    /// Mathematicaly range for <see cref="UInt32"/>s.
    /// </summary>
    public struct UInt32RangeMathable : IRangeMathableSingleSize<UInt32, BigInteger>
    {
        /// <summary>
        /// Holds the range of this <see cref="UInt32RangeMathable"/>
        /// </summary>
        private Range<UInt32> TheRange;

        /// <summary>
        /// Gets or sets the start bound of this <see cref="UInt32RangeMathable"/>.
        /// </summary>
        /// <value><see cref="Range{UInt32}._StartBound"/> on <see cref="TheRange"/></value>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="StartBound"/> isn't allowed to be higher than the <see cref="EndBound"/>!</exception>
        public UInt32 StartBound
        {
            get
            {
                return TheRange.StartBound;
            }
            set
            {
                TheRange.StartBound = value;
            }
        }

        /// <summary>
        /// Gets or sets the end bound of this <see cref="UInt32RangeMathable"/>.
        /// </summary>
        /// <value><see cref="Range{UInt32}._EndBound"/> on <see cref="TheRange"/></value>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="EndBound"/> isn't allowed to be lower than the <see cref="StartBound"/>!</exception>
        public UInt32 EndBound
        {
            get
            {
                return TheRange.EndBound;
            }
            set
            {
                TheRange.EndBound = value;
            }
        }

        /// <summary>
        /// Gets or sets the state of this <see cref="UInt32RangeMathable"/> if it is empty.
        /// </summary>
        /// <value><see cref="Range{UInt32}._EmptyRange"/> on <see cref="TheRange"/></value>
        public bool EmptyRange
        {
            get
            {
                return TheRange.EmptyRange;
            }
            set
            {
                TheRange.EmptyRange = value;
            }
        }

        /// <summary>
        /// Constructor of this <see cref="UInt32RangeMathable"/>.
        /// </summary>
        /// <param name="startBound">The starting bound.</param>
        /// <param name="endBound">The ending bound.</param>
        /// <param name="emptyRange">Is the range to small to hold any range?</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startBound"/> value is bigger than the <paramref name="endBound"/> value!</exception>
        public UInt32RangeMathable(bool emptyRange = true, UInt32 startBound = default(UInt32), UInt32 endBound = default(UInt32))
        {
            TheRange = new Range<UInt32>(emptyRange, startBound, endBound);
        }

        /// <summary>
        /// Compares where the given <see cref="RangeValueType"/> is to the range.
        /// </summary>
        /// <param name="other">The point to compare to the range.</param>
        /// <returns>Return can be {-1; 0; 1}. -1 equals (given <see cref="UInt32"/> under the range); 0 equals (given <see cref="UInt32"/> in the range) or 1 equals (given <see cref="UInt32"/> over the range).</returns>
        public int CompareTo(UInt32 other)
        {
            return TheRange.CompareTo(other);
        }

        /// <summary>
        /// Gets the size of this <see cref="UInt32RangeMathable"/>.
        /// </summary>
        /// <returns>The size!</returns>
        public BigInteger RangeSize()
        {
            return new BigInteger((Int64)TheRange.EndBound - TheRange.StartBound + 1);
        }

        /// <summary>
        /// Combines this range with the given range <paramref name="toCombine"/> based on the given <see cref="RangeCombination"/>.
        /// </summary>
        /// <param name="toCombine">The other range to combine with.</param>
        /// <param name="combinationType">How to combine the 2 ranges.</param>
        /// <param name="whatToDoWithResults">What to do with the result?</param>
        /// <returns>Result <see cref="IRangeMathable{UInt32, UInt32}"/>s.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="combinationType"/> is not a valid <see cref="RangeCombination"/> value!</exception>
        public IRangeMathableSingleSize<UInt32, BigInteger>[] Combine(IRangeMathableSingleSize<UInt32, BigInteger> toCombine, RangeCombination combinationType, RangeMathematicResultUseage whatToDoWithResults)
        {
            IRangeMathableSingleSize<UInt32, BigInteger>[] result;
            if (toCombine == null)
            {
                result = new IRangeMathableSingleSize<UInt32, BigInteger>[1];
                switch (combinationType)
                {
                    case RangeCombination.Difference:
                    case RangeCombination.Union:
                        result[0] = new UInt32RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound);
                        break;
                    case RangeCombination.Intersect:
                        result[0] = default(UInt32RangeMathable);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("The combinationType is not a valid RangeCombinations value!");
                }
            }
            else
            {
                int comparationResult = CompareTo(toCombine);
                switch (combinationType)
                {
                    case RangeCombination.Difference:
                        if (TheRange.EmptyRange)
                        {
                            result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { new UInt32RangeMathable(toCombine.EmptyRange, toCombine.StartBound, toCombine.EndBound) };
                        }
                        else if (toCombine.EmptyRange)
                        {
                            result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { new UInt32RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound) };
                        }
                        else
                        {
                            if (comparationResult == 0)
                            {
                                result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { new UInt32RangeMathable(true, 0, 0) };
                            }
                            else
                            {
                                if (TheRange.EndBound < toCombine.EndBound)
                                {
                                    result = new IRangeMathableSingleSize<UInt32, BigInteger>[2];
                                    Int64 tempNewBound = (Int64)toCombine.StartBound - 1;
                                    if (tempNewBound <= TheRange.StartBound)
                                    {
                                        result[0] = new UInt32RangeMathable(true, TheRange.StartBound, TheRange.StartBound);
                                    }
                                    else
                                    {
                                        result[0] = new UInt32RangeMathable(false, TheRange.StartBound, (UInt32)tempNewBound);
                                    }
                                    tempNewBound = (Int64)TheRange.EndBound + 1;
                                    if (tempNewBound >= toCombine.EndBound)
                                    {
                                        result[1] = new UInt32RangeMathable(true, toCombine.EndBound, toCombine.EndBound);
                                    }
                                    else
                                    {
                                        result[1] = new UInt32RangeMathable(false, (UInt32)tempNewBound, toCombine.EndBound);
                                    }
                                }
                                else
                                {
                                    Int64 newEndBound = (Int64)toCombine.StartBound - 1;
                                    if (newEndBound <= TheRange.StartBound)
                                    {
                                        result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { new UInt32RangeMathable(true, TheRange.StartBound, TheRange.StartBound) };
                                    }
                                    else
                                    {
                                        result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { new UInt32RangeMathable(false, TheRange.StartBound, (UInt32)newEndBound) };
                                    }
                                }
                            }
                        }
                        break;
                    case RangeCombination.Intersect:
                        result = new IRangeMathableSingleSize<UInt32, BigInteger>[1];
                        if (TheRange.EmptyRange || toCombine.EmptyRange)
                        {
                            result[0] = default(UInt32RangeMathable);
                        }
                        else
                        {
                            switch (comparationResult)
                            {
                                case -1:
                                    if (toCombine.StartBound > UInt32.MinValue && TheRange.EndBound < ((Int64)toCombine.StartBound - 1))
                                    {
                                        result[0] = default(UInt32RangeMathable);
                                    }
                                    else
                                    {
                                        if (TheRange.EndBound > toCombine.EndBound)
                                        {
                                            result[0] = new UInt32RangeMathable(false, toCombine.StartBound, toCombine.EndBound);
                                        }
                                        else
                                        {
                                            result[0] = new UInt32RangeMathable(false, toCombine.StartBound, TheRange.EndBound);
                                        }
                                    }
                                    break;
                                case 0:
                                    result[0] = new UInt32RangeMathable(false, TheRange.StartBound, TheRange.EndBound);
                                    break;
                                case 1:
                                    if (TheRange.StartBound < UInt32.MinValue && toCombine.EndBound < ((Int64)TheRange.StartBound - 1))
                                    {
                                        result[0] = default(UInt32RangeMathable);
                                    }
                                    else
                                    {
                                        if (toCombine.EndBound > TheRange.EndBound)
                                        {
                                            result[0] = new UInt32RangeMathable(false, toCombine.StartBound, toCombine.EndBound);
                                        }
                                        else
                                        {
                                            result[0] = new UInt32RangeMathable(false, toCombine.StartBound, TheRange.EndBound);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    case RangeCombination.Union:
                        if (TheRange.EmptyRange && toCombine.EmptyRange)
                        {
                            result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { default(UInt32RangeMathable) };
                        }
                        else
                        {
                            switch (comparationResult)
                            {
                                case -1:
                                    if (TheRange.EmptyRange)
                                    {
                                        result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { new UInt32RangeMathable(toCombine.EmptyRange, toCombine.StartBound, toCombine.EndBound) };
                                    }
                                    else if (toCombine.EmptyRange)
                                    {
                                        result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { new UInt32RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound) };
                                    }
                                    else
                                    {
                                        if (TheRange.EndBound < UInt32.MaxValue && ((Int64)TheRange.EndBound + 1) < toCombine.StartBound)
                                        {
                                            result = new IRangeMathableSingleSize<UInt32, BigInteger>[2];
                                            result[0] = new UInt32RangeMathable(false, TheRange.StartBound, TheRange.EndBound);
                                            result[1] = new UInt32RangeMathable(false, toCombine.StartBound, toCombine.EndBound);
                                        }
                                        else
                                        {
                                            result = new IRangeMathableSingleSize<UInt32, BigInteger>[1];
                                            if (TheRange.EndBound <= toCombine.EndBound)
                                            {
                                                result[0] = new UInt32RangeMathable(false, TheRange.StartBound, toCombine.EndBound);
                                            }
                                            else
                                            {
                                                result[0] = new UInt32RangeMathable(false, TheRange.StartBound, TheRange.EndBound);
                                            }
                                        }
                                    }
                                    break;
                                case 0:
                                    result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { new UInt32RangeMathable(false, TheRange.StartBound, TheRange.EndBound) };
                                    break;
                                case 1:
                                    if (TheRange.EmptyRange)
                                    {
                                        result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { new UInt32RangeMathable(toCombine.EmptyRange, toCombine.StartBound, toCombine.EndBound) };
                                    }
                                    else if (toCombine.EmptyRange)
                                    {
                                        result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { new UInt32RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound) };
                                    }
                                    else
                                    {
                                        if (toCombine.EndBound < UInt32.MaxValue && TheRange.StartBound < ((Int64)toCombine.EndBound + 1))
                                        {
                                            result = new IRangeMathableSingleSize<UInt32, BigInteger>[2];
                                            result[1] = new UInt32RangeMathable(false, toCombine.StartBound, toCombine.EndBound);
                                            result[0] = new UInt32RangeMathable(false, TheRange.StartBound, TheRange.EndBound);
                                        }
                                        else
                                        {
                                            result = new IRangeMathableSingleSize<UInt32, BigInteger>[1];
                                            if (TheRange.EndBound >= toCombine.EndBound)
                                            {
                                                result[0] = new UInt32RangeMathable(false, toCombine.StartBound, TheRange.EndBound);
                                            }
                                            else
                                            {
                                                result[0] = new UInt32RangeMathable(false, toCombine.StartBound, toCombine.EndBound);
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        result = new IRangeMathableSingleSize<UInt32, BigInteger>[1] { new UInt32RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound) };
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("The combinationType is not a valid RangeCombinations value!");
                }
            }
            // working with the result to do the wanted actions
            if ((whatToDoWithResults & RangeMathematicResultUseage.UseLowestResultRangeOnOwnRange) > 0)
            {
                if (result[0].StartBound > TheRange.EndBound)
                {
                    TheRange.EndBound = result[0].EndBound;
                    TheRange.StartBound = result[0].StartBound;
                }
                else
                {
                    TheRange.StartBound = result[0].StartBound;
                    TheRange.EndBound = result[0].EndBound;
                }
                TheRange.EmptyRange = result[0].EmptyRange;
            }
            else if ((whatToDoWithResults & RangeMathematicResultUseage.UseHighestResultRangeOnOwnRange) > 0)
            {
                int targetPosition = result.Length - 1;
                if (result[targetPosition].StartBound > TheRange.EndBound)
                {
                    TheRange.EndBound = result[targetPosition].EndBound;
                    TheRange.StartBound = result[targetPosition].StartBound;
                }
                else
                {
                    TheRange.StartBound = result[targetPosition].StartBound;
                    TheRange.EndBound = result[targetPosition].EndBound;
                }
                TheRange.EmptyRange = result[targetPosition].EmptyRange;
            }
            return result;
        }

        /// <summary>
        /// Splits the range on the given <paramref name="splitPoint"/>.
        /// </summary>
        /// <param name="splitPoint">The point on the range to split it.</param>
        /// <param name="includeSplitPointToUpperRange">Which range gets the <paramref name="splitPoint"/>?</param>
        /// <param name="whatToDoWithResults">What to do with the result?</param>
        /// <returns>Result <see cref="IRangeMathableSingleSize{UInt32, BigInteger}"/>s.</returns>
        public IRangeMathableSingleSize<UInt32, BigInteger>[] Split(UInt32 splitPoint, bool includeSplitPointToUpperRange, RangeMathematicResultUseage whatToDoWithResults)
        {
            IRangeMathableSingleSize<UInt32, BigInteger>[] result;
            if (TheRange.EmptyRange)
            {
                result = new IRangeMathableSingleSize<UInt32, BigInteger>[2] { default(UInt32RangeMathable), default(UInt32RangeMathable) };
            }
            else
            {
                result = new IRangeMathableSingleSize<UInt32, BigInteger>[2];
                switch (TheRange.CompareTo(splitPoint))
                {
                    case -1:
                        result[0] = new UInt32RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound);
                        result[1] = default(UInt32RangeMathable);
                        break;
                    case 0:
                        if (includeSplitPointToUpperRange)
                        {
                            if (TheRange.StartBound == TheRange.EndBound || TheRange.StartBound == splitPoint)
                            {
                                result[0] = default(UInt32RangeMathable);
                                result[1] = new UInt32RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound);
                            }
                            else
                            {
                                result[0] = new UInt32RangeMathable(TheRange.EmptyRange, TheRange.StartBound, (UInt32)(splitPoint - 1));
                                result[1] = new UInt32RangeMathable(TheRange.EmptyRange, splitPoint, TheRange.EndBound);
                            }
                        }
                        else
                        {
                            if (TheRange.StartBound == TheRange.EndBound || TheRange.EndBound == splitPoint)
                            {
                                result[0] = new UInt32RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound);
                                result[1] = default(UInt32RangeMathable);
                            }
                            else
                            {
                                result[0] = new UInt32RangeMathable(TheRange.EmptyRange, TheRange.StartBound, splitPoint);
                                result[1] = new UInt32RangeMathable(TheRange.EmptyRange, (UInt32)(splitPoint + 1), TheRange.EndBound);
                            }
                        }
                        break;
                    case 1:
                        result[0] = default(UInt32RangeMathable);
                        result[1] = new UInt32RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound);
                        break;
                }
            }
            // working with the result to do the wanted actions
            if ((whatToDoWithResults & RangeMathematicResultUseage.UseLowestResultRangeOnOwnRange) > 0)
            {
                if (result[0].StartBound > TheRange.EndBound)
                {
                    TheRange.EndBound = result[0].EndBound;
                    TheRange.StartBound = result[0].StartBound;
                }
                else
                {
                    TheRange.StartBound = result[0].StartBound;
                    TheRange.EndBound = result[0].EndBound;
                }
                TheRange.EmptyRange = result[0].EmptyRange;
            }
            else if ((whatToDoWithResults & RangeMathematicResultUseage.UseHighestResultRangeOnOwnRange) > 0)
            {
                if (result[1].StartBound > TheRange.EndBound)
                {
                    TheRange.EndBound = result[1].EndBound;
                    TheRange.StartBound = result[1].StartBound;
                }
                else
                {
                    TheRange.StartBound = result[1].StartBound;
                    TheRange.EndBound = result[1].EndBound;
                }
                TheRange.EmptyRange = result[1].EmptyRange;
            }
            return result;
        }

        /// <summary>
        /// Splits the range in nearly equal sized ranges.
        /// </summary>
        /// <param name="includeOddToUpperRange">If the range range is odd where to add the element on the split to?</param>
        /// <param name="whatToDoWithResults">What to do with the result?</param>
        /// <returns>Result <see cref="IRangeMathable{UInt32, BigInteger}"/>s.</returns>
        public IRangeMathableSingleSize<UInt32, BigInteger>[] Split(bool includeOddToUpperRange, RangeMathematicResultUseage whatToDoWithResults)
        {
            IRangeMathableSingleSize<UInt32, BigInteger>[] result = new IRangeMathableSingleSize<UInt32, BigInteger>[2];
            Int64 tempSize = BigInteger.ToInt64(RangeSize());
            switch (tempSize.CompareTo(1L))
            {
                case -1:
                    result[0] = default(UInt32RangeMathable);
                    result[1] = default(UInt32RangeMathable);
                    break;
                case 0:
                    if (includeOddToUpperRange)
                    {
                        result[0] = default(UInt32RangeMathable);
                        result[1] = new UInt32RangeMathable(true, TheRange.StartBound, TheRange.EndBound);
                    }
                    else
                    {
                        result[0] = new UInt32RangeMathable(true, TheRange.StartBound, TheRange.EndBound);
                        result[1] = default(UInt32RangeMathable);
                    }
                    break;
                case 1:
                    bool storedOddBit = (tempSize & 1) == 1;
                    Int64 halfSize = tempSize >> 1;
                    if (storedOddBit)
                    {
                        if (halfSize > 0)
                        {
                            if (includeOddToUpperRange)
                            {
                                result[0] = new UInt32RangeMathable(false, TheRange.StartBound, (UInt32)(TheRange.StartBound + halfSize - 1));
                                result[1] = new UInt32RangeMathable(false, (UInt32)(TheRange.EndBound - halfSize), TheRange.EndBound);
                            }
                            else
                            {
                                result[0] = new UInt32RangeMathable(false, TheRange.StartBound, (UInt32)(TheRange.StartBound + halfSize));
                                result[1] = new UInt32RangeMathable(false, (UInt32)(TheRange.EndBound - halfSize + 1), TheRange.EndBound);
                            }
                        }
                        else
                        {
                            if (includeOddToUpperRange)
                            {
                                result[0] = default(UInt32RangeMathable);
                                result[1] = new UInt32RangeMathable(false, TheRange.EndBound, TheRange.EndBound);
                            }
                            else
                            {
                                result[0] = new UInt32RangeMathable(false, TheRange.StartBound, TheRange.StartBound);
                                result[1] = default(UInt32RangeMathable);
                            }
                        }
                    }
                    else
                    {
                        if (halfSize > 0)
                        {
                            result[0] = new UInt32RangeMathable(false, TheRange.StartBound, (UInt32)(TheRange.StartBound + halfSize - 1));
                            result[1] = new UInt32RangeMathable(false, (UInt32)(TheRange.EndBound - halfSize + 1), TheRange.EndBound);
                        }
                        else
                        {
                            result[0] = default(UInt32RangeMathable);
                            result[1] = default(UInt32RangeMathable);
                        }
                    }
                    break;
            }
            // working with the result to do the wanted actions
            if ((whatToDoWithResults & RangeMathematicResultUseage.UseLowestResultRangeOnOwnRange) > 0)
            {
                if (result[0].StartBound > TheRange.EndBound)
                {
                    TheRange.EndBound = result[0].EndBound;
                    TheRange.StartBound = result[0].StartBound;
                }
                else
                {
                    TheRange.StartBound = result[0].StartBound;
                    TheRange.EndBound = result[0].EndBound;
                }
                TheRange.EmptyRange = result[0].EmptyRange;
            }
            else if ((whatToDoWithResults & RangeMathematicResultUseage.UseHighestResultRangeOnOwnRange) > 0)
            {
                if (result[1].StartBound > TheRange.EndBound)
                {
                    TheRange.EndBound = result[1].EndBound;
                    TheRange.StartBound = result[1].StartBound;
                }
                else
                {
                    TheRange.StartBound = result[1].StartBound;
                    TheRange.EndBound = result[1].EndBound;
                }
                TheRange.EmptyRange = result[1].EmptyRange;
            }
            return result;
        }

        /// <summary>
        /// Compares where the given <see cref="IRangeMathableSingleSize{UInt32, BigInteger}"/> is to this <see cref="UInt32RangeMathable"/>.
        /// </summary>
        /// <param name="other">The <see cref="IRangeMathableSingleSize{UInt32, BigInteger}"/> to compare to this <see cref="UInt32RangeMathable"/>.</param>
        /// <returns>Return can be {-1; 0; 1}.<para/>
        /// -1 on:<para />
        /// - The <paramref name="other"/> is null.<para />
        /// - The <paramref name="other"/> range is the only range that is <see cref="IRange{UInt32}.EmptyRange"/> equal true.<para />
        /// - This <see cref="UInt32RangeMathable"/> range comes before the <paramref name="other"/> range.<para />
        /// - This <see cref="UInt32RangeMathable"/> range starts equaly but ends before the <paramref name="other"/> range.<para />
        /// 0 on:<para />
        /// - Both ranges are <see cref="IRange{UInt32}.EmptyRange"/> equal true.<para />
        /// - Both ranges are equaly in size and position.<para />
        /// 1 on:<para />
        /// - This <see cref="UInt32RangeMathable"/> range is the only range that is <see cref="IRange{UInt32}.EmptyRange"/> equal true.
        /// - The <paramref name="other"/> range comes before this <see cref="UInt32RangeMathable"/> range.<para />
        /// - The <paramref name="other"/> range starts equaly but ends before this <see cref="UInt32RangeMathable"/> range.<para />
        /// </returns>
        public int CompareTo(IRangeMathableSingleSize<UInt32, BigInteger> other)
        {
            int result;
            if (other == null)
            {
                result = -1;
            }
            else
            {
                if (other.EmptyRange)
                {
                    if (TheRange.EmptyRange)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = -1;
                    }
                }
                else
                {
                    if (TheRange.EmptyRange)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = TheRange.CompareTo(other.StartBound);
                        if (result == 0)
                        {
                            result = TheRange.EndBound.CompareTo(other.EndBound);
                        }
                    }
                }
            }
            return result;
        }
    }
}