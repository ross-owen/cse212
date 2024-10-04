/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    // 'left', 'right', 'up', and 'down'
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        Move(Direction.Left);
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        Move(Direction.Right);
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        Move(Direction.Up);
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        Move(Direction.Down);
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }

    private void Move(Direction direction)
    {
        var validMovements = _mazeMap[(_currX, _currY)];
        if (validMovements[(int)direction])
        {
            switch (direction)
            {
                case Direction.Left:
                    _currX--;
                    break;
                case Direction.Right:
                    _currX++;
                    break;
                case Direction.Up:
                    _currY--;
                    break;
                case Direction.Down:
                    _currY++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, "Bad programmer! bad, bad.");
            }
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }
}

internal enum Direction
{
    Left = 0,
    Right = 1,
    Up = 2,
    Down = 3
}