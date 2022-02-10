using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy Bullet"))
        {
            FindObjectOfType<GameManager>().DoDamage(2);
        }
        Destroy(other.gameObject);
    }
}
