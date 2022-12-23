using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menujuego : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject menuOptions;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GestionClickMenu(string menu)
    {
        switch (menu)
        {
            case "play":
                SceneManager.LoadScene("Tutorial_1");
                break;
            case "options":
                menuOptions.SetActive(true);
                menuPanel.SetActive(false);
                break;
            case "return":
                menuOptions.SetActive(false);
                menuPanel.SetActive(true);
                break;
            case "mute":
                if (audio.isPlaying) 
                {
                audio.Pause();
                }
                else
                    audio.Play();
                break;
            case "exit":
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
               Application.Quit();
#endif

                break;


        }


    }
}
