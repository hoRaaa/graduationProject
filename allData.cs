using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allData : MonoBehaviour
{
    //滑板数值
    public float maxSpeed = 500;//最高速度
    public float acceleration = 1;//加速度
    public float offsetSpeed = 50;//偏移速度
    public float slowDown = 20;//减速度

    //游戏数值
    public int HP = 3;//生命值
    public int time = 100000;//时间
    public int addTime = 10;//加时间
    public int addScore = 100;//加分
    public int someScore = 500;//加时间所需要的分数

    //场景数值
    public float generatePoint = -14000;//生成点
    public float startPoint = -4000;//起点
    public float endPoint = 10000;//终点，删除点
    public float roadLength = 10000;//路长

    //生成能量体和障碍物的位置
    public float[] X = { 50, 25, 0, -25, -50 };
    public float spacing = 60;//刷新间距

    //边界
    public float Rboundary = -55;//右边界
    public float Lboundary = 55;//左边界
    private void Start()
    {
        Time.timeScale = 1;
    }
}
