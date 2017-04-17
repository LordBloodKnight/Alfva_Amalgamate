using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using AlfvaAmalgamate.MVVM;
using AlfvaAmalgamate.Trees.Generic;
using AlfvaAmalgamate.MathExtends.Matrices.Generic;

/// <summary>
/// Holds interfaces and classes that representing generic tree based structuring and execution. 
/// </summary>
namespace AlfvaAmalgamate.MathExtends.Generic
{
    /// <summary>
    /// General class every 
    /// </summary>
    /// <typeparam name="CalculationType"></typeparam>
    /// <typeparam name="VectorCaculationType"></typeparam>
    /// <typeparam name="MatrixCalculationType"></typeparam>
    public abstract class GeneralMathTree<CalculationType, VectorCaculationType, MatrixCalculationType> : BaseViewModel, IMathableTree<CalculationType, VectorCaculationType, MatrixCalculationType> where CalculationType : struct where VectorCaculationType : GeneralVector<CalculationType> where MatrixCalculationType : GeneralMatrixViewModel<CalculationType>
    {
        //
        public abstract int GetMaxAllowedSupTrees();

        //
        public abstract int AddSubTree(IMathableTree<CalculationType, VectorCaculationType, MatrixCalculationType> newTree);

        //
        public abstract ITreeable<IMathableTree<CalculationType, VectorCaculationType, MatrixCalculationType>> GetSubTreeByIndex(int index);

        //
        public abstract void RemoveSubTreeByIndex(int index);

        //
        public abstract void SetSubTreeByIndex(int index, IMathableTree<CalculationType, VectorCaculationType, MatrixCalculationType> newTree);

        /// <summary>
        /// Gets a <see cref="SortedList{string, CalculationType}"/> with all named variables and there default value.
        /// </summary>
        /// <typeparam name="CalculationType">A <see cref="Type"/> with those a calculation is possible.</typeparam>
        /// <param name="explicitConversion">If true and a default value couldn't converted into <typeparamref name="CalculationType"/> without an <see cref="Exception"/> than it will converted to his nearest convertable value.</param>
        /// <returns>A <see cref="SortedList{string, CalculationType}"/> of all named </returns>
        public abstract SortedList<string, CalculationType> GetNamedDefaultVariables/*<CalculationType>*/(bool explicitConversion);

        /// <summary>
        /// Gets the priority of this <see cref="GeneralMathTree"/>.
        /// </summary>
        /// <returns>The priority of this <see cref="GeneralMathTree"/>.</returns>
        /// <remarks>A higher priority means that it must be filled/calculated before the lower priority.</remarks>
        public abstract int GetPriority();

        /// <summary>
        /// Calculates the sub parts of this <see cref="GeneralMathTree"/> and returns the combined <typeparamref name="CalculationType"/>.
        /// </summary>
        /// <typeparam name="CalculationType">A <see cref="Type"/> with those a calculation is possible.</typeparam>
        /// <param name="dynamicVariables">Values for named variables in this <see cref="GeneralMathTree"/>.</param>
        /// <returns>The calculated result <typeparamref name="CalculationType"/>.</returns>
        /// <exception cref="ArithmeticException">
        /// All <see cref="ArithmeticException"/>s that can occur during an caclulation:
        /// <see cref="ArithmeticException"/>; <see cref="ArgumentOutOfRangeException"/>; <see cref="DivideByZeroException"/>; <see cref="OverflowException"/>; <see cref="NotFiniteNumberException"/>
        /// </exception>
        /// <remarks><see cref="VectorCaculationType"/> and <see cref="MatrixCalculationType"/> results are getting converted down to <see cref="CalculationType"/>!</remarks>
        public abstract CalculationType Calculate(SortedList<string, CalculationType> dynamicVariables = null);

        /// <summary>
        /// Tryes to calculate the sub parts of this <see cref="GeneralMathTree"/> and outputs in <paramref name="result"/> the combined <typeparamref name="CalculationType"/>.
        /// </summary>
        /// <typeparam name="CalculationType">A <see cref="Type"/> with those a calculation is possible.</typeparam>
        /// <param name="result">The calculated result.</param>
        /// <param name="dynamicVariables">Values for named variables in this <see cref="GeneralMathTree"/>.</param>
        /// <returns>True if no <see cref="ArithmeticException"/> occured else false.</returns>
        /// <remarks><see cref="VectorCaculationType"/> and <see cref="MatrixCalculationType"/> results are getting converted down to <see cref="CalculationType"/>!</remarks>
        public abstract bool TryCalculate(out CalculationType result, SortedList<string, CalculationType> dynamicVariables = null);
    }
}
