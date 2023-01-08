using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menujuego : MonoBehaviour
{
    [SerializeField] private float transitionTime = 1f;

    public GameObject menuPanel;
    public GameObject menuOptions;
    public GameObject prefabTransition;
    public GameObject LevelSelector;
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;
    public Button level6;
    public Button level7;
    public Button level8;
    public AudioSource audio;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(720, 1000, FullScreenMode.Windowed);
        StartCoroutine(Transition());
        level2.interactable = false;
        level3.interactable = false;
        level4.interactable = false;
        level5.interactable = false;
        level6.interactable = false;
        level7.interactable = false;
        level8.interactable = false;

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
                menuPanel.SetActive(false);
                LevelSelector.SetActive(true);
                if (PlayerPrefs.GetInt("tuto_2") == 1)
                {
                    level2.interactable = true;
                }

                if (PlayerPrefs.GetInt("tuto_3") == 1)
                {
                    level3.interactable = true;
                }

                if (PlayerPrefs.GetInt("tuto_4") == 1)
                {
                    level4.interactable = true;
                }

                if (PlayerPrefs.GetInt("lev_1") == 1)
                {
                    level5.interactable = true;
                }

                if (PlayerPrefs.GetInt("lev_2") == 1)
                {
                    level6.interactable = true;
                }

                if (PlayerPrefs.GetInt("lev_3") == 1)
                {
                    level7.interactable = true;
                }

                if (PlayerPrefs.GetInt("lev_4") == 1)
                {
                    level8.interactable = true;
                }
                break;
            case "options":
                menuOptions.SetActive(true);
                menuPanel.SetActive(false);
                break;
            case "return":               
                menuOptions.SetActive(false);
                LevelSelector.SetActive(false);
                menuPanel.SetActive(true);
                break;
            case "level1":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad1());
                break;
            case "level2":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad2());
                break;
            case "level3":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad3());
                break;
            case "level4":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad4());
                break;
            case "level5":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad5());
                break;
            case "level6":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad6());
                break;
            case "level7":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad7());
                break;
            case "level8":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad8());
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


    public IEnumerator SceneLoad1()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Tutorial_1");
    }
    public IEnumerator SceneLoad2()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Tutorial_2");
    }

    public IEnumerator SceneLoad3()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Tutorial_3");
    }

    public IEnumerator SceneLoad4()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Tutorial_4");
    }

    public IEnumerator SceneLoad5()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level_1");
    }

    public IEnumerator SceneLoad6()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level_2");
    }
    public IEnumerator SceneLoad7()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level_3");
    }
    public IEnumerator SceneLoad8()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level_4");
    }




    public IEnumerator Transition() 
    {
        yield return new WaitForSeconds(transitionTime);
        prefabTransition.SetActive(false);
    }
}


