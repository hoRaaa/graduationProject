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
    public GameObject whereEnergy;//能量体父物体
    public GameObject obstacles;//障碍物
    public GameObject whereObstacles;//障碍物父物体
    public allData data;//所有数值

    public int random0 = 6;//障碍物随机生成点
    public int randomE;//能量体随机生成点
    public int wayRandom;//随机办法
    public float timer = 0;//计时器
    public int cycleIndex;//循环次数

    void Start()
    {
        whereEnergy = this.transform.Find("energy").gameObject;//能量体父物体
        whereObstacles = this.transform.Find("obstacles").gameObject;//障碍物父物体
        setData();
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
        Destroy(newEnergy, 15);
    }
    public void generateObstacles(int whereRandom, float zAxis)//生成障碍物
    {
        GameObject newObstacles = Instantiate(obstacles, new Vector3(X[whereRandom], 15, zAxis), obstacles.transform.rotation);
        newObstacles.transform.parent = whereObstacles.transform;
        Destroy(newObstacles, 15);
    }

    public void generate00()//生成办法1
    {
        randomE = Random.Range(1, 5);
        generateEnergy(randomE, zAxis);
        while (randomE == random0)
        {
            for (int x = Random.Range(0, 10); x < 10; x++)
            {
                random0 = Random.Range(1, 5);
            }
        }     
        generateObstacles(random0, zAxis);
        generateEnergy(randomE, zAxis + spacing);
    }

    public void generate01()//生成办法2
    {
        for (int i = 1; i <= 5; i++)
        {
            generateEnergy(i, zAxis + spacing);
            if (i == 5)
            {
                generateObstacles(1, zAxis);
                generateObstacles(2, zAxis);
                generateObstacles(3, zAxis);
                generateObstacles(4, zAxis);
            }
        }
    }

    public void generate02()//生成办法3
    {
        for (int i = 5; i >= 1; i--)
        {
            generateEnergy(i, zAxis + spacing);
            if (i == 0)
            {
                generateObstacles(5, zAxis);
                generateObstacles(4, zAxis);
                generateObstacles(3, zAxis);
                generateObstacles(2, zAxis);
            }
        }
    }

    public void doGenerate()//生成物件
    {
        zAxis = GameObject.Find("aPoint").transform.position.z;
        endPoint = 100000;//GameObject.Find("bPoint").transform.position.z;
        //int i;
        while (zAxis < endPoint)
        {
            /*i = Random.Range(1, 3);
            switch (i)
            {
                case 1: generate00();break;
                case 2: generate01(); break;
                case 3: generate02(); break;
            }*/
            generateEnergy(1,zAxis);
            zAxis += spacing;
        }
    }
}
