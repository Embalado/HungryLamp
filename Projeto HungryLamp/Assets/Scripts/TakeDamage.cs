using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
  


    void OnTriggerStay(Collider n)
    {
        if (n.CompareTag("Player"))
        {
            PlayerMovement.damage = true;
         
        }
    }
}
