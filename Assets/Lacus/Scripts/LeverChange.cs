using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeverChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {

            ChangeTutorial1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            ChangeTutorial2();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeTutorial3();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeTutorial4();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeLevel1();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ChangeLevel2();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ChangeLevel3();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ChangeLevel4();

        }




    }


   public void ChangeTutorial1()
    {
        SceneManager.LoadScene("Tutorial_1", LoadSceneMode.Single);
    }

   public void ChangeTutorial2()
    {
        SceneManager.LoadScene("Tutorial_2", LoadSceneMode.Single);
    }

   public void ChangeTutorial3()
    {
        SceneManager.LoadScene("Tutorial_3", LoadSceneMode.Single);
    }

   public void ChangeTutorial4()
    {
        SceneManager.LoadScene("Tutorial_4", LoadSceneMode.Single);
    }

   public void ChangeLevel1() 
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }

   public void ChangeLevel2()
    {
        SceneManager.LoadScene("Level_2", LoadSceneMode.Single);
    }

   public void ChangeLevel3()
    {
        SceneManager.LoadScene("Level_3", LoadSceneMode.Single);
    }

   public void ChangeLevel4()
    {
        SceneManager.LoadScene("Level_4", LoadSceneMode.Single);
    }
}
