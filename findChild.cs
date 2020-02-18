using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findChild
{
    /// <summary>
    /// 在层级未知情况下查找子物体
    /// </summary>
    /// <param name="parentTF">父物体变换组件</param>
    /// <param name="childName">子物体名称</param>
    /// <returns></returns>
    public static Transform getChild(Transform parentTF,string childName)
    {
        //在子物体中查找
        Transform childTF = parentTF.Find(childName);
        if (childTF != null)
            return childTF;

        //将问题交由子物体
        int count = parentTF.childCount;
        for (int i = 0; i < count; i++)
        {
            childTF = getChild(parentTF.GetChild(i), childName);
            if (childTF != null)
                return childTF;
        }
        return null;
    }
}
