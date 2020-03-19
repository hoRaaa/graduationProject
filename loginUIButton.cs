using System;
using System.Collections;
using System.Security.Cryptography;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Commons;

public class loginUIButton : MonoBehaviour
{
    private Transform inputUserName;  //用户名输入框
    private Transform inputUserPass;    //密码输入框
    private Text hintText;                      //提示框

    private string userName;                //用户名
    private string userPass;                  //密码
    private string reply;                       //php返回值

    private string url_login = "http://localhost:8081/gameServer/userLogin.php";    //php脚本

    private Animator anim;                      //转场动画
    private string animInt = "buttonInt";  //动画器变量，注册或登录

    //初始化获取组件
    void Start()
    {
        inputUserName = findChild.getChild(this.transform, "userName");
        inputUserPass = findChild.getChild(this.transform, "userPass");
        hintText = findChild.getChild(this.transform,"hint").GetComponent<Text>();
        anim = GameObject.Find("scene").GetComponent<Animator>();
    }

    //按下登录按钮
    public void loginButton()
    {
        userName = inputUserName.GetComponent<InputField>().text;
        userPass = Common.strEncrypMD5(inputUserPass.GetComponent<InputField>().text);
        if (userName == null || userPass == null)
        {
            hintText.text = "用户名或密码不能为空";
        }
        else
        {
            StartCoroutine(login(userName, userPass));
        }
    }

    //按下注册按钮
    public void siginButton()
    {
        anim.SetInteger(animInt, 2);
    }

    //登录
    private IEnumerator login(string userName, string userPass)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", userName);
        form.AddField("userPass", userPass);

        WWW www = new WWW(url_login, form);

        yield return www;
        reply = www.text;
        if (reply == "Login")
        {
            hintText.text = "登录成功";
            anim.SetInteger(animInt, 1);
            PlayerPrefs.GetString("userName", "DefaultValue");
        }
        if (reply == "Not_user")
        {
            hintText.text = "用户不存在";
        }
        if (reply == "Password_error")
        {
            hintText.text = "密码错误";
        }
    }
}
