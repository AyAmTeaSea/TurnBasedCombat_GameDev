using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float timer = 3f;

    private void Start()
    {
        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;
    }

    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        if (TurnSystem.Instance.GetIsPlayerTurn()) return;

        timer = 3f;
    }

    private void Update()
    {
        if (TurnSystem.Instance.GetIsPlayerTurn()) return;
        
        timer -= Time.deltaTime;
        
        if (timer <= 0) TurnSystem.Instance.NextTurn();
    }
}
