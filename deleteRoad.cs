using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteRoad : MonoBehaviour
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
        if (roadScene > end.endPoint)
        {
            Destroy(gameObject);
        }
    }
}
