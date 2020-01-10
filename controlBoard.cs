using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 滑板的控制，前进，偏移
/// </summary>
public class controlBoard : MonoBehaviour
{
    public float speed = 0;//实时速度
    public float maxSpeed;//最高速度
    public float acceleration;//加速度
    public float offsetSpeed;//偏移速度
    public float slowDown;//减速
    public void setData()//获取数值
    {
        maxSpeed = GetComponent<allData>().maxSpeed;
        acceleration = GetComponent<allData>().acceleration;
        offsetSpeed = GetComponent<allData>().offsetSpeed;
    }

    public void forward()//滑板速度
    {
        if (speed < maxSpeed)
        {
            speed += acceleration;
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public void offset()//滑板偏移，转向
    {
        if()
    }

    void Start()
    {
        setData();
    }
    void Update()
    {
        forward();
        offset();
    }
}
