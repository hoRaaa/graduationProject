using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMenuBG : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(0, 0, -300 * Time.deltaTime);
        if (this.transform.position.z < -6000)
        {
            this.transform.position = new Vector3(0, 0, 14000);
        }
    }
}
