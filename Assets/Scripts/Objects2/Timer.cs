using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // 计时器文本
    void Start()
    {
    }

    void Update()
    {
        if (info.timerIsRunning)
        {
            if (info.timeRemaining > 0)
            {
                info.timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(info.timeRemaining);
            }
            else
            {
                info.timeRemaining = 0;
                info.timerIsRunning = false;
                // 倒计时结束后触发的事件（可根据需求自行修改）
                Debug.Log("倒计时结束！");
            }
        }
    }

    void UpdateTimerDisplay(float time)
    {
        // 将时间格式化为 "MM:SS"
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}