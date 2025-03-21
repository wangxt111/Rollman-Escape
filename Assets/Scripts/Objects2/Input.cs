using UnityEngine;
using TMPro;

public class CheckInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public string[] correctAnswer = new string[3] { "19", "2", "9" };
    public int type;

    void Start()
    {
        inputField.gameObject.SetActive(info.level2);
        inputField.onEndEdit.AddListener(SubmitInput);
    }

    void Update()
    {
        inputField.gameObject.SetActive(info.level2&&(!info.puzzles[type]));
    }

    void SubmitInput(string userInput)
    {
        if (userInput == correctAnswer[type])
        {
            info.puzzles[type] = true;
            inputField.gameObject.SetActive(false);
        }
        else
        {
            inputField.text = "";
        }
    }

    void OnDestroy()
    {
        inputField.onEndEdit.RemoveListener(SubmitInput);
    }
}
