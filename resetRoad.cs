using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetRoad : MonoBehaviour
{
    public allData end;
    void Awake()
    {
        end = GameObject.Find("allData").GetComponent<allData>();
    }
    void Update()
    {
        if (this.transform.position.z > end.endPoint)
        {
            this.transform.position = new Vector3(0, 0, -9999);
        }
    }
}
