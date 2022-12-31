using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menujuego : MonoBehaviour
{
    [SerializeField] private float transitionTime = 1f;

    public GameObject menuPanel;
    public GameObject menuOptions;
    public GameObject prefabTransition;
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
                StartCoroutine(SceneLoad());
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


