using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        //コンポーネントする
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        { //地面についていて
            if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Z))
            {//Zキーを押すと
                moveDirection.y = 15; //ジャンプするベクトルの代入
            }
        }

        moveDirection.y -= 10 * Time.deltaTime;          //重力計算
        controller.Move(moveDirection * Time.deltaTime); //cubeを動かす処理
    }

}
