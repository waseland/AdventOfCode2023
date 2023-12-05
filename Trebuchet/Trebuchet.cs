using System.Text.RegularExpressions;

public class Trebuchet
{
    private static Dictionary<string, int> wordsToDigits = new Dictionary<string, int>
{
    {"one", 1},
    {"two", 2},
    {"three", 3},
    {"four", 4},
    {"five", 5},
    {"six", 6},
    {"seven", 7},
    {"eight", 8},
    {"nine", 9}
};

    // This method calculates the sum of calibration values from a list of lines.
    public static int Solve(string[] lines)
    {
        // Initialize total to 0. This will hold the sum of all calibration values.
        int total = 0;

        // Iterate over each line in the input.
        foreach (var line in lines)
        {
            // Use a regular expression to match either a digit or one of the spelled out digits.
            // Convert each match to its value and convert the resulting sequence to a list.
            var first = Regex.Matches(line, @"one|two|three|four|five|six|seven|eight|nine|\d", RegexOptions.IgnoreCase)
                .Select(m => m.Value)
                .First();

            var last = Regex.Matches(line, @"one|two|three|four|five|six|seven|eight|nine|\d", RegexOptions.RightToLeft)
                .Select(m => m.Value)
                .First();

            // If there are any words in the list, get the first and last word.
            if (first.Any())
            {
                // If the word is a digit, parse it to an integer.
                // If the word is a spelled out digit, look up its numerical equivalent in the wordsToDigits dictionary.
                int firstDigit = first.All(char.IsDigit) ? int.Parse(first) : wordsToDigits[first];
                int lastDigit = last.All(char.IsDigit) ? int.Parse(last) : wordsToDigits[last];

                // Combine the first and last digit to form a two-digit number, parse it to an integer, and add it to the total.
                total += int.Parse($"{firstDigit}{lastDigit}");
            }
        }

        // Return the total.
        return total;
    }
}