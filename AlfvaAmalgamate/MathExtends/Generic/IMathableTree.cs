using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlfvaAmalgamate.Trees.Generic;
using AlfvaAmalgamate.MathExtends.Matrices.Generic;
using AlfvaAmalgamate.MathExtends.Matrices;

/// <summary>
/// Holds interfaces and classes that representing generic tree based structuring and execution. 
/// </summary>
namespace AlfvaAmalgamate.MathExtends.Generic
{
    /// <summary>
    /// Interface for all <see cref="ITreeable"/> that can be used in the math enviroment.
    /// </summary>
    public interface IMathableTree<CalculationType, VectorCaculationType, MatrixCalculationType> : ITreeable<IMathableTree<CalculationType, VectorCaculationType, MatrixCalculationType>> where CalculationType : struct where VectorCaculationType : GeneralVector<CalculationType> where MatrixCalculationType : GeneralMatrixViewModel<CalculationType>
    {
        /// <summary>
        /// Gets the priority of this <see cref="IMathableTree"/>.
        /// </summary>
        /// <returns>The priority of this <see cref="IMathableTree"/>.</returns>
        /// <remarks>A higher priority means that it must be filled/calculated before the lower priority.</remarks>
        int GetPriority();

        /// <summary>
        /// Gets a <see cref="SortedList{string, CalculationType}"/> with all named variables and there default value.
        /// </summary>
        /// <typeparam name="CalculationType">A <see cref="Type"/> with those a calculation is possible.</typeparam>
        /// <param name="explicitConversion">If true and a default value couldn't converted into <typeparamref name="CalculationType"/> without an <see cref="Exception"/> than it will converted to his nearest convertable value.</param>
        /// <returns>A <see cref="SortedList{string, CalculationType}"/> of all named </returns>
        SortedList<string, CalculationType> GetNamedDefaultVariables(bool explicitConversion);

        /// <summary>
        /// Calculates the sub parts of this <see cref="IMathableTree"/> and returns the combined <typeparamref name="CalculationType"/>.
        /// </summary>
        /// <typeparam name="CalculationType">A <see cref="Type"/> with those a calculation is possible.</typeparam>
        /// <param name="dynamicVariables">Values for named variables in this <see cref="IMathableTree"/>.</param>
        /// <returns>The calculated result <typeparamref name="CalculationType"/>.</returns>
        /// <exception cref="ArithmeticException">
        /// All <see cref="ArithmeticException"/>s that can occur during an caclulation:
        /// <see cref="ArgumentOutOfRangeException"/>; <see cref="DivideByZeroException"/>; <see cref="OverflowException"/>; <see cref="NotFiniteNumberException"/>
        /// </exception>
        CalculationType Calculate(SortedList<string, CalculationType> dynamicVariables = null);

        /// <summary>
        /// Tryes to calculate the sub parts of this <see cref="IMathableTree"/> and outputs in <paramref name="result"/> the combined <typeparamref name="CalculationType"/>.
        /// </summary>
        /// <typeparam name="CalculationType">A <see cref="Type"/> with those a calculation is possible.</typeparam>
        /// <param name="result">The calculated result.</param>
        /// <param name="dynamicVariables">Values for named variables in this <see cref="IMathableTree"/>.</param>
        /// <returns>True if no <see cref="ArithmeticException"/> occured else false.</returns>
        bool TryCalculate(out CalculationType result, SortedList<string, CalculationType> dynamicVariables = null);
    }
}
