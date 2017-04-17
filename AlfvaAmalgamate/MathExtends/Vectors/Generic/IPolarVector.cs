using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Holds generic matheable data <see cref="Type"/>s.
/// </summary>
namespace AlfvaAmalgamate.MathExtends.Vectors.Generic
{
    /// <summary>
    /// A <see cref="IVector{ComponentsValueType}"/> its first component is the vector length in the X direction and all additional components are rotation informations.
    /// </summary>
    /// <typeparam name="ComponentsValueType">A <see cref="Type"/> that can be used to store a vector component value.</typeparam>
    public interface IPolarVector<ComponentsValueType> : IVector<ComponentsValueType>
    {
        /// <summary>
        /// Gets the <see cref="IPolarVector{ComponentsValueType, TrueComponentsValueType}"/> has unit vector.
        /// </summary>
        IPolarVector<ComponentsValueType> GetUnitPolarVector();

        /// <summary>
        /// Gets the length of this <see cref="IPolarVector{ComponentsValueType}"/>.
        /// </summary>
        ComponentsValueType GetMagnitudePolar();

        /// <summary>
        /// Gets the direction of this <see cref="IRadiusVector{ComponentsValueType}"/>.
        /// </summary>
        /// <returns></returns>
        IPolarVector<ComponentsValueType> GetDirectionPolarVector();
    }
}
