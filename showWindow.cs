using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class showWindow : MonoBehaviour
{
    [DllImport("user32.dll")]
    public static extern bool showWin(IntPtr hwnd, int nCmdShow);
    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();
    const int SW_SHOWMINIMIZED = 2;//最小化，激活
    const int SW_SHOWMAXIMIZED = 3;//最大化
    const int SW_SHOWRESTORE = 1;//还原

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            showWin(GetForegroundWindow(), SW_SHOWMINIMIZED);
        }
    }
}
