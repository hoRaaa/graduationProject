using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteItems : MonoBehaviour
{
    void Update()
    {
        if (this.transform.position.z > 4000)
        {
            Destroy(gameObject);
        }
    }
}
