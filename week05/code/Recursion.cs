using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
        {
            return 0;
        }

        var pow = Math.Pow(n, 2);
        return (int)pow + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // if there's not a wildcard, simply add the pattern to the results and exit
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }
        
        for (var i = 0; i < pattern.Length; i++)
        {
            if (pattern[i] != '*')
            {
                continue;
            }

            // get the left and right side of the wildcard so i can build the two strings
            // that will become the new "pattern" within the recursion
            var leftSide = pattern[..i];
            var rightSide = pattern[(i + 1)..];

            // recurse these new patterns. if no remaining wildcards, they will get added to the results
            // see above
            WildcardBinary(leftSide + "0" + rightSide, results);
            WildcardBinary(leftSide + "1" + rightSide, results);
                
            // since I've found a wildcard, and I've recursed replacing that wildcard, just return
            // any remaining wildcards will get handled within the recursion
            return;
        }
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
        }
        else
        {
            for (var i = 0; i < letters.Length; i++)
            {
                var lettersLeft = letters.Remove(i, 1);
                PermutationsChoose(results, lettersLeft, size, word + letters[i]);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int steps, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (steps == 0)
            return 0;
        if (steps == 1)
            return 1;
        if (steps == 2)
            return 2;
        if (steps == 3)
            return 4;

        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        if (remember.TryGetValue(steps, out var climb))
        {
            return climb;
        }
        // Solve using recursion
        decimal ways = CountWaysToClimb(steps - 1, remember) 
                       + CountWaysToClimb(steps - 2, remember) 
                       + CountWaysToClimb(steps - 3, remember);
        remember[steps] = ways;
        
        return ways;
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        currPath ??= [];
        currPath.Add((x, y));
        
        // am i at the end?
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            return;
        }
        
        // try moving all directions
        // the move method will recursively call SolveMaze
        Move(x, y - 1, maze, currPath, results);
        Move(x, y + 1, maze, currPath, results);
        Move(x - 1, y, maze, currPath, results);
        Move(x + 1, y, maze, currPath, results);
    }

    private static void Move(int x, int y, Maze maze, List<(int, int)> currPath, List<string> results)
    {
        if (!maze.IsValidMove(currPath, x, y))
            return;

        SolveMaze(results, maze, x, y, currPath); // will recurse through until either blocked or at the end
        currPath.Remove((x, y));    // remove it since we've either been blocked or successfully hit the end so we can look for another path
    }
}