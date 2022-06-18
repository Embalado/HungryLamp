using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSpawn : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Ghost")
        {

            Destroy(collision.transform.gameObject);


        }
        if (collision.transform.tag == "Bat")
        {

            Destroy(collision.transform.gameObject);


        }
        if (collision.transform.tag == "Ghost1")
        {

            Destroy(collision.transform.gameObject);


        }
        if(collision.transform.tag == "Heal")
        {

            Destroy(collision.transform.gameObject);

        }

        }
        private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Heal")
        {

            Destroy(collision.transform.gameObject);


        }
    }
}
