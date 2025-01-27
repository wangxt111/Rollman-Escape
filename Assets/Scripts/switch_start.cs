using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneSwitcher_start : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SwitchScene);
    }
    public void SwitchScene()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("TableBar");
        SceneManager.LoadScene("Main_Scene", LoadSceneMode.Additive);
        // SceneManager.LoadScene("Wall1", LoadSceneMode.Additive);
        // SceneManager.LoadScene("Wall2", LoadSceneMode.Additive);
        // SceneManager.LoadScene("Wall3", LoadSceneMode.Additive);
        // SceneManager.LoadScene("Wall4", LoadSceneMode.Additive);
    }
}
