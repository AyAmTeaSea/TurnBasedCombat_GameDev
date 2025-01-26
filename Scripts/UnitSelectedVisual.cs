using System;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    Unit unit;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        unit = GetComponentInParent<Unit>();
    }

    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        
        UpdateVisual();
    }

    private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();

        if (selectedUnit == unit)
        {
            meshRenderer.enabled = true;
            return;
        }
        
        meshRenderer.enabled = false;
    }
}
