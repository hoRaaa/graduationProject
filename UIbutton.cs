using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIbutton : MonoBehaviour
{
    public void play()//开始游戏
    {
        SceneManager.LoadScene("gameScene");
    }
    public void exit()//退出游戏
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))//开始游戏
        {
            SceneManager.LoadScene("gameScene");
        }
        if (Input.GetKey(KeyCode.S))//退出游戏
        {
            Application.Quit();
        }
    }
}
