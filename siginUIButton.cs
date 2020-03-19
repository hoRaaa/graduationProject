using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Commons;

public class siginUIButton : MonoBehaviour
{
    private Transform inputUserName;      //用户名输入框
    private Transform inputUserPass;        //密码输入框
    private Transform inputConfirmPass;  //确认密码输入框
    private Text hintText;                         //提示框

    private string userName;                   //用户名
    private string userPass;                     //密码
    private string confirmPass;               //确认密码
    private string reply;                          //php返回值

    private string url_sigin = "http://localhost:8081/gameServer/userInsert.php"; //php脚本

    private Animator anim;                     //转场动画
    private string animInt = "buttonInt";  //动画器变量

    //初始化获取组件
    void Start()
    {
        inputUserName = findChild.getChild(this.transform, "signName");
        inputUserPass = findChild.getChild(this.transform, "signPass");
        inputConfirmPass = findChild.getChild(this.transform, "confirmPass");
        hintText = findChild.getChild(this.transform, "hint").GetComponent<Text>();
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

            StartCoroutine(sigin(userName,userPass));
        }
    }

    //按下返回按钮
    public void returnButton()
    {
        anim.SetInteger(animInt, 3);
    }

    //注册
    private IEnumerator sigin(string userName, string userPass)
    {
        WWWForm form = new WWWForm();
        form.AddField("addUserName",userName);
        form.AddField("addPass",userPass);

        WWW www = new WWW(url_sigin, form);
        yield return www;
        reply = www.text;
        if (reply == "user_exists")
        {
            hintText.text = "用户名已存在";
        }
        if (reply == "success")
        {
            hintText.text = "注册成功";
            yield return new WaitForSeconds(1);
            hintText.text = "";
        }
    }
}
