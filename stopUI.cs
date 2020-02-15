using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stopUI : MonoBehaviour
{
    public void again()//重新开始
    {
        SceneManager.LoadScene("gameScene");
        Time.timeScale = 1;
    }

    public void menu()//返回主菜单
    {
        SceneManager.LoadScene("startScene");
    }

    public void continueGame()
    {
        GameObject.Find("stopUI").transform.position = new Vector3(0, -500, 0);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            GameObject.Find("stopUI").transform.position = new Vector3(0, 50, -50);
            Time.timeScale = 0;
        }
    }
}
