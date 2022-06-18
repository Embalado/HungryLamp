using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour
{
    public GameObject Text,Text1;
    public int time;


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider n)
    {
        if (n.gameObject.tag == "Player")
        {
           
            Text.SetActive(true);
            StartCoroutine("WaitForSec");  
        }
    }

    IEnumerator WaitForSec()
    {

       yield return new WaitForSecondsRealtime(time);
        
        Text.SetActive(false);
        Text1.SetActive(true);
        Destroy(gameObject);
        //yield return new WaitForSecondsRealtime(time);
        //Text1.SetActive(false);
    }
}
