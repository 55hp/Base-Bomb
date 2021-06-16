using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mazza : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ball"))
        {
            GameManager.Instance.AddPoints(1);
            
        }

        if (collision.CompareTag("GoldenBall"))
        {
            GameManager.Instance.AddPoints(10);
        }

        if (collision.CompareTag("DarkBall"))
        {
            GameManager.Instance.SubPoints(20);
        }

        Destroy(collision.gameObject);
    }
}
