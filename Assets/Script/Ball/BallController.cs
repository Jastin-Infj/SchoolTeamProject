using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class BallController : MonoBehaviour
{
    //Ballを指定した箇所間を往復するスクリプト
    //-------------------------------------------------------------------------------------
    //Ballにアタッチしてください。
    //-------------------------------------------------------------------------------------

    public Transform StartTarget; //開始地点
    public Transform GoalTarget;　//終着点
    NavMeshAgent agent;
    bool turn = false;
    public float cnt = 3.0f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //3秒毎にTrue、false入れ替え
        cnt -= Time.deltaTime;
        if (cnt <= 0.0)
        {
            turn = !turn;
            cnt = 3.0f;
        }
    
        //ボールが指定した場所へ向かう
        if (turn == false)
        {
            agent.SetDestination(GoalTarget.position);
        }
        else if(turn == true)
        {
            agent.SetDestination(StartTarget.position);
        }
     }
}