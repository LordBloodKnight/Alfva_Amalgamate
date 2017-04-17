using System;

/// <summary>
/// Holds math extensions.
/// </summary>
namespace AlfvaAmalgamate.MathExtends
{
    /// <summary>
    /// Rounding modes available.
    /// </summary>
    public enum RoundingType
    {
        /// <summary>
        /// Removes any value part that is not a pure integer value part.
        /// </summary>
        Truncate = 0,

        /// <summary>
        /// Rounds to the next lower integer if value is not already a pure integer.
        /// </summary>
        Floor = 0,

        /// <summary>
        /// Rounds to the next higher integer if the value is not already a pure integer.
        /// </summary>
        Ceiling = 1,

        /// <summary>
        /// Rounds to the nearest integer if the value is not already a pure integer.
        /// </summary>
        Round = 2,
    }
}