using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class death_handler : MonoBehaviour
{
    public Canvas death_screen;

    int delay =2;

    void Start() 
    {
        death_screen.enabled=true;    
    }

    // public void handle_death()
    // {
    //     FindObjectOfType<switch_weap>().enabled=false;
    //     FindObjectOfType<weapons>().enabled=false;
    //     death_screen.enabled=true;
    //     Invoke("retry",delay);

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("BYE");
            Application.Quit();
        }

    }
        
    


        

    // }


    void retry()
    {
        int currentindexscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentindexscene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         
    }

}