using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
using System.Text;

public class SetMaptile : MonoBehaviour
{

    // Use this for initialization

    //マップチップテキスト
    public string[] texts;
	void Start ()
    {
        //テキスト用のアセットを追加する
        TextAsset textAsset = new TextAsset();
        //マップタイルのテキストをリソースフォルダから std::ifstream + std::getline()
        textAsset = Resources.Load("maptile", typeof(TextAsset)) as TextAsset;
        //読み込んだ文字列を指定の文字列へ代入する
        string textstring = textAsset.text;
        //マップを1行読み込みしたあとに改行をする
        string kaigyou = "\n";
        //改行ごとに読み込みを区切る
        texts = textstring.Split(kaigyou[0]);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
