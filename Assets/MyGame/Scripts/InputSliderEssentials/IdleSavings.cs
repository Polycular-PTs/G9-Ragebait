using UnityEngine;

public class IdleSavings : MonoBehaviour
{
    [Header("Save Settings")]
    public string saveKey = "SliderValue";

    public void SaveInt(int value)
    {
        PlayerPrefs.SetInt(saveKey, value);
        PlayerPrefs.Save();
    }

    public int LoadInt(int defaultValue)
    {
        return PlayerPrefs.GetInt(saveKey, defaultValue);
    }
}

