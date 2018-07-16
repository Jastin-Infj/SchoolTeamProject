using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class BallController : MonoBehaviour
{
    //Ballを指定した箇所間を往復するスクリプト (※現在片道のみ)
    //-------------------------------------------------------------------------------------
    //Ballにアタッチしてください。
    //-------------------------------------------------------------------------------------

    public Transform StartTarget; //開始地点
    public Transform GoalTarget;　//終着点
    NavMeshAgent agent;
    bool turn = false;
    public int cnt = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        cnt++;
        if(cnt >= 350)
        {
            if (turn == false)
            {
                turn = true;
            }
            else if(turn == true)
            {
                turn = false;
            }
            cnt = 0;
        }
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