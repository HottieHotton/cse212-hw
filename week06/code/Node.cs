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
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else if (Left.Data != value)
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else if (Right.Data != value)
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {

        if (Data == value)
        {
            return true;
        }

        if (Left != null && Left.Contains(value))
        {
            return true;
        }

        if (Right != null && Right.Contains(value))
        {
            return true;
        }

        return false;
    }

    public int GetHeight()
    {
        int leftHeight = 1;
        int rightHeight = 1;
        
        if (Left == null && Right == null)
            return 1;

        if (Left != null)
            leftHeight = Left.GetHeight();

        if (Right != null)
            rightHeight = Right.GetHeight();

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}