﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    public void over()
    {
        GameObject.Find("overUI").GetComponent<overUI>().showUI();
        GameObject.Find("overUI").transform.position = new Vector3(0, 25, -50);
        Destroy(GameObject.Find("Cuboid(Clone)"));
        Destroy(GameObject.Find("obstacles(Clone)"));
        Time.timeScale = 0;
    }
}
