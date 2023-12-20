using UnityEngine;
using UnityEngine.UI;
public class ToggleSaver : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    public Progress progressScript;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        progressScript = FindObjectOfType<Progress>();
        
        if (PlayerPrefs.HasKey("SongValue"))
        {
            bool isToggleOn = PlayerPrefs.GetInt("SongValue") == 1;
            toggle.isOn = isToggleOn;
        }
    }

    private void OnEnable()
    {
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnDisable()
    {
        toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
    }

    private void OnDestroy()
    {
        int toggleValue = toggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("SongValue", PlayerPrefs.GetInt("SongValue"));
    }

    private void OnToggleValueChanged(bool isOn)
    {
        progressScript.SwitchFlag();
        int toggleValue = isOn ? 1 : 0;
        PlayerPrefs.SetInt("SongValue", toggleValue);
    }
}