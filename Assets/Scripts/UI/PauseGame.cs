using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Image pausePanel;

    private bool isGameOnPause = false;

    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    public void SetOnOffGamePause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        pausePanel.gameObject.SetActive(!isGameOnPause);
        isGameOnPause = !isGameOnPause;
    }
}
