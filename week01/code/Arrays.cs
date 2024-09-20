public static class Arrays
{
    // * <summary>
    // * This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    // * example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    // * integer greater than 0.
    // * </summary>
    // * <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        var doubleArray = new double[length];
        // * Run a for loop to have i <= length
        for (int i = 0; i < length; i++){
            // * For each index, multiply the number and add the result to the array
            var answer = number * (i+1);
            doubleArray[i] = answer;
        }

        return doubleArray;
    }

    // */ <summary>
    // */ Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    // */ List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    // */ List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    // */
    // */ Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    // */ </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // * Get the length of the list
        int count = data.Count;

        // * Make sure this is not 0
        amount = amount % count;
        if (amount == 0) return;

        // * Split the data List and get the necessary values
        var rightPart = data.GetRange(count - amount, amount);
        var leftPart = data.GetRange(0, count - amount);

        // * Clear the list and add the new data back into the List
        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
