namespace ConsoleApp.Exercise4.Extensions
{
    public static class PluralizeExtension
    {
        /// <summary>
            /// Pluralize: takes a word, inserts a number in front, and makes the word plural if the number is not exactly 1.
            /// </summary>
            /// <example>"{n.Pluralize("maid")} a-milking</example>
            /// <param name="word">The word to make plural</param>
            /// <param name="number">The number of objects</param>
            /// <param name="pluralSuffix">An optional suffix; "s" is the default.</param>
            /// <param name="singularSuffix">An optional suffix if the count is 1; "" is the default.</param>
            /// <returns>Formatted string: "number word[suffix]", pluralSuffix (default "s") only added if the number is not 1, otherwise singularSuffix (default "") added</returns>
            internal static string Pluralize(this int number, string word, string pluralSuffix = "s", string singularSuffix = "")
            {
                return $@"{number} {word}{(number != 1 ? pluralSuffix : singularSuffix)}";
            }
        }
    }