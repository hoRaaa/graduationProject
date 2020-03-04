using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class loginUIButton : MonoBehaviour
{
    private string host = "localhost";
    private string database = "game_data";
    private string id = "root";
    private string password = "root";
    private string port = "3306";
    private string pooling = "false";
    private string charset = "utf8";

    private Transform inputUserName;
    private Transform inputUserPass;
    private string userName;
    private int userPass;
    private databaseLinks sql;

    private Animator anim;
    private string animInt = "buttonInt";

    public bool loginState;

    void Start()
    {
        inputUserName = findChild.getChild(this.transform, "userName");
        inputUserPass = findChild.getChild(this.transform, "userPass");
        sql = new databaseLinks(host, database, id, password, port, pooling, charset);
        sql.openSQL();
        anim = GameObject.Find("scene").GetComponent<Animator>();

    }

    //按下登录按钮
    public void loginButton()
    {
        userName = inputUserName.GetComponent<InputField>().text;
        userPass = int.Parse(inputUserPass.GetComponent<InputField>().text);
        if(userPass == sql.getPass(userName))
        {
            print("登录成功");
            anim.SetInteger(animInt, 1);
            loginState = true;
        }
    }

    //按下注册按钮
    public void siginButton()
    {
        anim.SetInteger(animInt, 2);
    }
}
