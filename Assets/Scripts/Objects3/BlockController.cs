using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class BlockController : MonoBehaviour
{

    public int[] grid = new int[9];
    public GameObject[] TrueGrids = new GameObject[9];
    public int emptyIndex = 8;
    public GameObject[] Blocks = new GameObject[9];
    public GameObject border;

    public float speed = 8.0f; // 移动速度

    private int checkedgrid = -1;
    private int targetemptyindex = 8;
    void Start()
    {
        int[] indices = new int[8] {0, 1, 2, 3, 4, 5, 6, 7};
        GameObject[] objects = new GameObject[8] {Blocks[0], Blocks[1], Blocks[2], Blocks[3], Blocks[4], Blocks[5], Blocks[6], Blocks[7]};
        indices = ShuffleArray(indices);
        while(CalculateInversions(indices) % 2 != 0){
            indices = ShuffleArray(indices);
        }
        for(int i=0;i<8;i++){
            grid[i] = indices[i];
            Blocks[i] = objects[grid[i]];
        }
        grid[8] = -1;
        Blocks[8] = null;
        for(int i=0;i<8;i++){
            if(i != emptyIndex){
                Blocks[i].transform.position = TrueGrids[i].transform.position;
            }
        }
        return;
    }

    void Update()
    {
        //设置选择框
        SpriteRenderer spriteRenderer = border.GetComponent<SpriteRenderer>();
        if(checkedgrid<0 || info.MovingBlock){
            spriteRenderer.enabled = false;
        }else{
            spriteRenderer.enabled = true;
            Vector3 position = TrueGrids[checkedgrid].transform.position;
            border.transform.position = position;
        }

        if(Checkwin()){
            Debug.Log("win!!!!!!!!!!!!!!");
        }
    }

    public void Choose(int index){ //选中第index格
        if(checkedgrid<0 && emptyIndex!=index){
            checkedgrid = index;
        }else if(emptyIndex==index){
            if(IsAdjacent(checkedgrid, index)){
                Move(checkedgrid, index);
                grid[index] = grid[checkedgrid];
                emptyIndex = checkedgrid;
                Blocks[index] = Blocks[checkedgrid];
                checkedgrid = -1;
            }else{
                checkedgrid = -1;
            }
        }else if(checkedgrid==index){
            Blocks[index].GetComponent<Block>().SwitchSprite();
        }else if(emptyIndex!=index){
            checkedgrid = index;
        }
    }


    bool IsAdjacent(int a, int b)
    {
        int rowA = a / 3, colA = a % 3;
        int rowB = b / 3, colB = b % 3;
        return (Mathf.Abs(rowA - rowB) + Mathf.Abs(colA - colB)) == 1;
    }

    public void Move(int index, int targetindex){
        StartCoroutine(MoveTo(index, targetindex));
    }
    private IEnumerator MoveTo(int index, int targetindex){
        info.MovingBlock = true; 

        GameObject block = Blocks[index];
        Vector3 targetPosition = TrueGrids[targetindex].transform.position;

        while (Vector3.Distance(block.transform.position, targetPosition) > 0.001f)
        {
            block.transform.position = Vector3.MoveTowards(block.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        block.transform.position = targetPosition;

        info.MovingBlock = false;
    }

    bool Checkwin(){
        if(emptyIndex != targetemptyindex) return false;
        for(int i = 0; i < 9; ++i){
            if(i==targetemptyindex) continue;
            if(grid[i] != i) return false;
        }
        return true;
    }

    // 随机打乱数组
    int[] ShuffleArray(int[] arr)
    {
        System.Random random = new System.Random();
        int[] shuffled = new int[arr.Length];
        Array.Copy(arr, shuffled, arr.Length);

        for (int i = shuffled.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            int temp = shuffled[i];
            shuffled[i] = shuffled[j];
            shuffled[j] = temp;
        }

        return shuffled;
    }

    // 计算逆序数
    int CalculateInversions(int[] arr)
    {
        int inversions = 0;
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (arr[i] > arr[j])
                {
                    inversions++;
                }
            }
        }

        return inversions;
    }
}
