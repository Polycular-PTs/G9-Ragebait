using UnityEngine;

public class SliderColor : MonoBehaviour
{
    public GameObject sliderObject;
    public Gradient colorGradient;
    public float minX;
    public float maxX;

    private SpriteRenderer rendererTarget;

    void Start()
    {
        rendererTarget = sliderObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float normalizedValue = Mathf.InverseLerp(minX, maxX, sliderObject.transform.position.x);
        rendererTarget.color = colorGradient.Evaluate(normalizedValue);
    }
}

