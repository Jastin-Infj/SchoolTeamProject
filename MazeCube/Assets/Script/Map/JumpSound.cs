using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;


public class JumpSound : MonoBehaviour {

    public List<AudioClip> audioClips = new  List<AudioClip>();
    private AudioSource audioSource;
    private Renderer render;
    private string mateName;
    private int Colorid;
    private enum Color
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        Yellow = 3,
        Purple = 4,
        Orange = 5,
        Pink = 6,
        Lime = 7,
        LightBlue = 8
    }
	// Use this for initialization
	void Start ()
    {
        this.audioSource = this.gameObject.AddComponent<AudioSource>();
        this.render = this.gameObject.GetComponent<Renderer>();
        //マテリアル名を格納
        this.mateName = render.material.name.ToString();
        //マテリアル名からColorIDを変更する
        this.ColorCheck();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void SoundPlay()
    {
        //音を3D可をする
        this.audioSource.spatialBlend = 1.0f;
        //一定以上離れた場合に音が小さくなる
        this.audioSource.rolloffMode = AudioRolloffMode.Linear;
        //値の調整
        this.audioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff,AnimationCurve.Linear(0.0f,100.0f,300,230));

        //再生する
        this.audioSource.PlayOneShot(this.audioClips[this.Colorid]);
    }

    private void ColorCheck()
    {
       switch(this.mateName)
        {
            case "Red (Instance)":
                this.Colorid = (int)Color.Red;
                break;
            case "Green (Instance)":
                this.Colorid = (int)Color.Green;
                break;
            case "Blue (Instance)":
                this.Colorid = (int)Color.Blue;
                break;
            case "Yellow (Instance)":
                this.Colorid = (int)Color.Yellow;
                break;
            case "Pink (Instance)":
                this.Colorid = (int)Color.Pink;
                break;
            case "Purple (Instance)":
                this.Colorid = (int)Color.Purple;
                break;
            case "Lime (Instance)":
                this.Colorid = (int)Color.Lime;
                break;
            case "LightBlue (Instance)":
                this.Colorid = (int)Color.LightBlue;
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //接触判定したなら・・・
        if (collision.gameObject.name == "Chara" || collision.gameObject.name == "Boll")
        {
            this.SoundPlay();
        }
    }
}
