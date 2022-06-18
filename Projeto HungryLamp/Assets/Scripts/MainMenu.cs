using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject continueButton;
    void Start()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.GetInt("Already")== 1)
        {
            continueButton.SetActive(true);
        }
    }
    public void NewGame()
    {

        PlayerPrefs.SetInt("ID-1Aux", 0);
        PlayerPrefs.SetInt("ID-2Aux", 0);
        PlayerPrefs.SetInt("ID-3Aux", 0);
        PlayerPrefs.SetInt("ID-1", 0);
        PlayerPrefs.SetInt("ID-2", 0);
        PlayerPrefs.SetInt("ID-3", 0);
        PlayerPrefs.SetInt("Key-1Aux", 0);
        PlayerPrefs.SetInt("Key-2Aux", 0);
        PlayerPrefs.SetInt("Key-3Aux", 0);
        PlayerPrefs.SetInt("Key-1", 0);
        PlayerPrefs.SetInt("Key-2", 0);
        PlayerPrefs.SetInt("Key-3", 0);
        PlayerPrefs.SetInt("SceneSave", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Continue()
    {
        PlayerMovement.CanLoad = true;
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneSave"));
        
      
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
