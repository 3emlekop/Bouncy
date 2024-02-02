using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject blockPrefab;

    public static int LevelId { get; set; }

    private Transform levelTransform;
    private Vector2 startCoordinates;
    private Vector2 currentCoordinates;
    private Vector2 blockScale;

    void Start()
    {
        LevelId = MainMenu.currentLevelId;
        levelTransform = transform;
        startCoordinates.x = -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        startCoordinates.y = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;

        LevelData levelData = new LevelData(LayoutCreator.GetLayout(LevelId), Mathf.Abs(startCoordinates.x * 2));

        startCoordinates.x += levelData.BlockSize / 2;
        startCoordinates.y -= levelData.BlockSize / 2;
        currentCoordinates = startCoordinates;

        BuildLevel(levelData);
    }

    private void BuildLevel(LevelData levelData)
    {
        blockScale.x = levelData.BlockSize * 0.9f;
        blockScale.y = levelData.BlockSize * 0.9f;

        wallPrefab.transform.localScale = blockScale;
        blockPrefab.transform.localScale = blockScale;

        for (int i = 0; i < levelData.Layout.GetLength(0)-1; i++)
        {
            currentCoordinates.x = startCoordinates.x;
            for (int j = 0; j < levelData.Layout.GetLength(1)-1; j++)
            {
                switch (levelData.Layout[i, j])
                {
                    case 0:
                        break;
                    case 1:
                        Instantiate(wallPrefab, currentCoordinates, Quaternion.identity, levelTransform);
                        break;
                    case 2:
                        Instantiate(blockPrefab, currentCoordinates, Quaternion.identity, levelTransform);
                        break;
                    default:
                        break;
                }
                currentCoordinates.x += levelData.BlockSize;
            }
            currentCoordinates.y -= levelData.BlockSize;
        }
    }
}
