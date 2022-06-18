using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapideSave : MonoBehaviour
{

    public static bool CanSave = false;
    public AudioSource m_AudioSource;
    PlayerMovement pm;
    public GameObject effect,Text;
    private void Update()
    {
        if(CanSave)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Instantiate(effect, new Vector3(transform.position.x, 0.6f, transform.position.z), transform.rotation);
                PlayerPrefs.SetInt("Already", 1);
                PlayerPrefs.SetInt("SceneSave", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.SetInt("ID-1", PlayerPrefs.GetInt("ID-1Aux"));
                PlayerPrefs.SetInt("ID-2", PlayerPrefs.GetInt("ID-2Aux"));
                PlayerPrefs.SetInt("ID-3", PlayerPrefs.GetInt("ID-3Aux"));
                PlayerPrefs.SetInt("Key-1", PlayerPrefs.GetInt("Key-1Aux"));
                PlayerPrefs.SetInt("Key-2", PlayerPrefs.GetInt("Key-2Aux"));
                PlayerPrefs.SetInt("Key-3", PlayerPrefs.GetInt("Key-3Aux"));

                //Debug.Log("quanto1" + PlayerPrefs.GetInt("ID-1"));
                //Debug.Log("quanto2" + PlayerPrefs.GetInt("ID-2"));
                //Debug.Log("quanto3" + PlayerPrefs.GetInt("ID-3"));

                m_AudioSource.Play();

            }
        }
    }
    void OnTriggerEnter(Collider n)
    {
        if (n.gameObject.tag == "Player")
        {
            CanSave = true;
            Text.SetActive(true);
            PlayerMovement.heal1 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        CanSave = false;
        Text.SetActive(false);

    }
}
