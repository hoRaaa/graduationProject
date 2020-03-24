using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class overUI : MonoBehaviour
{
    string URL = "http://localhost:8081/gameServer/uploadScore.php";
    public string[] usersData;
    public string[] usersName;
    public string[] usersScore;

    public Text scoreTxt;
    public Text topNameTxt;
    public Text topScoreTxt;
    public int score;

    public void showUI()//显示得分，游戏时长
    {
        scoreTxt = findChild.getChild(this.transform, "lastScore").GetComponent<Text>();
        topNameTxt = findChild.getChild(this.transform, "TOPname").GetComponent<Text>();
        topScoreTxt = findChild.getChild(this.transform, "TOPscore").GetComponent<Text>();
        score = GameObject.Find("playingUI").GetComponent<updataUI>().score;
        scoreTxt.text = scoreTxt.text + score;
        StartCoroutine(getTOP());
    }

    public void again()
    {
        SceneManager.LoadScene("PlayScene");
        Time.timeScale=1;
    }

    public void menu()
    {
        SceneManager.LoadScene("StartScene");
    }

    private IEnumerator getTOP()
    {
        WWW users = new WWW(URL);
        yield return users;
        usersData = users.text.Split(';');
        for (int i = 0; i < usersData.Length - 1; i = i + 2)
        {
            topNameTxt.text = topNameTxt.text + usersData[i] + "\n\n";
            topScoreTxt.text = topScoreTxt.text + usersData[i + 1] + "\n\n";
        }
    }

}
