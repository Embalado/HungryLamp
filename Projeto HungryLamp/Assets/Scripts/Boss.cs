using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;
    Transform NextPos;
    private Animator m_Animator;
    int NextPosIndex;
    private Vector3 scaleChange;
    private bool capture = false, stunned = false, stunned1 = false;
    public int Life = 3;
    float timer;
    public GameObject effect , effect1, Damage, CapTrigger ,pointTransform,life1,life2,life3;
    
    // Start is called before the first frame update
    void Start()
    {
        NextPos = Positions[0];
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NextPosIndex >= 4)
        {
            Life -= 1;
            capture = false;
            stunned = false;
            transform.position = pointTransform.transform.position;
            Instantiate(effect1, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            transform.localScale = new Vector3(1.356688f, 1.356688f, 1.356688f);



            stunned1 = false;
            effect.SetActive(false);
            Damage.SetActive(true);

            timer = 0;
           
            NextPosIndex = 0;
        }
        if(Life <= 0)
        {
            ArenaManager.enemyCount += 10;
            life3.SetActive(false);
            Instantiate(effect, transform.position, transform.rotation);
            m_Animator.SetBool("Death", true);
            Destroy(gameObject,2);
            
        }
        if (Life == 2)
        {
            life1.SetActive(false);
        }
        else if(Life == 1)
        {
            life2.SetActive(false);
        }
        if (CapTrigger.activeSelf == false)
        {
            capture = false;
        }
        if (capture && stunned )
        {
            MoveGameObject();
        }
        if (!capture && stunned)
        {

            transform.localScale = new Vector3(1.356688f, 1.356688f, 1.356688f);

            timer += Time.deltaTime;
            if (timer > 3)
            {
                effect.SetActive(false);
                Damage.SetActive(true);
                NextPosIndex = 0;
                stunned = false;
                timer = 0;
            }

        }
    }

    void MoveGameObject()
    {
        if (transform.position == NextPos.position)
        {

            NextPosIndex++;

            if (NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);
            transform.Rotate(0.0f, 3f, 0.0f, Space.Self);
            transform.localScale -= new Vector3(0.004f, 0.004f, 0.004f);
        }
    }
    void OnTriggerStay(Collider n)
    { 

        if(n.gameObject == CapTrigger)
        {
            capture = true;
        }
        if (n.gameObject.tag == "Shield" && stunned1 == true)
        {


            Damage.SetActive(false);
            effect.SetActive(true);
            stunned = true;
            stunned1 = false;


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
    public bool SetBoolStun1(bool a)
    {
        return stunned1=a;
    }

}
