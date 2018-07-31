using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class toMapStage : MonoBehaviour
{
    public string SceceName;                    //次に動かすタスク名
    public FadeController[] fadeController;     //フェードアウト処理の対象物

	// Use this for initialization
	void Start ()
    {
       
	}

    // Update is called once per frame
    void Update()
    {
        this.NectTask_Update();
	}


    /// <summary>
    /// 次のタスクに遷移するまでの一連の処理
    /// </summary>
    void NectTask_Update()
    {
        int count = 0;
        for (int i = 0; i < this.fadeController.Length; ++i)
        {
            if (this.fadeController[i].isFadein())
            {
                count++;
            }
        }
        if (count == this.fadeController.Length)
        {
            SceneManager.LoadScene(SceceName);
        }
    }
}
