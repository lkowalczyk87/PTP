using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class BlueBullet : PlayerBullet
{
    [SerializeField]
    float startSpeedFactor = 0.5f;
    [SerializeField]
    float fullSpeedDelay = 0.4f;

    private float lastDirection = 0;

    private bool isAccelereting = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        speed = 12;
        hp = 5;
        base.Start();
    }

    // POLYMORPHISM
    protected override void Move(float direction)
    {
        ResetFullSpeed(direction);

        if (!isAccelereting)
        {
            Accelerate(direction);
        }

        lastDirection = direction;
    }

    private void Accelerate(float direction)
    {
        isAccelereting = true;
        rb.velocity = new Vector3(speed * direction * startSpeedFactor, 0, 0);
        StartCoroutine(TurnOnFullSpeed());
    }

    private void ResetFullSpeed(float direction)
    {
        if ((direction > 0 && lastDirection < 0) || (direction < 0 && lastDirection > 0) || direction == 0)
        {
            startSpeedFactor = 0.5f;
        }
    }

    IEnumerator TurnOnFullSpeed()
    {
        yield return new WaitForSeconds(fullSpeedDelay);
        isAccelereting = false;
        startSpeedFactor = 1;
    }
}
