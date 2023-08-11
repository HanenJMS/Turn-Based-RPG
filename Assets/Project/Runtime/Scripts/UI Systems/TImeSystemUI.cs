using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TImeSystemUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Button pauseButton;
    private void Start()
    {
        TimeSystem.Instance.OnTimerChanged += TimeSystem_OnTimeChanged;
        UpdateVisual();
        pauseButton.onClick.AddListener(() =>
        {
            TimeSystem.Instance.PauseTimer();
        });
    }
    public void TimeSystem_OnTimeChanged()
    {
        UpdateVisual();
    }
    void UpdateVisual()
    {

        UpdateTimer();
    }
    void UpdateTimer()
    {
        textMeshProUGUI.text = TimeSystem.Instance.GetUpdateTimer();
    }
}
