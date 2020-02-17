using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetRoad : MonoBehaviour
{
    public allData end;
    public float roadScene;
    void Awake()
    {
        end = GameObject.Find("allData").GetComponent<allData>();
        roadScene = GameObject.Find("roadScene").transform.position.z;
    }
    void Update()
    {
        if (this.transform.position.z > end.endPoint)
        {
            this.transform.position = new Vector3(0, 0, -9999);
        }
    }
}
