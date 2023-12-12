using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUResizePaddleController : MonoBehaviour
{
    public Collider2D ball;
    public Collider2D[] paddle;
    public float multiple;
    public PowerUpManager manager;
    private bool ballCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            paddle[0].GetComponent<PaddleController>().Resize(multiple);
            paddle[1].GetComponent<PaddleController>().Resize(multiple);
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
