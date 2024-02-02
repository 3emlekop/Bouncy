using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Pickup[] pickupPrefabs;
    [Range(0, 100)]
    [SerializeField] private byte spawnChance;

    private Transform blockTransform;
    private GameObject dropGameObject;

    private void Awake()
    {
        GameManager.AddBlockCount();
        blockTransform = transform;
        if (Random.Range(0, 100) < spawnChance)
        {
            dropGameObject = Instantiate(pickupPrefabs[Random.Range(0, pickupPrefabs.Length)], blockTransform.position, Quaternion.identity).gameObject;
            dropGameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        GameManager.RemoveBlockCount();
        if(dropGameObject != null)
            dropGameObject.SetActive(true);
    }
}
