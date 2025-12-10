using UnityEngine;
using System;

public class IdleTimer : MonoBehaviour
{
    [Header("Idle Settings")]
    public float requiredIdle = 15f; 

    private float idleTimer = 0f;
    private int lastStep = 0;
    private bool isIdle = false;

    [Header("Events")]
    public Action OnIdle;

    public void StepChanged(int currentStep)
    {
        if (currentStep == lastStep)
        {
            idleTimer += Time.deltaTime;

            if (!isIdle && idleTimer >= requiredIdle)
            {
                isIdle = true;
                OnIdle?.Invoke(); 
            }
        }
        else
        {
            ResetIdleState();
            lastStep = currentStep;
        }
    }

    private void ResetIdleState()
    {
        idleTimer = 0f;
        isIdle = false;
    }
}
