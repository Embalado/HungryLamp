using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject Music, combatMusic, GameOverMusic, winMusic;
    void Start()
    {
        if (PlayerMovement.CanLoad == true)
        {
            ArenaManager.EnterArena = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.isDead==true)
        {
            StartCoroutine(Loadtimer());
        }
        else
        {
            GameOverMusic.SetActive(false);
            Music.SetActive(true);
           
        }
        if(ArenaManager.EnterArena==true)
        {
           
           Music.SetActive(false);
            combatMusic.SetActive(true);

        }
        else
        {
            combatMusic.SetActive(false);
            Music.SetActive(true);
           
        }
        if (WinCollider.win == true)
        {
            Music.SetActive(false);
            combatMusic.SetActive(false);
            winMusic.SetActive(true);
        }







    }
    IEnumerator Loadtimer()
    {

        yield return new WaitForSecondsRealtime(3.0f);
        Music.SetActive(false);
        combatMusic.SetActive(false);
        yield return new WaitForSecondsRealtime(0.2f);
        GameOverMusic.SetActive(true);



    }
        
  


}
