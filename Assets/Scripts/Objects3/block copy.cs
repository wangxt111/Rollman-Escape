using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    public static Vector3[] positions = new Vector3[9]
    {
        new Vector3(-2.45f, 2.35f, 0),
        new Vector3(0f, 2.35f, 0),
        new Vector3(2.45f, 2.35f, 0),
        new Vector3(-2.45f, -0.13f, 0),
        new Vector3(0f, -0.13f, 0),
        new Vector3(2.45f, -0.13f, 0),
        new Vector3(-2.45f, -2.6f, 0),
        new Vector3(0f, -2.6f, 0),
        new Vector3(2.45f, -2.6f, 0)
    };

    public static int[] grid = new int[9];
    public static int emptyIndex = 8;
    public static GameObject[] allBlocks = new GameObject[8];
    public static bool initialized = false;

    public int blockId;

    void Start()
    {
        if (!initialized)
        {
            InitBlocks();
            //ShuffleGrid();
            UpdateAllBlockPositions();
            initialized = true;
        }
    }

    void OnMouseDown()
    {
        int currentIndex = GetBlockIndex(blockId);
        if (IsAdjacent(currentIndex, emptyIndex))
        {
            grid[emptyIndex] = blockId;
            grid[currentIndex] = -1;
            emptyIndex = currentIndex;

            UpdateAllBlockPositions();
            CheckWin();
        }
    }

    int GetBlockIndex(int id)
    {
        for (int i = 0; i < 9; i++)
        {
            if (grid[i] == id) return i;
        }
        return -1;
    }

    bool IsAdjacent(int a, int b)
    {
        int rowA = a / 3, colA = a % 3;
        int rowB = b / 3, colB = b % 3;
        return (Mathf.Abs(rowA - rowB) + Mathf.Abs(colA - colB)) == 1;
    }

    void InitBlocks()
    {
        // 注册所有块到 allBlocks 数组
        BlockMover[] movers = FindObjectsOfType<BlockMover>();
        foreach (var m in movers)
        {
            allBlocks[m.blockId] = m.gameObject;
        }

        // 初始化 grid：0~7为块编号，8号位置为空
        for (int i = 0; i < 8; i++) grid[i] = i;
        grid[8] = -1;
        emptyIndex = 8;
    }

    void ShuffleGrid()
    {
        System.Random rand = new System.Random();
        for (int i = 0; i < 100; i++)
        {
            List<int> neighbors = GetNeighbors(emptyIndex);
            int chosen = neighbors[rand.Next(neighbors.Count)];
            grid[emptyIndex] = grid[chosen];
            grid[chosen] = -1;
            emptyIndex = chosen;
        }
    }

    List<int> GetNeighbors(int index)
    {
        List<int> neighbors = new List<int>();
        int row = index / 3;
        int col = index % 3;
        if (row > 0) neighbors.Add(index - 3); // 上
        if (row < 2) neighbors.Add(index + 3); // 下
        if (col > 0) neighbors.Add(index - 1); // 左
        if (col < 2) neighbors.Add(index + 1); // 右
        return neighbors;
    }

    void UpdateAllBlockPositions()
    {
        for (int i = 0; i < 9; i++)
        {
            if (grid[i] != -1)
            {
                int id = grid[i];
                allBlocks[id].transform.position = positions[i];
            }
        }
    }

    void CheckWin()
    {
        for (int i = 0; i < 8; i++)
        {
            if (grid[i] != i) return;
        }
    }
}
