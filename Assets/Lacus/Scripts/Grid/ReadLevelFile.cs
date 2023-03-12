using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;

public class ReadLevelFile : MonoBehaviour
{
    [SerializeField] private Transform worldCoords;
    [SerializeField] public string levelName;

    [SerializeField] private GameObject normalTile;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject onOffArrow;
    [SerializeField] private GameObject autoArrow;
    [SerializeField] private GameObject battery;
    [SerializeField] private GameObject lacus;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject final;
    [SerializeField] private GameObject stop;

    // Walls corner
    [SerializeField] private GameObject TopLeftWall;
    [SerializeField] private GameObject TopRightWall;
    [SerializeField] private GameObject BotLeftWall;
    [SerializeField] private GameObject BotRightWall;

    [SerializeField] private GameObject HorizontalWall;
    [SerializeField] private GameObject VerticalWall;

    private ButtonManager buttonManager;


    float x = 0f; // Posició Tiles X
    float y = 0f; // Posició Tiles Y
    float leftMargin = 0.4f; // Alineació horitzontal
    float topMargin = -0.55f; // Alineació vertical

    private void Awake()
    {
        
    }

    void Start()
    {
        buttonManager = GetComponent<ButtonManager>();
        
        worldCoords.transform.position = new Vector3(2, -3, -10);
        GenerateWalls();
        GenerateMap();
    }

    void Update()
    {
        
    }

    public string ReadFile()
    {
        string line = "";
        try
        {
            var textFile = Resources.Load<TextAsset>("Text/" + levelName);
            line = textFile.text;
            return line;
        }
        catch (Exception e)
        {
            Debug.LogError($"The process failed: {e.ToString()}");
        }
        return null;
    }

    List<Vector2> LookForTiles(char c)
    {
        int numRows = ReadNumOfRows();
        string mapFile = ReadFile();
        List<Vector2> tiles = new List<Vector2>();

        int j = 0;
        for (int i = 0; i < numRows; i++)
        {
            int columnCounter = 0;


            // Bucle Linia a Linia
            while (mapFile[j] != '\n')
            {
                if (mapFile[j] == c)
                {
                    // Dividit entre 2 pels espais en blanc
                    tiles.Add(new Vector2(columnCounter / 2, i));
                }

                // Ignorar els chars identificadors
                if(mapFile[j] == '0' || mapFile[j] == '1' || mapFile[j] == '2' || mapFile[j] == '3' || mapFile[j] == '4' || mapFile[j] == '5' || mapFile[j] == '6' || mapFile[j] == '7' || mapFile[j] == '8' || mapFile[j] == '9')
                {
                    columnCounter--;
                }
                columnCounter++;
                j++;
            }

            // Saltar el "\n"
            if (mapFile[j] == '\n')
            {
                j++;
            }

        }

        return tiles;
    }


    void GenerateWalls()
    {
        // Lista de les posicions de les parets
        List<Vector2> wallPositions = LookForTiles('#');
        List<Vector2> goalPositions = LookForTiles('F');

        bool connectionUp = false;
        bool connectionDown = false;
        bool connectionLeft = false;
        bool connectionRight = false;

        GameObject sprite = stop;

        // Casella
        for (int i = 0; i < wallPositions.Count; i++)
        {

            // Mirar Totes les caselles
            for (int j = 0; j < wallPositions.Count; j++)
            {
                //Debug.Log(j + " / " + wallPositions.Count + " // " + wallPositions[i] + " / " + wallPositions[j]);

                // Skipejar si es mira la mateixa casella
                if (i == j)
                {
                    continue;
                }

                // Comprobació de conexions Parets
                if(CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.right) || CompareWallPositions(wallPositions[i], goalPositions[0], Vector2.right))
                {
                    connectionRight = true;
                }
                if (CompareWallPositions(wallPositions[i], wallPositions[j], -Vector2.down) || CompareWallPositions(wallPositions[i], goalPositions[0], -Vector2.down))
                {
                    connectionDown = true;
                }
                if (CompareWallPositions(wallPositions[i], wallPositions[j], -Vector2.up) || CompareWallPositions(wallPositions[i], goalPositions[0], -Vector2.up))
                {
                    connectionUp = true;
                }
                if (CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.left) || CompareWallPositions(wallPositions[i], goalPositions[0], Vector2.left))
                {
                    connectionLeft = true;
                }
            }

            if (connectionDown && connectionRight)
            {
                // Top Left Corner
                sprite = TopLeftWall;
            }
            else if (connectionLeft && connectionRight)
            {
                // Horizontal
                sprite = HorizontalWall;
            }
            else if (connectionLeft && connectionDown)
            {
                // Top Right
                sprite = TopRightWall;
            }
            else if (connectionUp && connectionDown)
            {
                // Vertical
                sprite = VerticalWall;
            }
            else if (connectionUp && connectionRight)
            {
                // Bot Left
                sprite = BotLeftWall;
            }
            else if (connectionLeft && connectionUp)
            {
                // Bot Right
                sprite = BotRightWall;
            }

            // Instantiate
            Instantiate(sprite, new Vector3(wallPositions[i].x - leftMargin - wallPositions[i].x * (1 - sprite.transform.localScale.x), -wallPositions[i].y - topMargin + wallPositions[i].y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
            
            // Sprite default per comprobar si hi ha algun error en les parets
            sprite = stop;

            // Resetejar els Connection Bools
            connectionUp = false;
            connectionDown = false;
            connectionLeft = false;
            connectionRight = false;
        }
    }

    bool CompareWallPositions(Vector2 currentVector, Vector2 checkingVector, Vector2 direction)
    {
        return checkingVector == (currentVector + direction);
    }

    public int ReadNumOfRows()
    {
        string line;
        int lineCount = 0;

        try
        {
            var textFile = Resources.Load<TextAsset>("Text/" + levelName);
            line = textFile.text;
            for (int i = 0; i < line.Length; i++)
            {
                if(line[i] == '\n')
                {
                    lineCount++;
                }
            }
            return lineCount;
        }
        catch (Exception e)
        {
            Debug.LogError($"The process failed: {e.ToString()}");
        }
        return 0;
    }

    public Vector2 FarthestWallPosition()
    {
        Vector2 farPositions = new Vector2(0, 0);

        List<Vector2> tiles = LookForTiles('#');

        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].x > farPositions.x) // Right
            {
                farPositions.x = tiles[i].x;
            }
            if (tiles[i].y > farPositions.y)
            {
                farPositions.y = tiles[i].y;
            }
        }

        return farPositions;
    }

    void GenerateMap()
    {
        GameObject sprite = TopLeftWall;

        string line = ReadFile();

        List<GameObject> onOffArrows = new List<GameObject>();
        List<GameObject> buttons = new List<GameObject>();

        int currentID = 0;

        foreach (char tile in line)
        {
            switch (tile)
            {
                case '<': // Arrow
                    {
                        Instantiate(arrow, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        break;
                    }
                case '>': // Arrow Button
                    {
                        GameObject obj = Instantiate(onOffArrow, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        obj.GetComponent<OnOffArrow>().ID = currentID;
                        buttonManager.ListOnOffArrows.Add(obj);
                        break;
                    }
                case '^': // Arrow That Changes Clockwise
                    {
                        Instantiate(autoArrow, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        break;
                    }
                case '_': // Normal tile
                    {
                        Instantiate(normalTile, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        break;
                    }
                case 'B': // Battery
                    {
                        Instantiate(battery, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        break;
                    }
                case 'L': // Lacus
                    {
                        Instantiate(lacus, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        Instantiate(normalTile, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        break;
                    }
                case '?': // Button
                    {
                        GameObject obj = Instantiate(button, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        obj.GetComponent<Buttons>().ID = currentID;
                        buttonManager.ListButtons.Add(obj);
                        break;
                    }
                case '!': // Deactivated Arrow
                    {
                        Instantiate(arrow, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        break;
                    }
                case 'F': // Exit
                    {
                        Instantiate(final, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        break;
                    }
                case 'S': // Stop
                    {
                        Instantiate(stop, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        break;
                    }
                case '#': // Wall
                    {

                        break;
                    }

                case '.': // Espai Blanc
                    {
                        break;
                    }
                case '0': // Assignar currentID
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    {
                        // Convertir char a int
                        currentID = tile - '0';
                        x--;
                        break;
                    }
                // En el cas de fer més caselles, seguir la estructura

                case ' ': // Usat per legibilitat al txt
                    {
                        x--;
                        break;
                    }
                case '\n': // Salt de linea
                    {
                        y--;
                        x = -1f;
                        break;
                    }

                default:
                    {
                        //Debug.LogError("tile is unknown or not implemented");
                        //Debug.Log(x);
                        x--;
                        break;
                    }

            }
            x++;
        }
    }
}