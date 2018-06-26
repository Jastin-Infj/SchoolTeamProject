using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SetTime : MonoBehaviour
{
    public string NextScece;
    public float counttime;

    private float firstcount;
    bool countZero;
	// Use this for initialization
	void Start ()
    {
        this.firstcount = this.counttime;
        this.countZero = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //カウントが0になった
        if(countZero)
        {
            counttime = firstcount;
            this.countZero = false;
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
            }
            else
            {
                this.countZero = true;
            }
        }
    }
}
