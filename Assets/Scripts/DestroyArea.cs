using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy"))
            collider.gameObject.SetActive(false);
    }
}
