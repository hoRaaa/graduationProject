using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subtractHP : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        GameObject.Find("playingUI").GetComponent<updataUI>().HP--;
        GameObject.Find("board").GetComponent<controlBoard>().speed = 100;
        Destroy(gameObject);
    }
}
