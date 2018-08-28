using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //System.IO.FileInfo, System.IO.StreamReader, System.IO.StreamWriter
using System; //Exception
using System.Text; //Encoding
using UnityEngine.UI;

public class setMap : MonoBehaviour
{
    //生成するオブジェクト
    public GameObject wall;
    public GameObject createobject;
    public GameObject player;
    public GameObject ball;

    public Material[] mate;

    public string filePath;
    public int number;

    private string line;
    private string[] data;

    private float CubeOffset = 2.54f;
    private int MapsizeX = 10;
    private int MapsizeZ = 10;


    private TextAsset textAsset;

    // Use this for initialization
    void Awake()
    {
        this.textAsset = new TextAsset();
        this.textAsset = Resources.Load("StageData/" + this.filePath + this.number) as TextAsset;
        this.line = this.textAsset.text;
        Set(this.number);
        this.player.transform.position = new Vector3 { };
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void Set(int value)
    {
       

        Vector3 createpos;

        
        char[] kugiri = {',','\r', '\n'};
        for (int z = 0; z < MapsizeZ; ++z)
        {
            for (int x = 0; x < MapsizeX; ++x)
            {
                this.data = line.Split(kugiri, StringSplitOptions.RemoveEmptyEntries);
                createpos = new Vector3(x * this.CubeOffset, value * this.CubeOffset, -z * this.CubeOffset);

                if(data[z * 10 + x] == "0")
                {
                    continue;
                }
                this.JudgeCreate(data[z * 10 + x],createpos);
            }
        }
    }

    private void JudgeCreate(string value, Vector3 vector3)
    {
        switch (value)
        {
            case "r":
                GameObject red = Instantiate(this.createobject) as GameObject;
                GameObject floorred = Instantiate(this.wall) as GameObject;
                floorred.transform.position = vector3;
                floorred.transform.position += new Vector3(0, 1.3f, 0);
                //座標の変換する
                red.transform.position = vector3;
                red.GetComponent<Renderer>().material = mate[0];
                break;
            case "rw":
                GameObject redwall = Instantiate(this.createobject) as GameObject;
                //座標の変換する
                redwall.transform.position = vector3;
                redwall.GetComponent<Renderer>().material = mate[0];
                break;
            case "g":
                //複製する
                GameObject green = Instantiate(this.createobject) as GameObject;
                GameObject greenred = Instantiate(this.wall) as GameObject;
                greenred.transform.position = vector3;
                greenred.transform.position += new Vector3(0, 1.3f, 0);
                //座標の変換する
                green.transform.position = vector3;
                green.GetComponent<Renderer>().material = mate[1];
                break;
            case "gw":
                GameObject greenwall = Instantiate(this.createobject) as GameObject;
                //座標の変換する
                greenwall.transform.position = vector3;
                greenwall.GetComponent<Renderer>().material = mate[0];
                break;
            case "b":
                GameObject blue = Instantiate(this.createobject) as GameObject;
                GameObject floorblue = Instantiate(this.wall) as GameObject;
                floorblue.transform.position = vector3;
                floorblue.transform.position += new Vector3(0, 1.3f, 0);
                //座標の変換する
                blue.transform.position = vector3;
                blue.GetComponent<Renderer>().material = mate[2];
                break;
            case "bw":
                GameObject bluewall = Instantiate(this.createobject) as GameObject;
                //座標の変換する
                bluewall.transform.position = vector3;
                bluewall.GetComponent<Renderer>().material = mate[0];
                break;
            case "y":
                GameObject yellow = Instantiate(this.createobject) as GameObject;
                GameObject flooryellow = Instantiate(this.wall) as GameObject;
                flooryellow.transform.position = vector3;
                flooryellow.transform.position += new Vector3(0, 1.3f, 0);
                //座標の変換する
                yellow.transform.position = vector3;
                yellow.GetComponent<Renderer>().material = mate[3];
                break;
            case "yw":
                GameObject yellowwall = Instantiate(this.createobject) as GameObject;
                //座標の変換する
                yellowwall.transform.position = vector3;
                yellowwall.GetComponent<Renderer>().material = mate[0];
                break;
            case "p":
                GameObject purple = Instantiate(this.createobject) as GameObject;
                GameObject floorpurple = Instantiate(this.wall) as GameObject;
                floorpurple.transform.position = vector3;
                floorpurple.transform.position += new Vector3(0, 1.3f, 0);
                //座標の変換する
                purple.transform.position = vector3;
                purple.GetComponent<Renderer>().material = mate[4];
                break;
            case "pw":
                GameObject purplewall = Instantiate(this.createobject) as GameObject;
                //座標の変換する
                purplewall.transform.position = vector3;
                purplewall.GetComponent<Renderer>().material = mate[0];
                break;
            case "o":
                GameObject orange = Instantiate(this.createobject) as GameObject;
                GameObject floororange = Instantiate(this.wall) as GameObject;
                floororange.transform.position = vector3;
                floororange.transform.position += new Vector3(0, 1.3f, 0);
                //座標の変換する
                orange.transform.position = vector3;
                orange.GetComponent<Renderer>().material = mate[5];
                break;
            case "ow":
                GameObject orangewall = Instantiate(this.createobject) as GameObject;
                //座標の変換する
                orangewall.transform.position = vector3;
                orangewall.GetComponent<Renderer>().material = mate[0];
                break;
            case "i":
                GameObject pink = Instantiate(this.createobject) as GameObject;
                GameObject floorpink = Instantiate(this.wall) as GameObject;
                floorpink.transform.position = vector3;
                floorpink.transform.position += new Vector3(0, 1.3f, 0);
                //座標の変換する
                pink.transform.position = vector3;
                pink.GetComponent<Renderer>().material = mate[6];
                break;
            case "iw":
                GameObject pinkwall = Instantiate(this.createobject) as GameObject;
                //座標の変換する
                pinkwall.transform.position = vector3;
                pinkwall.GetComponent<Renderer>().material = mate[0];
                break;
            case "l":
                GameObject lime = Instantiate(this.createobject) as GameObject;
                GameObject floorlime = Instantiate(this.wall) as GameObject;
                floorlime.transform.position = vector3;
                floorlime.transform.position += new Vector3(0, 1.3f, 0);
                //座標の変換する
                lime.transform.position = vector3;
                lime.GetComponent<Renderer>().material = mate[7];
                break;
            case "lw":
                GameObject limewall = Instantiate(this.createobject) as GameObject;
                //座標の変換する
                limewall.transform.position = vector3;
                limewall.GetComponent<Renderer>().material = mate[0];
                break;
            case "L":
                GameObject lightblue = Instantiate(this.createobject) as GameObject;
                GameObject floorlightblue = Instantiate(this.wall) as GameObject;
                floorlightblue.transform.position = vector3;
                floorlightblue.transform.position += new Vector3(0, 1.3f, 0);
                //座標の変換する
                lightblue.transform.position = vector3;
                lightblue.GetComponent<Renderer>().material = mate[8];
                break;
            case "Lw":
                GameObject lightbluewall = Instantiate(this.createobject) as GameObject;
                //座標の変換する
                lightbluewall.transform.position = vector3;
                lightbluewall.GetComponent<Renderer>().material = mate[0];
                break;
            case "s":
                //座標の変換する
                GameObject Player = Instantiate(this.player) as GameObject;
                //座標の変換する
                Player.transform.position = new Vector3(vector3.x , vector3.y, vector3.z + CubeOffset / 2);
                break;
            case "G":
                GameObject goal = Instantiate(this.createobject) as GameObject;
                //座標の変換する
                goal.transform.position = vector3;
                goal.GetComponent<Renderer>().material = mate[9];
                goal.gameObject.tag = "Goal";
                break;
            case "B":
                GameObject ball = Instantiate(this.ball) as GameObject;
                //座標の変換する
                ball.transform.position = vector3;
                break;
        }
    }
}
