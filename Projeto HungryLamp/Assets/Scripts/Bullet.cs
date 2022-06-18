using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public GameObject boom;
    GameObject find;
    public float vel;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
         Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * vel;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Wall")
        {
           
            Instantiate(boom, transform.position, transform.rotation);
           
            Destroy(gameObject);
            
        }
        if (collision.transform.tag == "Ghost")
        {
            ArenaManager.enemyCount += 1;
            Instantiate(boom, transform.position, transform.rotation);
        
            Destroy(collision.transform.gameObject);
                Destroy(gameObject);

            
        }
        if (collision.transform.tag == "Ghost1")
        {
            ArenaManager.enemyCount += 1;
            Instantiate(boom, transform.position, transform.rotation);
     
            Destroy(collision.transform.gameObject);
            Destroy(gameObject);

        }
        if (collision.transform.tag == "Bat")
        {
            ArenaManager.enemyCount += 1;

            Instantiate(boom, transform.position, transform.rotation);
          
            Destroy(collision.transform.gameObject);
            Destroy(gameObject);

        }


    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Mirror")
        {

         
            Instantiate(boom, transform.position, transform.rotation);
         
            Destroy(collision.transform.gameObject);
            Destroy(gameObject);

        }
    }
    }
