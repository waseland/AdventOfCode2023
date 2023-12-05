public static class GearRatios
{
    public static int Solve(string[] input)
    {
        // Initialize the sum of part numbers
        int sum = 0;

        // Iterate over each line in the input
        for (int i = 0; i < input.Length; i++)
        {
            // Iterate over each character in the line
            for (int j = 0; j < input[i].Length; j++)
            {
                // If the character is a digit, it might be part of a part number
                if (Char.IsDigit(input[i][j]))
                {
                    // Find the end of the sequence of digits
                    int end = j;
                    while (end < input[i].Length && Char.IsDigit(input[i][end]))
                        end++;

                    // Extract the number from the line
                    string numberStr = input[i].Substring(j, end - j);
                    int number = int.Parse(numberStr);

                    // Check if the number is adjacent to a symbol
                    bool isAdjacentToSymbol = false;
                    for (int k = j; k < end; k++)
                    {
                        // Check all 8 directions around the digit
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            for (int dy = -1; dy <= 1; dy++)
                            {
                                int nx = i + dx;
                                int ny = k + dy;

                                // If the adjacent character is within the bounds of the input and is a symbol, the number is adjacent to a symbol
                                if (nx >= 0 && nx < input.Length && ny >= 0 && ny < input[i].Length && !Char.IsDigit(input[nx][ny]) && input[nx][ny] != '.')
                                {
                                    isAdjacentToSymbol = true;
                                    break;
                                }
                            }
                            if (isAdjacentToSymbol)
                                break;
                        }
                        if (isAdjacentToSymbol)
                            break;
                    }

                    // If the number is adjacent to a symbol, add it to the sum
                    if (isAdjacentToSymbol)
                        sum += number;

                    // Skip over the rest of the number
                    j = end - 1;
                }
            }
        }

        // Return the sum of the part numbers
        return sum;
    }
}