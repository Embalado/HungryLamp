using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonEnemy : MonoBehaviour
{
    //Attacking
    public Transform Gun;
    public float Force = 0;
    public float timeBetweenAttacks;
    private bool alreadyAttacked = true;
    public GameObject projectile;
    public GameObject effect;
    void Start()
    {
        StartCoroutine(ChangeBool());

    }

    // Update is called once per frame
    void Update()
    {
        AttackPlayer();
    }
    private void AttackPlayer()
    {
   

        if (!alreadyAttacked)
        {
            Instantiate(effect, new Vector3(Gun.transform.position.x, Gun.transform.position.y, Gun.transform.position.z), transform.rotation);
            Rigidbody rb = Instantiate(projectile, Gun.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(Gun.transform.forward * Force,ForceMode.Impulse);
            
            // rb.AddForce(transform.forward * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    IEnumerator ChangeBool()
    {

        yield return new WaitForSecondsRealtime(timeBetweenAttacks);
        alreadyAttacked = false;

    }
}
