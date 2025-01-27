using UnityEngine;

public class CubeColorChanger : MonoBehaviour
{
    // 使用默认的材质创建材质实例并指定颜色
    private Material frontMaterial;
    private Material backMaterial;
    private Material leftMaterial;
    private Material rightMaterial;
    private Material topMaterial;
    private Material bottomMaterial;

    void Start()
    {
        // 为每个面创建材质并设置颜色
        frontMaterial = new Material(Shader.Find("Standard")) { color = Color.red }; // 红色
        backMaterial = new Material(Shader.Find("Standard")) { color = Color.green }; // 绿色
        leftMaterial = new Material(Shader.Find("Standard")) { color = Color.blue }; // 蓝色
        rightMaterial = new Material(Shader.Find("Standard")) { color = Color.yellow }; // 黄色
        topMaterial = new Material(Shader.Find("Standard")) { color = Color.cyan }; // 青色
        bottomMaterial = new Material(Shader.Find("Standard")) { color = Color.magenta }; // 品红色

        // 获取正方体的 MeshRenderer
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        // 将不同颜色的材质分配到正方体的各个面
        Material[] materials = new Material[6]; // 正方体有六个面
        materials[0] = frontMaterial; // 前面
        materials[1] = backMaterial;  // 后面
        materials[2] = leftMaterial;  // 左面
        materials[3] = rightMaterial; // 右面
        materials[4] = topMaterial;   // 上面
        materials[5] = bottomMaterial;// 下面

        // 将材质数组应用到正方体的 MeshRenderer
        meshRenderer.materials = materials;
    }
}
