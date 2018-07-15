using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class BallController : MonoBehaviour
{
    //Ballを指定した箇所間を往復するスクリプト (※現在片道のみ)
    //-------------------------------------------------------------------------------------
    //Ballにアタッチしてください。
    //-------------------------------------------------------------------------------------

    public Transform StartTarget;
    public Transform GoalTarget;
    NavMeshAgent agent;
    bool turn = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (turn == false)
        {
            agent.SetDestination(GoalTarget.position);
            //turn = true;
        }
        //else if(turn == true)
        //{
        //    agent.SetDestination(StartTarget.position);
        //    turn = false;
        //}
    }
}