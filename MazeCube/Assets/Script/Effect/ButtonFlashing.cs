using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ボタンUI用のフェードアウト＆インを行うスクリプト
//-------------------------------------------------------------------------------------
//適用したいUIにアタッチしてください。
//-------------------------------------------------------------------------------------

public class ButtonFlashing : MonoBehaviour
{
    float fadeSpeed = 0.1f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理

    public bool isFadeOut = true;  //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

    float FlashingCnt = 0;            //点滅する時間


    Image fadeImage;                //透明度を変更するパネルのイメージ

    void Start()
    {
        fadeImage = GetComponent<Image>();

        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    void Update()
    {
        FlashingCnt += 1.0f * Time.deltaTime;

        if (FlashingCnt >= 1.2f)
        {
            isFadeOut = true;
        }

        if (FlashingCnt >= 2.0f)
        {
            isFadeIn = true;
            FlashingCnt = 0;
        }



        if (isFadeIn)
        {
            StartFadeIn();
        }

        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {
        alfa -= fadeSpeed;                //不透明度を徐々に下げる
        SetAlpha();                       //変更した不透明度パネルに反映する
        if (alfa <= 0)
        {                                 //完全に透明になったら処理を抜ける
            isFadeIn = false;
            fadeImage.enabled = false;    //パネルの表示をオフにする
        }
    }

    void StartFadeOut()
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
}
