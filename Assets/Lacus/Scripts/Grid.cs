using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int width;
    public int height;

    public TileSprite tile;
    public TileSpriteFletxa tileFletxa;
    public Transform worldCoords; // La camera

    private Dictionary<Vector2, TileSprite> tiles;

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, TileSprite>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                TileSprite spawnedTile = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                
                spawnedTile.name = $"Tile {x} {y}";

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);


                tiles[new Vector2(x, y)] = spawnedTile;

                
            }
        }

        Instantiate(tileFletxa, new Vector3(2, 3), Quaternion.identity);

        worldCoords.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);

    }

    public TileSprite GetTilePosition(Vector2 pos)
    {
        if(tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    }

    void Start()
    {
        GenerateGrid();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
