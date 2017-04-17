using System;

/// <summary>
/// Holds generic matheable data <see cref="Type"/>s.
/// </summary>
namespace AlfvaAmalgamate.MathExtends.Vectors.Generic
{
    /// <summary>
    /// The base functionality of every vector <see cref="Type"/>.
    /// </summary>
    /// <typeparam name="ComponentsValueType">A <see cref="Type"/> that can be used to store a vector component value.</typeparam>
    public interface IVector<ComponentsValueType>
    {
        /// <summary>
        /// Gets the components amount of this <see cref="IVector{ValueType}"/>.
        /// </summary>
        int GetComponentsAmout();

        /// <summary>
        /// Gets the component on the given <paramref name="componentIndex"/>.
        /// </summary>
        /// <param name="componentIndex">The index number to the target component.</param>
        /// <param name="checkedSearch">If true and <paramref name="componentIndex"/> is pointing to a not existing component an <see cref="ArgumentOutOfRangeException"/> gets thrown.</param>
        /// <returns>The wanted component if existing else if allowed a default value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The target component is not in the range of existing components!</exception>
        ComponentsValueType GetComponent(int componentIndex, bool checkedSearch = false);

        /// <summary>
        /// Sets the component on the given <paramref name="componentIndex"/>.
        /// </summary>
        /// <param name="componentIndex">The index number to the target component.</param>
        /// <param name="newValue">The new value of the target component.</param>
        /// <param name="checkedSearch">If true and <paramref name="componentIndex"/> is pointing to a not existing component an <see cref="ArgumentOutOfRangeException"/> gets thrown.</param>
        /// <exception cref="ArgumentOutOfRangeException">The target component is not in the range of existing components!</exception>
        void SetComponent(int componentIndex, ComponentsValueType newValue, bool checkedSearch = false);
    }
}
