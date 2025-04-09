using UnityEngine;
using UnityEngine.UI;

public class Dead : MonoBehaviour
{
    public Canvas canvas; // Reference to the Canvas
    public Font textFont;
    public static string nowtext = "";

    public static Text textComponent;

    void Start()
    {
        // Create a new GameObject for the text
        GameObject textGO = new GameObject("CenteredText");
        textGO.transform.SetParent(canvas.transform, false);

        // Add Text component and configure it
        textComponent = textGO.AddComponent<Text>();
        textComponent.text = nowtext;
        textComponent.font = textFont;
        textComponent.color = new Color(1f, 0f, 0f, 0.5f); // Red color with semi-transparency
        textComponent.alignment = TextAnchor.MiddleCenter;
        textComponent.horizontalOverflow = HorizontalWrapMode.Wrap; // Wrap text if it's too long
        textComponent.verticalOverflow = VerticalWrapMode.Overflow; // Don't care about vertical overflow
        textComponent.fontSize = 64;

        // Add Outline component and configure it
        Outline outlineComponent = textGO.AddComponent<Outline>();
        outlineComponent.effectColor = new Color(0f, 0f, 0f, 0.5f); // Make sure this color is different from the text color
        outlineComponent.effectDistance = new Vector2(4f, 4f); // Increase the outline width if needed

        // Configure the RectTransform
        RectTransform rectTransform = textComponent.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        // Set the width to a quarter of the screen width and let the height be determined by the content
        rectTransform.sizeDelta = new Vector2(Screen.width*0.75f, 0f);

        // Add ContentSizeFitter and configure it
        ContentSizeFitter contentSizeFitter = textGO.AddComponent<ContentSizeFitter>();
        contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained; // Do not constraint the width
        contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize; // Fit the height to the preferred size

        // Set the anchored position to center the text
        rectTransform.anchoredPosition = new Vector2(0f, 0f);
    }

    public static void UpdateText(string text){
        nowtext = text;
        textComponent.text = nowtext;
    }
}
