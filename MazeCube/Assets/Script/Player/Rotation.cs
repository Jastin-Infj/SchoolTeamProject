﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    private int time;
    private bool flagR;
    private float grv;
    // Use this for initialization
    void Start () {
        time = 0;
        flagR = false;
        grv = -9.81f;
    }

    // Update is called once per frame
    void Update()
    {


        if (flagR == false && Input.GetKey(KeyCode.T)) //Fを押すとmaze1度ずつ回転
        {
            flagR = true;
            //transform.Rotate(new Vector3(0, 180, 0));
            //transform.Rotate(new Vector3(0, 3, 0));
        }

        if (flagR == true && time <=60)
        {
            time++;
         
        }

        if(flagR == true /*&& time <= 20*/)
        {
            transform.Rotate(new Vector3(0,0, 3));
            //transform.Rotate(new Vector3(3, 0, 0));
            //transform.Rotate(new Vector3(0, 3,0));
            //transform.Rotate(new Vector3(0, 0, 3));
        }
        //else if (flagR == true && time <= 40)
        //{
        //    transform.Rotate(new Vector3(9, 0, 0));

        //}
        //else if (flagR == true && time <= 60)
        //{
        //    transform.Rotate(new Vector3(0, 0, 9));

        //}
        if (flagR == true && time >= 60)
        {
            time = 0;
            //transform.Rotate(new Vector3(180, 0, 0));
            //  transform.Rotate(new Vector3(0, 0,180));
            flagR = false;
            grv *= -1;
            Physics.gravity = new Vector3(0, grv, 0);
        }

        //if (flagR == false && Input.GetKey(KeyCode.J)) //Fを押すとmaze1度ずつ回転
        //{
        //    flagR = true;
        //    //transform.Rotate(new Vector3(90, 0, 0));
        //    //transform.Rotate(new Vector3(0, 3, 0));

        //}

        //if (flagR == true && time < 60)
        //{
        //    time++;

        //}

        //if (flagR == true)
        //{

        //    //transform.Rotate(new Vector3(3, 0,0));
        //}
        ////else if (flagR == true && time <= 40)
        ////{
        ////    transform.Rotate(new Vector3(9, 0, 0));

        ////}
        ////else if (flagR == true && time <=60)
        ////{
        ////    transform.Rotate(new Vector3(0, 0, 9));

        ////}
        //if (flagR == true && time >=30)
        //{
        //    time = 0;
        //    //transform.Rotate(new Vector3(180, 0, 0));
        //    //  transform.Rotate(new Vector3(0, 0,180));
        //    flagR = false;

        //    Physics.gravity = new Vector3(0, 0, grv);
        //}

    }

}
