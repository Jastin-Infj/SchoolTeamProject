using UnityEngine;
using System.Collections;

public class BallTest : MonoBehaviour
{

    //巡回地点。若い順から
    public Vector3[] checkpoints;

    //到達マージン.どれぐらいの範囲で到達したと判定するか
    const float margin = 0.5f;
    const float speed = 0.1f;

    //目的地番号
    private int whereToGo = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (checkpoints.Length == 0)
            return;

        if (checkpoints.Length <= this.whereToGo)
            whereToGo = 0;

        this.transform.position = Vector3.MoveTowards(this.transform.position, checkpoints[whereToGo], speed);

        if (Vector3.Distance(transform.position, checkpoints[whereToGo]) < margin)
        {
            whereToGo++;
        }
    }
}