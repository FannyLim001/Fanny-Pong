using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed;
    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;
    private Transform tf;

    public float powerUpDuration = 5.0f;
    private Vector2 originalScale;
    private float originalSpeed;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();

        originalSpeed = speed;
    }

    private void Update()
    {
        // get input 
        Vector3 movement = GetInput();

        // move object 
        MoveObject(movement);
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("TEST: " + movement);
        rig.velocity = movement;
    }

    public void Resize(float multiple)
    {
        originalScale = tf.localScale;
        tf.localScale = new Vector2(originalScale.x * multiple, originalScale.y);

        StartCoroutine(ResetSize());
    }

    private IEnumerator ResetSize()
    {
        yield return new WaitForSeconds(powerUpDuration);

        tf.localScale = originalScale;
    }

    public void SpeedUp(float multiple)
    {
        speed *= multiple;

        StartCoroutine(ResetSpeed());
    }

    private IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(powerUpDuration);

        speed = originalSpeed;
    }
}
