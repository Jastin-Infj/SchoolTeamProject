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
    public GameObject createObject;
    public GameObject player;
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
    void Start ()
    {
        this.textAsset = new TextAsset();
        this.textAsset = Resources.Load("StageData/" + this.filePath + this.number) as TextAsset;
        this.line = this.textAsset.text;
        Set(this.number);

    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void Set(int value)
    {
       

        Vector3 createpos;

        
        char[] kugiri = {' ','\r', '\n'};
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
                this.JudgeCreate(data[x], createpos);
            }
        }
    }

    private void JudgeCreate(string value, Vector3 vector3)
    {
        switch (value)
        {
            case "r":
                GameObject red = Instantiate(this.createObject) as GameObject;
                //座標の変換する
                red.transform.position = vector3;
                red.GetComponent<Renderer>().material = mate[0];
                break;
            case "g":
                //複製する
                GameObject green = Instantiate(this.createObject) as GameObject;
                //座標の変換する
                green.transform.position = vector3;
                green.GetComponent<Renderer>().material = mate[1];
                break;
            case "b":
                GameObject blue = Instantiate(this.createObject) as GameObject;
                //座標の変換する
                blue.transform.position = vector3;
                blue.GetComponent<Renderer>().material = mate[2];
                break;
            case "y":
                GameObject yellow = Instantiate(this.createObject) as GameObject;
                //座標の変換する
                yellow.transform.position = vector3;
                yellow.GetComponent<Renderer>().material = mate[3];
                break;
            case "p":
                GameObject purple = Instantiate(this.createObject) as GameObject;
                //座標の変換する
                purple.transform.position = vector3;
                purple.GetComponent<Renderer>().material = mate[4];
                break;
            case "o":
                GameObject orange = Instantiate(this.createObject) as GameObject;
                //座標の変換する
                orange.transform.position = vector3;
                orange.GetComponent<Renderer>().material = mate[5];
                break;
            case "i":
                GameObject pink = Instantiate(this.createObject) as GameObject;
                //座標の変換する
                pink.transform.position = vector3;
                pink.GetComponent<Renderer>().material = mate[6];
                break;
            case "l":
                GameObject lime = Instantiate(this.createObject) as GameObject;
                //座標の変換する
                lime.transform.position = vector3;
                lime.GetComponent<Renderer>().material = mate[7];
                break;
            case "L":
                GameObject lightblue = Instantiate(this.createObject) as GameObject;
                //座標の変換する
                lightblue.transform.position = vector3;
                lightblue.GetComponent<Renderer>().material = mate[8];
                break;
            case "P":
                GameObject playercopy = Instantiate(this.player) as GameObject;
                //座標の変換する
                playercopy.transform.position = vector3;
                break;
            case "G":
                GameObject goal = Instantiate(this.createObject) as GameObject;
                //座標の変換する
                goal.transform.position = vector3;
                goal.GetComponent<Renderer>().material = mate[9];
                this.gameObject.tag = "Goal";
                break;
        }
    }
}
