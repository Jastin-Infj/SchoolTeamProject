using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour {

    public string[] Tag;
    private AudioSource sound;

    // Use this for initialization
    void Start ()
    {
        this.sound = GetComponent<AudioSource>();
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
               this.sound.Play();
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
