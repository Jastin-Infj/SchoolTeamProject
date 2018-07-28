using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        // エスケープキー取得
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // アプリケーション終了
            Application.Quit();
            return;
        }
    }
}
