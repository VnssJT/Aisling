using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetComplexity : MonoBehaviour
{
    public MazeAlgo mazeAlgo;

    public int mazeWidth = 10;
    public int mazeLenght= 10;
    bool measureMode = true;
    int[,] maze;
    int t1;
    int t2;
    [SerializeField] GameObject dialogueTriggerPrefab;
    int nDialogueTriggers = 5;
    [SerializeField] int scaleFactor = 2;
    // Start is called before the first frame update
    void Start()
    {
        //long t1 = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        mazeAlgo.Generate(mazeWidth, mazeLenght);
        //long t2 = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        //Debug.Log("Gen time: " + (t2 - t1).ToString());
        maze = mazeAlgo.GetMaze();
        //Debug.Log("Cyclomatic complexity: " + 
        //GetCyclomaticComplexity(maze).ToString());
        List<Vector2Int> solutionTiles = GetSolutionTiles();
        prefabSpawner(solutionTiles);
    }

    void Update()
    {
        if (measureMode == true) {
            Debug.Log("Solution lenght: " + 
            GetSolutionLenght(maze).ToString());
            Debug.Log("Number of corridors:" +
            GetNumberofCorridors(maze).ToString());
            measureMode = false;
        }
    }

    int GetNumberofCorridors(int [,] maze)
    {
        int res = 0;

        for (int y = 0; y < maze.GetLongLength(0); y++) {
            for (int x = 0; x < maze.GetLongLength(1); x++) {
                if (maze[y,x] == (int)MazeAlgo.TileTypes.NE ||
                maze[y,x] == (int)MazeAlgo.TileTypes.NS||
                maze[y,x] == (int)MazeAlgo.TileTypes.NW ||
                maze[y,x] == (int)MazeAlgo.TileTypes.ES ||
                maze[y,x] == (int)MazeAlgo.TileTypes.EW ||
                maze[y,x] == (int)MazeAlgo.TileTypes.SW)
                    res += 1;
            }
        }
        return res;
    }

    int GetCyclomaticComplexity(int[,] maze)
    {
        // E – N + 2, where E = number of edges, N = number of nodes
        int edges = 0;
        int nodes = maze.Length;
        for (int y = 0; y < maze.GetLongLength(0); y++) {
            for (int x = 0; x < maze.GetLongLength(1); x++) {
                if (!HasNorthEdge(maze[y, x])) { edges +=1;}
                if (!HasEastEdge(maze[y, x])) { edges +=1;}
                if (!HasSouthEdge(maze[y, x])) { edges +=1;}
                if (!HasWestEdge(maze[y, x])) { edges +=1;}
            }
        }
        return edges - nodes + 2;
    }

    int GetSolutionLenght(int[,] maze)
    {
        float[,] distanceMap = GetDistanceMap(maze);
        return (int)distanceMap[0, 0];
    }

    List<Vector2Int> GetSolutionTiles(){
        // Get distant map of the maze
        float[,] distanceMap = GetDistanceMap(maze);

        // Create empty array
        List<Vector2Int> solutionTiles = new List<Vector2Int>();

        int currentDistance = (int)distanceMap[0, 0];
        Vector2Int currentTile = new Vector2Int(0, 0);

        while(currentDistance > 0)
        {
            if (distanceMap[Math.Min(currentTile.x + 1, mazeWidth - 1), currentTile.y] == currentDistance - 1
                && !HasSouthEdge(maze[currentTile.x, currentTile.y]))
            {
                currentTile = new Vector2Int(Math.Min(currentTile.x + 1, mazeWidth - 1), currentTile.y);

            } else if (distanceMap[currentTile.x, Math.Min(currentTile.y + 1, mazeLenght - 1)] == currentDistance - 1
                && !HasEastEdge(maze[currentTile.x, currentTile.y]))
            {
                currentTile = new Vector2Int(currentTile.x, Math.Min(currentTile.y + 1, mazeLenght - 1));

            } else if(distanceMap[currentTile.x, Math.Max(currentTile.y - 1, 0)] == currentDistance - 1
                && !HasWestEdge(maze[currentTile.x, currentTile.y]))
            {
                currentTile = new Vector2Int(currentTile.x, Math.Max(currentTile.y - 1, 0));

            } else if (distanceMap[Math.Max(currentTile.x - 1, 0), currentTile.y] == currentDistance - 1
                && !HasNorthEdge(maze[currentTile.x, currentTile.y]))
            {
                currentTile = new Vector2Int(Math.Max(currentTile.x - 1, 0), currentTile.y);
            }

            solutionTiles.Add(currentTile);
            currentDistance--;
        }

        return solutionTiles;
    }

    void prefabSpawner(List<Vector2Int> solutionTiles)
    {
        int solutionLength = GetSolutionLenght(maze);
        int tileThreshold = (solutionLength - 10) / nDialogueTriggers;

        for (int i = tileThreshold; i < solutionTiles.Count; i += tileThreshold)
        //for(int i = 0; i < solutionTiles.Count; i++)
        {
            Instantiate(dialogueTriggerPrefab, new Vector3(solutionTiles[i].y, 0, -solutionTiles[i].x) * scaleFactor, Quaternion.identity);
        }
    }

    float[,] GetDistanceMap(int[,] maze)
    {
        float [,] distanceMap = new float
        [maze.GetLongLength(0), maze.GetLongLength(1)];
        for (int y = 0; y < maze.GetLongLength(0); y++) {
            for (int x = 0; x < maze.GetLongLength(1); x++) {
                distanceMap[y, x] = -1;
            }
        }

        bool hasIndexed = true;
        int currentDistance = 0;
        distanceMap[maze.GetLongLength(0) -1, maze.GetLongLength(1) - 1] = 0;
        while (hasIndexed == true) {
            hasIndexed = false;
            currentDistance += 1;
            for (int y = 0; y < maze.GetLongLength(0); y++) {   
                for (int x = 0; x < maze.GetLongLength(1); x++) {
                    if (distanceMap[y, x] != currentDistance -1)
                        continue;
                    if (!HasNorthEdge(maze[y, x]) && distanceMap[y - 1, x] == -1) {
                        hasIndexed = true;
                        distanceMap[y - 1, x] = currentDistance;
                    }
                    if (!HasEastEdge(maze[y, x]) && distanceMap[y, x + 1] == -1) {
                        hasIndexed = true;
                        distanceMap[y, x + 1] = currentDistance;
                    }
                    if (!HasSouthEdge(maze[y, x]) && distanceMap[y + 1, x] == -1) {
                        hasIndexed = true;
                        distanceMap[y + 1, x] = currentDistance;
                    }
                    if (!HasWestEdge(maze[y, x]) && distanceMap[y, x - 1] == -1) {
                        hasIndexed = true;
                        distanceMap[y, x - 1] = currentDistance;
                    }
                }
            }
        }
        return distanceMap;
    }

    bool HasNorthEdge(int tileValue) 
    {
        if (tileValue == (int)MazeAlgo.TileTypes.N
        || tileValue == (int)MazeAlgo.TileTypes.NE
        || tileValue == (int)MazeAlgo.TileTypes.NES
        || tileValue == (int)MazeAlgo.TileTypes.NESW
        || tileValue == (int)MazeAlgo.TileTypes.NEW
        || tileValue == (int)MazeAlgo.TileTypes.NS
        || tileValue == (int)MazeAlgo.TileTypes.NSW
        || tileValue == (int)MazeAlgo.TileTypes.NW)
            return true;
        return false;
    }

    bool HasEastEdge(int tileValue) 
    {
        if (tileValue == (int)MazeAlgo.TileTypes.E
        || tileValue == (int)MazeAlgo.TileTypes.NE
        || tileValue == (int)MazeAlgo.TileTypes.NES
        || tileValue == (int)MazeAlgo.TileTypes.NESW
        || tileValue == (int)MazeAlgo.TileTypes.NEW
        || tileValue == (int)MazeAlgo.TileTypes.EW
        || tileValue == (int)MazeAlgo.TileTypes.ESW
        || tileValue == (int)MazeAlgo.TileTypes.ES)
            return true;
        return false;
    }

    bool HasSouthEdge(int tileValue) 
    {
        if (tileValue == (int)MazeAlgo.TileTypes.S
        || tileValue == (int)MazeAlgo.TileTypes.NS
        || tileValue == (int)MazeAlgo.TileTypes.NES
        || tileValue == (int)MazeAlgo.TileTypes.NESW
        || tileValue == (int)MazeAlgo.TileTypes.NSW
        || tileValue == (int)MazeAlgo.TileTypes.ES
        || tileValue == (int)MazeAlgo.TileTypes.ESW
        || tileValue == (int)MazeAlgo.TileTypes.SW)
            return true;
        return false;
    }

    bool HasWestEdge(int tileValue) 
    {
        if (tileValue == (int)MazeAlgo.TileTypes.W
        || tileValue == (int)MazeAlgo.TileTypes.NW
        || tileValue == (int)MazeAlgo.TileTypes.NEW
        || tileValue == (int)MazeAlgo.TileTypes.NESW
        || tileValue == (int)MazeAlgo.TileTypes.EW
        || tileValue == (int)MazeAlgo.TileTypes.SW
        || tileValue == (int)MazeAlgo.TileTypes.NSW
        || tileValue == (int)MazeAlgo.TileTypes.ESW)
            return true;
        return false;
    }
}
