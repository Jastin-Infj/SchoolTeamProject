using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SetTime : MonoBehaviour
{
    public string NextScece;
    public float counttime;
    public PlayerCont player;

    private Image gameover;
    private Image clear;

    private float firstcount;
    /// <summary>
    /// どのタイムを表示するのかを格納
    /// </summary>
    private int[] imagenumber = new int[5];
    /// <summary>
    /// 実際にタイムに表示するUI
    /// </summary>
    private GameObject[] countdownui = new GameObject[5];

    /// <summary>
    /// 登録するタイム
    /// </summary>
    public Sprite[] timeUI;


    bool countZero;
	// Use this for initialization
	void Start ()
    {
        this.gameover = GetComponent<Image>();
        this.clear = GetComponent<Image>();
        this.countdownui = GetComponents<GameObject>();
        this.firstcount = this.counttime;
        this.countZero = false;

        //ゲームオブジェクトを生成する
        this.ImageConvertCreate();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //カウントが0になった
        if(countZero)
        {
            counttime = firstcount;
            this.countZero = false;
            this.gameover.enabled = true;
            SceneManager.LoadScene(this.NextScece);
            return;
        }
        else
        {
            //カウントが0ではない場合タイムを減らす
            if(counttime > 0)
            {
                //タイムのカウントを減らす
                this.counttime -= Time.deltaTime;

                //Textクラスのテキストにタイムを表示する　（小数点0）
                this.GetComponent<Text>().text = counttime.ToString("F0");


                //ゲーム状況を確認する
                if (!ClearCheck())
                {
                    this.gameover.enabled = false;
                }
                else
                {
                    this.clear.enabled = false;
                }
            }
            else
            {
                this.countZero = true;
            }
        }
        this.ImageConvert();
    }


    /// <summary>
    /// Playerのクリア状況を返します
    /// </summary>
    /// <returns>
    /// クリア状況
    /// </returns>
    private bool ClearCheck()
    {
       return this.player.ClearCheck();
    }

    /// <summary>
    /// カウントダウンカウントを文字列にしてImageに適用させる
    /// </summary>
    /// <param name="counttime">
    /// Imageに適用させる値
    /// </param>
    private void CountTimeStringtoInt(int counttime)
    {
        //配列IDを指す値を初期化
        int imageidnumber = 0;

        //分を返す
        string minutes = this.Minutes_string(counttime);
        //秒を返す
        string second = this.Second_string(counttime);


        //先に分の値を代入
        for(int i = 0; i < minutes.Length;++i)
        {
            //数字の桁数が1である
            if(this.Digit(minutes) == 1)
            {
                //タイムを0とする
                this.imagenumber[imageidnumber] = 0;
                imageidnumber++;
            }
            this.imagenumber[imageidnumber] = int.Parse(minutes.Substring(i, 1));
            imageidnumber++;
        }


        //コロンを追記する
        imageidnumber++;
        this.imagenumber[imageidnumber] = 10;


        //秒の読み取りを行う
        for(int i = 0; i < second.Length;--i)
        {
            //数字の桁数が1である
            if (this.Digit(second) == 1)
            {
                //タイムを0とする
                this.imagenumber[imageidnumber] = 0;
                imageidnumber++;
            }
            this.imagenumber[imageidnumber] = int.Parse(second.Substring(i,1));
            imageidnumber++;
        }

    }


    /// <summary>
    /// 分の値を返す
    /// </summary>
    /// <param name="counttime">
    /// 分の値を取得したい値
    /// </param>
    /// <returns>
    /// 分
    /// </returns>
    private string Minutes_string(int counttime)
    {
        return (counttime / 60).ToString();
    }


    /// <summary>
    /// 秒の値を返す
    /// </summary>
    /// <param name="counttime">
    /// 秒の値を取得したい値
    /// </param>
    /// <returns>
    /// 秒
    /// </returns>
    private string Second_string(int counttime)
    {
        return (counttime % 60).ToString();
    }


    /// <summary>
    /// 数字の桁数を返す
    /// </summary>
    /// <param name="counttime_string">
    /// 検索したい桁数
    /// </param>
    /// <returns>
    /// 数字の桁数
    /// </returns>
    private int Digit(string counttime_string)
    {
        //文字列からIntに変換する
        int counttime = int.Parse(counttime_string);

        //数字の桁数を取得する
        int count = 0;

        while(counttime != 0)
        {
            //10進数
            counttime /= 10;
            count++;
        }
        return count;
    }


    /// <summary>
    /// タイムの表示するためのゲームオブジェクトを生成する
    /// </summary>
    private void ImageConvertCreate()
    {
        string[] objectname = new string[5] {"min1","min2","coron","sec1","sec2"};

        for (int i = 0; i < this.countdownui.Length; ++i)
        {
            this.countdownui[i] = new GameObject(objectname[i]);
            //Canvasの中に格納する
            this.countdownui[i].transform.parent = GameObject.Find("Canvas").transform;
            //座標は0とする
            this.countdownui[i].AddComponent<RectTransform>().anchoredPosition = new Vector3 { };
            this.countdownui[i].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    /// <summary>
    /// タイムを表示をテクスチャに貼り付けて表示をします
    /// </summary>
    private void ImageConvert()
    {
        for(int i = 0;i < countdownui.Length;++i)
        {
            this.countdownui[i].AddComponent<Image>().sprite = timeUI[this.imagenumber[i]];
        }
    }
}
