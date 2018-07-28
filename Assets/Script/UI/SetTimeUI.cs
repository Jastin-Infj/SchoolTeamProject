using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTimeUI : MonoBehaviour
{
    /// <summary>
    /// 現在のカウント
    /// </summary>
    public SetTime nowtime;
    /// <summary>
    /// 0 - 9 : のリソース
    /// </summary>
    public Sprite[] timeui;

    /// <summary>
    /// 何桁目を貰うのかを決める
    /// </summary>
    public int select;

    /// <summary>
    /// 現在の画像
    /// </summary>
    private Image image;

	// Use this for initialization
	void Start ()
    {
        this.image = GetComponent<Image>();
        this.image.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        int selectnumber = nowtime.getImagenumber(select);
        this.image.sprite = timeui[selectnumber];
	}
}
