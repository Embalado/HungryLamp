using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPuzzle : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;
    public GameObject Door, WinSound, Guia;
    bool Can = false;


    Transform NextPos;
    int NextPosIndex;
    void Start()
    {
        NextPos = Positions[0];
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Can==true)
        {
            MoveGameObject();
        }
        if (ColorPuzzle.PuzzleCont1 >= 5)
        {


            if (ColorPuzzle.PuzzleCont == 5)
            {
                Instantiate(WinSound, transform.position, transform.rotation);
                Door.SetActive(false);
                Guia.SetActive(false);

                Destroy(gameObject);

            }else if (ColorPuzzle.PuzzleCont > 5)
            {
                ColorPuzzle.PuzzleCont = 0;
                ColorPuzzle.PuzzleCont1 = 0;
            }
        }
        
        
    }



    void MoveGameObject()
    {
        if (Guia.transform.position == NextPos.position)
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
            Guia.transform.position = Vector3.MoveTowards(Guia.transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {


            Can = true;



        }
    }
}
