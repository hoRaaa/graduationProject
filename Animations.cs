using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 定义需要播放的动画片段名称
/// </summary>
public class Animations : MonoBehaviour
{
    //登录动画
    public string cameraRoate = "cameraRoate";
    public string loginUI_UP = "loginUI_UP";
    public string playUI_UP = "playUI_UP";

    public AnimationAction action;
    private void Awake()
    {

        action = new AnimationAction(GetComponentInChildren<Animation>());
    }
}
