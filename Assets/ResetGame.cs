using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public GameObject grid;
    public GameObject Lacus;
    public LacusStats LacusS;
    public LacusMovement LacusM;
    public Grid gridScript;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GridTest", LoadSceneMode.Single);
        }
    }
}
