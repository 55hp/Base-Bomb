﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Detonatore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.EndGame();
        }

    }
}
