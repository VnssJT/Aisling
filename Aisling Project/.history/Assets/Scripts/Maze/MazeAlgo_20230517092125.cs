using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class MazeAlgo : MonoBehaviour
{
    //public Tilemap tilemap;

    //public TileBase[] tiles;
    public GameObject[] tiles3d;
    public GameObject player;
    public GameObject mazeParent;
    int scaleFactor = 2;
    public enum TileTypes 
    {
        empty = 0, NESW = 15,
        W = 1, S = 2, E = 4, N = 8,
        SW = 3, EW = 5, ES = 6, NW = 9, 
        NS = 10, NE = 12,
        ESW = 7, NSW = 11, NEW = 13, NES = 14
    };

    public int[,] maze;
    public abstract void Generate(int width, int lenght);
    public abstract void FillMaze(int height, int width);

    public delegate void MazeGenerated();
    public static event MazeGenerated OnSpawned;

    protected void DisplayMaze()
    {
        long height = maze.GetLongLength(0);
        long width = maze.GetLongLength(1);

        // Spawn player at the first tile
        Instantiate(player, new Vector3Int(0, 1, 0), Quaternion.identity);

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                //tilemap.SetTile(new Vector3Int(x, -y, 0), tiles[maze[y, x]]);
                Instantiate(tiles3d[maze[y, x]], new Vector3Int(x, 0, -y) * scaleFactor, Quaternion.identity, mazeParent.transform);
            }
        }
        
    }

    public int[,] GetMaze() { return maze;}
}
