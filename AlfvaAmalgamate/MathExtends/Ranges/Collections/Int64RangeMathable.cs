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
    /// Mathmaticaly range for <see cref="Int64"/>s.
    /// </summary>
    public struct Int64RangeMathable : IRangeMathableSingleSize<Int64, BigInteger>
    {
        /// <summary>
        /// Holds the range of this <see cref="Int64RangeMathable"/>
        /// </summary>
        private Range<Int64> TheRange;

        /// <summary>
        /// Gets or sets the start bound of this <see cref="Int64RangeMathable"/>.
        /// </summary>
        /// <value><see cref="Range{Int64}._StartBound"/> on <see cref="TheRange"/></value>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="StartBound"/> isn't allowed to be higher than the <see cref="EndBound"/>!</exception>
        public Int64 StartBound
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
        /// Gets or sets the end bound of this <see cref="Int64RangeMathable"/>.
        /// </summary>
        /// <value><see cref="Range{Int64}._EndBound"/> on <see cref="TheRange"/></value>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="EndBound"/> isn't allowed to be lower than the <see cref="StartBound"/>!</exception>
        public Int64 EndBound
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
        /// Gets or sets the state of this <see cref="Int64RangeMathable"/> if it is empty.
        /// </summary>
        /// <value><see cref="Range{Int64}._EmptyRange"/> on <see cref="TheRange"/></value>
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
        /// Constructor of this <see cref="Int64RangeMathable"/>.
        /// </summary>
        /// <param name="startBound">The starting bound.</param>
        /// <param name="endBound">The ending bound.</param>
        /// <param name="emptyRange">Is the range to small to hold any range?</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startBound"/> value is bigger than the <paramref name="endBound"/> value!</exception>
        public Int64RangeMathable(bool emptyRange = true, Int64 startBound = default(Int64), Int64 endBound = default(Int64))
        {
            TheRange = new Range<Int64>(emptyRange, startBound, endBound);
        }

        /// <summary>
        /// Compares where the given <see cref="RangeValueType"/> is to the range.
        /// </summary>
        /// <param name="other">The point to compare to the range.</param>
        /// <returns>Return can be {-1; 0; 1}. -1 equals (given <see cref="Int64"/> under the range); 0 equals (given <see cref="Int64"/> in the range) or 1 equals (given <see cref="Int64"/> over the range).</returns>
        public int CompareTo(Int64 other)
        {
            return TheRange.CompareTo(other);
        }

        /// <summary>
        /// Gets the size of this <see cref="Int64RangeMathable"/>.
        /// </summary>
        /// <returns>The size!</returns>
        public BigInteger RangeSize()
        {
            return ((new BigInteger(TheRange.EndBound) - TheRange.StartBound) & Int64.MaxValue) + 1;
        }

        /// <summary>
        /// Combines this range with the given range <paramref name="toCombine"/> based on the given <see cref="RangeCombination"/>.
        /// </summary>
        /// <param name="toCombine">The other range to combine with.</param>
        /// <param name="combinationType">How to combine the 2 ranges.</param>
        /// <param name="whatToDoWithResults">What to do with the result?</param>
        /// <returns>Result <see cref="IRangeMathable{Int64, Int64}"/>s.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="combinationType"/> is not a valid <see cref="RangeCombination"/> value!</exception>
        public IRangeMathableSingleSize<Int64, BigInteger>[] Combine(IRangeMathableSingleSize<Int64, BigInteger> toCombine, RangeCombination combinationType, RangeMathematicResultUseage whatToDoWithResults)
        {
            IRangeMathableSingleSize<Int64, BigInteger>[] result;
            if (toCombine == null)
            {
                result = new IRangeMathableSingleSize<Int64, BigInteger>[1];
                switch (combinationType)
                {
                    case RangeCombination.Difference:
                    case RangeCombination.Union:
                        result[0] = new Int64RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound);
                        break;
                    case RangeCombination.Intersect:
                        result[0] = default(Int64RangeMathable);
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
                            result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { new Int64RangeMathable(toCombine.EmptyRange, toCombine.StartBound, toCombine.EndBound) };
                        }
                        else if (toCombine.EmptyRange)
                        {
                            result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { new Int64RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound) };
                        }
                        else
                        {
                            if (comparationResult == 0)
                            {
                                result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { new Int64RangeMathable(true, 0, 0) };
                            }
                            else
                            {
                                if (TheRange.EndBound < toCombine.EndBound)
                                {
                                    result = new IRangeMathableSingleSize<Int64, BigInteger>[2];
                                    BigInteger tempNewBound = new BigInteger(toCombine.StartBound) - 1;
                                    if (tempNewBound <= TheRange.StartBound)
                                    {
                                        result[0] = new Int64RangeMathable(true, TheRange.StartBound, TheRange.StartBound);
                                    }
                                    else
                                    {
                                        result[0] = new Int64RangeMathable(false, TheRange.StartBound, BigInteger.ToInt64(tempNewBound));
                                    }
                                    tempNewBound = new BigInteger(toCombine.EndBound) + 1;
                                    if (tempNewBound >= toCombine.EndBound)
                                    {
                                        result[1] = new Int64RangeMathable(true, toCombine.EndBound, toCombine.EndBound);
                                    }
                                    else
                                    {
                                        result[1] = new Int64RangeMathable(false, BigInteger.ToInt64(tempNewBound), toCombine.EndBound);
                                    }
                                }
                                else
                                {
                                    BigInteger newEndBound = new BigInteger(toCombine.StartBound) - 1;
                                    if (newEndBound <= TheRange.StartBound)
                                    {
                                        result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { new Int64RangeMathable(true, TheRange.StartBound, TheRange.StartBound) };
                                    }
                                    else
                                    {
                                        result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { new Int64RangeMathable(false, TheRange.StartBound, BigInteger.ToInt64(newEndBound)) };
                                    }
                                }
                            }
                        }
                        break;
                    case RangeCombination.Intersect:
                        result = new IRangeMathableSingleSize<Int64, BigInteger>[1];
                        if (TheRange.EmptyRange || toCombine.EmptyRange)
                        {
                            result[0] = default(Int64RangeMathable);
                        }
                        else
                        {
                            switch (comparationResult)
                            {
                                case -1:
                                    if (toCombine.StartBound > Int64.MinValue && TheRange.EndBound < (toCombine.StartBound - 1))
                                    {
                                        result[0] = default(Int64RangeMathable);
                                    }
                                    else
                                    {
                                        if (TheRange.EndBound > toCombine.EndBound)
                                        {
                                            result[0] = new Int64RangeMathable(false, toCombine.StartBound, toCombine.EndBound);
                                        }
                                        else
                                        {
                                            result[0] = new Int64RangeMathable(false, toCombine.StartBound, TheRange.EndBound);
                                        }
                                    }
                                    break;
                                case 0:
                                    result[0] = new Int64RangeMathable(false, TheRange.StartBound, TheRange.EndBound);
                                    break;
                                case 1:
                                    if (TheRange.StartBound < Int64.MinValue && toCombine.EndBound < (TheRange.StartBound - 1))
                                    {
                                        result[0] = default(Int64RangeMathable);
                                    }
                                    else
                                    {
                                        if (toCombine.EndBound > TheRange.EndBound)
                                        {
                                            result[0] = new Int64RangeMathable(false, toCombine.StartBound, toCombine.EndBound);
                                        }
                                        else
                                        {
                                            result[0] = new Int64RangeMathable(false, toCombine.StartBound, TheRange.EndBound);
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    case RangeCombination.Union:
                        if (TheRange.EmptyRange && toCombine.EmptyRange)
                        {
                            result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { default(Int64RangeMathable) };
                        }
                        else
                        {
                            switch (comparationResult)
                            {
                                case -1:
                                    if (TheRange.EmptyRange)
                                    {
                                        result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { new Int64RangeMathable(toCombine.EmptyRange, toCombine.StartBound, toCombine.EndBound) };
                                    }
                                    else if (toCombine.EmptyRange)
                                    {
                                        result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { new Int64RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound) };
                                    }
                                    else
                                    {
                                        if (TheRange.EndBound < Int64.MaxValue && (TheRange.EndBound + 1) < toCombine.StartBound)
                                        {
                                            result = new IRangeMathableSingleSize<Int64, BigInteger>[2];
                                            result[0] = new Int64RangeMathable(false, TheRange.StartBound, TheRange.EndBound);
                                            result[1] = new Int64RangeMathable(false, toCombine.StartBound, toCombine.EndBound);
                                        }
                                        else
                                        {
                                            result = new IRangeMathableSingleSize<Int64, BigInteger>[1];
                                            if (TheRange.EndBound <= toCombine.EndBound)
                                            {
                                                result[0] = new Int64RangeMathable(false, TheRange.StartBound, toCombine.EndBound);
                                            }
                                            else
                                            {
                                                result[0] = new Int64RangeMathable(false, TheRange.StartBound, TheRange.EndBound);
                                            }
                                        }
                                    }
                                    break;
                                case 0:
                                    result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { new Int64RangeMathable(false, TheRange.StartBound, TheRange.EndBound) };
                                    break;
                                case 1:
                                    if (TheRange.EmptyRange)
                                    {
                                        result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { new Int64RangeMathable(toCombine.EmptyRange, toCombine.StartBound, toCombine.EndBound) };
                                    }
                                    else if (toCombine.EmptyRange)
                                    {
                                        result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { new Int64RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound) };
                                    }
                                    else
                                    {
                                        if (toCombine.EndBound < Int64.MaxValue && TheRange.StartBound < (toCombine.EndBound + 1))
                                        {
                                            result = new IRangeMathableSingleSize<Int64, BigInteger>[2];
                                            result[1] = new Int64RangeMathable(false, toCombine.StartBound, toCombine.EndBound);
                                            result[0] = new Int64RangeMathable(false, TheRange.StartBound, TheRange.EndBound);
                                        }
                                        else
                                        {
                                            result = new IRangeMathableSingleSize<Int64, BigInteger>[1];
                                            if (TheRange.EndBound >= toCombine.EndBound)
                                            {
                                                result[0] = new Int64RangeMathable(false, toCombine.StartBound, TheRange.EndBound);
                                            }
                                            else
                                            {
                                                result[0] = new Int64RangeMathable(false, toCombine.StartBound, toCombine.EndBound);
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        result = new IRangeMathableSingleSize<Int64, BigInteger>[1] { new Int64RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound) };
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
        /// <returns>Result <see cref="IRangeMathableSingleSize{Int64, BigInteger}"/>s.</returns>
        public IRangeMathableSingleSize<Int64, BigInteger>[] Split(Int64 splitPoint, bool includeSplitPointToUpperRange, RangeMathematicResultUseage whatToDoWithResults)
        {
            IRangeMathableSingleSize<Int64, BigInteger>[] result;
            if (TheRange.EmptyRange)
            {
                result = new IRangeMathableSingleSize<Int64, BigInteger>[2] { default(Int64RangeMathable), default(Int64RangeMathable) };
            }
            else
            {
                result = new IRangeMathableSingleSize<Int64, BigInteger>[2];
                switch (TheRange.CompareTo(splitPoint))
                {
                    case -1:
                        result[0] = new Int64RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound);
                        result[1] = default(Int64RangeMathable);
                        break;
                    case 0:
                        if (includeSplitPointToUpperRange)
                        {
                            if (TheRange.StartBound == TheRange.EndBound || TheRange.StartBound == splitPoint)
                            {
                                result[0] = default(Int64RangeMathable);
                                result[1] = new Int64RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound);
                            }
                            else
                            {
                                result[0] = new Int64RangeMathable(TheRange.EmptyRange, TheRange.StartBound, (splitPoint - 1));
                                result[1] = new Int64RangeMathable(TheRange.EmptyRange, splitPoint, TheRange.EndBound);
                            }
                        }
                        else
                        {
                            if (TheRange.StartBound == TheRange.EndBound || TheRange.EndBound == splitPoint)
                            {
                                result[0] = new Int64RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound);
                                result[1] = default(Int64RangeMathable);
                            }
                            else
                            {
                                result[0] = new Int64RangeMathable(TheRange.EmptyRange, TheRange.StartBound, splitPoint);
                                result[1] = new Int64RangeMathable(TheRange.EmptyRange, (splitPoint + 1), TheRange.EndBound);
                            }
                        }
                        break;
                    case 1:
                        result[0] = default(Int64RangeMathable);
                        result[1] = new Int64RangeMathable(TheRange.EmptyRange, TheRange.StartBound, TheRange.EndBound);
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
        /// <returns>Result <see cref="IRangeMathable{Int64, BigInteger}"/>s.</returns>
        public IRangeMathableSingleSize<Int64, BigInteger>[] Split(bool includeOddToUpperRange, RangeMathematicResultUseage whatToDoWithResults)
        {
            IRangeMathableSingleSize<Int64, BigInteger>[] result = new IRangeMathableSingleSize<Int64, BigInteger>[2];
            BigInteger tempSize = BigInteger.ToUInt64(RangeSize());
            switch (tempSize.CompareTo(new BigInteger(1UL)))
            {
                case -1:
                    result[0] = default(Int64RangeMathable);
                    result[1] = default(Int64RangeMathable);
                    break;
                case 0:
                    if (includeOddToUpperRange)
                    {
                        result[0] = default(Int64RangeMathable);
                        result[1] = new Int64RangeMathable(true, TheRange.StartBound, TheRange.EndBound);
                    }
                    else
                    {
                        result[0] = new Int64RangeMathable(true, TheRange.StartBound, TheRange.EndBound);
                        result[1] = default(Int64RangeMathable);
                    }
                    break;
                case 1:
                    bool storedOddBit = (tempSize & 1) == 1;
                    BigInteger halfSize = tempSize >> 1;
                    if (storedOddBit)
                    {
                        if (halfSize > 0)
                        {
                            if (includeOddToUpperRange)
                            {
                                result[0] = new Int64RangeMathable(false, TheRange.StartBound, (TheRange.StartBound + BigInteger.ToInt64(halfSize) - 1));
                                result[1] = new Int64RangeMathable(false, (TheRange.EndBound - BigInteger.ToInt64(halfSize)), TheRange.EndBound);
                            }
                            else
                            {
                                result[0] = new Int64RangeMathable(false, TheRange.StartBound, (TheRange.StartBound + BigInteger.ToInt64(halfSize)));
                                result[1] = new Int64RangeMathable(false, (TheRange.EndBound - BigInteger.ToInt64(halfSize) + 1), TheRange.EndBound);
                            }
                        }
                        else
                        {
                            if (includeOddToUpperRange)
                            {
                                result[0] = default(Int64RangeMathable);
                                result[1] = new Int64RangeMathable(false, TheRange.EndBound, TheRange.EndBound);
                            }
                            else
                            {
                                result[0] = new Int64RangeMathable(false, TheRange.StartBound, TheRange.StartBound);
                                result[1] = default(Int64RangeMathable);
                            }
                        }
                    }
                    else
                    {
                        if (halfSize > 0)
                        {
                            result[0] = new Int64RangeMathable(false, TheRange.StartBound, (TheRange.StartBound + BigInteger.ToInt64(halfSize) - 1));
                            result[1] = new Int64RangeMathable(false, (TheRange.EndBound - BigInteger.ToInt64(halfSize) + 1), TheRange.EndBound);
                        }
                        else
                        {
                            result[0] = default(Int64RangeMathable);
                            result[1] = default(Int64RangeMathable);
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
        /// Compares where the given <see cref="IRangeMathableSingleSize{Int64, BigInteger}"/> is to this <see cref="Int64RangeMathable"/>.
        /// </summary>
        /// <param name="other">The <see cref="IRangeMathableSingleSize{Int64, BigInteger}"/> to compare to this <see cref="Int64RangeMathable"/>.</param>
        /// <returns>Return can be {-1; 0; 1}.<para/>
        /// -1 on:<para />
        /// - The <paramref name="other"/> is null.<para />
        /// - The <paramref name="other"/> range is the only range that is <see cref="IRange{Int64}.EmptyRange"/> equal true.<para />
        /// - This <see cref="Int64RangeMathable"/> range comes before the <paramref name="other"/> range.<para />
        /// - This <see cref="Int64RangeMathable"/> range starts equaly but ends before the <paramref name="other"/> range.<para />
        /// 0 on:<para />
        /// - Both ranges are <see cref="IRange{Int64}.EmptyRange"/> equal true.<para />
        /// - Both ranges are equaly in size and position.<para />
        /// 1 on:<para />
        /// - This <see cref="Int64RangeMathable"/> range is the only range that is <see cref="IRange{Int64}.EmptyRange"/> equal true.
        /// - The <paramref name="other"/> range comes before this <see cref="Int64RangeMathable"/> range.<para />
        /// - The <paramref name="other"/> range starts equaly but ends before this <see cref="Int64RangeMathable"/> range.<para />
        /// </returns>
        public int CompareTo(IRangeMathableSingleSize<Int64, BigInteger> other)
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