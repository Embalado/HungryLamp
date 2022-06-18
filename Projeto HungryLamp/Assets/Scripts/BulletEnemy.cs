using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public GameObject boom;

    void Start()
    {
        StartCoroutine(ChangeBool());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
       
            Instantiate(boom, transform.position, transform.rotation);
            PlayerMovement.damage = true;
            Destroy(gameObject);

        }
        if (collision.transform.tag == "Wall")
        {

            Instantiate(boom, transform.position, transform.rotation);
            
            Destroy(gameObject);

        }
        if (collision.transform.tag == "Bullet")
        {

            Instantiate(boom, transform.position, transform.rotation);

            Destroy(gameObject);

        }
        if(collision.transform.tag == "BulletEnemy")
        {

            Instantiate(boom, transform.position, transform.rotation);

            Destroy(gameObject);

        }
        if (collision.transform.tag == "Ghost" || collision.transform.tag == "Ghost1")
        {

            Instantiate(boom, transform.position, transform.rotation);

            Destroy(gameObject);

        }
    }
    IEnumerator ChangeBool()
    {

        yield return new WaitForSecondsRealtime(5);
        Instantiate(boom, transform.position, transform.rotation);
        Destroy(gameObject);
        

    }
}
