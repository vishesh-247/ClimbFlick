using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    
    
  public void StartGame()
                    
    {   

        SceneManager.LoadScene("Game"); 
        
        
        


                
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("NOOB RAGE QUIT?");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options");
    }   
}
