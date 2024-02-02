using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform ballsParent;
    [SerializeField] private TextMeshProUGUI blocksCountText;
    [SerializeField] private TextMeshProUGUI ballsCountText;
    [SerializeField] private GameMenu gameMenu;

    public static Transform BallsParent { get; private set; }
    private static GameManager instance;
    private int ballCount = new int();
    private int blockCount = new int();
    private int pickupCount = new int();

    private void Awake()
    {
        BallsParent = ballsParent;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this);
    }

    public static void AddBallsCount()
    {
        instance.ballCount++;
        instance.ballsCountText.text = $"balls: {instance.ballCount}";
    }

    public static void RemoveBallsCount()
    {
        instance.ballCount--;
        instance.ballsCountText.text = $"balls: {instance.ballCount}";
        if (instance.ballCount <= 0 && instance.pickupCount <= 0)
            instance.EndGame();
    }

    public static void AddBlockCount()
    {
        instance.blockCount++;
        instance.blocksCountText.text = $"blocks: {instance.blockCount}";
    }

    public static void RemoveBlockCount()
    {
        instance.blockCount--;
        instance.blocksCountText.text = $"blocks: {instance.blockCount}";
        if (instance.blockCount <= 0)
            instance.WinGame();
    }

    public static void AddPickupCount()
    {
        instance.pickupCount++;
    }

    public static void RemovePickupCount()
    {
        instance.pickupCount--;
        if (instance.ballCount <= 0 && instance.pickupCount <= 0)
            instance.EndGame();
    }

    private void EndGame()
    {
        if (this != null)
            StartCoroutine(CheckForGameResult());
    }

    private void WinGame()
    {
        if (this != null)
            StartCoroutine(CheckForGameResult());
    }

    private IEnumerator CheckForGameResult()
    {
        if (gameMenu == null)
            yield break;

        yield return new WaitForSeconds(1);
        if (ballCount <= 0 && pickupCount <= 0)
        {
            gameMenu.Lose();
            gameMenu.gameObject.SetActive(true);
        }
        if (blockCount <= 0)
        {
            gameMenu.Win();
            gameMenu.gameObject.SetActive(true);
        }
    }
}
