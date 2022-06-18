using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    private Transform Cam;
    void Start()
    {
        Cam = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CamPosition = new Vector3(Cam.transform.position.x, transform.position.y, Cam.transform.position.z);
         transform.LookAt(CamPosition);
       
    }
}
