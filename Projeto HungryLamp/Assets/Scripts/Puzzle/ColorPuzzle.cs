using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPuzzle : MonoBehaviour
{
    public static int PuzzleCont = 0;
    public static int PuzzleCont1 = 0;


    public  bool ErrorInterno = false;
    public int Id ;
    public GameObject CristalClaro, Cristal;
    void Start()
    {
        ErrorInterno = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (ErrorInterno == true)
        {
          
            if (Id == PuzzleCont)
            {
                Cristal.SetActive(false);
                CristalClaro.SetActive(true);
                PuzzleCont1 += 1;
                PuzzleCont +=1;
            }
            else
            {
                Cristal.SetActive(false);
                CristalClaro.SetActive(true);
                PuzzleCont1 += 1;
                PuzzleCont += 5;
            }
            ErrorInterno = false;
        }


        if (PuzzleCont == 0)
        {
            Cristal.SetActive(true);
            CristalClaro.SetActive(false);
          

        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Stun")
        {

          



            
           
           ErrorInterno = true;
          


        }
    }
}
