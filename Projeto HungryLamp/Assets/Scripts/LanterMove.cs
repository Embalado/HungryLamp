using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanterMove : MonoBehaviour
{
    Animator m_Animator;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);
       
      
    }
}
