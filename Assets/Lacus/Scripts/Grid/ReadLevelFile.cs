using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows;

public class ReadLevelFile : MonoBehaviour
{
    [SerializeField] private string levelName;

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
        float leftMargin = 0.4f; // Alineació horitzontal
        float topMargin = -0.55f; // Alineació vertical

        GameObject sprite = TopLeftWall;

    

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

        List<OnOffArrow> onOffArrows = new List<OnOffArrow>();
        Button arrowsButton = null;
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
                        break;
                    }
                case '?': // Button
                    {
                        GameObject obj = Instantiate(button, new Vector3(x - leftMargin - x * (1 - sprite.transform.localScale.x), y - topMargin - y * (1 - sprite.transform.localScale.y), 0), Quaternion.identity);
                        arrowsButton = obj.GetComponent<Button>();
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

                        if (x == 0 && y == 0)
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