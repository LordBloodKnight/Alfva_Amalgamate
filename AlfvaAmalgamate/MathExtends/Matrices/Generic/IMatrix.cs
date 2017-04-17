using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Holds generic matheable data <see cref="Type"/>s.
/// </summary>
namespace AlfvaAmalgamate.MathExtends.Matrices.Generic
{
    /// <summary>
    /// Interface for mathematical matrices any size and value type.
    /// </summary>
    /// <typeparam name="ElementsValueType">A <see cref="Type"/> that can be used in a matrix as element variable <see cref="Type"/>.</typeparam>
    public interface IMatrix<ElementsValueType>
    {
        /// <summary>
        /// Gets the <see cref="IMatrix{ElementsValueType}"/> elements.
        /// </summary>
        ElementsValueType[,] GetMatrixElements();

        /// <summary>
        /// Gets the row amounts.
        /// </summary>
        int GetRowAmounts();

        /// <summary>
        /// Gets the column amounts.
        /// </summary>
        int GetColumnAmounts();

        /// <summary>
        /// Gets a single element on the given matrix location.
        /// </summary>
        /// <param name="rowIdentifier">The target row.</param>
        /// <param name="columnIdentifier">The target column.</param>
        /// <returns>The element from the target location.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given target identifiers are pointing outside of this <see cref="IMatrix{ElementsValueType}"/>!</exception>
        ElementsValueType GetSingleElement(int rowIdentifier, int columnIdentifier);

        /// <summary>
        /// Sets a single element on the given matrix location.
        /// </summary>
        /// <param name="rowIdentifier">The target row.</param>
        /// <param name="columnIdentifier">The target column.</param>
        /// <param name="newValue">The new value to set the target element to.</param>
        /// <param name="checkedCalculation">If true and the given <paramref name="newValue"/> is invalid an exception gets thrown else this <see cref="IMatrix{ElementsValueType}"/> will make it to a valid element before setting it!</param>
        /// <remarks>Its faster than trying to set a single element with the <see cref="SetMatrixArea(int, int, IMatrix{ElementsValueType})"/>!</remarks>
        /// <exception cref="ArgumentOutOfRangeException">The given target identifiers are pointing outside of this <see cref="IMatrix{ElementsValueType}"/>!</exception>
        /// <exception cref="ArgumentException">The given <see cref="ElementsValueType"/> is not a valid element!</exception>
        void SetSingleElement(int rowIdentifier, int columnIdentifier, ElementsValueType newValue, bool checkedCalculation = false);

        /// <summary>
        /// Gets the wanted <see cref="IMatrix{ElementsValueType}"/> area from this <see cref="IMatrix{ElementsValueType}"/>.
        /// </summary>
        /// <param name="rowOffset">The row offset there the wanted matrix area starts.</param>
        /// <param name="columnOffset">The column offset there the wanted matrix area starts.</param>
        /// <param name="rowAmounts">The amount of rows to get from this <see cref="IMatrix{ElementsValueType}"/>.</param>
        /// <param name="columnAmounts">The amount of columns to get from this <see cref="IMatrix{ElementsValueType}"/>.</param>
        /// <returns>The wanted <see cref="IMatrix{ElementsValueType}"/> area.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The given row and/or column amounts are smaller 1 and this would return an unuseable <see cref="IMatrix{ElementsValueType}"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The target offset position and the wanted row and column amounts are pointing to a matrix area that is not fully inside of this <see cref="IMatrix{ElementsValueType}"/>!</exception>
        IMatrix<ElementsValueType> GetMatrixArea(int rowOffset, int columnOffset, int rowAmounts, int columnAmounts);

        /// <summary>
        /// Sets an area of elements in the <see cref="IMatrix{ElementsValueType}"/> with the given <see cref="IMatrix{ElementsValueType}"/>.
        /// </summary>
        /// <param name="rowOffset">The row offset there the given matrix area starts to replace the old elements.</param>
        /// <param name="columnOffset">The column offset there the given matrix area starts to replace the old elements.</param>
        /// <param name="newValueArea">A bunch/(matrix area) of elements to set the target area to.</param>
        /// <param name="checkedCalculation">If true and one element of the given <see cref="IMatrix{ElementsValueType}"/> is invalid an exception gets thrown else this <see cref="IMatrix{ElementsValueType}"/> will make it to a valid element before setting it!</param>
        /// <exception cref="ArgumentNullException">The given <see cref="IMatrix{ElementsValueType}"/> is null!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given newValueArea row/column amounts is smaller 1 so the matrix couldn't hold any values!</exception>
        /// <exception cref="ArgumentOutOfRangeException">One element of the given matrixToValidate is out of the valid range for this specific <see cref="GeneralMatrixViewModel{ElementsValueType}"/>!</exception>
        /// <exception cref="ArgumentOutOfRangeException">The given <see cref="IMatrix{ElementsValueType}"/> can't be placed fully in this <see cref="IMatrix{ElementsValueType}"/> on the target offset position!</exception>
        void SetMatrixArea(int rowOffset, int columnOffset, IMatrix<ElementsValueType> newValueArea, bool checkedCalculation = false);

        /// <summary>
        /// Gives the identity matrix of the given size for row and column.
        /// </summary>
        /// <param name="bothSidesSizes">The size for row and column.</param>
        /// <returns>An Identity matrix of the wanted size.</returns>
        /// <exception cref="ArgumentOutOfRangeException">A <see cref="IMatrix{ElementsValueType}"/> can't have a size smaller 1!</exception>
        IMatrix<ElementsValueType> IdentityMatrix(int bothSidesSizes);

        /// <summary>
        /// Is the given <see cref="ElementsValueType"/> a valid value for this <see cref="IMatrix{ElementsValueType}"/>?
        /// </summary>
        /// <param name="toValidate">The <see cref="ElementsValueType"/> to validate.</param>
        /// <returns>
        /// <list type="table">
        /// <listheader>
        /// <term>Return Value</term>
        /// <term>Condition</term>
        /// </listheader>
        /// <item>
        /// <term>True</term>
        /// <term>If <paramref name="toValidate"/> is a valid to the specified allowed <see cref="ElementsValueType"/> range to this <see cref="IMatrix{ElementsValueType}"/>.</term>
        /// </item>
        /// <item>
        /// <term>False</term>
        /// <term>If <paramref name="toValidate"/> is a invalid to the specified allowed <see cref="ElementsValueType"/> range to this <see cref="IMatrix{ElementsValueType}"/>.</term>
        /// </item>
        /// </list>
        /// </returns>
        /// </returns>
        bool IsValidValue(ElementsValueType toValidate);
        
        /// <summary>
        /// Converts the given <paramref name="toValityConvert"/> to a valid <see cref="ElementsValueType"/> that is in the allowed range of this specific <see cref="IMatrix{ElementsValueType}"/>.
        /// </summary>
        /// <param name="toValityConvert">To convert to a valid <see cref="ElementsValueType"/>.</param>
        /// <returns>The vality converted <see cref="ElementsValueType"/> value.</returns>
        ElementsValueType ValidConversation(ElementsValueType toValityConvert);

        /// <summary>
        /// Is the given matrix an <see cref="ElementsValueType"/> <see cref="Type"/> valid matrix?
        /// </summary>
        /// <param name="matrixToValidate">The matrix to validate.</param>
        /// <param name="violationException">Holds a constructed <see cref="Exception"/> specified to the violation of the first propertie that where checked and is not allowed. (On no violation this will be null!)</param>
        /// <param name="checkForSize">If true than the matrix size will be checked for validity. On violation the <paramref name="violationException"/> will be <see cref="ArgumentOutOfRangeException"/>.</param>
        /// <param name="checkForValues">If true than the matrix <see cref="ElementsValueType"/> values will be validated. On violation the <paramref name="violationException"/> will be <see cref="ArgumentOutOfRangeException"/>.</param>
        /// <returns>
        /// <list type="table">
        /// <listheader>
        /// <term>Return Value</term>
        /// <term>Condition</term>
        /// </listheader>
        /// <item>
        /// <term>True</term>
        /// <term>If <paramref name="matrixToValidate"/> is a valid in the checked properties to the specified allowed properties of an <see cref="ElementsValueType"/> <see cref="Type"/> matrix.</term>
        /// </item>
        /// <item>
        /// <term>False</term>
        /// <term>If <paramref name="matrixToValidate"/> violates the checked properties to the specified allowed properties of an <see cref="ElementsValueType"/> <see cref="Type"/> matrix.</term>
        /// </item>
        /// </list>
        /// </returns>
        /// <remarks>Giving a null matrix will automatically set the <paramref name="violationException"/> to the <see cref="ArgumentNullException"/> and return false!</remarks>
        bool IsValidMatrix(ElementsValueType[,] matrixToValidate, out Exception violationException, bool checkForSize = true, bool checkForValues = true);

        /// <summary>
        /// Is the given <see cref="IMatrix{ElementsValueType}"/> equal in row and column amounts?
        /// </summary>
        /// <param name="other">The other <see cref="IMatrix{ElementsValueType}"/> to check the row and column amounts with.</param>
        /// <remarks>Usefull for matrix operations with other matrices!</remarks>
        /// <returns>The boolean euqality result of the row and column amounts.</returns>
        bool EqualsRowColumnAmounts(IMatrix<ElementsValueType> other);

        #region innerMatrixOperations
        /// <summary>
        /// Switches two rows in this <see cref="IMatrix{ElementsValueType}"/>.
        /// </summary>
        /// <param name="firstRow">The first target row.</param>
        /// <param name="secondRow">The second target row.</param>
        /// <exception cref="ArgumentOutOfRangeException">One target row is not in the range of the matrix size!</exception>
        void SwitchRows(int firstRow, int secondRow);

        /// <summary>
        /// Multiplies the <paramref name="targetRow"/> with the given <paramref name="multiplier"/>.
        /// </summary>
        /// <param name="targetRow">The target row that gets multiplied.</param>
        /// <param name="multiplier">The multiplier for the <paramref name="targetRow"/>.</param>
        /// <param name="checkedCalculation">If true than <see cref="ArithmeticException"/>, <see cref="OverflowException"/> and <see cref="DivideByZeroException"/> are can get thrown.</param>
        /// <exception cref="OverflowException">One element of the <paramref name="targetRow"/> caused an <see cref="OverflowException"/>.</exception>
        /// <exception cref="ArithmeticException">The <paramref name="multiplier"/> is not be allowed to equals <see cref="ElementsValueType"/> neutral element value (typically 0)!</exception>
        void MultiplySingleRow(int targetRow, ElementsValueType multiplier, bool checkedCalculation = false);

        /// <summary>
        /// Works nearly the same as <see cref="MultiplySingleRow(int, ElementsValueType, bool)"/> but it will instead of overwriting the <paramref name="multiplierRow"/> return the result row as a new <see cref="IMatrix{ElementsValueType}"/>.
        /// </summary>
        /// <param name="multiplierRow">The row that gets used as multiplier.</param>
        /// <param name="multiplier">The multiplier for the <paramref name="multiplierRow"/>.</param>
        /// <param name="checkedCalculation">If true than <see cref="ArithmeticException"/>, <see cref="OverflowException"/> and <see cref="DivideByZeroException"/> are can get thrown.</param>
        /// <returns>The result row as a new <see cref="IMatrix{ElementsValueType}"/>.</returns>
        /// <exception cref="OverflowException">One element of the <paramref name="targetRow"/> caused an <see cref="OverflowException"/>.</exception>
        /// <exception cref="ArithmeticException">The <paramref name="multiplier"/> is not be allowed to equals <see cref="ElementsValueType"/> neutral element value (typically 0)!</exception>
        IMatrix<ElementsValueType> MultiplySingleRowToReturn(int multiplierRow, ElementsValueType multiplier, bool checkedCalculation = false);

        /// <summary>
        /// Adds the <paramref name="additiveRow"/> to the <paramref name="targetRow"/>.
        /// </summary>
        /// <param name="targetRow">The target row the additive gets added to.</param>
        /// <param name="additiveRow">The row to add to the <paramref name="targetRow"/>.</param>
        /// <param name="checkedCalculation">If true than <see cref="ArithmeticException"/>, <see cref="OverflowException"/> and <see cref="DivideByZeroException"/> are can get thrown.</param>
        void AddRowToRow(int targetRow, int additiveRow, bool checkedCalculation = false);

        /// <summary>
        /// Works nearly the same as <see cref="AddRowToRow(int, int, bool)"/> but it will instead of overwriting the <paramref name="startValueRow"/> return the result row as a new <see cref="IMatrix{ElementsValueType}"/>.
        /// </summary>
        /// <param name="startValueRow">The row the calculation starts from.</param>
        /// <param name="additiveRow">The row to add to the <paramref name="startValueRow"/>.</param>
        /// <param name="checkedCalculation">If true than <see cref="ArithmeticException"/>, <see cref="OverflowException"/> and <see cref="DivideByZeroException"/> are can get thrown.</param>
        /// <returns>The result row as a new <see cref="IMatrix{ElementsValueType}"/>.</returns>
        IMatrix<ElementsValueType> AddRowToRowToReturn(int startValueRow, int additiveRow, bool checkedCalculation = false);

        /// <summary>
        /// Subtracts the <paramref name="subtracterRow"/> from the <paramref name="targetRow"/>.
        /// </summary>
        /// <param name="targetRow">The target row the subtracter subtracts from.</param>
        /// <param name="subtracterRow">The row that subtracts his values from <paramref name="targetRow"/>.</param>
        /// <param name="checkedCalculation">If true than <see cref="ArithmeticException"/>, <see cref="OverflowException"/> and <see cref="DivideByZeroException"/> are can get thrown.</param>
        void SubtractRowFromRow(int targetRow, int subtracterRow, bool checkedCalculation = false);

        /// <summary>
        /// Works nearly the same as <see cref="SubtractRowFromRow(int, int, bool)"/> but it will instead of overwriting the <paramref name="startValueRow"/> return the result row as a new <see cref="IMatrix{ElementsValueType}"/>.
        /// </summary>
        /// <param name="startValueRow">The row the calculation starts from.</param>
        /// <param name="subtracterRow">The row that subtracts his values from <paramref name="startValueRow"/>.</param>
        /// <param name="checkedCalculation">If true than <see cref="ArithmeticException"/>, <see cref="OverflowException"/> and <see cref="DivideByZeroException"/> are can get thrown.</param>
        /// <returns>The result row as a new <see cref="IMatrix{ElementsValueType}"/>.</returns>
        IMatrix<ElementsValueType> SubtractRowFromRowToReturn(int targetRow, int subtracterRow, bool checkedCalculation = false);
        #endregion
    }
}
