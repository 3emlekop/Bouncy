using UnityEngine;

public class BallPickup : Pickup
{
    [SerializeField] private GameObject spawnObjectPrefab;
    [SerializeField] private byte objectCount = 1;

    private float angle = new float();
    private Quaternion rotation = Quaternion.identity;

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
            if (objectCount == 1)
                Instantiate(spawnObjectPrefab, currentPos, Quaternion.identity, GameManager.BallsParent);
            else
                for (int i = 0; i < objectCount; i++)
                {
                    angle = -(10 * objectCount) + i * 10 * objectCount;
                    rotation = Quaternion.Euler(0, 0, angle);
                    Instantiate(spawnObjectPrefab, currentPos, rotation, GameManager.BallsParent);
                }

            pickupGameObject.SetActive(false);
            GameManager.RemovePickupCount();
        }
    }
}
