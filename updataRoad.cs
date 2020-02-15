using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updataRoad : MonoBehaviour
{
    public allData data;//所有数值
    public float generatePoint;//生成点
    public float startPoint;//起点
    public float endPoint;//终点，删除点
    public GameObject whereRoad;//道路父物体
    public GameObject road;

    public void setData()//获取数值
    {
        data = GameObject.Find("allData").GetComponent<allData>();
        generatePoint = data.generatePoint;
        startPoint = data.startPoint;
        endPoint = data.endPoint;
    }

    /*public void Road01()//生成道路01
    {
        if (this.transform.position.z == startPoint)
        {
            GameObject newRoad = Instantiate(road01, new Vector3(0, 0, generatePoint), road.transform.rotation);
            newRoad.transform.parent = whereRoad.transform;

        }
    }*/

    public void generateRoad()//生成道路
    {
        if (this.transform.position.z == startPoint)
        {
            /*int i = Random.Range(1, 3);//随机选择生成的道路
            switch (i)
            {
                case '1':Road01();break;
            }*/

            GameObject newRoad = Instantiate(road, new Vector3(0, 0, generatePoint), road.transform.rotation);
            newRoad.transform.parent = whereRoad.transform;

        }
        if (this.transform.position.z > endPoint)
        {
            this.transform.position = new Vector3(0, 0, startPoint);
        }
    }

    void Awake()
    {
        whereRoad = GameObject.Find("roadScene");
        setData();
    }

    void Update()
    {
        generateRoad();
    }
}
