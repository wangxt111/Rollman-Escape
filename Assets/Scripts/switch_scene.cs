using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
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
        SceneManager.LoadScene(SceneName);
    }
}
