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
                if (info.timeRemaining < 0)
                {
                    info.timeRemaining = 0;
                }
                UpdateTimerDisplay(info.timeRemaining);
            }
            else
            {
                info.timeRemaining = 0;
                info.timerIsRunning = false;

                if (info.level == 2)
                {
                    Application.Quit();  // 退出游戏
                    #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;  // 在编辑器中停止运行
                    #endif
                }
                else
                {
                    this.enabled = false;  // 停止倒计时组件
                }
            }
        }
    }

    void UpdateTimerDisplay(float time)
    {
        if (time < 0) time = 0;
        // 将时间格式化为 "MM:SS"
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}