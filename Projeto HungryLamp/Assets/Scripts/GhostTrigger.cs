using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTrigger : MonoBehaviour
{
    public Animator m_Animator;
  
    void OnTriggerStay(Collider n)
    {
        if (n.gameObject.tag == "Player")
        {
            m_Animator.SetBool("IsAttack", true);
        }
    



    }
    void OnTriggerExit(Collider n)
    {

        m_Animator.SetBool("IsAttack", false);

    }
}
