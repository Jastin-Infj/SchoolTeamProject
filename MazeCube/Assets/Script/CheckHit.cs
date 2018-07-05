using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour {

    public string[] Tag;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    //オブジェクトが衝突したとき
    void OnCollisionEnter(Collision collision)
    {
        for(int i = 0; i < Tag.Length;++i)
        {
            if (collision.gameObject.tag == Tag[i])
            {
                Destroy(collision.gameObject);
            }
        }
    }

    //オブジェクトが離れた時
    void OnCollisionExit(Collision collision)
    {
       
    }

    //オブジェクトが触れている間
    void OnCollisionStay(Collision collision)
    {
        
    }
}
