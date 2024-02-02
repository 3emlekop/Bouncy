using UnityEngine;

public class LayoutCreator : MonoBehaviour
{
    public static int[,] GetLayout(int layoutId)
    {
        int[,] layout = new int[35, 35];
        switch (layoutId)
        {
            case 0:
                FillArea(layout, new Vector2(3, 3), new Vector2(31, 31), 2);
                break;
            case 1:
                for (byte i = 5; i < 35; i += 4)
                    InsertHorizontalLine(layout, new Vector2(i, 0), 35, 2);

                for (byte i = 0; i < 35; i += 4)
                    InsertVerticalLine(layout, new Vector2(5, i), 35, 1);

                break;
            case 2:
                FillArea(layout, new Vector2(5, 5), new Vector2(layout.GetLength(1) - 5, layout.GetLength(0) - 5), 2);
                InsertVerticalLine(layout, new Vector2(5, 29), 31, 1);
                InsertVerticalLine(layout, new Vector2(5, 5), 31, 1);
                InsertHorizontalLine(layout, new Vector2(30, 5), 30, 1);
                break;
            case 3:
                FillArea(layout, new Vector2(5, 5), new Vector2(layout.GetLength(1) - 5, layout.GetLength(0) - 5), 2);
                InsertVerticalLine(layout, new Vector2(5, 29), 21, 1);
                InsertVerticalLine(layout, new Vector2(5, 5), 21, 1);
                InsertHorizontalLine(layout, new Vector2(20, 5), 13, 1);
                InsertHorizontalLine(layout, new Vector2(20, 18), 13, 1);
                InsertHorizontalLine(layout, new Vector2(5, 5), 30, 1);
                break;
        }
        return layout;
    }

    private static void FillArea(int[,] layout, Vector2 startPos, Vector2 endPos, int blockTypeId)
    {
        startPos.x = Mathf.Clamp(startPos.x, 0, layout.GetLength(0));
        startPos.y = Mathf.Clamp(startPos.y, 0, layout.GetLength(1));

        endPos.x = Mathf.Clamp(endPos.x, 0, layout.GetLength(0));
        endPos.y = Mathf.Clamp(endPos.y, 0, layout.GetLength(1));

        for (int i = (int)startPos.x; i < (int)endPos.x; i++)
            for (int j = (int)startPos.y; j < (int)endPos.y; j++)
                layout[i, j] = blockTypeId;
    }

    private static void InsertVerticalLine(int[,] layout, Vector2 startPos, int height, int blockTypeId)
    {
        startPos.x = Mathf.Clamp(startPos.x, 0, layout.GetLength(0));
        startPos.y = Mathf.Clamp(startPos.y, 0, layout.GetLength(1));

        for (int i = (int)startPos.x; i < height; i++)
            layout[i, (int)startPos.y] = blockTypeId;
    }

    private static void InsertHorizontalLine(int[,] layout, Vector2 startPos, int width, int blockTypeId)
    {
        startPos.x = Mathf.Clamp(startPos.x, 0, layout.GetLength(0));
        startPos.y = Mathf.Clamp(startPos.y, 0, layout.GetLength(1));

        for (int i = (int)startPos.y; i < width; i++)
            layout[(int)startPos.x, i] = blockTypeId;
    }
}
