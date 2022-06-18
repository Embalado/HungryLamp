using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public GameObject LockDoor0, LockDoor1,KillEnemy,WinSound;
    [SerializeField] GameObject[] SpawnPoints;
    public GameObject player, pointTransform;
    private EnemySpawn ES;
    private bool Can=true;
    public int totalEnemies;
    public static int enemyCount = 0;
    public static bool EnterArena=false;
    public int ID;
    public int IDposition=0;
    





    private bool CanClose = true, CanOpen = false,canSpawn=false;
    float timer = 0;
   


    void Start()
    {
        if(PlayerMovement.CanLoad==true)
        {
          
            if (ID == 1)
            {
           
                if (PlayerPrefs.GetInt("ID-1") >= IDposition)
                {
                    Destroy(gameObject);
                    Destroy(pointTransform);
                }

            }
            else if(ID == 2)
            {
                if (PlayerPrefs.GetInt("ID-2") >= IDposition)
                {
                    Destroy(gameObject);
                    Destroy(pointTransform);
                }

            }
            else if (ID == 3)
            {

                if (PlayerPrefs.GetInt("ID-3") >= IDposition)
                {
                    Destroy(gameObject);
                    Destroy(pointTransform);
                }
            }

        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (CanOpen)
        {
          
            if (Input.GetKeyDown(KeyCode.R))
            {
                enemyCount = 0;

                KillEnemy.SetActive(true);
                PlayerMovement.Fire = false;
                PlayerMovement.Shield = false;
                canSpawn = true;
                player.transform.position = pointTransform.transform.position;


            }

            if (Can == true)
            {
                for (int i = 0; i < SpawnPoints.Length; i++)
                {

                    SpawnPoints[i].SetActive(true);


                }
                Can=false;

            }
            else
            {
                for (int i = 0; i < SpawnPoints.Length; i++)
                {

                    SpawnPoints[i].SetActive(false);


                }
            }

            if (canSpawn)
            {
                timer += Time.deltaTime;
                for (int i = 0; i < SpawnPoints.Length; i++)
                {

                    SpawnPoints[i].SetActive(true);


                }
                if (timer>0.3)
                {
                    KillEnemy.SetActive(false);
                    // ES.GetComponent<EnemySpawn>().Can = true;
                    Can = true;
                    canSpawn = false;
                    timer = 0;

                }

            }
            else
            {
                //if (LockDoor0 == true)
                //{


                //    Can.SetActive(false);
                //}
            }
           

           
            if (totalEnemies == enemyCount)
            {
                Instantiate(WinSound, transform.position, transform.rotation);
                LockDoor0.SetActive(false);
                LockDoor1.SetActive(false);
                CanClose = false;
                EnterArena = false;
                enemyCount = 0;
                if (ID == 1)
                {
                    
                    PlayerPrefs.SetInt("ID-1Aux", PlayerPrefs.GetInt("ID-1Aux") + 1);

                }
                else if (ID == 2)
                {
                  
                    PlayerPrefs.SetInt("ID-2Aux", PlayerPrefs.GetInt("ID-2Aux") + 1);

                }
                else if (ID == 3)
                {

                   
                    PlayerPrefs.SetInt("ID-3Aux", PlayerPrefs.GetInt("ID-3Aux") + 1);
                }
                
                //for (int i = 0; i < SpawnPoints.Length; i++)
                //{

                //    Destroy(SpawnPoints[i]);


                //}
                Destroy(gameObject);
                Destroy(pointTransform);
                // Can.SetActive(true);
            }
        }
    }
    void OnTriggerEnter(Collider n)
    {
        if (n.gameObject.tag == "Player" && CanClose == true)
        {
            enemyCount = 0;
            CanOpen = true;
            CanClose = false;
            LockDoor0.SetActive(true);
            LockDoor1.SetActive(true);
            EnterArena = true;
            for (int i = 0; i < SpawnPoints.Length; i++)
            {

                SpawnPoints[i].SetActive(true);
              

            }
            
        


        }
    }

}

