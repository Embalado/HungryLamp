using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
   
        private Transform Player;
        public Boss cap;
    public Transform[] Guns;
        public Transform pointTransform;
    public float Force = 0;
        public AudioSource m_AudioSource;
    public GameObject Exclamation;
        //Attacking
        public float timeBetweenAttacks, timeBetweenAttacks1;
        private bool alreadyAttacked = true, alreadyAttacked1= true, alreadyAttacked2 = true;
        public GameObject projectile,effect;
        public float speed;
    public float DashSpeed;
    public float DashTime;
     Animator m_Animator;

    void Start()
        {
            FindWay();
            StartCoroutine(ChangeBool());
            StartCoroutine(ChangeBool1());
            StartCoroutine(ChangeBool2());

        m_Animator = GetComponent<Animator>();
    }

        // Update is called once per frame
        void Update()
        {
        if(cap.Life!=0)
        { 

        if (cap.GetBoolStun() == false)
        {

            transform.LookAt(Player);
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);


                
                AttackPlayer();
                AttackPlayer2();
                AttackPlayer1();
              
        }
        else
        {
            m_Animator.SetBool("Attack", false);
        }

        }
        else
        {

        }
        }



        private void AttackPlayer()
        {
            //Make sure enemy doesn't move
            // Enemy.SetDestination(transform.position);

            transform.LookAt(Player);

            if (!alreadyAttacked)
            {
            ///Attack code here
           
            transform.position = pointTransform.transform.position;
            Instantiate(effect, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            for (int i = 0; i < Guns.Length; i++)
            {
                Rigidbody rb = Instantiate(projectile, Guns[i].transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * Force, ForceMode.Impulse);
            }
            //Rigidbody rb = Instantiate(projectile, Guns[i].transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * Force, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code
           
            m_AudioSource.Play();
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }


    private void AttackPlayer1()
    {
        //Make sure enemy doesn't move
        // Enemy.SetDestination(transform.position);

        transform.LookAt(Player);

        if (!alreadyAttacked1)
        {
            ///Attack code here
            Exclamation.SetActive(false);
            StartCoroutine(Dash());

            m_AudioSource.Play();
            alreadyAttacked1 = true;
           
            Invoke(nameof(ResetAttack1), timeBetweenAttacks1);
        }
        else
        {
            
            m_Animator.SetBool("Attack", false);
            cap.SetBoolStun1(false);

        }
    }

    private void AttackPlayer2()
    {
       

        if (!alreadyAttacked2)
        {
            ///Attack code here
            Exclamation.SetActive(true);

            alreadyAttacked2 = true;
            Invoke(nameof(ResetAttack2), 9);
        }
        else
        {

          

        }
    }


    private void ResetAttack()
        {
            alreadyAttacked = false;
        }

    private void ResetAttack1()
    {
        alreadyAttacked1 = false;
    }
    private void ResetAttack2()
    {
        alreadyAttacked2 = false;
    }
    public void FindWay()
        {
            // Enemy = GetComponent<NavMeshAgent>();
            Player = GameObject.FindWithTag("Player").transform;
        }
        IEnumerator ChangeBool()
        {

            yield return new WaitForSecondsRealtime(timeBetweenAttacks);
            alreadyAttacked = false;

        }

    IEnumerator ChangeBool1()
    {

        yield return new WaitForSecondsRealtime(timeBetweenAttacks1);
        alreadyAttacked1 = false;
      

    }
    IEnumerator ChangeBool2()
    {
       
        yield return new WaitForSecondsRealtime(9);
        alreadyAttacked2 = false;

    }




    IEnumerator Dash()
    {
        float startTime = Time.time;
        while(Time.time < startTime + DashTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, DashSpeed * Time.deltaTime);
            m_Animator.SetBool("Attack", true);
            cap.SetBoolStun1(true);
            yield return null;
        }
    }


    }

