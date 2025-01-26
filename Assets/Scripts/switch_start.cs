using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneSwitcher_start : MonoBehaviour
{
    Button button;
    public string SceneName;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SwitchScene);
    }
    public void SwitchScene()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("TableBar");
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }
}
