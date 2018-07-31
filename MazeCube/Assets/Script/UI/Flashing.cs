using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashing : MonoBehaviour {

    public float flashtime;             //点滅時間
    private Image flashingimage;        //点滅処理をするImage
    private float color_a;              //不透明度

	// Use this for initialization
	void Start ()
    {
        this.flashingimage = GetComponent<Image>();
        this.color_a = this.flashingimage.color.a;
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.Flash();
	}

    /// <summary>
    /// 点滅処理を行います
    /// </summary>
    void Flash()
    {
        if (this.color_a > 0)
        {
           this.color_a -= this.flashtime * Time.deltaTime;
        }
        else
        {
            this.color_a = 1.0f;
        }
        this.flashingimage.color = new Color(this.flashingimage.color.r, this.flashingimage.color.g, this.flashingimage.color.b, this.color_a);
    }
}
