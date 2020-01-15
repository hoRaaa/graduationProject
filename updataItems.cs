using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updataItems : MonoBehaviour
{
    public float[] X;//生成位置
    public GameObject energy;//能量体
    public GameObject whereEnergy = GameObject.Find("energy");//能量体父物体
    public GameObject obstacles;//障碍物
    public GameObject whereObstacles = GameObject.Find("obstacles");//障碍物父物体
    public allData data;//所有数值

    public int random0 = 6;//障碍物随机生成点
    public int randomE;//能量体随机生成点
    public int wayRandom;//随机办法
    public float timer = 0;//计时器
    public int cycleIndex;//循环次数

    void Start()
    {
        setData();
        InvokeRepeating("doUpdata", 1, 1);
    }

    public void setData()//获取数值
    {
        data = GameObject.Find("allData").GetComponent<allData>();
        X = data.X;
    }

    public void generateEnergy(int whereRandom)//生成能量体
    {
        GameObject newEnergy = Instantiate(energy, new Vector3(X[whereRandom], 15, -500), energy.transform.rotation);
        newEnergy.transform.parent = whereEnergy.transform;
        Destroy(newEnergy, 15);
    }
    public void generateObstacles(int whereRandom)//生成障碍物
    {
        GameObject newObstacles = Instantiate(obstacles, new Vector3(X[whereRandom], 15, -500), obstacles.transform.rotation);
        newObstacles.transform.parent = whereObstacles.transform;
        Destroy(newObstacles, 15);
    }

    public void generate00()//生成办法1
    {
        randomE = Random.Range(1, 5);
        generateEnergy(randomE);
        while (randomE == random0)
        {
            random0 = Random.Range(1, 5);
        }
        generateObstacles(random0);
    }

    public void generate01()//生成办法2
    {

    }

    public void generate02()//生成办法3
    {

    }

    public void doUpdata()//刷新物件
    {
        if (GameObject.Find("board").GetComponent<controlBoard>().speed > 250)
        {
            generate00();
        }
    }
}
