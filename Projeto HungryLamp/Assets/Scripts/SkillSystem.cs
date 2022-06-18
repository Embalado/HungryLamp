using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSystem : MonoBehaviour
{
    public Image iconFireBall;
    public Image iconShield;



    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.Fire==true)
        {
            iconFireBall.color= new Color32(255, 91, 0, 255);
        }
        else
        {

            iconFireBall.color = Color.gray;
        }
        if (PlayerMovement.Shield == true)
        {
            iconShield.color = new Color32(0, 255, 255, 255);
        }
        else
        {

            iconShield.color = Color.gray;
        }
    }
}
