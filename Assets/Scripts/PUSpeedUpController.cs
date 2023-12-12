using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    public float magnitude;
    public PowerUpManager manager;
    private bool ballCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            // Speed Up the ball
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            ballCollided = true;
            RemovePowerUp();
        }
    }

    private void Update()
    {
        if(!ballCollided)
        {
            Invoke("RemovePowerUp", manager.spawnInterval+2);
        }
    }

    private void RemovePowerUp()
    {
        manager.RemovePowerUp(gameObject);
    }
}
