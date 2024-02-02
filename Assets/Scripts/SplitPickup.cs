using UnityEngine;

public class SplitPickup : Pickup
{
    [SerializeField] private byte splitCount = 3;

    private float angle = new float();
    private Quaternion rotation = Quaternion.identity;
    private GameObject spawnBall;
    private Vector2 spawnBallPos;

    new private void Start()
    {
        base.Start();
    }

    new private void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            for (int i = 1; i < splitCount; i++)
            {
                foreach (Transform ball in GameManager.BallsParent)
                {
                    if (ball.gameObject.activeSelf)
                    {
                        spawnBall = ball.gameObject;
                        spawnBallPos = ball.position;
                        break;
                    }
                }

                if (spawnBall == null)
                    return;

                angle = -(20 * splitCount) + i * 20 * splitCount;
                rotation = Quaternion.Euler(0, 0, angle);
                Instantiate(spawnBall, spawnBallPos, rotation, GameManager.BallsParent);
            }

            pickupGameObject.SetActive(false);
            GameManager.RemovePickupCount();
        }
    }
}
