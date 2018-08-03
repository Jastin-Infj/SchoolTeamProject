using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonCheck : MonoBehaviour {

    //次のシーンへ飛ぶスクリプト
    //-------------------------------------------------------------------------------------
    //SceneChangeにアタッチしてください。
    //-------------------------------------------------------------------------------------
    public void StringArgFunction(string s)
    {
        SceneManager.LoadScene(s); //移動先のスクリプトはユニティ側で設定
    }
}
