using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGhost : MonoBehaviour
{
    private Transform Player;
    private NavMeshAgent Enemy;
    public CaptureScript cap;
    
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (cap.GetBoolStun() == false)
        {
            //transform.LookAt(Player);
            //transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
           
            Enemy.enabled = true;
        }
        else
        {
            Enemy.enabled = false;
        }
        if (Enemy.enabled == true)
        {
            Enemy.SetDestination(Player.position);
        }
       
       
    }
}
