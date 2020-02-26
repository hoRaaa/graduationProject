using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updataUI : MonoBehaviour
{
    public int HP;//生命值
    public int time;//时间
    public int addTime;//加时间
    public int addScore;//加分
    public int score = 0;//分数
    public int someScore;//加时间所需要的分数
    public float timer;//计时器

    public Text txtHP;
    public Text txtTime;
    public Text txtScore;

    public allData data;//所有数据
    void Start()
    {
        setData();
        txtHP = GameObject.Find("HP").GetComponent<Text>();
        txtTime = GameObject.Find("time").GetComponent<Text>();
        txtScore = GameObject.Find("score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        updataHP();
        updataTime();
        updataScore();
    }

    public void setData()
    {
        data = GameObject.Find("allData").GetComponent<allData>();
        HP = data.HP;
        time = data.time;
        addTime = data.addTime;
        addScore = data.addScore;
        someScore = data.someScore;
    }

    public void updataHP()//刷新生命值
    {
        txtHP.text = HP + " ";
        if (HP <= 0)
        {
            GetComponent<gameOver>().over();//游戏结束
        }
    }
    public void updataTime()//刷新时间
    {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            time--;
            if (time >= 0)
            {
                txtTime.text = string.Format("{0:d2}:{1:d2}", time / 60, time % 60);
            }
            if (time <= 0)
            {
                GetComponent<gameOver>().over();//游戏结束
            }
            timer = 0;
        }
    }
    public void updataScore()//刷新分数
    {
        txtScore.text = score + " ";
        if (score == someScore)
        {
            time += addTime;
            someScore += someScore;
        }
    }
}
