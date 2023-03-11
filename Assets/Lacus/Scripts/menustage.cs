using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class menustage : MonoBehaviour
{

    [SerializeField] private float transitionTime = 1f;

    public GameObject Panel;
    public AudioSource audioGame;
    private string sceneName;
    public GameObject prefabTransition;
    public Animator animator;
    public GameObject space;
    public GameObject reset;
    public GameObject options;


    // Start is called before the first frame update
    void Start()
    {
        reset.SetActive(true);
        sceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(Transition());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GestionClickMenuFinal(string menuf)
    {

        switch (menuf)
        {
            case "next":
                Debug.Log("next");
                Panel.SetActive(false);
                StartCoroutine(SceneLoad(sceneName));
                break;
            case "return":
                options.SetActive(false);
                Debug.Log("return");
                SceneManager.LoadScene("Menu");
                Time.timeScale = 1;
                break;
            case "options":
                options.SetActive(true);
                Time.timeScale = 0f;
                break;
            case "resume":
                options.SetActive(false);
                Time.timeScale = 1;
                break;
            case "speed":
                if(Time.timeScale == 1) 
                { 
                Time.timeScale = 2;
                }
                else if (Time.timeScale == 2)
                {
                    Time.timeScale = 1;
                }
                break;
            case "mute":
                if (audioGame.isPlaying)
                {
                    audioGame.Pause();
                }
                else
                    audioGame.Play();
                break;
                
        }
    }

    public IEnumerator SceneLoad(string scene)
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        switch (scene)
        {
            case "Tutorial_1":
                if (!PlayerPrefs.HasKey("tuto_2"))
                {
                    PlayerPrefs.SetInt("tuto_2", 1);
                }
                SceneManager.LoadScene("Tutorial_2");
                break;
            case "Tutorial_2":
                if (!PlayerPrefs.HasKey("tuto_3"))
                {
                    PlayerPrefs.SetInt("tuto_3", 1);
                }
                SceneManager.LoadScene("Tutorial_3");
                break;
            case "Tutorial_3":
                if (!PlayerPrefs.HasKey("tuto_4"))
                {
                    PlayerPrefs.SetInt("tuto_4", 1);
                }
                SceneManager.LoadScene("Tutorial_4");
                break;
            case "Tutorial_4":
                if (!PlayerPrefs.HasKey("lev_1"))
                {
                    PlayerPrefs.SetInt("lev_1", 1);
                }
                SceneManager.LoadScene("Level_1");
                break;
            case "Level_1":
                if (!PlayerPrefs.HasKey("lev_2"))
                {
                    PlayerPrefs.SetInt("lev_2", 1);
                }
                SceneManager.LoadScene("Level_2");
                break;
            case "Level_2":
                if (!PlayerPrefs.HasKey("lev_3"))
                {
                    PlayerPrefs.SetInt("lev_3", 1);
                }
                SceneManager.LoadScene("Level_3");
                break;
            case "Level_3":
                if (!PlayerPrefs.HasKey("lev_4"))
                {
                    PlayerPrefs.SetInt("lev_4", 1);
                }
                SceneManager.LoadScene("Level_4");
                break;
            case "Level_4":
                if (!PlayerPrefs.HasKey("lev_5"))
                {
                    PlayerPrefs.SetInt("lev_5", 1);
                }
                SceneManager.LoadScene("Level_5");
                break;
            case "Level_5":
                if (!PlayerPrefs.HasKey("lev_6"))
                {
                    PlayerPrefs.SetInt("lev_6", 1);
                }
                SceneManager.LoadScene("Level_6");
                break;
            case "Level_6":
                if (!PlayerPrefs.HasKey("lev_7"))
                {
                    PlayerPrefs.SetInt("lev_7", 1);
                }
                SceneManager.LoadScene("Level_7");
                break;
            case "Level_7":              
                break;
        }
    }

    public IEnumerator Transition()
    {
        yield return new WaitForSeconds(transitionTime);
        prefabTransition.SetActive(false);
    }

    public void SpaceActive() 
    {
        space.SetActive(false);
       
    }
    public void ResetActive() 
    {
        reset.SetActive(false);
       
    }
   




}
