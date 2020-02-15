using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class overUI : MonoBehaviour
{
    public Text txtScore;
    public Text time;
    public int score;
    void Start()
    {
        txtScore = GameObject.Find("lastScore").GetComponent<Text>();
        time = GameObject.Find("lastTime").GetComponent<Text>();
    }

    public void showUI()//显示得分，游戏时长
    {
        score = GameObject.Find("playingUI").GetComponent<updataUI>().score;
        txtScore.text = "" + score;
        time.text = "" + Time.time;
    }

    public void again()
    {
        SceneManager.LoadScene("gameScene");
        Time.timeScale=1;
    }

    public void menu()
    {
        SceneManager.LoadScene("startScene");
    }
}
