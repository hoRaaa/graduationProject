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
        int k;
        int j1, j2;
        for (int i = 0; i < 10; i++)
        {
            k = Random.Range(0, 4);
            generateEnergy(k, zAxis);
            if(i==3||i==6||i==9)
            {
                j1 = Random.Range(0, 4);
                j2 = Random.Range(0, 4);
                while (j1 == k)
                {
                    j1 = Random.Range(0, 4);
                }
                while (j2 == k || j2 == j1)
                {
                    j2 = Random.Range(0, 4);
                }
                generateObstacles(j1, zAxis);
                generateObstacles(j2, zAxis);
            }
            zAxis += spacing;
        }    
    }

    public void generate01()//生成办法2
    {
        int k;
        k = Random.Range(0, 100);
        if (k >= 50)
        {
            for (int i = 0; i < 4; i++)
            {
                generateEnergy(i, zAxis);
                zAxis += spacing;
            }
            generateEnergy(4, zAxis);
            generateObstacles(1, zAxis);
            generateObstacles(2, zAxis);
            generateObstacles(3, zAxis);
        }
        if (k < 50)
        {
            for (int i = 4; i > 0; i--)
            {
                generateEnergy(i, zAxis);
                zAxis += spacing;
            }
            generateEnergy(0, zAxis);
            generateObstacles(1, zAxis);
            generateObstacles(2, zAxis);
            generateObstacles(3, zAxis);
        }
    }

    public void generate02()//生成办法3
    {
        int k;
        k = Random.Range(0, 2);
        switch (k)
        {
            case 0:
                for (int i = 0; i < 10; i++)
                {
                    generateEnergy(0, zAxis);
                    generateObstacles(1, zAxis);
                    generateObstacles(2, zAxis);
                    generateObstacles(3, zAxis);
                    zAxis += spacing;
                }  
                break;
            case 1:
                for (int i = 0; i < 10; i++)
                {
                    generateEnergy(2, zAxis);
                    generateObstacles(0, zAxis);
                    generateObstacles(1, zAxis);
                    generateObstacles(3, zAxis);
                    generateObstacles(4, zAxis);
                    zAxis += spacing;
                }
                break;
            case 2:
                for (int i = 0; i < 10; i++)
                {
                    generateEnergy(4, zAxis);
                    generateObstacles(1, zAxis);
                    generateObstacles(2, zAxis);
                    generateObstacles(3, zAxis);
                    zAxis += spacing;
                }
                break;
        }
    }

    public void doGenerate()//生成物件
    {
        int k;
        zAxis = findChild.getChild(this.transform, "aPoint").transform.position.z;
        endPoint = findChild.getChild(this.transform, "bPoint").transform.position.z;
        while (zAxis < endPoint)
        {
            k = Random.Range(0, 1);
            switch (k)
            {
                case 0:generate00();break;
                case 1: generate01(); break;
                case 2: generate02(); break;
            }
        }
    }
}
