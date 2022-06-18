using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWayPuzzle : MonoBehaviour
{
    public GameObject obj1, obj2;
    void OnTriggerEnter(Collider n)
    {
        if (n.gameObject.tag == "Player")
        {

            obj1.SetActive(true);
            obj2.SetActive(false);
            


        }
    }
}
