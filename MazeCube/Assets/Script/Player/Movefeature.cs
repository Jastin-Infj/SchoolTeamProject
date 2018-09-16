using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///@atuthor　日本電子専門学校　ゲーム制作科  横尾拓実(takumiyokoo@gmail.com)
///@version  1.0 
///2018/09/05 10:20 

//@brief ブックマークを付けているのは仮処理

/// <summary>
/// 移動機能クラス
/// </summary>
public class Movefeature : MonoBehaviour
{

    public float moveSpeed;     　　//移動速度
    private Vector3 gravity;    　　//重力方向
    public HitWall hitWall;     　　//範囲用当たり判定
    private bool rotationFlag;  　　//回転度

    public HitWall rangeWallCheck;  //周囲の壁判定

    private enum State
    {
        Normal,     //通常状態
        Fall,       //落下中
        Wall,       //壁
        Res         //リスポーン
    };

    private enum Angle
    {
        DOWN,       //下
        LEFT,       //左
        UP,         //上
        RIGHT,      //右 
    };

    private Angle           angle;               //アングル
    private Vector3         respwonPos;          //リスポーン座標
    private float           respawnTime;         //落下してからどれくらいの時間かを計測する
    private State           state;               //ステート状態
    private PlayerCameraPos playerCameraPos;     //カメラの位置を取得するクラス
    private bool            respawnnow;          //リスポーンしてきた？
    private Rigidbody       Rigidbody;           //重力機能
    private bool            clearCheck;          //クリア判定
    private Animator        fallflag;            //落下速度を変更するため

    public bool camerasetflag;                   //カメラを設置するか？


    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="speed">
    /// 移動速度
    /// </param>
    Movefeature(float speed)
    {
        this.moveSpeed = speed;
    }




    // Use this for initialization
    void Start()
    {
        this.playerCameraPos = GetComponent<PlayerCameraPos>();
        this.state = State.Normal;
        this.Rigidbody = GetComponent<Rigidbody>();
        this.respwonPos = this.gameObject.transform.position;
        this.respawnnow = true;
        this.clearCheck = false;
        this.angle = Angle.UP;
        this.gravity = new Vector3(0, 9.81f, 0);
        this.rotationFlag = false;
        this.fallflag = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.clearCheck)
        {
            SceneManager.LoadScene("Result");
        }
        //カメラの位置と同じにする
        this.ChangePostoCameraPos();

        switch (this.state)
        {
            case State.Normal:
                if(rotationFlag)
                {
                    this.RotateLeft();
                }
                //壁判定
                if (this.hitWall.HitFlag())
                {
                    this.rotationFlag = true;
                }
                //落ちているか
                if (this.FallCheck())
                {
                    this.state = State.Fall;
                }
                //回転中は中止
                if (!rotationFlag)
                {
                    this.JoykeyMove();
                    this.Rigidbody.useGravity = true;
                    this.fallflag.applyRootMotion = false;
                }
                break;
            case State.Fall:
                this.RespawnTimeCnt();
                this.Rigidbody.useGravity = true;
                this.fallflag.applyRootMotion = false;
                break;
            case State.Res:
                this.ResetPos();
                this.state = State.Normal;
                break;
            case State.Wall:
                if (!this.hitWall.HitFlag())
                {
                    this.rotationFlag = false;
                    this.fallflag.applyRootMotion = false;
                    this.state = State.Normal;   
                }
                this.FallMove();
                break;
        };
        Debug.Log(this.state);
    }


    /// <summary>
    /// 回転度を返す
    /// </summary>
    /// <returns>
    /// 回転度
    /// </returns>
    public Quaternion Getrotation()
    {
        return this.transform.rotation;
    }


    /// <summary>
    /// ゲームパッドでの移動
    /// </summary>
    private void JoykeyMove()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //移動
            this.gameObject.transform.position += this.MoveLeft();

            this.gameObject.transform.rotation = Quaternion.Euler(-90, 0, -90);
            
            this.angle = Angle.LEFT;
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            //移動
            this.gameObject.transform.position += this.MoveRight();


            this.angle = Angle.RIGHT;

            this.gameObject.transform.rotation = Quaternion.Euler(-90, 0, 90);
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            //移動
            this.gameObject.transform.position += this.MoveDown();

            this.gameObject.transform.localRotation = Quaternion.Euler(-90, -180, 0);
            this.angle = Angle.DOWN;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
           this.gameObject.transform.position += this.MoveUP();

           this.gameObject.transform.localRotation = Quaternion.Euler(-90, -180, -180);
           this.angle = Angle.UP;
        }
    }

    private Vector3 MoveUP()
    {
        if (this.state == State.Wall)
        {
            return new Vector3(0, this.moveSpeed, 0);
        }
        return new Vector3(0, 0, this.moveSpeed);
    }

    private Vector3 MoveDown()
    {

        if (this.state == State.Wall)
        {
            return new Vector3(0, -this.moveSpeed, 0);
        }
        return new Vector3(0, 0, -this.moveSpeed);
    }

    private Vector3 MoveLeft()
    {
        return new Vector3(-this.moveSpeed, 0, 0);
    }

    private Vector3 MoveRight()
    {
        return new Vector3(this.moveSpeed, 0, 0);
    }

    /// <summary>
    /// リスポーン状態かを判定します
    /// </summary>
    /// <returns></returns>
    private bool CheckRespawn()
    {
        //リスポーン条件を記載する
        return this.respawnTime >= 2.0 ? true : false;
    }

    /// <summary>
    /// リスポーンのタイムを計算します
    /// </summary>
    private void RespawnTimeCnt()
    {
        if (this.respawnnow)
        {
            if (this.CheckRespawn())
            {
                this.respawnTime = 0;
                this.respawnnow = false;
                this.ChengePlayerState(State.Res);
            }
            this.respawnTime += Time.deltaTime;
        }
    }

    /// <summary>
    /// ステートを変更します
    /// </summary>
    /// <param name="changestate">
    /// 変化させたい状態
    /// </param>
    private void ChengePlayerState(State changestate)
    {
        this.state = changestate;
    }

    /// <summary>
    /// カメラの座標をPlayerに上書きします
    /// </summary>
    private void ChangePostoCameraPos()
    {
        if (this.camerasetflag)
        {
            //未定
        }
    }

    public bool ClearCheck()
    {
        return this.clearCheck;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Map" || collision.gameObject.tag == "Goal")
        {
            //リスポーンの判定
            if (this.gameObject.transform.position.y > 0)
            {
                if (this.state != State.Wall)
                {
                    this.state = State.Normal;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            this.clearCheck = true;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        //未確定
    }

    /// <summary>
    /// リスポーン状態になってからの座標修正
    /// </summary>
    private void ResetPos()
    {
        this.respawnnow = true;
        this.gameObject.transform.position = this.respwonPos;
    }

    private bool FallCheck()
    {
        return this.gameObject.transform.position.y < 0.0f ? true : false;
    }

    private void FallMove()
    {
        this.Rigidbody.useGravity = false;
        if (this.angle == Angle.LEFT)        //右から左
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                this.transform.rotation = Quaternion.Euler(0, 90 * (int)angle, 180);
                this.gameObject.transform.position += this.MoveDown();
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                this.transform.rotation = Quaternion.Euler(0, 90 * (int)angle, 180);
                this.gameObject.transform.position += this.MoveUP();
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                this.gameObject.transform.localRotation = Quaternion.Euler(-90, 0, 90);
                this.angle = Angle.RIGHT;
                this.state = State.Fall;

                this.Rigidbody.AddForce(-this.gravity, ForceMode.Acceleration);
                this.gameObject.transform.position += this.MoveRight();
            }
        }
        else if (this.angle == Angle.RIGHT)
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 180);
                this.gameObject.transform.position += this.MoveDown();
                Physics.gravity = this.gravity;
                this.Rigidbody.AddForce(this.gravity, ForceMode.Acceleration);
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 180);
                this.gameObject.transform.position += this.MoveUP();
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                this.gameObject.transform.position += this.MoveLeft();
            }
        }
        if (this.angle == Angle.UP)
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                this.transform.rotation = Quaternion.Euler(-180, 0, 0);
                this.gameObject.transform.position += this.MoveDown();
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                this.transform.rotation = Quaternion.Euler(-180, 0, 0);
                this.gameObject.transform.position += this.MoveUP();

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                this.gameObject.transform.position += this.MoveRight();
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                this.gameObject.transform.position += this.MoveLeft();
            }
        }
        else if (this.angle == Angle.DOWN)
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                this.transform.rotation = Quaternion.Euler(180, -180, 0);
                this.gameObject.transform.position += this.MoveDown();
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                this.transform.rotation = Quaternion.Euler(180, -180, 0);
                this.gameObject.transform.position += this.MoveUP();
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                this.gameObject.transform.position += this.MoveRight();
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                this.gameObject.transform.position += this.MoveLeft();
            }
        }
    }

    void RotateDown()
    {
        ///メモ　(270,0,360)
        
        if(this.gameObject.transform.localEulerAngles.x == 0 && this.gameObject.transform.localEulerAngles.x == 360)
        {
            this.RotateRelease();
        }
        if (this.gameObject.transform.localEulerAngles.x >= 270 && this.gameObject.transform.localEulerAngles.x < 360)
        {
            this.gameObject.transform.Rotate(-1, 0, 0);
        }
        else if(this.gameObject.transform.localEulerAngles.x > 0 && this.gameObject.transform.localEulerAngles.x <= 90)
        {
            this.gameObject.transform.Rotate(1, 0, 0);
        }
    }

    void RotateUp()
    {
        ///メモ　(-270,0,0)
        
        if(this.gameObject.transform.localEulerAngles.x >= 360 && this.gameObject.transform.localEulerAngles.x <= 0)
        {
            this.RotateRelease();
        }
        if(this.gameObject.transform.localEulerAngles.x >= 270 && this.gameObject.transform.localEulerAngles.x <= 0)
        {
            this.gameObject.transform.Rotate(-1, 0, 0);
        }
        else if(this.gameObject.transform.localEulerAngles.x <= 90 && this.gameObject.transform.localEulerAngles.x > 0)
        {
            this.gameObject.transform.Rotate(1, 0, 0);
        }
    }

    void RotateLeft()
    {
        ///メモ　(270,0,270) 
        if (this.gameObject.transform.localEulerAngles.x >= 360 - 1)
        {
            this.RotateRelease();
        }
        if (this.gameObject.transform.localEulerAngles.x >= 270 && this.gameObject.transform.localEulerAngles.x <= 360)
        {
            this.gameObject.transform.Rotate(-1, 0, 0);
        }
        else if(this.gameObject.transform.localEulerAngles.x <= 90 && this.gameObject.transform.localEulerAngles.x > 0)
        {
            this.gameObject.transform.Rotate(1, 0, 0);
        }
    }

    void RotateRight()
    {
        ///メモ　(-90,0,90)
        if(this.gameObject.transform.localEulerAngles.x == 90)
        {
            this.RotateRelease();
        }
        if(this.gameObject.transform.localEulerAngles.x <= 180 && this.gameObject.transform.localEulerAngles.x >= 90)
        {
            this.gameObject.transform.Rotate(-1, 0, 0);
        }
        else if(this.gameObject.transform.localEulerAngles.x > 0 && this.gameObject.transform.localEulerAngles.x <= 90)
        {
            this.gameObject.transform.Rotate(1, 0, 0);
        }
    }

    void Rotatewall()
    {
        switch (this.angle)
        {
            case Angle.DOWN:
                this.RotateDown();
                break;
            case Angle.LEFT:
                this.RotateLeft();
                break;
            case Angle.RIGHT:
                this.RotateRight();
                break;
            case Angle.UP:
                this.RotateUp();
                break;
        }
    }
    void RotateRelease()
    {
        this.rotationFlag = false;
        this.state = State.Wall;
    }
}


//if (this.gameObject.transform.localEulerAngles.z < 0)
//{
//    this.transform.Rotate(0, 0, -10);
//}
//else if (this.gameObject.transform.localEulerAngles.z > 180)
//{
//    this.transform.Rotate(0, 0, 10);
//}