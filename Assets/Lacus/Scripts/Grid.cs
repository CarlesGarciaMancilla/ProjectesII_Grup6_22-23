using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int width;
    public int height;

    public TileSprite tile;
    public TileSprite bateria;
    public TileSprite final;
    public TileSpriteFletxa tileFletxa;
    public Button button;
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

        Instantiate(tileFletxa, new Vector3(0, 4), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(4, 4), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(1, 0), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(1, 2), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(3, 0), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(3, 1), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(3, 2), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(3, 3), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(4, 1), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(5, 0), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(5, 4), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(6, 2), Quaternion.identity);
        Instantiate(tileFletxa, new Vector3(6, 3), Quaternion.identity);

        Instantiate(bateria, new Vector3(1, 1), Quaternion.identity);
        Instantiate(bateria, new Vector3(5, 2), Quaternion.identity);

        Instantiate(button, new Vector3(2, 0), Quaternion.identity);

        Instantiate(final, new Vector3(0, 1), Quaternion.identity);

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
