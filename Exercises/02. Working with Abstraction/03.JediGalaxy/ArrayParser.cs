using System.Linq;

public class ArrayParser
{
    public int[] IntegersParser(string[] args)
    {
        int[] numbers = args.Select(int.Parse).ToArray();

        return numbers;
    }
}