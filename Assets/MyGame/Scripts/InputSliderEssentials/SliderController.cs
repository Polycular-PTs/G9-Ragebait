using UnityEngine;
using System.Collections;

public class SliderController : MonoBehaviour
{
    [Header("References")]
    public Transform sliderHandle;

    [Header("Slider Settings")]
    public int maxStepsPerDirection = 5;
    public Vector3 barLength;
    public Transform barScale;
    public float lineLength = 17.76123f;
    public Vector3 centerPosition = Vector3.zero;

    [Header("Input Settings")]
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveLeftKey = KeyCode.A;

    [Header("Saving Settings")]
    public IdleSavings saver;
    public int zeroStepValue = 0;
    public float saveCooldown = 1f; 

    [Header("Idle Settings")]
    public IdleTimer idleTimer;

    private float stepDistance;
    private int currentStep = 0;
    private bool isSaving = false;

    void Start()
    {
        barLength = barScale.localScale;
        lineLength = barLength.x;
        stepDistance = (lineLength / 2f) / maxStepsPerDirection;
        currentStep = 0;
        UpdateSliderPosition();

        if (idleTimer != null)
            idleTimer.OnIdle += SaveIfIdle;
    }

    void Update()
    {
        if (Input.GetKeyDown(moveRightKey))
            Move(1);

        if (Input.GetKeyDown(moveLeftKey))
            Move(-1);

        idleTimer?.StepChanged(currentStep);
    }

    private void Move(int step)
    {
        currentStep = Mathf.Clamp(currentStep + step, -maxStepsPerDirection, maxStepsPerDirection);
        UpdateSliderPosition();
    }

    private void UpdateSliderPosition()
    {
        sliderHandle.position = centerPosition + Vector3.right * (currentStep * stepDistance);
    }

    public void SaveIfIdle()
    {
        if (!isSaving && saver != null && currentStep != zeroStepValue)
            StartCoroutine(SavePositionAsync());
    }

    private IEnumerator SavePositionAsync()
    {
        isSaving = true;
        saver.SaveInt(currentStep);
        yield return new WaitForSeconds(saveCooldown);
        isSaving = false;
    }

    public int CurrentStep => currentStep;
}
