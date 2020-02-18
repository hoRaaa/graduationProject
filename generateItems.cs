using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateItems : MonoBehaviour
{
    public float roadLength;//路长
    public float spacing;//间距
    public float zAxis;//生成位置（z轴）
    public float[] X;//生成位置（x轴）
    public float endPoint;//结束点

    public GameObject energy;//能量体
    public Transform whereEnergy;//能量体父物体
    public GameObject obstacles;//障碍物
    public Transform whereObstacles;//障碍物父物体
    public allData data;//所有数值

    public int random0 = 6;//障碍物随机生成点
    public int randomE;//能量体随机生成点
    public int wayRandom;//随机办法
    public float timer = 0;//计时器
    public int cycleIndex;//循环次数

    void Start()
    {
        whereEnergy = findChild.getChild(this.transform, "energy");//能量体父物体
        whereObstacles = findChild.getChild(this.transform, "obstacles");//障碍物父物体
        setData();
        doGenerate();
    }

    void Update()
    {
        if(this.transform.position.z == -9999)
            doGenerate();
    }

    public void setData()//获取数值
    {
        data = GameObject.Find("allData").GetComponent<allData>();
        X = data.X;
        roadLength = data.roadLength;
        spacing = data.spacing;
    }

    public void generateEnergy(int whereRandom,float zAxis)//生成能量体
    {
        GameObject newEnergy = Instantiate(energy, new Vector3(X[whereRandom], 15, zAxis), energy.transform.rotation);
        newEnergy.transform.parent = whereEnergy.transform;
    }
    public void generateObstacles(int whereRandom, float zAxis)//生成障碍物
    {
        GameObject newObstacles = Instantiate(obstacles, new Vector3(X[whereRandom], 15, zAxis), obstacles.transform.rotation);
        newObstacles.transform.parent = whereObstacles.transform;
    }

    public void generate00()//生成办法1
    {
        
    }

    public void generate01()//生成办法2
    {
        for (int i = 0; i <= 4; i++)
        {
            generateEnergy(i, zAxis + spacing);
            if (i == 4)
            {
                generateObstacles(0, zAxis);
                generateObstacles(1, zAxis);
                generateObstacles(2, zAxis);
                generateObstacles(3, zAxis);
            }
        }
    }

    public void generate02()//生成办法3
    {
        for (int i = 4; i >= 0; i--)
        {
            generateEnergy(i, zAxis + spacing);
            if (i == 0)
            {
                generateObstacles(4, zAxis);
                generateObstacles(3, zAxis);
                generateObstacles(2, zAxis);
                generateObstacles(1, zAxis);
            }
        }
    }

    public void doGenerate()//生成物件
    {
        zAxis = findChild.getChild(this.transform, "aPoint").transform.position.z;
        endPoint = 100000;//GameObject.Find("bPoint").transform.position.z;
        int k;
        while (zAxis < endPoint)
        {
            k = Random.Range(0, 1);
             /*switch (i)
             {
                 case 1: generate00();break;
                 case 2: generate01(); break;
                 case 3: generate02(); break;
             }*/
            //generate01();
        }
    }
}
