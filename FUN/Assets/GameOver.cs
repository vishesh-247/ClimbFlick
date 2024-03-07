using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }




    public void RestartGame()
    {
        gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
