
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class PlayerCont : MonoBehaviour {
    //-------------------------------------------------------
    //仮のプレイヤ処理
    //-------------------------------------------------------

    public float movementSpeed; //ユニティ側で進む速度を指定
   
    public float Dash;
    private float addSpeed; //減加速
    private bool flag;
    private float moveCnt;
    private Vector3 vel;
    private Vector3 vel2;
    private Vector3 vel3;
    private Vector3 moveDirection;
    private bool goalflag;
    private Vector3 res;
    private Animator animator;
    private float fallCnt;
    private bool fallFlag;
    // Use this for initialization
    //-------------------------------------------------------
    public GameObject start;
    public Camera Pcamera;
    public GameObject plCamera;
    
    // Use this for initialization
    void Start()
    {
        
        
        animator = GetComponent<Animator>();
        addSpeed = 0;
        flag = true;
        goalflag = false;
        fallFlag = false;
        fallCnt = 0;
        //grv = -9.81f;
        vel = new Vector3();
        vel2 = new Vector3();
       
        this.transform.position = start.transform.position + new Vector3(0, 5, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goalflag == false)
        {
            //if (flag == true)
            //{
            //    this.transform.rotation = Quaternion.Euler(-90, 0, 0);
            //    flag = false;
            //}
            if(flag==true)
            if (Input.GetButtonDown("Fire5"))//Aキーでダッシュ
                {
                    Dush();
                }
                else if (Input.GetButtonUp("Fire5"))
                {
                    addSpeed = 0;
                }


            

            //方向キー操作
            vel = Vector3.zero;
            vel += Input.GetAxis("Horizontal") * plCamera.transform.right;
            vel += Input.GetAxis("Vertical") * (plCamera.transform.forward);
            
            vel.y = 0;
            vel = vel.normalized * (movementSpeed + addSpeed);
            //if (Input.GetKey(KeyCode.W))
            //{
            //    vel += plCamera.transform.forward;
            //}
                this.transform.LookAt(this.transform.position + vel/*+ rig.velocity*/);
            this.transform.position += vel * Time.deltaTime * 60;
            //vel.x=Input.GetAxis("Horizontal")/** movementSpeed*/;
            //vel.z = Input.GetAxis("Vertical")/***//*movementSpeed*/;
            //vel.x *= movementSpeed;
            //vel.z *= movementSpeed;

            //vel2 = plCamera.transform.forward;
            //vel2.x -= 20;



            //vel.x += 20;

            //Rigidbody rig = this.GetComponent<Rigidbody>();

            //rig.velocity = vel * 1.0f;
            //vel = Quaternion.Euler(0, plCamera.transform.localEulerAngles.y,0)* new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
            //vel = transform.TransformDirection(vel);

            ////vel *= movementSpeed;

            //this.transform.rotation += Quaternion.LookRotation(new Vector3(vel.x, 0, vel.z));
            //if (vel.magnitude > 0)
            //{



            //    ////this.transform.rotation = Quaternion.LookRotation(vel);

            //    ////transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Pcamera.transform.rotation.y * vel), 0);
            //    //transform.position += Pcamera.transform.rotation.y * vel;
            //}

            //if (flagR == false && Input.GetKey(KeyCode.T)) //Fを押すとmaze1度ずつ回転
            //{
            //    flagR = true;

            //    //transform.Rotate(new Vector3(0, 180, 0));
            //    //transform.Rotate(new Vector3(0, 3, 0));
            //}

            //if (flagR == true && moveCnt <= 60)
            //{
            //    Reverse();

            //    moveCnt++;

            //}

            //if (Input.GetAxisRaw("Horizontal") < 0)//   lに進む
            //{
            //    transform.Rotate(new Vector3(0, 0, 0));
            //    transform.position -= transform.right * (movementSpeed + addSpeed);
            //    //transform.position += transform.forward * (movementSpeed + addSpeed);
            //}
            //else if (0 < Input.GetAxisRaw("Horizontal"))
            //{
            //    transform.position += transform.right * (movementSpeed + addSpeed);
            //    //transform.position -= transform.forward * (movementSpeed + addSpeed);
            //    //transform.Rotate(new Vector3(0, 0, 1));
            //}
            //if (Input.GetAxis("Vertical") < 0)//s
            //{
            //    //transform.position += transform.up * (movementSpeed + addSpeed);
            //    //transform.position -= transform.forward * (movementSpeed + addSpeed);
            //    transform.position += transform.up * (movementSpeed + addSpeed);
            //    //transform.Rotate(new Vector3(90, 0, 0));
            //}
            //else if (0 < Input.GetAxis("Vertical"))//m
            //{
            //    transform.position -= transform.up * (movementSpeed + addSpeed);

            //    //transform.position -= transform.right * (movementSpeed + addSpeed);

            //}
            //if (Input.GetKey(KeyCode.W)) //wキーで前に進む
            //{
            //    transform.position += transform.up * (movementSpeed + addSpeed);
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

            //if (/*Input.GetButtonDown("Fire4")||*/Input.GetKey(KeyCode.E))
            //{
            //    transform.position += transform.up * (jumpPower);
            //}
            ////if (controller.isGrounded)
            ////{ //地面についていて
            //if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Z))
            //    {//Zキーを押すと
            //     //transform.position -= transform.right * (jumpPower);
            //    transform.position += transform.up * (jumpPower);
            //}
            ////}
            /* moveDirection.y -= 10 * Time.deltaTime;*/          //重力計算
                                                                  //controller.Move(moveDirection * Time.deltaTime); //cubeを動かす処理
                                                                  //if (Input.GetButtonDown("Fire3") || Input.GetKey(KeyCode.Q))
                                                                  //{
                                                                  //    stage1.transform.position -= transform.right * (jumpPower);
                                                                  //    //flag = true;
                                                                  //}
                                                                  //if (flag == true && tim < 60)
                                                                  //{
                                                                  //    //GameObject stage1 = GameObject.Find("Stage");
                                                                  //    //Vector3 v = stage1.transform.localPosition;
                                                                  //    //v.x += 0.1f;
                                                                  //    //stage1.transform.localPosition = v;
                                                                  //    //stage1.transform.Rotate(new Vector3(30, 0, 0));
                                                                  //    //transform.position -= transform.right * (jumpPower);

            //}
            //else
            //{
            //    tim = 0;
            //    flag = false;
            if (fallFlag == true)
            {
                fallCnt += Time.deltaTime;
            }
            if(fallCnt>=0.8f)
            {
                Fall();
            }
        }
        
        if (goalflag == true)
        {
            if (moveCnt >= Time.deltaTime * 3)
            {
                SceneManager.LoadScene("Result");
            }
            moveCnt += Time.deltaTime;
        }
    }
    //if (Input.GetKey(KeyCode.F)) //Fを押すとプレイヤが1度ずつ回転
    //{
    //    transform.Rotate(new Vector3(1, 0, 0));
    //}

    public void Nutlal()
    {

    }
    public void Walk()
    {

    }
        public      void Dush()
    {
        addSpeed = Dash;
        //animator.SetTrigger("defaut");
    }
    //public void Reverse()
    //{
    //    animator.SetTrigger("defaut");
        

        
    //    if (flagR == true && moveCnt>= 60)
    //    {
    //        moveCnt = 0;
    //        //transform.Rotate(new Vector3(180, 0, 0));
    //        //  transform.Rotate(new Vector3(0, 0,180));
    //        flagR = false;
    //        grv *= -1;
    //        Physics.gravity = new Vector3(0, grv, 0);
    //    }
    //}

        public void Fall()
    {
        this.transform.position = start.transform.position + new Vector3(0, 9, 0);
        //this.transform.rotation = new Vector3(0, 0, 0);
        this.transform.rotation = Quaternion.Euler(-90, 0, 0);
        fallCnt = 0;
        fallFlag = false;
    }
 
    void OnCollisionEnter(Collision collision)
    {
        if (goalflag == false && collision.gameObject.tag == "Goal")
        {
            goalflag = true;
          
            
        }
       

    }
    void OnCollisionStay(Collision collision)
    {
        if (fallFlag == true && collision.gameObject.tag == "Map")
        {
            fallFlag = false;
            fallCnt = 0;
        }

    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            fallFlag = true;
        }
    }

    public bool ClearCheck()
    {
        return this.goalflag;
    }

}
