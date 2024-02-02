public class LevelData
{
    public float BlockSize { get; private set; }
    public int[,] Layout { get; private set; }

    public LevelData(int[,] layout, float levelWidth)
    {
        BlockSize = levelWidth / (layout.GetLength(1)-1);
        Layout = layout;
    }
}