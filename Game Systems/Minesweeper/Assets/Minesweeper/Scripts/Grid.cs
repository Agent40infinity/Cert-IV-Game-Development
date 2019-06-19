using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper
{
    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10, height = 10;
        public float spacing = .155f;

        private Tile[,] tiles;
        Tile SpawnTile(Vector3 pos) //Creates a variable that allows for the creation of a new tile.
        {
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos;
            Tile currentTile = clone.GetComponent<Tile>();
            return currentTile;
        }

        void Start() //Calls upon the specified function/sub-routine
        {
            GenerateTiles();
        }

        void GenerateTiles() //Used to generate the tiles within the array
        {
            tiles = new Tile[width, height];
            for (int x = 0; x < width; x++) 
            {
                for (int y = 0; y < height; y++) //Sets up the spawning position for each tile based on the dimensions specified within the 2D array.
                {
                    Vector2 halfSize = new Vector2(width * 0.5f, height * 0.5f);
                    Vector2 pos = new Vector2(x - halfSize.x, y - halfSize.y);
                    Vector2 offset = new Vector2(.5f, .5f);
                    pos += offset;
                    pos *= spacing;
                    Tile tile = SpawnTile(pos);
                    tile.transform.SetParent(transform);
                    tile.x = x;
                    tile.y = y;
                    tiles[x, y] = tile;
                }
            }
        }

        private void Update() //Checks whether or not we've clicked on a tile and begins the function/sub-routine.
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectATile();
            }
        }

        void SelectATile() //Used to check whether or not we've clicked on a tile; Creates a raycast as a check.
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            if (hit.collider != null) //If the raycast has hit something, then get the component required.
            {
                Tile hitTile = hit.collider.GetComponent<Tile>();
                if (hitTile != null) //If the raycast hit 'Tile' then GetAdjacentMineCount and reveal tile.
                {
                    int adjacentMines = GetAdjacentMineCount(hitTile);
                    hitTile.Reveal(adjacentMines);
                }
            }
        }

        public int GetAdjacentMineCount(Tile tile) //Get's the adjacent mine count to check whether or not a mine is near by and sets the sprite based on that value.
        {
            int count = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int desiredX = tile.x + x;
                    int desiredY = tile.y + y;
                    if (desiredX < 0 || desiredX >= width || desiredY < 0 || desiredY >= height)
                    {
                        continue;
                    }
                    Tile currentTile = tiles[desiredX, desiredY];
                    if (currentTile.isMine)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        void FFuncover(int x, int y, bool[,] visited) //uncovers near by tiles that are black or equal to 1.
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                if (visited[x, y]) 
                {
                    return;
                }
                Tile tile = tiles[x, y];
                int adjacentMines = GetAdjacentMineCount(tile);
                tile.Reveal(adjacentMines);

                if (adjacentMines == 0) //Used to check all tiles around the clicked tile.
                {
                    visited[x, y] = true;
                    FFuncover(x - 1, y, visited);
                    FFuncover(x + 1, y, visited);
                    FFuncover(x, y - 1, visited);
                    FFuncover(x, y + 1, visited);   
                }
            }
        }

        void UncoverMines() //Uncovers all mines if a single mine is clicked.
        {
            for (int x = 0; x < width; x++) //Checks for the location of the mines.
            {
                for (int y = 0; y < height; y++)
                {
                    Tile tile = tiles[x, y];
                    if (tile.isMine) //Uncovers them.
                    {
                        int adjacentMines = GetAdjacentMineCount(tile);
                    }
                }
            }
        }
    }
}