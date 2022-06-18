using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayPuzzle : MonoBehaviour
{
    bool fall = false;
    float vel;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if (fall)
        {
            vel -= 0.08f;
            transform.position = new Vector3(transform.position.x, vel , transform.position.z);
            Destroy(gameObject, 1.3f);

        }
    }

    void OnTriggerEnter(Collider n)
    {
        if (n.gameObject.tag == "Player")
        {


            fall = true;
         

        }
    }
   
}
