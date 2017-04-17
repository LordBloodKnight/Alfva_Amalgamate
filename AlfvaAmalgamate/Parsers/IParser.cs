using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Holds parser interfaces and classes useable to parse a structured string into a specified <see cref="Type"/>.
/// </summary>
namespace AlfvaAmalgamate.Parsers
{
    /// <summary>
    /// Interface for every parser that parses a structured string into a <see cref="ParsableToType"/>.
    /// </summary>
    /// <typeparam name="ParsableToType">A <see cref="Type"/> that can be parsed to.</typeparam>
    public interface IParser<ParsableToType>
    {
        /// <summary>
        /// Parses the given <paramref name="toParse"/> into a <see cref="ParsableToType"/>.
        /// </summary>
        /// <param name="toParse">String to parse into <see cref="ParsableToType"/>.</param>
        /// <returns>Parsed <see cref="ParsableToType"/>.</returns>
        /// <exception cref="ArgumentNullException">The given <paramref name="toParse"/> is null!</exception>
        /// <exception cref="FormatException">The given <paramref name="toParse"/> does not represent a <see cref="ParsableToType"/> in a valid format.</exception>
        /// <exception cref="OverflowException">The given <paramref name="toParse"/> is outside the minimum or maximum of <see cref="ParsableToType"/>.</exception>
        ParsableToType Parse(string toParse);

        /// <summary>
        /// Parses the given <paramref name="toParse"/> into a <see cref="ParsableToType"/>.
        /// </summary>
        /// <param name="toParse">String to parse into <see cref="ParsableToType"/>.</param>
        /// <returns>Parsed <see cref="ParsableToType"/>.</returns>
        /// <exception cref="ArgumentNullException">The given <paramref name="toParse"/> is null!</exception>
        /// <exception cref="FormatException">The given <paramref name="toParse"/> does not represent a <see cref="ParsableToType"/> in a valid format.</exception>
        /// <exception cref="OverflowException">The given <paramref name="toParse"/> is outside the minimum or maximum of <see cref="ParsableToType"/>.</exception>
        ParsableToType Parse(StringBuilder toParse);

        /// <summary>
        /// Tryes to parses the given <paramref name="toParse"/> into a <see cref="ParsableToType"/>.
        /// </summary>
        /// <param name="toParse">String to parse into <see cref="ParsableToType"/>.</param>
        /// <param name="result">The parsed <paramref name="toParse"/> as <see cref="ParsableToType"/>.</param>
        /// <returns>
        /// <list type="table">
        /// <listheader>
        /// <term>Return Value</term>
        /// <term>Condition</term>
        /// </listheader>
        /// <item>
        /// <term>True</term>
        /// <term>If parsing was successfull.</term>
        /// </item>
        /// <item>
        /// <term>False</term>
        /// <term>If parsing failed because of a converting <see cref="Exception"/>.</term>
        /// </item>
        /// </list>
        /// </returns>
        bool TryParse(string toParse, out ParsableToType result);

        /// <summary>
        /// Tryes to parses the given <paramref name="toParse"/> into a <see cref="ParsableToType"/>.
        /// </summary>
        /// <param name="toParse">String to parse into <see cref="ParsableToType"/>.</param>
        /// <param name="result">The parsed <paramref name="toParse"/> as <see cref="ParsableToType"/>.</param>
        /// <returns>
        /// <list type="table">
        /// <listheader>
        /// <term>Return Value</term>
        /// <term>Condition</term>
        /// </listheader>
        /// <item>
        /// <term>True</term>
        /// <term>If parsing was successfull.</term>
        /// </item>
        /// <item>
        /// <term>False</term>
        /// <term>If parsing failed because of a converting <see cref="Exception"/>.</term>
        /// </item>
        /// </list>
        /// </returns>
        bool TryParse(StringBuilder toParse, out ParsableToType result);
    }
}
