
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerCont : MonoBehaviour {
    //-------------------------------------------------------
    //仮のプレイヤ処理
    //-------------------------------------------------------

    public float movementSpeed;
    public float Dash;


    private float addSpeed; //減加速
    private float moveCnt;
    private Vector3 vel;
    private bool goalflag;
    private Animator animator;
    private BoxCollider Box;
    private float fallCnt;
    private bool fallFlag;
    private bool respFlag;
    private float reversetime;
    private bool flagR;
    private float grv;
    private Vector3 wall;
    private float rev;
    private float timR;
    private bool flagRt;
    private bool skyFlag;
    private Vector3 nowRot;
    private Vector3 tempVec;
    //public GameObject start;
    private Vector3 start;
    private GameObject plCamera;

    /// <summary>
    /// ゲームクリアを表示する
    /// </summary>
    private Image clearui;

    // Use this for initialization
    //-------------------------------------------------------


    // Use this for initialization
    void Start()
    {
        ///<summary>
        ///plCameraの情報を受け取る
        ///</summary>
        this.plCamera = GetComponent<GameObject>();
        this.plCamera = CameraFind();
        this.clearui = GetComponent<Image>();

        Box =GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        addSpeed = 0;
        goalflag = false;
        fallFlag = false;
        respFlag = true;
        fallCnt = 0;
        rev = 0;
        reversetime = 0;
        flagR = false;
        grv = -9.81f;
        vel = new Vector3();
        tempVec = vel;
       timR = 0;
        flagR = false;
        skyFlag = true;
        nowRot = new Vector3();
        wall = new Vector3();
        start =  this.transform.position ;
        this.animator.SetBool("Walk", false);
        this.animator.SetBool("Take", true);
    }

    // Update is called once per frame
    void Update()
    {
      
        //this.transform.localScale = new Vector3(10, 10, 10);
        if (respFlag == true)
        {
            this.transform.rotation = Quaternion.Euler(-90, 0, 0);

        }

        if (goalflag == false)
        {
            if (flagR == false)
            {
                if (respFlag == false)
                {


                    //if (flag == false) { }
                    if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.K))//Kキーでダッシュ
                    {
                        addSpeed = Dash;
                    }
                    if (Input.GetKeyUp(KeyCode.JoystickButton0) || Input.GetKeyUp((KeyCode.K)))
                    {
                        addSpeed = 0;
                    }




                    //方向キー操作
                    vel = Vector3.zero;
                    vel += Input.GetAxis("Horizontal") * plCamera.transform.right;

                    vel += Input.GetAxis("Vertical") * (plCamera.transform.forward);
                    //vel.y -= 20;
                    tempVec = vel;
                    vel = vel.normalized * (movementSpeed + addSpeed);

                   


                    this.transform.LookAt(this.transform.position + vel);

                    if (vel.magnitude > 0)
                    {

                        //Box.size = new Vector3(1.0f, 1.0f, 2.0f);
                        this.transform.Rotate(new Vector3(-90 + rev+wall.x, rev+wall.y, 0));
                        this.animator.SetBool("Take", false);
                        this.animator.SetBool("Walk", true);

                        
                      
                        this.transform.position += vel * Time.deltaTime * 60;
                    

                    }
                    else
                    {
                        this.animator.SetBool("Walk", false);

                        this.animator.SetBool("Take", true);
                        //Box.size = new Vector3(0.1f, 0.1f, 0.2f);


                    }

                   


                }

                if (skyFlag == true)
                {
                    transform.position += transform.forward * grv * Time.deltaTime /** 60*/;
                }
                if (flagR == false && Input.GetKey(KeyCode.T) || Input.GetKeyDown(KeyCode.JoystickButton2)) //Ｔを押すと反転
                {
                    this.transform.position += transform.forward * 1;
                    flagR = true;
                   
                }


              
                if (fallFlag == true)
                {
                    fallCnt += Time.deltaTime;
                }
                if (fallCnt >= 0.1f)
                {
                    Fall();
                }
              




            }
            if (flagR == true && reversetime < 1.0f)
            {
      
                reversetime += Time.deltaTime;
              
            }

            if (flagR == true)
            {
                transform.Rotate(new Vector3(0, (0.025f * Time.deltaTime) * 4.5f, 0));
               

            }

            if (flagR == true && reversetime >= 1.0f)
            {
                reversetime = 0;
                rev += 180;
                flagR = false;
                skyFlag = true;
                //grv *= -1;
                //Physics.gravity = new Vector3(0, grv, 0);
                flagRt = true;
            }
            if (flagRt == true)
            {
                timR += Time.deltaTime;
            }
            if (timR >= 3.0f)
            {
                flagRt = false;
                timR = 0;
                if (fallFlag == true)
                {
                    Fall();
                }
            }
           
            if (respFlag == true)
            {
                if (moveCnt >= 1)
                {
                    respFlag = false;
                    moveCnt = 0;
                }
                moveCnt += Time.deltaTime;
            }
            
        }
        if (goalflag == true)
        {
            if (moveCnt >= 3)
            {
                SceneManager.LoadScene("Result");
            }
            moveCnt += Time.deltaTime;
        }
        //skyFlag = true;
    }


    
        

        public void Fall()
        {
        this.animator.SetBool("Take", true);
        Box.size = new Vector3(0.1f, 0.1f, 0.2f);
        this.animator.SetBool("Walk", false);
         grv = -9.81f;
            //Physics.gravity = new Vector3(0, grv, 0);
            this.transform.position = start;

        //this.transform.rotation = new Vector3(0, 0, 0);
        //this.transform.rotation = Quaternion.Euler(-90, 0, 0);
        fallCnt = 0;
            fallFlag = false;
            respFlag = true;
        }

        void OnCollisionEnter(Collision collision)
        {
        if (goalflag == false && collision.gameObject.tag == "Goal")
        {
            goalflag = true;


        }
        if (flagRt==true&& collision.gameObject.tag == "Map")
        {
            flagRt = false;
            timR = 0;
        }


        }
        void OnCollisionStay(Collision collision)
        {
            if (fallFlag == true && collision.gameObject.tag == "Map")
            {
                fallFlag = false;
                fallCnt = 0;
            
            }
        if (collision.gameObject.tag == "Map")
        {
            skyFlag =false;
        }
    }
    void OnCollisionExit(Collision collision)
        {
            if (flagRt == false && flagR == false && collision.gameObject.tag == "Map")
            {
            fallFlag = true;
        }
        if (collision.gameObject.tag == "Map")
        {
            skyFlag = true;
        }
    }

    public void WallRotation()
    {
       nowRot =this.transform.localEulerAngles;
        if(nowRot.z <= 90+15 && nowRot.z >= 90-15)
        {
           //if(tempVec.x>0 && tempVec.y==0)
           // {
                this.transform.Rotate(-90, 90, 0);
                wall.x-= 90;
                wall.y += 90;
            //}
        }
        if (nowRot.z >= -90 - 15 && nowRot.z <= -90 + 15)
        {
            if (1 == 0)
            {

            }
        }
        if (nowRot.z <= 0 + 15 && nowRot.z >= 0 - 15)
        {
            if (1 == 0)
            {

            }
        }
        if (nowRot.z <= -180 + 15 && nowRot.z >= 180 - 15)
        {
            if (1 == 0)
            {

            }
        }
    }
	public bool ClearCheck()
    	{
        return this.goalflag;
    	}

    GameObject CameraFind()
    {
        return GameObject.Find("PlayerPos");
    }
    void GameClearRender()
    {
        if(ClearCheck())
        {
            
        }
    }
}
