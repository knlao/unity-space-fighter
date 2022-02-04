using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float moveSpeed;
    public float spriteWidth;

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if (transform.position.y < -spriteWidth * 2)
        {
            transform.position += Vector3.up * spriteWidth * 4;
        }
    }
}
