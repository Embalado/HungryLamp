using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparentWall : MonoBehaviour
{
	public Transform alvo;
	public RaycastHit hitpoint = new RaycastHit();

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Physics.Linecast(transform.position, alvo.transform.position, out hitpoint))
		{
			Debug.DrawLine(transform.position, alvo.transform.position);
		}
	}
}
