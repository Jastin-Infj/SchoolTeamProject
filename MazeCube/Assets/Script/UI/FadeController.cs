using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//フェードを操作するスクリプト
//-------------------------------------------------------------------------------------
//Fadeにアタッチしてください。
//-------------------------------------------------------------------------------------

public class FadeController : MonoBehaviour
{
    public float fadeSpeed;         //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理

    public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ
    private bool buttonclicked;     //ボタンが押されたかのフラグ

    Image fadeImage;                //透明度を変更するパネルのイメージ

    void Start()
    {
        fadeImage = GetComponent<Image>();


        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        this.buttonclicked = false;
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B)) && isFadeIn)
        {
            this.buttonclicked = true;
        }

        if((Input.GetButtonDown("A") || Input.GetButtonDown("B")) && isFadeIn)
        {
            this.buttonclicked = true;
        }

        if(buttonclicked)
        {
            if(isFadeIn)
            {
                this.StartFadeIn();
            }
            if (isFadeOut)
            {
                this.StartFadeOut();
            }
        }
    }

    public void StartFadeIn()
    {
        alfa -= fadeSpeed;                //不透明度を徐々に下げる
        SetAlpha();                       //変更した不透明度パネルに反映する
        if (alfa <= 0)
        {                                 //完全に透明になったら処理を抜ける
            isFadeIn = false;
            fadeImage.enabled = false;    //パネルの表示をオフにする
        }
    }

    public void StartFadeOut()
    {
        fadeImage.enabled = true;    // パネルの表示をオンにする
        alfa += fadeSpeed;           // 不透明度を徐々にあげる
        SetAlpha();                  // 変更した透明度をパネルに反映する
        if (alfa >= 1)
        {                            // 完全に不透明になったら処理を抜ける
            isFadeOut = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }


    ///<summary>
    ///フェードイン処理が終了しているかどうかを判定します
    /// </summary>
    /// <returns>
    /// 終了しているかを判定する
    /// </returns>
    public bool isFadein()
    {
        return this.alfa <= 0 ? true : false; 
    }

    
    ///<summary>
    ///フェードアウト処理が終了しているかどうかを判定します
    /// </summary>
    ///<returns>
    ///終了しているかどうかを判定します
    /// </returns>
    public bool isFadeout()
    {
        return this.alfa >= 1 ? true : false; 
    }
}
