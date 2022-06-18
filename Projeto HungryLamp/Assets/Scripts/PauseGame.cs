using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public GameObject GameOver;
    public GameObject Win;
    public AudioMixer audiomixer;
    public static bool isPaused;
   
  
    void Start()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            if (isPaused)
            {
                ResumeMenu();
            }
            else
            {
                PauseMenu();
            }
        }
        if(PlayerMovement.isDead==true)
        {
            Cursor.visible = true;
            StartCoroutine(Loadtimer());
        }
        if(WinCollider.win==true)
        {
            Cursor.visible = true;
            Win.SetActive(true);
            Time.timeScale = 0f;
            audiomixer.SetFloat("EffectVol", -80);
        }
      
        



    }
    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        AudioListener.volume = 0;
    }
    public void ResumeMenu()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        AudioListener.volume = 1;
    }
    public void goToMenu()
    {
        PlayerMovement.isDead = false;
        Time.timeScale = 1f;
        AudioListener.volume = 1;
        audiomixer.SetFloat("EffectVol", PlayerPrefs.GetFloat("EffectVolume", 0.75f));
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Continue()
    {
        audiomixer.SetFloat("EffectVol", PlayerPrefs.GetFloat("EffectVolume", 0.75f));
        if (PlayerPrefs.GetInt("Already") == 1)
        {
         
            PlayerMovement.CanLoad = true;
           
            SceneManager.LoadScene(PlayerPrefs.GetInt("SceneSave"));
        }
        else
        {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        PlayerMovement.isDead = false;
        Time.timeScale = 1f;
        AudioListener.volume = 1;

    }
    IEnumerator Loadtimer()
    {
        
        yield return new WaitForSecondsRealtime(3);
        GameOver.SetActive(true);
        Time.timeScale = 0f;
        audiomixer.SetFloat("EffectVol", -80);
       


    }
    
}
