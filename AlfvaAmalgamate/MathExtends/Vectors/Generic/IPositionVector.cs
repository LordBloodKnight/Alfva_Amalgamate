using System;

/// <summary>
/// Holds generic matheable data <see cref="Type"/>s.
/// </summary>
namespace AlfvaAmalgamate.MathExtends.Vectors.Generic
{
    /// <summary>
    /// Alias of the <see cref="IRadiusVector{ValueType}"/>.<para />
    /// This interface is interoperable with vectors from most engines.
    /// </summary>
    /// <typeparam name="ComponentsValueType">A <see cref="Type"/> that can be used to store a vector component value.</typeparam>
    public interface IPositionVector<ComponentsValueType> : IRadiusVector<ComponentsValueType>
    {
        /// <summary>
        /// Gets the <see cref="IPositionVector{ComponentsValueType, TrueComponentsValueType}"/> has unit vector.
        /// </summary>
        IPositionVector<ComponentsValueType> GetUnitVector();

        /// <summary>
        /// Alias of the <see cref="IRadiusVector{ComponentsValueType, TrueComponentsValueType}.MagnitudeRadius"/> .
        /// </summary>
        /// <exception cref="OverflowException">The calculated magnitude is to large to be stored in a <see cref="ComponentsValueType"/>! Use <see cref="GetTrueMagnitude"/> instead!</exception>
        ComponentsValueType GetMagnitude();

        /// <summary>
        /// Alias of the <see cref="IRadiusVector{ComponentsValueType}.TrueMagnitudeRadius"/>.
        /// </summary>
        /// <returns>First <see cref="Array"/> element is the length without the overflow and the second <see cref="Array"/> element stores the overflow.</returns>
        ComponentsValueType[] GetTrueMagnitude();

        /// <summary>
        /// Gets the direction of this <see cref="IPositionVector{ComponentsValueType}"/>.
        /// </summary>
        /// <returns><see cref="IPositionVector{ComponentsValueType}"/> direction.</returns>
        IPositionVector<ComponentsValueType> GetDirectionVector();
    }
}
