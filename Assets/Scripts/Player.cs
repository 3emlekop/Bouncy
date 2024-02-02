using UnityEngine;

public class Player : MonoBehaviour
{
    private const float yOffset = -4.5f;
    private float movementAreaX;
    private Camera mainCamera;
    private Transform playerTransform;
    private Vector2 currentPlayerPos = Vector2.zero;
    private Vector2 currentMousePos = Vector2.zero;

    private void Start()
    {
        mainCamera = Camera.main;
        playerTransform = transform;
        currentPlayerPos.y = yOffset;
        movementAreaX = Screen.width/100 - 1 - (playerTransform.localScale.x / 2);
    }

    private void Update()
    {
        currentMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if(Mathf.Abs(currentMousePos.x) < movementAreaX)
        {
            currentPlayerPos.x = currentMousePos.x;
            playerTransform.position = currentPlayerPos;
        }
    }
}