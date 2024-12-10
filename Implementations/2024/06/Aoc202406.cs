using Implementations.Helpers;
using Implementations.Helpers.Enums;

namespace Implementations._2024._06;

using Vector = (Coordinate Position, Coordinate Direction);

public class Aoc202406 : IAoc<int, int>
{
    public int SolvePart1()
    {
        LoadInput();
        var guardPos        = GetGuardPosition();
        var currDir         = PossibleMovements[Directions.UP];
        var patrolPositions = new List<Coordinate>();
        while (!guardPos.OutOfBounds(Input[0].Length, Input.Length))
        {
            patrolPositions.Add(guardPos);
            currDir  =  GetNewDirection(guardPos, currDir);
            guardPos += currDir;
        }

        return patrolPositions.Distinct().Count();
    }

    public int SolvePart2()
    {
        LoadInput();
        var guardPos             = GetGuardPosition();
        var initialGuardPosition = guardPos;
        var currDir              = PossibleMovements[Directions.UP];
        var patrolPositions      = new HashSet<Coordinate>();
        var loopsCount           =0;
        while (!guardPos.OutOfBounds(Input[0].Length, Input.Length))
        {
            patrolPositions.Add(guardPos);
            currDir  =  GetNewDirection(guardPos, currDir);
            guardPos += currDir;
        }

        foreach (var pos in patrolPositions.Skip(1))
        {
            if (CheckLoop(initialGuardPosition, pos))
            {
                loopsCount++;
            }
        }
        return loopsCount;
    }

    private bool CheckLoop( Coordinate guardPos, Coordinate possibleObstruction)
    {
        var currDir=PossibleMovements[Directions.UP];
        Input[possibleObstruction.Y][possibleObstruction.X] = Obstacle;
        var loopDirection=GetNewDirection(guardPos,currDir);
        var loopPosition  = guardPos + loopDirection;
        var loopPositions = new HashSet<Vector>();
        while (!loopPosition.OutOfBounds(Input[0].Length, Input.Length))
        {
            if (!loopPositions.Add((loopPosition, loopDirection)))
            {
                Input[possibleObstruction.Y][possibleObstruction.X] = '.';
                return true;
            }
            loopDirection =  GetNewDirection(loopPosition, loopDirection);
            loopPosition  += loopDirection;
        }
        Input[possibleObstruction.Y][possibleObstruction.X] = '.';
        return false;
    }

    private void LoadInput()
    {
        Input = File.ReadAllLines("2024/06/Input.txt").Select(x => x.ToCharArray()).ToArray();
    }

    private Coordinate GetNewDirection(Coordinate guardPos, Coordinate currDir)
    {
        var newPos = guardPos + currDir;
        while (!newPos.OutOfBounds(Input[0].Length, Input.Length) && Input[newPos.Y][newPos.X] == Obstacle)
        {
            currDir = RotateDirection(currDir);
            newPos  = guardPos + currDir;
        }

        return currDir;
    }

    private Coordinate RotateDirection(Coordinate currDir)
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

    private Coordinate GetGuardPosition()
    {
        for (int i = 0; i < Input.Length; i++)
        {
            var currLine = Input[i];
            for (int j = 0; j < currLine.Length; j++)
            {
                if (currLine[j] == Guard)
                {
                    return new Coordinate(j, i);
                }
            }
        }

        throw new Exception("GUARD NOT FOUND");
    }

    private       char[][] Input { get; set; }
    private const char     Guard    = '^';
    private const char     Obstacle = '#';

    private Dictionary<Directions, Coordinate> PossibleMovements = new()
                                                                   {
                                                                       { Directions.UP, new(0, -1) },
                                                                       { Directions.DOWN, new(0, 1) },
                                                                       { Directions.LEFT, new(-1, 0) },
                                                                       { Directions.RIGHT, new(1, 0) }
                                                                   };
}