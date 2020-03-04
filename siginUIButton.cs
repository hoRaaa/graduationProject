using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class siginUIButton : MonoBehaviour
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
    private Transform inputConfirmPass;
    private string userName;
    private string userPass;
    private string confirmPass;
    private databaseLinks sql;

    private int pass;

    private Animator anim;
    private string animInt = "buttonInt";

    void Start()
    {
        inputUserName = findChild.getChild(this.transform, "signName");
        inputUserPass = findChild.getChild(this.transform, "signPass");
        inputConfirmPass = findChild.getChild(this.transform, "confirmPass");
        sql = new databaseLinks(host, database, id, password, port, pooling, charset);
        sql.openSQL();
        anim = GameObject.Find("scene").GetComponent<Animator>();

    }
    
    //按下确定按钮
    public void confirmButton()
    {
        userName = inputUserName.GetComponent<InputField>().text;
        userPass = inputUserPass.GetComponent<InputField>().text;
        confirmPass = inputConfirmPass.GetComponent<InputField>().text;
        if (userPass == confirmPass)
        {
            sql.addUser(userName, userPass);
        }
    }

    //按下返回按钮
    public void returnButton()
    {
        anim.SetInteger(animInt, 3);
    }
}
