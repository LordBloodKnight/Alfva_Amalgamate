using System;
using System.Threading;

/// <summary>
/// Holds general collection useable for <see cref="Array"/> based reference types.
/// </summary>
namespace AlfvaAmalgamate.Arrays
{
    /// <summary>
    /// Holds extensions for <see cref="Array"/> based reference types.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Populates the <see cref="Array"/> with the given <paramref name="value"/> from <paramref name="fromIndex"/> to <paramref name="toIndex"/>.
        /// </summary>
        /// <typeparam name="T">A <see cref="Type"/> that is usefull to be stored in an <see cref="Array"/> multiple times.</typeparam>
        /// <param name="self">The <see cref="Array"/> where the <paramref name="value"/> gets placed multiple times in an row.</param>
        /// <param name="value">The value that gets populated in the target range of the <see cref="Array"/>.</param>
        /// <param name="fromIndex">Where to start in the <see cref="Array"/> to populate the <see cref="Array"/> with the <paramref name="value"/>.</param>
        /// <param name="toIndex">Where to stop in the <see cref="Array"/> to populate the <see cref="Array"/> with the <paramref name="value"/>.</param>
        /// <param name="arrayLockNeeded">Is the <see cref="Array"/> needed to be locked before using it?</param>
        /// <param name="ignoreThreadingAccess">If true and the <see cref="Array"/> is locked it will aborde this action silently else an <see cref="TimeoutException"/> gets thrown on the same event.</param>
        public static void Populate<T>(this T[] self, T value, int fromIndex, int toIndex, bool arrayLockNeeded = false, bool ignoreThreadingAccess = true)
        {
            if (fromIndex < 0 || toIndex < 0)
            {
                throw new IndexOutOfRangeException("fromIndex and toIndex aren't allowed to be negative!");
            }
            if ((self.Length > 0) && (fromIndex >= self.Length || (toIndex >= self.Length)))
            {
                throw new IndexOutOfRangeException("fromIndex and toIndex aren't allowed to be greater than the highest accessable element of the Array!");
            }
            if (arrayLockNeeded)
            {
                bool lockGot = false;
                try
                {
                    lockGot = Monitor.TryEnter(self);
                    if (lockGot)
                    {
                        for (int currentElement = fromIndex; currentElement < self.Length; currentElement++)
                        {
                            self[currentElement] = value;
                        }
                    }
                    else
                    {
                        if (!ignoreThreadingAccess)
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
                    }
                }
            }
            else
            {
                for (int currentElement = fromIndex; currentElement < self.Length; currentElement++)
                {
                    self[currentElement] = value;
                }
            }
        }
    }
}
