using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    public Text txt;
    public Animator anim;

    public void ChangeText(string msg)
    {
        txt.text = msg;
        anim.SetBool("Activate", true);
    }
    
    private float timeLast = 10;

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
