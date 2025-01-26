using System;
using UnityEngine;

public class ActionBusyUI : MonoBehaviour
{
    [SerializeField] private GameObject busyImage;
    [SerializeField] private GameObject busyText;

    private bool isBusy = false;
    
    private void Start()
    {
        UnitActionSystem.Instance.OnBusyChanged += UnitActionSystem_OnBusyChanged;
        
        SetBusyObject(isBusy);
    }

    private void UnitActionSystem_OnBusyChanged(object sender, EventArgs e)
    {
        isBusy = !isBusy;

        SetBusyObject(isBusy);
    }

    private void SetBusyObject(bool isBusy)
    {
        busyImage.SetActive(isBusy);
        busyText.SetActive(isBusy);
    }
}
