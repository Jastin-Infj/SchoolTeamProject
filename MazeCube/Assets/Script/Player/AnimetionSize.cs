using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimetionSize : MonoBehaviour {

    Animator text;

    int timeCnt;
    bool flag;
	// Use this for initialization
	void Start () {
        this.timeCnt = 0;
        this.flag = false;
        text = GetComponent<Animator>();
        text.updateMode = AnimatorUpdateMode.Normal;
        text.cullingMode = AnimatorCullingMode.AlwaysAnimate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.timeCnt++;
        if(timeCnt % 4 != 0)
        {
            text.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
        else
        {
            text.updateMode = AnimatorUpdateMode.UnscaledTime;
        }

        if(Input.anyKeyDown)
        {
            text.updateMode = AnimatorUpdateMode.Normal;
        }
        this.gameObject.transform.localScale = new Vector3(10, 10, 10);
    }
}