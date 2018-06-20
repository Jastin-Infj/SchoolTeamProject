using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour {
    //-------------------------------------------------------
    //仮のプレイヤ処理
    //-------------------------------------------------------

    public float movementSpeed; //ユニティ側で進む速度を指定
    public float jumpPower; //ユニティ側で上方向に進む速度を指定
    public float Dash;
    private float addSpeed; //減加速
    private bool flag;
    private int tim;
    // Use this for initialization
    void Start()
    {
        addSpeed =0;
        flag = false;
        tim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        if (Input.GetButtonDown("Fire5"))//Aキーでダッシュ
        {
            addSpeed = Dash;
        }
        else if(Input.GetButtonUp("Fire5"))
        {
            addSpeed = 0;
        }

      if(Input.GetAxisRaw("Horizontal")<0)//前に進む
        {
            transform.Rotate(new Vector3(0, 0, 0));
            transform.position += transform.forward * (movementSpeed + addSpeed);
        }
       else if ( 0<Input.GetAxisRaw("Horizontal"))
        {
            transform.position -= transform.forward * (movementSpeed + addSpeed);
            //transform.Rotate(new Vector3(180, 0, 0));
        }
        if ( Input.GetAxis("Vertical")<0)
        {
           
            transform.position -= transform.up * (movementSpeed + addSpeed);
            //transform.Rotate(new Vector3(90, 0, 0));
        }
        else if (0<Input.GetAxis("Vertical") )
        {
            transform.position += transform.up * (movementSpeed + addSpeed);

        }
        //if (Input.GetKey(KeyCode.W)) //wキーで前に進む
        //{
        //    transform.position += transform.up * (movementSpeed+addSpeed);
        //}
        //if (Input.GetKey(KeyCode.S)) //sキーで後ろに進む
        //{
        //    transform.position -= transform.up * (movementSpeed + addSpeed);
        //}
        //if (Input.GetKey(KeyCode.A)) //Aキーで左に進む
        //{
        //    transform.position += transform.forward * (movementSpeed + addSpeed);
        //}
        //if (Input.GetKey(KeyCode.D)) //sキーで右に進む
        //{
        //    transform.position -= transform.forward * (movementSpeed + addSpeed);
        //}

        if (Input.GetButtonDown("Fire4")) 
        {
            transform.position -= transform.right * (jumpPower);
        }
        if (Input.GetButtonDown("Fire3"))
        {
            flag = true;
        }
        if(tim<60)
        {
           
                transform.position -= transform.right * (jumpPower);
        }
        else
        {
            tim =0;
            flag = false;
        }
        //if (Input.GetKey(KeyCode.F)) //Fを押すとプレイヤが1度ずつ回転
        //{
        //    transform.Rotate(new Vector3(1, 0, 0));
        //}
    }
}