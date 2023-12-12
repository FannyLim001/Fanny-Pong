using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpPaddleController : MonoBehaviour
{
    public Collider2D ball;
    public Collider2D[] paddle;
    public float multiple = 2.0f;
    public PowerUpManager manager;
    private bool ballCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            paddle[0].GetComponent<PaddleController>().SpeedUp(multiple);
            paddle[1].GetComponent<PaddleController>().SpeedUp(multiple);
            ballCollided = true;
            RemovePowerUp();
        }
    }

    private void Update()
    {
        if (!ballCollided)
        {
            Invoke("RemovePowerUp", manager.spawnInterval);
        }
    }

    private void RemovePowerUp()
    {
        manager.RemovePowerUp(gameObject);
    }
}
