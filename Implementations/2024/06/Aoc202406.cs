using Implementations.Helpers;
using Implementations.Helpers.Enums;

namespace Implementations._2024._06;

using Vector = (Coordinate Position, Directions Direction);

public class Aoc202406 : IAoc<int, int>
{
    public int SolvePart1()
    {
        LoadInput();
        var guardPos        = GetGuardPosition();
        var currDir         = Directions.UP;
        var patrolPositions = new List<Coordinate>();
        while (!guardPos.OutOfBounds(Input[0].Length, Input.Length))
        {
            patrolPositions.Add(guardPos);
            currDir  =  GetNewDirection(guardPos, currDir);
            guardPos += Coordinate.GetDirectionVector(currDir);
        }

        return patrolPositions.Distinct().Count();
    }

    public int SolvePart2()
    {
        LoadInput();
        var guardPos             = GetGuardPosition();
        var initialGuardPosition = guardPos;
        var currDir              = Directions.UP;
        var patrolPositions      = new HashSet<Coordinate>();
        var loopsCount           =0;
        while (!guardPos.OutOfBounds(Input[0].Length, Input.Length))
        {
            patrolPositions.Add(guardPos);
            currDir  =  GetNewDirection(guardPos, currDir);
            guardPos += Coordinate.GetDirectionVector(currDir);
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
        var currDir=Directions.UP;
        Input[possibleObstruction.Y][possibleObstruction.X] = Obstacle;
        var loopDirection=GetNewDirection(guardPos,currDir);
        var loopPosition  = guardPos + Coordinate.GetDirectionVector(loopDirection);
        var loopPositions = new HashSet<Vector>();
        while (!loopPosition.OutOfBounds(Input[0].Length, Input.Length))
        {
            if (!loopPositions.Add((loopPosition, loopDirection)))
            {
                Input[possibleObstruction.Y][possibleObstruction.X] = '.';
                return true;
            }
            loopDirection =  GetNewDirection(loopPosition, loopDirection);
            loopPosition  += Coordinate.GetDirectionVector(loopDirection);
        }
        Input[possibleObstruction.Y][possibleObstruction.X] = '.';
        return false;
    }

    private void LoadInput()
    {
        Input = File.ReadAllLines("2024/06/Input.txt").Select(x => x.ToCharArray()).ToArray();
    }

    private Directions GetNewDirection(Coordinate guardPos, Directions currDir)
    {
        var newPos = guardPos + Coordinate.GetDirectionVector(currDir);
        while (!newPos.OutOfBounds(Input[0].Length, Input.Length) && Input[newPos.Y][newPos.X] == Obstacle)
        {
            currDir = RotateDirection(currDir);
            newPos  = guardPos + Coordinate.GetDirectionVector(currDir);
        }

        return currDir;
    }

    private Directions RotateDirection(Directions currDir)
    {
        return currDir switch
               {
                   Directions.RIGHT => Directions.DOWN,
                   Directions.LEFT  => Directions.UP,
                   Directions.DOWN  => Directions.LEFT,
                   Directions.UP    => Directions.RIGHT,
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

    
}