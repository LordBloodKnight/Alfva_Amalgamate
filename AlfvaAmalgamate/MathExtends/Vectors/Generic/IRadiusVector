using System;

/// <summary>
/// Holds generic matheable data <see cref="Type"/>s.
/// </summary>
namespace AlfvaAmalgamate.MathExtends.Vectors.Generic
{
    /// <summary>
    /// A <see cref="IVector{ComponentsValueType}"/> that points from the origin to the current position.
    /// </summary>
    /// <typeparam name="ComponentsValueType">A <see cref="Type"/> that can be used to store a vector component value.</typeparam>
    public interface IRadiusVector<ComponentsValueType> : IVector<ComponentsValueType>
    {
        /// <summary>
        /// Gets the <see cref="IRadiusVector{ComponentsValueType}"/> has unit vector.
        /// </summary>
        IRadiusVector<ComponentsValueType> GetUnitRadiusVector();

        /// <summary>
        /// Gets the length of this <see cref="IRadiusVector{ComponentsValueType}"/>.
        /// </summary>
        /// <exception cref="OverflowException">The calculated magnitude is to large to be stored in a <see cref="ComponentsValueType"/>! Use <see cref="GetTrueMagnitudeRadius"/> instead!</exception>
        ComponentsValueType GetMagnitudeRadius();

        /// <summary>
        /// Gets the true length of this <see cref="IRadiusVector{ComponentsValueType}"/> with an value type that as a larger/(more precise) range.
        /// </summary>
        /// <returns>First <see cref="Array"/> element is the length without the overflow and the second <see cref="Array"/> element stores the overflow.</returns>
        ComponentsValueType[] GetTrueMagnitudeRadius();

        /// <summary>
        /// Gets the direction of this <see cref="IRadiusVector{ComponentsValueType}"/>.
        /// </summary>
        /// <returns><see cref="IRadiusVector{ComponentsValueType}"/> direction.</returns>
        IRadiusVector<ComponentsValueType> GetDirectionRadiusVector();
    }
}
