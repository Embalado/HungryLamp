using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform Player;
    private NavMeshAgent Enemy;
    public Transform Gun;
    public float Force = 0;
    public AudioSource m_AudioSource;
    //Attacking
    public float timeBetweenAttacks;
    private bool alreadyAttacked = true;
    public GameObject projectile;
    

    void Start()
    {
        FindWay();
        StartCoroutine(ChangeBool());
    }

    // Update is called once per frame
    void Update()
    {
      
        
      
      
        Enemy.SetDestination(Player.position);
      
        AttackPlayer();
     
    }




    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        // Enemy.SetDestination(transform.position);

        transform.LookAt(Player);
       
        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, Gun.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * Force, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code
            m_AudioSource.Play();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
   public void FindWay()
    {
        Enemy = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player").transform;
    }
     IEnumerator ChangeBool()
    {

        yield return new WaitForSecondsRealtime(timeBetweenAttacks);
        alreadyAttacked = false;

    }
  

}
