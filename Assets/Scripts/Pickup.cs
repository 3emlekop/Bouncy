using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] protected float speed = 1f;

    protected Transform pickupTransform;
    protected GameObject pickupGameObject;
    protected Vector3 currentPos;
    protected float movementAreaY;

    protected void Start()
    {
        pickupTransform = transform;
        pickupGameObject = gameObject;
        currentPos = pickupTransform.position;
        movementAreaY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - pickupTransform.localScale.y / 2;
        GameManager.AddPickupCount();
    }

    protected void Update()
    {
        if (currentPos.y < -movementAreaY)
        {
            pickupGameObject.SetActive(false);
            GameManager.RemovePickupCount();
            return;
        }

        currentPos.y -= speed * Time.deltaTime;
        pickupTransform.position = currentPos;
    }
}
