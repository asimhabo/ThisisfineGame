using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverArea : MonoBehaviour
{
    GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen = Resources.Load<GameObject>("GameOvrScreen");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(gameOverScreen);
        }
    }
}
