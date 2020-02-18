using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addScore : MonoBehaviour
{
    public allData data;
    public AudioClip music;
    void Start()
    {
        data = GameObject.Find("allData").GetComponent<allData>();
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject.Find("playingUI").GetComponent<updataUI>().score += data.addScore;
        AudioSource.PlayClipAtPoint(music, gameObject.transform.position);
        Destroy(gameObject);
    }
}
