using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour

{
    public GameObject boom,heal,aim;
  
    bool entrou = false;
    

    // Update is called once per frame
    void Update()
    {
        if(entrou)
        {
            Instantiate(boom, transform.position, transform.rotation);
            Instantiate(heal, new Vector3(transform.position.x, 0.3f, transform.position.z), transform.rotation);
            Destroy(gameObject);

            ArenaManager.enemyCount++;

           
        }
        if (PlayerMovement.hitFireball.transform == transform && PlayerMovement.Fire== true)
        {
            aim.SetActive(true);
        }
        else
        {
            aim.SetActive(false);
        }
    }



    void OnTriggerEnter(Collider n)
    {
        if (n.gameObject.tag == "Stun")
        {

            entrou = true;
              


            //Instantiate(boom, transform.position, transform.rotation);
            //Instantiate(heal, new Vector3(transform.position.x, 0.3f, transform.position.z), transform.rotation);
            //Destroy(gameObject);

            //ArenaManager.enemyCount++;

            //Debug.Log("Entrou: " + ArenaManager.enemyCount);
        }
    }
}
