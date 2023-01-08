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


    // Start is called before the first frame update
    void Start()
    {

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
            case "returnmenu":
                Debug.Log("return");
                SceneManager.LoadScene("Menu");
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
   




}
