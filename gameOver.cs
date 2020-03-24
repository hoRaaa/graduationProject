using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    //databaseLinks v;
    public void over()
    {
        GameObject.Find("overUI").transform.position = new Vector3(0, 20, -30);
        Destroy(GameObject.Find("Cuboid(Clone)"));
        Destroy(GameObject.Find("obstacles(Clone)"));
        GameObject.Find("overUI").GetComponent<overUI>().showUI();
        Time.timeScale = 0;
        //v.uploadScore(250,"hor4");
    }
}
