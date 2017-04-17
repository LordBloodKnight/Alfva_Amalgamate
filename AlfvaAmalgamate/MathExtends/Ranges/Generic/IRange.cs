using System;
using System.Collections;
using System.Threading;

/// <summary>
/// Holds generics for ranges.
/// </summary>
namespace AlfvaAmalgamate.MathExtends.Ranges.Generic
{
    /// <summary>
    /// Combinations an <see cref="IRange{RangeValueType}"/> can do with another <see cref="IRange{RangeValueType}"/>.
    /// </summary>
    public enum RangeCombination
    {
        /// <summary>
        /// Returns <see cref="IRange{RangeValueType}"/>'s that repsesenting parts that are not covered by the other given <see cref="IRange{RangeValueType}"/>.
        /// </summary>
        Difference = 0,

        /// <summary>
        /// Returns <see cref="IRange{RangeValueType}"/>'s that representing parts that are the result of the union with the other given <see cref="IRange{RangeValueType}"/>.
        /// </summary>
        Union = 1,

        /// <summary>
        /// Returns <see cref="IRange{RangeValueType}"/> that represents the intersection result of the combination with the other given <see cref="IRange{RangeValueType}"/>.
        /// </summary>
        Intersect = 2,
    }

    /// <summary>
    /// How to use the range maths results?
    /// </summary>
    public enum RangeMathematicResultUseage
    {
        /// <summary>
        /// Not use the results of the range maths to change own range.
        /// </summary>
        NotUseResultsOnOwnRange = 0 << 0,

        /// <summary>
        /// Use lowest result range of the range maths to change own range.
        /// </summary>
        UseLowestResultRangeOnOwnRange = 1 << 0,

        /// <summary>
        /// Use highest result range of the range maths to change own range.
        /// </summary>
        /// <remarks>Only if <see cref="UseLowestResultRangeOnOwnRange"/> isn't true!</remarks>
        UseHighestResultRangeOnOwnRange = 2 << 0,
    }

    /// <summary>
    /// Generic struct that represents an range from a <see cref="StartBound"/> to an <see cref="EndBound"/>.
    /// </summary>
    /// <typeparam name="RangeValueType">A <see cref="Type"/> that can be used as a point on a line.</typeparam>
    public struct Range<RangeValueType> : IRange<RangeValueType> where RangeValueType : struct, IComparable<RangeValueType>
    {
        /// <summary>
        /// This value is only there to make sure that using the default() on this <see cref="Range{RangeValueType}"/> is producing right default values.
        /// </summary>
        private bool IsInitalized;

        /// <summary>
        /// Holds the start bound of this <see cref="Range{RangeValueType}"/>.
        /// </summary>
        private RangeValueType _StartBound;
        /// <summary>
        /// Gets or sets the start bound of this <see cref="Range{RangeValueType}"/>.
        /// </summary>
        /// <value><see cref="_StartBound"/></value>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="StartBound"/> isn't allowed to be higher than the <see cref="EndBound"/>!</exception>
        public RangeValueType StartBound
        {
            get
            {
                RangeValueType result;
                result = _StartBound;
                return result;
            }
            set
            {
                if (value.CompareTo(_EndBound) > 0)
                {
                    throw new ArgumentOutOfRangeException("The StartBound isn't allowed to be higher than the EndBound!");
                }
                _StartBound = value;
            }
        }

        /// <summary>
        /// Holds the end bound of this <see cref="Range{RangeValueType}"/>.
        /// </summary>
        private RangeValueType _EndBound;
        /// <summary>
        /// Gets or sets the end bound of this <see cref="Range{RangeValueType}"/>.
        /// </summary>
        /// <value><see cref="_EndBound"/></value>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="EndBound"/> isn't allowed to be lower than the <see cref="StartBound"/>!</exception>
        public RangeValueType EndBound
        {
            get
            {
                RangeValueType result;
                result = _EndBound;
                return result;
            }
            set
            {
                if (value.CompareTo(_StartBound) < 0)
                {
                    throw new ArgumentOutOfRangeException("The EndBound isn't allowed to be lower than the StartBound!");
                }
                _EndBound = value;
            }
        }

        /// <summary>
        /// Is this <see cref="Range{RangeValueType}"/> to small to hold any range?
        /// </summary>
        /// <remarks>Even if <see cref="StartBound"/> and <see cref="EndBound"/> are not equal and this is true this <see cref="Range{RangeValueType}"/> is seen as an empty range! It is the only way an <see cref="Range{RangeValueType}"/> can have a size equal 0!</remarks>
        private bool _EmptyRange;
        /// <summary>
        /// Gets or sets the state of this <see cref="Range{RangeValueType}"/> if it is empty.
        /// </summary>
        /// <value><see cref="_EmptyRange"/></value>
        public bool EmptyRange
        {
            get
            {
                if (!IsInitalized)
                {
                    _EmptyRange = true;
                    IsInitalized = true;
                }
                bool result;
                result = _EmptyRange;
                return result;
            }
            set
            {
                _EmptyRange = value;
            }
        }

        /// <summary>
        /// Constructor of this <see cref="Range{RangeValueType}"/>.
        /// </summary>
        /// <param name="startBound">The starting bound.</param>
        /// <param name="endBound">The ending bound.</param>
        /// <param name="emptyRange">Is the range to small to hold any range?</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startBound"/> value is bigger than the <paramref name="endBound"/> value!</exception>
        public Range(bool emptyRange = true, RangeValueType startBound = default(RangeValueType), RangeValueType endBound = default(RangeValueType))
        {
            if (startBound.CompareTo(endBound) > 0)
            {
                throw new ArgumentOutOfRangeException("startBound value is bigger than the endBound value!");
            }
            _StartBound = startBound;
            _EndBound = endBound;
            _EmptyRange = emptyRange;
            IsInitalized = true;
        }

        /// <summary>
        /// Compares where the given <see cref="RangeValueType"/> is to the range.
        /// </summary>
        /// <param name="other">The point to compare to the range.</param>
        /// <returns>Return can be {-1; 0; 1}. -1 equals (given <see cref="RangeValueType"/> under the range); 0 equals (given <see cref="RangeValueType"/> in the range) or 1 equals (given <see cref="RangeValueType"/> over the range).</returns>
        public int CompareTo(RangeValueType other)
        {
            int result;
            if (EmptyRange)
            {
                result = other.CompareTo(default(RangeValueType));
                if (result == 0)
                {
                    result = 1;
                }
            }
            else
            {
                result = other.CompareTo(_StartBound);
                if (result > 0)
                {
                    result = other.CompareTo(_EndBound);
                    if (result < 0)
                    {
                        result = 0;
                    }
                }
            }
            return result;
        }
    }

    /// <summary>
    /// Special version of <see cref="Range{RangeValueType}"/> for sharing between <see cref="Thread"/>s.
    /// </summary>
    /// <typeparam name="RangeValueType">A <see cref="Type"/> that can be used as a point on a line.</typeparam>
    public class RangeThreadable<RangeValueType> : IRange<RangeValueType> where RangeValueType : struct, IComparable<RangeValueType>
    {
        /// <summary>
        /// Holds the locker to all information about this <see cref="RangeThreadable{RangeValueType}"/>.
        /// </summary>
        private ReaderWriterLockSlim SystemLocker;

        /// <summary>
        /// This value is only there to make sure that using the default() on this <see cref="RangeThreadable{RangeValueType}"/> is producing right default values.
        /// </summary>
        private bool IsInitalized;

        /// <summary>
        /// Holds the start bound of this <see cref="RangeThreadable{RangeValueType}"/>.
        /// </summary>
        private RangeValueType _StartBound;
        /// <summary>
        /// Gets or sets the start bound of this <see cref="RangeThreadable{RangeValueType}"/>.
        /// </summary>
        /// <value><see cref="_StartBound"/></value>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="StartBound"/> isn't allowed to be higher than the <see cref="EndBound"/>!</exception>
        public RangeValueType StartBound
        {
            get
            {
                RangeValueType result = default(RangeValueType);
                try
                {
                    SystemLocker.EnterReadLock();
                    result = _StartBound;
                }
                finally
                {
                    if (SystemLocker.IsReadLockHeld)
                    {
                        SystemLocker.ExitReadLock();
                    }
                }
                return result;
            }
            set
            {
                try
                {
                    SystemLocker.EnterWriteLock();
                    if (value.CompareTo(_EndBound) > 0)
                    {
                        throw new ArgumentOutOfRangeException("The StartBound isn't allowed to be higher than the EndBound!");
                    }
                    _StartBound = value;
                }
                finally
                {
                    if (SystemLocker.IsWriteLockHeld)
                    {
                        SystemLocker.ExitWriteLock();
                    }
                }
            }
        }

        /// <summary>
        /// Holds the end bound of this <see cref="RangeThreadable{RangeValueType}"/>.
        /// </summary>
        private RangeValueType _EndBound;
        /// <summary>
        /// Gets or sets the end bound of this <see cref="RangeThreadable{RangeValueType}"/>.
        /// </summary>
        /// <value><see cref="_EndBound"/></value>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="EndBound"/> isn't allowed to be lower than the <see cref="StartBound"/>!</exception>
        public RangeValueType EndBound
        {
            get
            {
                RangeValueType result = default(RangeValueType);
                try
                {
                    SystemLocker.EnterReadLock();
                    result = _EndBound;
                }
                finally
                {
                    if (SystemLocker.IsReadLockHeld)
                    {
                        SystemLocker.ExitReadLock();
                    }
                }
                return result;
            }
            set
            {
                try
                {
                    SystemLocker.EnterWriteLock();
                    if (value.CompareTo(_StartBound) < 0)
                    {
                        throw new ArgumentOutOfRangeException("The EndBound isn't allowed to be lower than the StartBound!");
                    }
                    _EndBound = value;
                }
                finally
                {
                    if (SystemLocker.IsWriteLockHeld)
                    {
                        SystemLocker.ExitWriteLock();
                    }
                }
            }
        }

        /// <summary>
        /// Is this <see cref="RangeThreadable{RangeValueType}"/> to small to hold any range?
        /// </summary>
        /// <remarks>Even if <see cref="StartBound"/> and <see cref="EndBound"/> are not equal and this is true this <see cref="Range{RangeValueType}"/> is seen as an empty range! It is the only way an <see cref="Range{RangeValueType}"/> can have a size equal 0!</remarks>
        private bool _EmptyRange;
        /// <summary>
        /// Gets or sets the state of this <see cref="RangeThreadable{RangeValueType}"/> if it is empty.
        /// </summary>
        /// <value><see cref="_EmptyRange"/></value>
        public bool EmptyRange
        {
            get
            {
                bool result = true;
                try
                {
                    SystemLocker.EnterReadLock();
                    if (SystemLocker.IsReadLockHeld)
                    {
                        if (!IsInitalized)
                        {
                            EmptyRange = true;
                            IsInitalized = true;
                        }
                        result = _EmptyRange;
                    }
                    else
                    {
                        throw new TimeoutException("This RangeThreadable<RangeValueType> values are getting currently changed!");
                    }
                }
                finally
                {
                    if (SystemLocker.IsReadLockHeld)
                    {
                        SystemLocker.ExitReadLock();
                    }
                }
                return result;
            }
            set
            {
                try
                {
                    SystemLocker.EnterWriteLock();
                    _EmptyRange = value;
                }
                finally
                {
                    if (SystemLocker.IsWriteLockHeld)
                    {
                        SystemLocker.ExitWriteLock();
                    }
                }
            }
        }

        /// <summary>
        /// Constructor of this <see cref="RangeThreadable{RangeValueType}"/>.
        /// </summary>
        /// <param name="startBound">The starting bound.</param>
        /// <param name="endBound">The ending bound.</param>
        /// <param name="emptyRange">Is the range to small to hold any range?</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startBound"/> value is bigger than the <paramref name="endBound"/> value!</exception>
        public RangeThreadable(bool emptyRange = true, RangeValueType startBound = default(RangeValueType), RangeValueType endBound = default(RangeValueType))
        {
            if (startBound.CompareTo(endBound) > 0)
            {
                throw new ArgumentOutOfRangeException("startBound value is bigger than the endBound value!");
            }
            _StartBound = startBound;
            _EndBound = endBound;
            _EmptyRange = emptyRange;
            IsInitalized = true;
            SystemLocker = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }

        /// <summary>
        /// Compares where the given <see cref="RangeValueType"/> is to the range.
        /// </summary>
        /// <param name="other">The point to compare to the range.</param>
        /// <returns>Return can be {-1; 0; 1}. -1 equals (given <see cref="RangeValueType"/> under the range); 0 equals (given <see cref="RangeValueType"/> in the range) or 1 equals (given <see cref="RangeValueType"/> over the range).</returns>
        /// <exception cref="TimeoutException">This <see cref="RangeThreadable{RangeValueType}"/> values are getting currently changed!</exception>
        public int CompareTo(RangeValueType other)
        {
            int result = 0;
            try
            {
                SystemLocker.TryEnterReadLock(1);
                if (SystemLocker.IsReadLockHeld)
                {
                    if (EmptyRange)
                    {
                        result = other.CompareTo(default(RangeValueType));
                        if (result == 0)
                        {
                            result = 1;
                        }
                    }
                    else
                    {
                        result = other.CompareTo(_StartBound);
                        if (result > 0)
                        {
                            result = other.CompareTo(_EndBound);
                            if (result < 0)
                            {
                                result = 0;
                            }
                        }
                    }
                }
                else
                {
                    throw new TimeoutException("This RangeThreadable<RangeValueType> values are getting currently changed!");
                }
            }
            finally
            {
                if (SystemLocker.IsReadLockHeld)
                {
                    SystemLocker.ExitReadLock();
                }
            }
            return result;
        }
    }

    /// <summary>
    /// Interface for structs and classes that can be an range for a specific <see cref="RangeValueType"/>.
    /// </summary>
    /// <typeparam name="RangeValueType">A <see cref="Type"/> that can be used as a point on a line.</typeparam>
    /// <remarks>Be aware using <see cref="IComparable{IRange{RangeValueType}}.CompareTo(IRange{RangeValueType})"/> on a <see cref="Thread"/> shareable implementation because it can return a <see cref="TimeoutException"/> if the values are getting changed and is not yet finished!</remarks>
    public interface IRange<RangeValueType> : IComparable<RangeValueType> where RangeValueType : struct, IComparable<RangeValueType>
    {
        /// <summary>
        /// Gets or sets the start bound of this <see cref="IRange{RangeValueType}"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="StartBound"/> isn't allowed to be higher than the <see cref="EndBound"/>!</exception>
        RangeValueType StartBound { get; set; }

        /// <summary>
        /// Gets or sets the end bound of this <see cref="IRange{RangeValueType}"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="EndBound"/> isn't allowed to be lower than the <see cref="StartBound"/>!</exception>
        RangeValueType EndBound { get; set; }

        /// <summary>
        /// If this <see cref="IRange{RangeValueType}"/> is to small to hold any range.
        /// </summary>
        /// <remarks>Even if <see cref="StartBound"/> and <see cref="EndBound"/> are not equal and this is true this <see cref="IRange{RangeValueType}"/> is seen as an empty range! It is the only way an range can have a size equal 0!</remarks>
        bool EmptyRange { get; set; }
    }

    /// <summary>
    /// Interface for every <see cref="IRange{RangeValueType}"/> that supports mathematics with the range.
    /// </summary>
    /// <typeparam name="RangeValueType">A <see cref="Type"/> that can be used as a point on a line.</typeparam>
    public interface IRangeMathable<RangeValueType, RangeSizeValueType> : IRange<RangeValueType>, IComparable<IRangeMathable<RangeValueType, RangeSizeValueType>> where RangeValueType : struct, IComparable<RangeValueType> where RangeSizeValueType : struct, IComparable<RangeSizeValueType>
    {
        /// <summary>
        /// Gets the size of this <see cref="IRangeMathable{RangeValueType, RangeSizeValueType}"/>.
        /// </summary>
        /// <returns>The size of the range in 2 <see cref="RangeSizeValueType"/>s!</returns>
        RangeSizeValueType[] GetRangeSize();

        /// <summary>
        /// Combines this range with the given range based on the given <see cref="RangeCombination"/>.
        /// </summary>
        /// <param name="toCombine">The other range to combine with.</param>
        /// <param name="combinationType">How to combine the 2 ranges.</param>
        /// <param name="whatToDoWithResults">What to do with the result?</param>
        /// <returns>Result <see cref="IRangeMathable{RangeValueType, RangeSizeValueType}"/>s.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="combinationType"/> is not a valid <see cref="RangeCombination"/> value!</exception>
        IRangeMathable<RangeValueType, RangeSizeValueType>[] Combine(IRangeMathable<RangeValueType, RangeSizeValueType> toCombine, RangeCombination combinationType, RangeMathematicResultUseage whatToDoWithResults);

        /// <summary>
        /// Splits the range on the given <paramref name="splitPoint"/>.
        /// </summary>
        /// <param name="splitPoint">The point on the range to split it.</param>
        /// <param name="includeSplitPointToUpperRange">Which range gets the <paramref name="splitPoint"/>?</param>
        /// <param name="whatToDoWithResults">What to do with the result?</param>
        /// <returns>Result <see cref="IRangeMathable{RangeValueType, RangeSizeValueType}"/>s.</returns>
        IRangeMathable<RangeValueType, RangeSizeValueType>[] Split(RangeValueType splitPoint, bool includeSplitPointToUpperRange, RangeMathematicResultUseage whatToDoWithResults);

        /// <summary>
        /// Splits the range in nearly equal sized ranges.
        /// </summary>
        /// <param name="includeOddToUpperRange">If the range range is odd where to add the element on the split to?</param>
        /// <param name="whatToDoWithResults">What to do with the result?</param>
        /// <returns>Result <see cref="IRangeMathable{RangeValueType, RangeSizeValueType}"/>s.</returns>
        IRangeMathable<RangeValueType, RangeSizeValueType>[] Split(bool includeOddToUpperRange, RangeMathematicResultUseage whatToDoWithResults);
    }

    /// <summary>
    /// Spezial version of <see cref="IRangeMathable{RangeValueType, RangeSizeValueType}"/> with a single size information holder.
    /// </summary>
    /// <typeparam name="RangeValueType">A <see cref="Type"/> that can be used as a point on a line.</typeparam>
    public interface IRangeMathableSingleSize<RangeValueType, RangeSizeValueType> : IRange<RangeValueType>, IComparable<IRangeMathableSingleSize<RangeValueType, RangeSizeValueType>> where RangeValueType : struct, IComparable<RangeValueType> where RangeSizeValueType : IComparable<RangeSizeValueType>
    {
        /// <summary>
        /// Gets the size of this <see cref="IRangeMathableSingleSize{RangeValueType, RangeSizeValueType}"/>.
        /// </summary>
        /// <returns>The size of the range!</returns>
        RangeSizeValueType RangeSize();

        /// <summary>
        /// Combines this range with the given range based on the given <see cref="RangeCombination"/>.
        /// </summary>
        /// <param name="toCombine">The other range to combine with.</param>
        /// <param name="combinationType">How to combine the 2 ranges.</param>
        /// <param name="whatToDoWithResults">What to do with the result?</param>
        /// <returns>Result <see cref="IRangeMathableSingleSize{RangeValueType, RangeSizeValueType}"/>s.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="combinationType"/> is not a valid <see cref="RangeCombination"/> value!</exception>
        IRangeMathableSingleSize<RangeValueType, RangeSizeValueType>[] Combine(IRangeMathableSingleSize<RangeValueType, RangeSizeValueType> toCombine, RangeCombination combinationType, RangeMathematicResultUseage whatToDoWithResults);

        /// <summary>
        /// Splits the range on the given <paramref name="splitPoint"/>.
        /// </summary>
        /// <param name="splitPoint">The point on the range to split it.</param>
        /// <param name="includeSplitPointToUpperRange">Which range gets the <paramref name="splitPoint"/>?</param>
        /// <param name="whatToDoWithResults">What to do with the result?</param>
        /// <returns>Result <see cref="IRangeMathableSingleSize{RangeValueType, RangeSizeValueType}"/>s.</returns>
        IRangeMathableSingleSize<RangeValueType, RangeSizeValueType>[] Split(RangeValueType splitPoint, bool includeSplitPointToUpperRange, RangeMathematicResultUseage whatToDoWithResults);

        /// <summary>
        /// Splits the range in nearly equal sized ranges.
        /// </summary>
        /// <param name="includeOddToUpperRange">If the range range is odd where to add the element on the split to?</param>
        /// <param name="whatToDoWithResults">What to do with the result?</param>
        /// <returns>Result <see cref="IRangeMathableSingleSize{RangeValueType, RangeSizeValueType}"/>s.</returns>
        IRangeMathableSingleSize<RangeValueType, RangeSizeValueType>[] Split(bool includeOddToUpperRange, RangeMathematicResultUseage whatToDoWithResults);
    }
}