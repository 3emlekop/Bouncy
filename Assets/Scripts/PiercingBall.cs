
using UnityEngine;

public class PiercingBall : Ball
{
    private Vector2 normal;
    private Vector2 currentVelocity = Vector2.zero;

    new private void Start()
    {
        base.Start();
    }

    new private void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            newVelocity.y = Mathf.Abs(velocity);
            newVelocity.x = (ballTransform.position.x - collision.transform.position.x) * 3;
            rb.velocity = newVelocity;
            return;
        }
        AddRandomMovement();
    }
}
