using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 当たり判定を実装してフラグを返すスクリプトです。


public class HitWall : MonoBehaviour {


    private bool hitflag;       //当たり判定

	// Use this for initialization
	void Start ()
    {
        this.hitflag = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            this.hitflag = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            this.hitflag = false;
        }
        string cName = collision.gameObject.name;
        if(cName.Substring(0,4) == "Cube")
        {
            Debug.Log("実装可能");
        }
    }
    public  bool HitFlag()
    {
        return this.hitflag;
    }
}
