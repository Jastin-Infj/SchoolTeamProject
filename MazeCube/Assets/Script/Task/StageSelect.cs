using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//ステージを選択するスクリプト
//-------------------------------------------------------------------------------------
//Main Cameraにアタッチしてください。
//-------------------------------------------------------------------------------------

public class StageSelect : MonoBehaviour
{
    Button tutorial;
    Button stage1;
    Button stage2;
    Button stage3;

    void Start()
    {
        // ボタンコンポーネントの取得
        tutorial = GameObject.Find("/SelectStage/Tutorial").GetComponent<Button>();
        stage1 = GameObject.Find("/SelectStage/Stage1").GetComponent<Button>();
        stage2 = GameObject.Find("/SelectStage/Stage2").GetComponent<Button>();
        stage3 = GameObject.Find("/SelectStage/Stage3").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        tutorial.Select();
    }
}