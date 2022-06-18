using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ON_OFF : MonoBehaviour
{
    public GameObject OBJ;
    public bool ON;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter(Collider n)
    {
        if (n.gameObject.tag == "Player")
        {

            if(ON)
            {
                OBJ.SetActive(true);
            }
            else
            {
                OBJ.SetActive(false);
            }
            


        }
    }

}
