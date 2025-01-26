using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class TurnSystemUI : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI turnText;
    [SerializeField] GameObject enemyTurnBanner;

    private void Start()
    {
        button.onClick.AddListener(
            () =>
            {
                TurnSystem.Instance.NextTurn();
                UpdateTurnNumber();
            });
        
        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;
        
        UpdateTurnNumber();
        UpdateEnemyTurnBanner();
        UpdateEndTurnButtonVisibility();
    }

    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        UpdateTurnNumber();
        UpdateEnemyTurnBanner();
        UpdateEndTurnButtonVisibility();
    }

    private void UpdateTurnNumber()
    {
        turnText.text = "TURN " + TurnSystem.Instance.GetTurnNumber();
    }

    private void UpdateEnemyTurnBanner()
    {
        enemyTurnBanner.SetActive(!TurnSystem.Instance.GetIsPlayerTurn());
    }

    void UpdateEndTurnButtonVisibility()
    {
        button.gameObject.SetActive(TurnSystem.Instance.GetIsPlayerTurn());
    }
}
