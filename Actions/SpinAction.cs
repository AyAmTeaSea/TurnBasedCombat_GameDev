using System;
using UnityEngine;

public class SpinAction : BaseAction
{
    float spinAmount = 360;
    float spinCompletion = 0;
    
    private void Update()
    {
        if (isActive)
        {
            transform.eulerAngles += Vector3.up * (Time.deltaTime * spinAmount);
            spinCompletion += (Time.deltaTime * spinAmount);
        }

        if (spinCompletion >= spinAmount)
        {
            isActive = false;
            spinCompletion = 0;
            onActionComplete?.Invoke();
        }
    }

    public void Spin(Action onSpinComplete)
    {
        this.onActionComplete = onSpinComplete;
        isActive = true;
    }
}
