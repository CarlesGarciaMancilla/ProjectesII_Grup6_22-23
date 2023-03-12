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
    public GameObject menuCredits;
    public GameObject prefabTransition;
    public GameObject LevelSelector;
    bool resPC;
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;
    public Button level6;
    public Button level7;
    public Button level8;
    public Button level9;
    public Button level10;
    public Button level11;
    public Button level12;
    public AudioSource audioS;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(720, 1080, FullScreenMode.FullScreenWindow);
        resPC = true;
        StartCoroutine(Transition());
        level2.interactable = false;
        level3.interactable = false;
        level4.interactable = false;
        level5.interactable = false;
        level6.interactable = false;
        level7.interactable = false;
        level8.interactable = false;
        level9.interactable = false;
        level10.interactable = false;
        level11.interactable = false;
        level12.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // No es crida en cap lloc, com funciona?
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
                

                if (PlayerPrefs.GetInt("lev_5") == 1)
                {
                    level9.interactable = true;
                }
               

                if (PlayerPrefs.GetInt("lev_6") == 1)
                {
                    level10.interactable = true;
                }
             

                if (PlayerPrefs.GetInt("lev_7") == 1)
                {
                    level11.interactable = true;
                }
                break;

            // StartCoroutine(SceneLoad("NomdelNivell"));
            case "options":
                menuOptions.SetActive(true);
                menuPanel.SetActive(false);
                break;
            case "resolution":
                if (resPC == true)
                {
                    Screen.SetResolution(1080, 1920, FullScreenMode.FullScreenWindow);
                    resPC = false;
                }
                else if (resPC == false) 
                {
                    Screen.SetResolution(720, 1080, FullScreenMode.FullScreenWindow);
                    resPC = true;    
                }
                break;
            case "credits":
                menuCredits.SetActive(true);
                menuPanel.SetActive(false);
                break;
            case "return":               
                menuOptions.SetActive(false);
                menuCredits.SetActive(false);
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
                StartCoroutine(SceneLoad5());
                break;
            case "level5":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad7());
                break;
            case "level6":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad4());
                
                break;
            case "level7":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad8());
                break;
            case "level8":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad6());
                break;
            case "level9":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad9());
                break;
            case "level10":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad10());
                break;
            case "level11":
                // LevelSelector.SetActive(false);
                StartCoroutine(SceneLoad11());
                break;
            case "mute":
                if (audioS.isPlaying) 
                {
                audioS.Pause();
                }
                else
                    audioS.Play();
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

    public IEnumerator SceneLoad9()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level_5");
    }

    public IEnumerator SceneLoad10()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level_6");
    }

    public IEnumerator SceneLoad11()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level_8");
    }

    // Fer les SceneLoad AIXI, NO facis 70 mil funcions que es practicament lo mateix y que nomes canvi 1 cosa, es fica un parametre a la funcio i et serveix per totes les coses
    public IEnumerator SceneLoad(string sceneName)
    {
        // Potser modificar una mica aixo per canviar les variables del menu i levelSelector
        // Aixo te elements de transition, mira si pots ficar Transition() aqui

        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }


    public IEnumerator Transition() 
    {
        yield return new WaitForSeconds(transitionTime);
        prefabTransition.SetActive(false);
    }
}


