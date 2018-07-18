
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

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
    private float rev;
    private float timR;
    private bool flagRt;
    public GameObject start;
    public GameObject plCamera;
    // Use this for initialization
    //-------------------------------------------------------


    // Use this for initialization
    void Start()
    {

        Box=GetComponent<BoxCollider>();
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
        timR = 0;
        flagR = false;
        this.transform.position = start.transform.position + new Vector3(0, 3, 0);
        this.animator.SetBool("Walk", false);
        this.animator.SetBool("Take", true);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(10, 10, 10);
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
                    vel.y = 0;

                    vel = vel.normalized * (movementSpeed + addSpeed);




                    this.transform.LookAt(this.transform.position + vel);

                    if (vel.magnitude > 0)
                    {

                        //Box.size = new Vector3(1.0f, 1.0f, 2.0f);
                        this.transform.Rotate(new Vector3(-90 + rev, rev, 0));
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
                if (flagR == false && Input.GetKey(KeyCode.T) || Input.GetKeyDown(KeyCode.JoystickButton2)) //Ｔを押すと反転
                {
                    flagR = true;

                }


              
                if (fallFlag == true)
                {
                    fallCnt += Time.deltaTime;
                }
                if (fallCnt >= 0.5f)
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
                grv *= -1;
                Physics.gravity = new Vector3(0, grv, 0);
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
            if (goalflag == true)
            {
                if (moveCnt >= 3)
                {
                    SceneManager.LoadScene("Result");
                }
                moveCnt += Time.deltaTime;
            }
        }

    }


    
        

        public void Fall()
        {
        this.animator.SetBool("Take", true);
        Box.size = new Vector3(0.1f, 0.1f, 0.2f);
        this.animator.SetBool("Walk", false);
        grv = -9.81f;
            Physics.gravity = new Vector3(0, grv, 0);
            this.transform.position = start.transform.position + new Vector3(0, 3, 0);

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
            if (flagRt == false && flagR == false && collision.gameObject.tag == "Map")
            {
                fallFlag = true;
            }
        }
	public bool ClearCheck()
    	{
        return this.goalflag;
    	}

    

}
