using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject popUp;

    [SerializeField] private Button closeSettingButton;

    [SerializeField] private Button settingButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingButton.onClick.AddListener(OpenSetting);
        closeSettingButton.onClick.AddListener(CloseSetting);
    }

    // Update is called once per frame
    private void CloseSetting()
    {
        Time.timeScale = 1;
        popUp.SetActive(false);
    }

    private void OpenSetting()
    {
        Time.timeScale = 0;
        
        popUp.SetActive(true);
    }
}
