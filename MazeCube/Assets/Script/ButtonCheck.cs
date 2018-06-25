using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonCheck : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    //ボタンが押されたあとの処理
    public void OnClick()
    {
        SceneManager.LoadScene("MainGame");
    }
}
