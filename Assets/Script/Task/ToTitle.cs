using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitle : MonoBehaviour {


    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("A") || Input.GetButtonDown("B"))
        {
            SceneManager.LoadScene("Title");
        }
	}
}
