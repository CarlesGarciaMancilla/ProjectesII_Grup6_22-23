using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private TileSprite tile;
    [SerializeField] private Transform worldCoords; // La camera

    private Dictionary<Vector2, TileSprite> tiles;

    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, TileSprite>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y > -height; y--)
            {
                TileSprite spawnedTile = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                
                spawnedTile.name = $"Tile {x} {y}";

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        worldCoords.transform.position = new Vector3(2, -3, -10);
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

    void Update()
    {
        
    }
}
