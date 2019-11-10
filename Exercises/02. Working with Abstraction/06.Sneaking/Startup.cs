using System;

public class Startup
{
    static char[][] room;

    static void ReadRoom(int rows)
    {
        room = new char[rows][];

        for (int row = 0; row < rows; row++)
        {
            room[row] = Console.ReadLine().ToCharArray(); ;
        }
    }

    static Cell GetPosition(char c)
    {
        int rows = room.Length;
        Cell position = new Cell();
        bool isPositionFound = false;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == c)
                {
                    position.Row = row;
                    position.Col = col;

                    isPositionFound = true;
                    break;
                }
            }

            if (isPositionFound)
            {
                break;
            }
        }

        return position;
    }

    static void MoveEnemy(int row, ref int col)
    {
        if (room[row][col] == 'b')
        {
            if (col + 1 >= 0 && col + 1 < room[row].Length)
            {
                room[row][col] = '.';
                room[row][col + 1] = 'b';
                col++;
            }
            else
            {
                room[row][col] = 'd';
            }
        }
        else if (room[row][col] == 'd')
        {
            if (col - 1 >= 0 && col - 1 < room[row].Length)
            {
                room[row][col] = '.';
                room[row][col - 1] = 'd';
            }
            else
            {
                room[row][col] = 'b';
            }
        }
    }

    static void MoveEnemies()
    {
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if ("bd".IndexOf(room[row][col]) != -1)
                {
                    MoveEnemy(row, ref col);
                }
            }
        }
    }

    static Cell GetPatrollingEnemyPosition(int samRow)
    {
        Cell patrollingEnemyPosition = new Cell();

        for (int col = 0; col < room[samRow].Length; col++)
        {
            if ("bd".IndexOf(room[samRow][col]) != -1)
            {
                patrollingEnemyPosition.Row = samRow;
                patrollingEnemyPosition.Col = col;
                break;
            }
        }

        return patrollingEnemyPosition;
    }

    static bool IsSamKilled(Cell samPosition, Cell patrollingEnemyPosition)
    {
        bool isSamKilled = false;
        int samRow = samPosition.Row,
            samCol = samPosition.Col;
        int patrollingEnemyRow = patrollingEnemyPosition.Row,
            patrollingEnemyCol = patrollingEnemyPosition.Col;
        char patrollingEnemy = room[patrollingEnemyRow][patrollingEnemyCol];

        if (samCol < patrollingEnemyCol && 
            patrollingEnemy == 'd' &&
            patrollingEnemyRow == samRow)
        {
            isSamKilled = true;
        }
        else if (patrollingEnemyCol < samCol &&
            patrollingEnemy == 'b' &&
            patrollingEnemyRow == samRow)
        {
            isSamKilled = true;
        }

        return isSamKilled;
    }

    static void MoveSam(char move, Cell samPosition)
    {
        room[samPosition.Row][samPosition.Col] = '.';

        switch (move)
        {
            case 'U':
                samPosition.Row--;
                break;
            case 'D':
                samPosition.Row++;
                break;
            case 'L':
                samPosition.Col--;
                break;
            case 'R':
                samPosition.Col++;
                break;
        }

        room[samPosition.Row][samPosition.Col] = 'S';
    }

    static void PrintRoom()
    {
        for (int row = 0; row < room.Length; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                Console.Write(room[row][col]);
            }

            Console.WriteLine();
        }
    }

    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());

        ReadRoom(rows);

        char[] moves = Console.ReadLine().ToCharArray();

        Cell samPosition = GetPosition('S');
        Cell nikoladzePosition = GetPosition('N');

        foreach (char move in moves)
        {
            MoveEnemies();

            Cell patrollingEnemyPosition = GetPatrollingEnemyPosition(samPosition.Row);

            if (IsSamKilled(samPosition, patrollingEnemyPosition))
            {
                room[samPosition.Row][samPosition.Col] = 'X';

                Console.WriteLine($"Sam died at {samPosition}");

                PrintRoom();
                Environment.Exit(0);
            }

            MoveSam(move, samPosition);

            if (nikoladzePosition.Row == samPosition.Row)
            {
                room[nikoladzePosition.Row][nikoladzePosition.Col] = 'X';

                Console.WriteLine("Nikoladze killed!");

                PrintRoom();
                Environment.Exit(0);
            }
        }
    }
}