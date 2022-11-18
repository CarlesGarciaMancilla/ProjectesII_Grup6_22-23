using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;

public class ReadLevelFile : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private GameObject normalTile;
    [SerializeField] private GameObject battery;
    [SerializeField] private GameObject lacus;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject stop;
    [SerializeField] private GameObject wall;
    [SerializeField] private string levelName;


    // Start is called before the first frame update
    void Start()
    {
        ReadTxt(levelName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadTxt(string fileName)
    {
        float x = 0f;
        float y = 0f;
        string line = "";

        try
        {
            var textFile = Resources.Load<TextAsset>("Text/"+fileName);
            line = textFile.text;
        }
        catch (Exception e)
        {
            Debug.LogError($"The process failed: {e.ToString()}");
        }

        foreach (char tile in line)
        {
            /*if (tile != ' ')
            {
                Debug.Log(tile);
            }*/

            switch (tile)
            {
                case '<': // Arrow
                    {
                        Instantiate(arrow, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    }
                case '_': // Normal tile
                    {
                        //Instantiate(normalTile, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    }
                case 'B': // Battery
                    {
                        Instantiate(battery, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    }
                case 'L': // Lacus
                    {
                        Instantiate(lacus, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    }
                case '?': // Button
                    {
                        Instantiate(button, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    }
                case '!': // Deactivated Arrow
                    {
                        Instantiate(arrow, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    }
                case 'E': // Exit
                    {
                        Instantiate(exit, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    }
                case 'S': // Stop
                    {
                        Instantiate(stop, new Vector3(x, y, 0), Quaternion.identity);
                        break;
                    }
                case '#': // Wall
                    {
                        Instantiate(wall, new Vector3(x, y, 0), Quaternion.identity);
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
