using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] int maxActionPoints = 2;

    public static event EventHandler OnAnyActionPointsChanged;
    
    [SerializeField] bool isEnemy = false;
    
    private GridPosition gridPosition;
    private MoveAction moveAction;
    private SpinAction spinAction;
    private BaseAction[] baseActions;
    private int actionPoints;
    
    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
        spinAction = GetComponent<SpinAction>();
        baseActions = GetComponents<BaseAction>();
        
        actionPoints = maxActionPoints;
    }

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);

        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;
    }


    private void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if (newGridPosition != gridPosition)
        {
            // Unit changed Grid Position
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }
    }
    
    public MoveAction GetMoveAction()
    {
        return moveAction;
    }

    public SpinAction GetSpinAction()
    {
        return spinAction;
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }

    public BaseAction[] GetBaseActions()
    {
        return baseActions;
    }

    public bool TrySpendActionPoints(BaseAction baseAction)
    {
        if (!CabSpendActionPoints(baseAction)) return false;

        SpendActionPoints(baseAction.GetActionPointsCost());
        return true;
    }

    public bool CabSpendActionPoints(BaseAction baseAction)
    {
        return (actionPoints >= baseAction.GetActionPointsCost());
    }

    private void SpendActionPoints(int amount)
    {
        actionPoints -= amount;
        
        OnAnyActionPointsChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetActionPointsLeft()
    {
        return actionPoints;
    }
    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        if ((!GetIsEnemy() || TurnSystem.Instance.GetIsPlayerTurn()) &&
            (GetIsEnemy() || !TurnSystem.Instance.GetIsPlayerTurn())) return;
        
        actionPoints = maxActionPoints;
        OnAnyActionPointsChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool GetIsEnemy()
    {
        return isEnemy;
    }
}
