using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashing : MonoBehaviour {

    public float flashtime;             //点滅時間
    public bool Fadein;                 //フェードイン処理
    public bool FadeOut;                //フェードアウト処理
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
        if(Fadein)
        {
            this.Flash_FadeIn();
        }
        if(FadeOut)
        {
            this.Flath_FadeOut();
        }
        //お互いある場合は失敗させる
        if(Fadein && FadeOut)
        {
            Debug.Log("フェード処理をどちらかにしてください");
            return;
        }
	}

    /// <summary>
    /// 点滅処理を行います フェードイン処理
    /// </summary>
    void Flash_FadeIn()
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



    /// <summary>
    /// 点滅処理を行います フェードアウト処理
    /// </summary>
    void Flath_FadeOut()
    {
        if(this.color_a < 1)
        {
            this.color_a += this.flashtime * Time.deltaTime;
        }
        else
        {
            this.color_a = 0.0f;
        }
        this.flashingimage.color = new Color(this.flashingimage.color.r, this.flashingimage.color.g, this.flashingimage.color.b, this.color_a);
    }
}
