using System;
using System.Collections.Generic;
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

    public override void TakeAction(GridPosition gridPosition, Action onSpinComplete)
    {
        this.onActionComplete = onSpinComplete;
        isActive = true;
    }

    public override string GetActionName()
    {
        return "Spin";
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridPosiiton = unit.GetGridPosition();

        return new List<GridPosition>
        {
            unitGridPosiiton
        };
    }

    public override int GetActionPointsCost()
    {
        return 2;
    }
}
