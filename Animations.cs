using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人动画;定义需要播放的动画片段名称
/// </summary>
public class Animations : MonoBehaviour
{
    //右转动画
    public string turnRight = "turnR";
    //左转动画
    public string turnLeft = "turnL";
    //行为类
    public AnimationAction action;
    private void Awake()
    {

        action = new AnimationAction(GetComponentInChildren<Animation>());
    }
}
