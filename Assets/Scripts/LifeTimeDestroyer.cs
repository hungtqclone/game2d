using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeDestroyer : MonoBehaviour
{
    public float time;
    void Start()
    {
        Destroy(gameObject,time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundBox")||collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
