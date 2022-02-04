using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour
{
    private bool isDebuging;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            isDebuging = !isDebuging;
        }

        if (isDebuging)
        {
            
        }
    }
}
