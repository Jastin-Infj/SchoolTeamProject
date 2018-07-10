using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class toMapStage : MonoBehaviour
{
    public string SceceName;

	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(SceceName);
        }
        //JoyPad A Bボタンが押されたら・・・
        if(Input.GetButtonDown("A") || Input.GetButtonDown("B"))
        {
            SceneManager.LoadScene(SceceName);
        }
	}
}
