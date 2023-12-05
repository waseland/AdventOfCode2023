public class CodeConundrum
{
    public static int Solve(string[] lines)
    {
        // Initialize sum to store the total power of all games
        int sum = 0;

        // Iterate over each line (game)
        foreach (var line in lines)
        {
            // Split the line into game parts
            var gameParts = line.Split(':');
            // Split the second part of each line into game sets
            var gameSets = gameParts[1].Split(';');

            // Initialize the maximum minimums for each color
            int maxMinBlue = 0, maxMinRed = 0, maxMinGreen = 0;

            // Iterate over each set in the game
            foreach (var set in gameSets)
            {
                // Initialize the counts for each color in the set
                int blue = 0, red = 0, green = 0;
                // Split the set into individual cubes
                var cubes = set.Split(',');

                // Iterate over each cube in the set
                foreach (var cube in cubes)
                {
                    // Split the cube into its parts (count and color)
                    var cubeParts = cube.Trim().Split(' ');
                    // Parse the count of the cube
                    var cubeCount = int.Parse(cubeParts[0]);
                    // Get the color of the cube
                    var cubeColor = cubeParts[1];

                    // Add the count to the appropriate color
                    switch (cubeColor)
                    {
                        case "blue":
                            blue += cubeCount;
                            break;
                        case "red":
                            red += cubeCount;
                            break;
                        case "green":
                            green += cubeCount;
                            break;
                    }
                }

                // Update the maximum minimums for each color
                maxMinBlue = Math.Max(maxMinBlue, blue);
                maxMinRed = Math.Max(maxMinRed, red);
                maxMinGreen = Math.Max(maxMinGreen, green);
            }

            // Calculate the power of the minimum set of cubes for the game
            int power = maxMinBlue * maxMinRed * maxMinGreen;
            // Add the power to the total sum
            sum += power;
        }

        // Return the total sum
        return sum;
    }
}