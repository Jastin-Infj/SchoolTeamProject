using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JumpSound : MonoBehaviour {

    public AudioSource[] audioSource;
    private Renderer render;
    private string mateName;
    private int colorid;
    private enum Color
    {
        Red   = 0,
        Green = 1,
        Blue  = 2,
        Yellow = 3,
        Purple = 4,
        Orange = 5,
        Pink   = 6,
        Lime   = 7,
        LightBlue = 8
    }
    private Color color;
	// Use this for initialization
	void Start ()
    {
        this.audioSource = this.gameObject.GetComponents<AudioSource>();
        this.render = GetComponent<Renderer>();
        //BGMのチェックを外す
        for (int i = 0; i < this.audioSource.Length;++i)
        {
            this.audioSource[i].enabled = false;
        }
        //マテリアル名を格納
        this.mateName = this.render.material.name;
        //マテリアル名をカラーにする
        this.color = (Color)Enum.Parse(typeof(Color), this.mateName);
        //番号を振る
        this.colorid = (int)this.color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.SoundPlay();
    }

    public void SoundPlay()
    {
        this.audioSource[this.colorid].enabled = true;
        this.audioSource[this.colorid].Play();
    }
}
