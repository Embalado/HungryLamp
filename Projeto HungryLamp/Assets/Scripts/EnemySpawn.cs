using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject effect;



    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
        Instantiate(effect, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
        Instantiate(enemy, transform.position, transform.rotation);
       



    }
  


}
