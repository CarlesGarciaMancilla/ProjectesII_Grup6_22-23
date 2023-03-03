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

    [SerializeField] private GameObject TopWall;
    [SerializeField] private GameObject BotWall;
    [SerializeField] private GameObject LeftWall;
    [SerializeField] private GameObject RightWall;

    float x = 0f; // Posició Tiles X
    float y = 0f; // Posició Tiles Y
    float leftMargin = 0.4f; // Alineació horitzontal
    float topMargin = -0.55f; // Alineació vertical

    private void Awake()
    {
        worldCoords.transform.position = new Vector3(2, -3, -10);
    }

    void Start()
    {
        LookForTiles('#');
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
                    tiles.Add(new Vector2(columnCounter / 2, i));
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

        // Variables per detectar quina casella dels costats és
        bool isTopWall = true;
        bool isLeftWall = true;

        GameObject sprite = stop;

        
        // Casella
        for (int i = 0; i < wallPositions.Count; i++)
        {
            // Mirar Totes les caselles
            for (int j = 0; j < wallPositions.Count; j++)
            {
                Vector2 sum = wallPositions[0] + Vector2.right;
                //Debug.Log(wallPositions[i] + " / " + sum + " / " + wallPositions[j]);
                //Debug.Log(j + " / " + wallPositions.Count + " // " + wallPositions[i] + " / " + wallPositions[j]);

                // Skipejar si es mira la mateixa casella
                if (i == j)
                {
                    continue;
                }

                // Si hi ha una casella Final, canviar la WallFacing, ja que el final es considera com una paret tot i que no ho és
                if (CompareWallPositions(goalPositions[0], wallPositions[j], Vector2.left) && CompareWallPositions(goalPositions[0], wallPositions[j], Vector2.right) && isTopWall)
                {
                    isTopWall = !isTopWall;
                }
                else if (CompareWallPositions(goalPositions[0], wallPositions[j], Vector2.left) && CompareWallPositions(goalPositions[0], wallPositions[j], Vector2.right) && !isTopWall)
                {
                    isTopWall = !isTopWall;
                }
                else if (CompareWallPositions(goalPositions[0], wallPositions[j], Vector2.left) && CompareWallPositions(goalPositions[0], wallPositions[j], Vector2.right) && isLeftWall)
                {
                    isLeftWall = !isLeftWall;
                }
                else if (CompareWallPositions(goalPositions[0], wallPositions[j], Vector2.left) && CompareWallPositions(goalPositions[0], wallPositions[j], Vector2.right) && !isLeftWall)
                {
                    isLeftWall = !isLeftWall;
                }

                // Comprobacions de walls
                //if (CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.right) && CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.down))
                if (CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.right) && CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.down))
                {
                    // Top Left Corner
                    Debug.Log("TopLeft");
                    sprite = TopLeftWall;
                }
                else if (CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.left) && CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.right) && isTopWall)
                {
                    // Top Mid
                    Debug.Log("TopMid");
                    sprite = TopWall;
                    isTopWall = !isTopWall;
                }
                else if (CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.left) && CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.down))
                {
                    // Top Right
                    Debug.Log("TopRight");
                    sprite = TopRightWall;
                }
                else if (CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.up) && CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.down) && isLeftWall)
                {
                    // Mid Left
                    Debug.Log("MidLeft");
                    sprite = LeftWall;
                    isLeftWall = !isLeftWall;
                }
                else if (CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.up) && CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.down) && !isLeftWall)
                {
                    // Mid Right
                    Debug.Log("MidRight");
                    sprite = RightWall;
                    isLeftWall = !isLeftWall;
                }
                else if (CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.up) && CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.right))
                {
                    // Bot Left
                    Debug.Log("BotLeft");
                    sprite = BotLeftWall;
                }
                else if (CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.left) && CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.right) && !isTopWall)
                {
                    // Bot Mid
                    Debug.Log("BotMid");
                    sprite = BotWall;
                    isTopWall = !isTopWall;
                }
                else if (CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.left) && CompareWallPositions(wallPositions[i], wallPositions[j], Vector2.up))
                {
                    // Bot Right
                    Debug.Log("BotRight");
                    sprite = BotRightWall;
                }
            }

            // Instantiate
            Instantiate(sprite, new Vector3(wallPositions[i].x - leftMargin - wallPositions[i].x * (1 - sprite.transform.localScale.x), -wallPositions[i].y - topMargin + wallPositions[i].y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
            sprite = stop;
        }
    }

    bool CompareWallPositions(Vector2 currentVector, Vector2 checkingVector, Vector2 direction)
    {
        //return checkingVector.x == currentVector.x + direction.x && checkingVector.y == currentVector.y + direction.y;
        return checkingVector == currentVector + direction;
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
    void GenerateMap()
    {
        GameObject sprite = TopLeftWall;

        string line = ReadFile();

        List<OnOffArrow> onOffArrows = new List<OnOffArrow>();
        Buttons arrowsButton = null;
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
                        onOffArrows.Add(obj.GetComponent<OnOffArrow>());
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
                        arrowsButton = obj.GetComponent<Buttons>();
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

                        // Problemes,
                        // buscar una solució al hardcode de la ultima casella de la fila i la ultima fila,
                        // es a dir buscar una alternativa a x == 4 i y == 6

                        /*if (x == 0 && y == 0)
                        {
                            // Corner Top Left
                            sprite = TopLeftWall;
                        }
                        else if (x == 6 && y == 0)
                        {
                            // Corner Top Right
                            sprite = TopRightWall;
                        }
                        else if (x == 0 && -y == 8) 
                        {
                            // Corner Bot Left
                            sprite = BotLeftWall;
                        }
                        else if (x == 6 && -y == 8)
                        {
                            // Corner Bot Right
                            sprite = BotRightWall;
                        }
                        else if (y == 0)
                        {
                            // Walls top
                            sprite = TopWall;
                        }
                        else if (y == -8)
                        {
                            // Walls Bot
                            sprite = BotWall;
                        }
                        else if (x == 0)
                        {
                            // Walls Left
                            sprite = LeftWall;
                        }
                        else if (x == 6)
                        {
                            // Walls Right
                            sprite = RightWall;
                        }
                        else
                        {
                            Debug.LogError("Walls exteriors no correctes");
                        }
                        Instantiate(sprite, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        */
                        break;
                    }

                case '.': // Espai Blanc
                    {
                        x++;
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

        foreach (var arr in onOffArrows)
        {
            arr.button = arrowsButton;
        }
    }
}