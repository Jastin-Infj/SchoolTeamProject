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
        Debug.Log("回転自体のパラメータ" + this.name + this.hitflag);
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
        this.hitflag = false;
    }
    public  bool HitFlag()
    {
        Debug.Log("返します" + this.name + this.hitflag);
        return this.hitflag;
    }
}
