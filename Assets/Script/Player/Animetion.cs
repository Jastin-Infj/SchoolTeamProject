using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animetion : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        this.animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.B))
        {
            this.animator.SetBool("Defolut", true);
        }
	}
}
