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
        StartCoroutine(Transition());
        
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
                level2.interactable = false;
                level3.interactable = false;
                level4.interactable = false;
                level5.interactable = false;
                level6.interactable = false;
                level7.interactable = false;
                level8.interactable = false;
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
                StartCoroutine(SceneLoad());
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


    public IEnumerator SceneLoad()
    {
        prefabTransition.SetActive(true);
        animator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Tutorial_1");
    }

    public IEnumerator Transition() 
    {
        yield return new WaitForSeconds(transitionTime);
        prefabTransition.SetActive(false);
    }
}


