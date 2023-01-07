using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menustage : MonoBehaviour
{

    [SerializeField] private float transitionTime = 1f;

    public GameObject Panel;
    public AudioSource audioGame;
    private string sceneName;
    public GameObject prefabTransition;
    public Animator animator;
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
                SceneManager.LoadScene("Tutorial_2");
                break;
            case "Tutorial_2":
                SceneManager.LoadScene("Tutorial_3");
                break;
            case "Tutorial_3":
                SceneManager.LoadScene("Tutorial_4");
                break;
            case "Tutorial_4":
                SceneManager.LoadScene("Level_1");
                break;
            case "Level_1":
                SceneManager.LoadScene("Level_2");
                break;
            case "Level_2":
                SceneManager.LoadScene("Level_3");
                break;
            case "Level_3":
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
}
