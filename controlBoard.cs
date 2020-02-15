using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 滑板的控制，前进，偏移
/// </summary>
public class controlBoard : MonoBehaviour
{
    public AnimationAction playAnimation;

    public float speed = 0;//实时速度
    public float maxSpeed;//最高速度
    public float acceleration;//加速度
    public float offsetSpeed;//偏移速度
    public float slowDown;//减速

    public float Rboundary;//右边界
    public float Lboundary;//左边界

    public allData data;//所有数值
    public void setData()//获取数值
    {
        data = GameObject.Find("allData").GetComponent<allData>();
        maxSpeed = data.maxSpeed;
        acceleration = data.acceleration;
        offsetSpeed = data.offsetSpeed;
        Rboundary = data.Rboundary;
        Lboundary = data.Lboundary;
    }

    public void forward()//滑板速度
    {
        if (speed < maxSpeed)
        {
            speed += acceleration;
        }
        GameObject.Find("roadScene").transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public void offset()//滑板偏移，转向
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (this.transform.position.x < Lboundary)
            {
                this.transform.Translate(offsetSpeed * Time.deltaTime, 0, 0, Space.World);
            }
            else
            {
                this.transform.position = new Vector3(Lboundary, 0, 0);
            }
            //playAnimation.Play("turnL");
        }
        /*else
        {
            GameObject.Find("boardModel").transform.Rotate(0, 0, 0);
        }*/
 
        if (Input.GetKey(KeyCode.D))
        {
            if (this.transform.position.x > Rboundary)
            {
                this.transform.Translate(-offsetSpeed * Time.deltaTime, 0, 0, Space.World);
            }
            else
            {
                this.transform.position = new Vector3(Rboundary, 0, 0);
            }
            //playAnimation.Play("turnR");
        }
        /*else
        {
            GameObject.Find("boardModel").transform.Rotate(0, 0, 0);
        }*/
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
