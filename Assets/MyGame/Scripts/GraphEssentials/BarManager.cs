using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Image[] bars;


    public int[] data;

    void Start()
    {
        UpdateChart(data);
    }

    public void UpdateChart(int[] values)
    {
        float maxBarHeight = 200f;
        for (int i = 0; i < bars.Length && i < values.Length; i++)
        {
            bars[i].rectTransform.pivot = new Vector2(0.5f, 0f);

            bars[i].rectTransform.sizeDelta = new Vector2(
                bars[i].rectTransform.sizeDelta.x,
                (values[i] / 10f) * maxBarHeight
            );


            bars[i].rectTransform.anchorMin = new Vector2(bars[i].rectTransform.anchorMin.x, 0f);
            bars[i].rectTransform.anchorMax = new Vector2(bars[i].rectTransform.anchorMax.x, 0f);
        }
    }
}