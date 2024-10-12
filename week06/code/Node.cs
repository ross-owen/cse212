public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
        {
            return true;
        }

        if (value < Data)
        {
            return Left is not null && Left.Contains(value);
        }

        return Right is not null && Right.Contains(value);
    }

    public int GetHeight()
    {
        var left = Left?.GetHeight() ?? 0;
        var right = Right?.GetHeight() ?? 0;
        return Math.Max(left, right) + 1; // add 1 for self
    }
}