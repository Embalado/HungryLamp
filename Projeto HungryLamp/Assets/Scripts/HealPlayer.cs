using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public GameObject effect;

  
    private void Update()
    {
        transform.Rotate(0.0f, 0.5f, 0.0f, Space.Self);
    }
    void OnTriggerEnter(Collider n)
    {
        if (n.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, transform.rotation);
            PlayerMovement.heal = true;
            Destroy(gameObject);
        }
       


    }
}

