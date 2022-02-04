using System;
using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour
{

	private float timeLast = 5;

	private float deadline;
	private void Start()
	{
		deadline = Time.time + timeLast;
	}

	void Update ()
	{

		if(Time.time >= deadline)
		   Destroy(transform.gameObject);
	
	}
}
