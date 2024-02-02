using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] protected float velocity = 3f;

    protected Transform ballTransform;
    protected GameObject ballGameObject;
    protected float movementAreaX;
    protected float movementAreaY;
    protected Vector2 currentPos;
    protected Vector2 newVelocity;
    protected Rigidbody2D rb;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0;
        rb.angularDrag = 0;

        ballTransform = transform;
        ballGameObject = gameObject;
        rb.velocity = new Vector2(ballTransform.up.x * velocity, ballTransform.up.y * velocity);
        GameManager.AddBallsCount();

        currentPos = ballTransform.position;
        movementAreaX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - ballTransform.localScale.x / 2;
        movementAreaY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - ballTransform.localScale.y / 2;
    }

    protected void FixedUpdate()
    {
        if (ballTransform.position.x >= movementAreaX)
        {
            newVelocity.x = -Mathf.Abs(rb.velocity.x);
            newVelocity.y = rb.velocity.y;
            rb.velocity = newVelocity;
            return;
        }

        if (ballTransform.position.x <= -movementAreaX)
        {
            newVelocity.x = Mathf.Abs(rb.velocity.x);
            newVelocity.y = rb.velocity.y;
            rb.velocity = newVelocity;
            return;
        }

        if (ballTransform.position.y >= movementAreaY)
        {
            newVelocity.x = rb.velocity.x;
            newVelocity.y = -Mathf.Abs(rb.velocity.y);
            rb.velocity = newVelocity;
            return;
        }

        if (ballTransform.position.y <= -movementAreaY)
        {
            ballGameObject.SetActive(false);
            GameManager.RemoveBallsCount();
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            return;
        }

        if (collision.collider.CompareTag("Player"))
        {
            newVelocity.y = Mathf.Abs(velocity);
            newVelocity.x = (ballTransform.position.x - collision.transform.position.x) * 3;
            rb.velocity = newVelocity;
            return;
        }
        AddRandomMovement();
    }

    protected void AddRandomMovement()
    {
        newVelocity.x = rb.velocity.x < 0 ? rb.velocity.x + 0.1f : rb.velocity.x - 0.1f;
        newVelocity.y = rb.velocity.y > 0 ? rb.velocity.y + 0.1f : rb.velocity.y - 0.1f;
        newVelocity.x = Mathf.Clamp(newVelocity.x, -velocity, velocity);
        newVelocity.y = Mathf.Clamp(newVelocity.y, -velocity, velocity);
        rb.velocity = newVelocity;
    }
}