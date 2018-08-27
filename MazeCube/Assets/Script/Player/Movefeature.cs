using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 移動機能クラス
/// </summary>
public class Movefeature : MonoBehaviour {

    public float moveSpeed;     //移動速度

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

    private Angle angle;            //アングル
    private Vector3 respwonPos;
    private float respawnTime;   //落下してからどれくらいの時間かを計測する
    private State state;         //ステート状態
    private PlayerCameraPos playerCameraPos;     //カメラの位置を取得するクラス
    private bool respawnnow;     //リスポーンしてきた？
    private Rigidbody Rigidbody;
    private bool clearCheck;

    public  bool camerasetflag;  //カメラを設置するか？

    
    Movefeature(float speed)
    {
        this.moveSpeed = speed;
    }




    // Use this for initialization
    void Start ()
    {
        this.playerCameraPos = GetComponent<PlayerCameraPos>();
        this.state = State.Normal;
        this.Rigidbody = GetComponent<Rigidbody>();
        this.respwonPos = this.gameObject.transform.position;
        this.respawnnow = true;
        this.clearCheck = false;
        this.angle = Angle.UP;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(this.clearCheck)
        {
            SceneManager.LoadScene("Result");
        }
        //カメラの位置と同じにする
        this.ChangePostoCameraPos();

        switch (this.state)
        {
            case State.Normal:
                if(this.FallCheck())
                {
                    this.state = State.Fall;
                }
                this.JoykeyMove();
                break;
            case State.Fall:
                this.RespawnTimeCnt();
                break;
            case State.Res:
                this.ResetPos();
                this.state = State.Normal;
                break;
            case State.Wall:
                this.FallMove();
                break;
        };
	}

    public Quaternion Getrotation()
    {
        return this.transform.rotation;
    }


    private void JoykeyMove()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            this.transform.rotation = Quaternion.Euler(-90, 0,-90);
            this.gameObject.transform.position += this.MoveLeft();
            this.angle = Angle.LEFT;

        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            this.transform.rotation = Quaternion.Euler(-90, 0, 90);
            this.gameObject.transform.position += this.MoveRight();
            this.angle = Angle.RIGHT;
        }
        if(Input.GetAxisRaw("Vertical") < 0)
        {
            this.transform.rotation = Quaternion.Euler(-90, 0, 180);
            this.gameObject.transform.position += this.MoveDown();
            this.angle = Angle.DOWN;
        }
        else if(Input.GetAxisRaw("Vertical") > 0)
        {
            this.transform.rotation = Quaternion.Euler(-90, 0, 0);
            this.gameObject.transform.position += this.MoveUP();
            this.angle = Angle.UP;
        }
       
    }

    private Vector3 MoveUP()
    {
        if(this.state == State.Wall)
        {
            return new Vector3(0, this.moveSpeed, 0);
        }
        return new Vector3(0, 0, this.moveSpeed);
    }

    private Vector3 MoveDown()
    {
        if(this.state == State.Wall)
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

    private void RespawnTimeCnt()
    {
        if(this.respawnnow)
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

    private void ChengePlayerState(State changestate)
    {
        this.state = changestate;
    }

    private void ChangePostoCameraPos()
    {
        if(this.camerasetflag)
        {
            
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
        //壁の場合
        if (collision.gameObject.tag == "Wall")
        {
            this.transform.rotation = Quaternion.Euler(0, (int)this.angle * 90, 90 + (int)this.angle * 90);
            this.state = State.Wall;
        }

        if(collision.gameObject.tag == "Goal")
        {
            this.clearCheck = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            this.transform.rotation = Quaternion.Euler(-90, 0, 0);
            this.Rigidbody.useGravity = true;
            this.state = State.Normal;
        }
    }
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
        if(this.angle == Angle.LEFT)        //右から左
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
                this.gameObject.transform.position += this.MoveRight();
            }
        }
        if(this.angle == Angle.RIGHT)
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 180);
                this.gameObject.transform.position += this.MoveDown();
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
        if(this.angle == Angle.UP)
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
            else if(Input.GetAxisRaw("Horizontal") < 0)
            {
                this.gameObject.transform.position += this.MoveLeft();
            }
        }
        if(this.angle == Angle.DOWN)
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                this.transform.rotation = Quaternion.Euler(-180, -180, 0);
                this.gameObject.transform.position += this.MoveDown();
                
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                this.transform.rotation = Quaternion.Euler(-180, -180, 0);
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
}




//private void KeyMove()
//{
//    if (Input.GetKeyDown(KeyCode.UpArrow))
//    {
//        this.gameObject.transform.position += this.MoveUP();
//    }

//    if (Input.GetKeyDown(KeyCode.DownArrow))
//    {
//        this.gameObject.transform.position += this.MoveDown();
//    }

//    if (Input.GetKeyDown(KeyCode.LeftArrow))
//    {
//        this.gameObject.transform.position += this.MoveLeft();
//    }

//    if (Input.GetKeyDown(KeyCode.RightArrow))
//    {
//        this.gameObject.transform.position += this.MoveRight();
//    }
//}
