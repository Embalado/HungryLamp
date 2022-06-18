using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureScript : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;
    public GameObject ghost, destroy,stun,effect,effectdeath,Damage,Mirror, aim;
    private bool capture = false, stunned = false;
    public int enemyID;

 
    Transform NextPos;
    int NextPosIndex;
    float timer;
    private Vector3 scaleChange;

    private void Start()
    {
        NextPos = Positions[0];
       



    }
    void FixedUpdate()
    {

       if(NextPosIndex ==4)
        {
            destroy.SetActive(true);
        }
        if (ghost.activeSelf==false)
        {
            capture = false;
        }

        if (capture && stunned)
        {
            MoveGameObject();
        }
        if (!capture && stunned)
        {
            
            transform.localScale = new Vector3(1, 1, 1);
          
            timer += Time.deltaTime;
            if (timer > 3)
            {
                effect.SetActive(false);
                Damage.SetActive(true);
                
                stunned = false;
                timer = 0;
            }

        }

        if (PlayerMovement.hitFireball.transform == transform && PlayerMovement.Fire == true) 
        {
            aim.SetActive(true);
        }
        else
        {
            aim.SetActive(false);
        }
    }

    void MoveGameObject()
    {
         if(transform.position == NextPos.position)
        {
           
            NextPosIndex++;
           
            if (NextPosIndex >=Positions.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position,ObjectSpeed * Time.deltaTime);
             transform.Rotate(0.0f, 3f, 0.0f, Space.Self);
            transform.localScale -= new Vector3(0.004f, 0.004f, 0.004f);
        }
    }


    void OnTriggerStay(Collider n)
    {
        if (n.gameObject == ghost)
        {
            capture = true;

        }


        if (n.gameObject == destroy && NextPosIndex >=4 )
        {
            
            if(enemyID==0)
            {
                PlayerMovement.Fire = true;
            }
            else if (enemyID == 1)
            {
                PlayerMovement.Shield = true;
            }
               
          
            Instantiate(effectdeath,transform.position, transform.rotation);
            ArenaManager.enemyCount += 1;
           
            Destroy(gameObject);
            destroy.SetActive(false);

        }
      

        if (n.gameObject == stun && enemyID == 0)
        {
            
            
                Damage.SetActive(false);
                effect.SetActive(true);
                stunned = true;

            
         
        }
        if (n.gameObject == stun && enemyID == 1)
        {
           
            if (Mirror == null)
            {
                Damage.SetActive(false);
                effect.SetActive(true);
                stunned = true;
               
            }
        }

    }

  
    void OnTriggerExit(Collider n)
    {

        capture = false;

    }
    public bool GetBoolStun()
    {
        return stunned;
    }
}

