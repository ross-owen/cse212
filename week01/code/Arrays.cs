public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // 1. create an array of doubles and initialize the length of value length
        // 2. loop using variable `i` from 1 to the length value (inclusive)
        // 2a. within the loop, multiply `number` and `i` value and store at `i - 1` (since the array begins at index zero and we are starting at 1)
        // 3. after looping is complete, return the array
        var results = new double [length];
        for (var i = 1; i <= length; i++)
        {
            results[i - 1] = number * i;
        }

        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // 1. initialize a variable `result` new List<int> to the same count as `data`
        // 2. create a `startAt` variable and set it to the `data` count minus the value of `amount` 
        //    example: if data has 10 elements (size is 10) and the amount is 3, the calculated value would be 10 - 3 = 7
        // 3. create an index `i` loop from `startAt` to the size of `data` (exclusive)
        // 3a. inside of the loop add the value from data to the result list
        // 4. create an index `i` loop from 0 to `startAt` (exclusive)
        // 4a. inside of the loop add the value from data to the result list
        // 5. loop through the result list setting the values at the same index in the data list making it match result
        
        // NOTE: this would be better to return the result instead of overwriting the original list
        // however, the complexity isn't bothered much when considering big O, since this results in O(2n) --> o(n)

        var result = new List<int>(data.Count);

        var startAt = data.Count - amount;
        for (var i = startAt; i < data.Count; i++)
        {
            result.Add(data[i]);
        }
        
        for (var i = 0; i < startAt; i++)
        {
            result.Add(data[i]);
        }

        for (var i = 0; i < result.Count; i++)
        {
            data[i] = result[i];
        }
    }
}
