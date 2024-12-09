using Implementations.Helpers;
using Implementations.Helpers.Enums;

namespace Implementations._2024._06;

public class Aoc202406 : IAoc<int, int>
{
    public int SolvePart1()
    {
        LoadInput();
        var guardPos         = GetGuardPosition();
        var currDir          = PossibleMovements[Directions.UP];
        while (!guardPos.OutOfBounds(Input[0].Length, Input.Length))
        {
            Input[guardPos.Y][guardPos.X] =  'X';
            currDir                       =  GetNewDirection(guardPos, currDir);
            guardPos                      += currDir;
        }

        return Input.Sum(x => x.Count(y => y == 'X'));
    }

    public int SolvePart2()
    {
        LoadInput();
        var guardPos         = GetGuardPosition();
        var currDir          = PossibleMovements[Directions.UP];
        var guardStartingPos = guardPos;
        while (!guardPos.OutOfBounds(Input[0].Length, Input.Length))
        {
            Input[guardPos.Y][guardPos.X] = PlaceGuardDirection(currDir);
            var possibleLoopPos = guardPos + RotateDirection(currDir);
            if (!possibleLoopPos.OutOfBounds(Input[0].Length, Input.Length)
             && Input[possibleLoopPos.Y][possibleLoopPos.X] != LOOP)
            {
                if (currDir == PossibleMovements[Directions.UP]
                 && Input[possibleLoopPos.Y][possibleLoopPos.X] == H_DIR)
                {
                    Input[possibleLoopPos.Y][possibleLoopPos.X] = LOOP;
                }
                else if (currDir == PossibleMovements[Directions.RIGHT]
                      && Input[possibleLoopPos.Y][possibleLoopPos.X] == V_DIR)
                {
                    Input[possibleLoopPos.Y][possibleLoopPos.X] = LOOP;
                }
                else if (currDir == PossibleMovements[Directions.DOWN]
                      && Input[possibleLoopPos.Y][possibleLoopPos.X] == H_DIR)
                {
                    Input[possibleLoopPos.Y][possibleLoopPos.X] = LOOP;
                }
                else if (currDir == PossibleMovements[Directions.LEFT]
                      && Input[possibleLoopPos.Y][possibleLoopPos.X] == V_DIR)
                {
                    Input[possibleLoopPos.Y][possibleLoopPos.X] = LOOP;
                }
            }

            currDir  =  GetNewDirection(guardPos, currDir);
            guardPos += currDir;
        }

        foreach (var c in Input)
        {
            Console.WriteLine(new string(c));
        }
        return Input.Sum(x => x.Count(y => y == LOOP));
    }

    private void LoadInput()
    {
        Input = File.ReadAllLines("2024/06/Test.txt").Select(x => x.ToCharArray()).ToArray();
    }

    private Position GetNewDirection(Position guardPos, Position currDir)
    {
        var newPos = guardPos + currDir;
        while (!newPos.OutOfBounds(Input[0].Length, Input.Length) && Input[newPos.Y][newPos.X] == OBSTACLE)
        {
            currDir = RotateDirection(currDir);
            newPos  = guardPos + currDir;
        }

        return currDir;
    }

    private Position RotateDirection(Position currDir)
    {
        return currDir switch
               {
                   { X: 1, Y : 0 }  => PossibleMovements[Directions.DOWN],
                   { X: -1, Y: 0 }  => PossibleMovements[Directions.UP],
                   { X: 0, Y : 1 }  => PossibleMovements[Directions.LEFT],
                   { X: 0, Y : -1 } => PossibleMovements[Directions.RIGHT],
                   _                => throw new ArgumentOutOfRangeException()
               };
    }

    private char PlaceGuardDirection(Position currDir) =>
        currDir switch
        {
            { X: 1, Y : 0 }  => H_DIR,
            { X: -1, Y: 0 }  => H_DIR,
            { X: 0, Y : 1 }  => V_DIR,
            { X: 0, Y : -1 } => V_DIR,
        };

    private Position GetGuardPosition()
    {
        for (int i = 0; i < Input.Length; i++)
        {
            var currLine = Input[i];
            for (int j = 0; j < currLine.Length; j++)
            {
                if (currLine[j] == GUARD)
                {
                    return new Position(j, i);
                }
            }
        }

        throw new Exception("GUARD NOT FOUND");
    }

    private       char[][] Input { get; set; }
    private const char     GUARD    = '^';
    private const char     OBSTACLE = '#';
    private const char     H_DIR    = '-';
    private const char     V_DIR    = '|';
    private const char     LOOP     = 'O';

    private Dictionary<Directions, Position> PossibleMovements = new()
                                                                 {
                                                                     { Directions.UP, new(0, -1) },
                                                                     { Directions.DOWN, new(0, 1) },
                                                                     { Directions.LEFT, new(-1, 0) },
                                                                     { Directions.RIGHT, new(1, 0) }
                                                                 };
}

public record Position(int X, int Y)
{
    public static Position operator +(Position left, Position right) => new(left.X + right.X, left.Y + right.Y);
    public        bool OutOfBounds(int         maxX, int      maxY)  => X < 0 || Y < 0 || X >= maxX || Y >= maxY;
}