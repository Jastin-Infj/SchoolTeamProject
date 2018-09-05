using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinCosTest : MonoBehaviour {

    // Use this for initialization

    
    private float sin;
    private float cos;
    private float insideX;       //距離を測る
    private float insideY;
    private Quaternion r;

	void Start ()
    {
        sin = transform.eulerAngles.z * (Mathf.PI / 180);
        Debug.Log(sin);
    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
