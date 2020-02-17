using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 动画行为类，提供有关动画的行为
/// </summary>
public class AnimationAction
{
    // 附加在敌人模型上的动画组件引用
    private Animation anim;

    // 创建动画行为
    public AnimationAction(Animation anim)
    {
        this.anim = anim;
    }

    //播放动画
    public void Play(string animName)
    {
        anim.CrossFade(animName);
    }
}
