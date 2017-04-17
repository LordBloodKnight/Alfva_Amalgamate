using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Holds interfaces and classes that representing generic tree based structuring and execution. 
/// </summary>
namespace AlfvaAmalgamate.Trees.Generic
{
    /// <summary>
    /// Interfaces for implementations that have a tree like data structure.
    /// </summary>
    /// <typeparam name="TreeType">A <see cref="Type"/> that is himself an <see cref="ITreeable{TreeType}"/> <see cref="Type"/>.</typeparam>
    public interface ITreeable<TreeType> where TreeType : ITreeable<TreeType>
    {
        /// <summary>
        /// Gets the amount of sub <see cref="TreeType"/>s allowed in this <see cref="ITreeable{TreeType}"/>.
        /// </summary>
        /// <returns>Amount of addable <see cref="TreeType"/>s.</returns>
        /// <remarks>The value is defined static in the implementation <see cref="Type"/>.</remarks>
        int GetMaxAllowedSupTrees();

        /// <summary>
        /// Gets the sub <see cref="TreeType"/> at the given <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index to the target <see cref="TreeType"/>.</param>
        /// <returns>The wanted <see cref="TreeType"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given <paramref name="index"/> is not in the range from 0 to <see cref="GetMaxAllowedSupTrees"/>!</exception>
        ITreeable<TreeType> GetSubTreeByIndex(int index);

        /// <summary>
        /// Sets the target <see cref="TreeType"/> at the given <paramref name="index"/> with the <paramref name="newTree"/>.
        /// </summary>
        /// <param name="index">The index of the target <see cref="TreeType"/>.</param>
        /// <param name="newTree">The <see cref="TreeType"/> to override the <see cref="TreeType"/> at the given <paramref name="index"/>.</param>
        void SetSubTreeByIndex(int index, TreeType newTree);

        /// <summary>
        /// Adds the given <paramref name="newTree"/> on a free index position.
        /// </summary>
        /// <param name="newTree">The new sub <see cref="TreeType"/> to add to this <see cref="ITreeable{TreeType}"/>.</param>
        /// <returns>Index position of the added <see cref="TreeType"/>.</returns>
        /// <exception cref="InvalidOperationException">There are no more available <see cref="TreeType"/> slots!</exception>
        int AddSubTree(TreeType newTree);

        /// <summary>
        /// Removes a <see cref="TreeType"/> at the given <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the target <see cref="TreeType"/>.</param>
        void RemoveSubTreeByIndex(int index);
    }
}
