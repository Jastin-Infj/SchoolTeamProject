using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    private int reversetime;
    private bool flagR;
    private float grv;
  


    // Use this for initialization
    void Start () {
        reversetime = 0;
        flagR = false;
        grv = -9.81f;
      

    }

    // Update is called once per frame
    void Update()
    {


   
            if (flagR == false && Input.GetKey(KeyCode.T)||Input.GetKeyDown(KeyCode.JoystickButton2)) //Ｔを押すと反転
        { 
                flagR = true;
               
            }
        

        if (flagR == true && reversetime <= 60)
        {
            reversetime++;
         
        }

        if(flagR == true )
        {
            transform.Rotate(new Vector3(0,3, 0));

            
        }
       
        if (flagR == true && reversetime >= 60)
        {
            reversetime = 0;
           
            flagR = false;
            grv *= -1;
            Physics.gravity = new Vector3(0, grv, 0);
        }

       

    

    //private void OnCollisioStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Map" || collision.gameObject.tag == "Goal")
    //    {
    //        this.gameObject.transform.position += new Vector3(0, 6, 0);
    //        this.gameObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
    //    }
    //}

    ////接触が離れたら
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Map" || collision.gameObject.tag == "Goal")
    //    {
    //        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    //    }
    //}
    }
}

