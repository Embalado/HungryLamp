using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleRotate : MonoBehaviour
{
    public float  rotateSpeed;
    public float Angle;
    public float Dir;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, Dir*Mathf.PingPong(Time.time * rotateSpeed,Angle), 0);
  

    }
}
  