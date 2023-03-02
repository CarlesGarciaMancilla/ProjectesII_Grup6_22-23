using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class WallsHorientation : MonoBehaviour
{
    [SerializeField] private ReadLevelFile map;
    private string mapFile;
    private char[][] chars;
    private int numRows;
    // Start is called before the first frame update
    void Start()
    {
        mapFile = map.ReadFile();
        numRows = map.ReadNumOfRows();
        chars = new char[numRows][];
        GridStringToChar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool CheckSides(int x, int y)
    {
        if (x > 0 || y > 0 && y < numRows)
        {
            // Top
            if (chars[y][x] == '#')
            {

            }

            // Left
            if ()
            {

            }

            // Right
            if ()
            {

            }

            // Down
            if ()
            {

            }
        }
        

        return false;






    }
    void GridStringToChar()
    {
        int j = 0;
        for (int i = 0; i < numRows; i++)
        {
            // Bucle Linia a Linia
            while (mapFile[j] != '\n')
            {
                // Assignar el char
                chars[i][j] = mapFile[j];
                j++;
            }
        }

        //CheckSides();
    }

    void IDK()
    {
        float x = 0f;
        float y = 0f;

        foreach (char tile in mapFile)
        {
            switch (tile)
            {
                case '#': // Wall
                    {
                        if (true)
                        {

                        }
                        else
                        {
                            Debug.LogError("Walls exteriors no correctes");
                        }


                        break;
                    }
                case 'F': // Exit
                    {

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
    }
}
