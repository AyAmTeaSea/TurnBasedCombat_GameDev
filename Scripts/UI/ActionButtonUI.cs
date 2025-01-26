using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private Button button;
    [SerializeField] private GameObject selectedGameObject;

    private BaseAction action;
    
    public void SetBaseAction(BaseAction action)
    {
        this.action = action;
        textMesh.text = action.GetActionName().ToUpper();
        
        button.onClick.AddListener(
            () =>
            {
                UnitActionSystem.Instance.SetSelectedAction(action);
            });
    }

    public void UpdateSelectedVisual()
    {
        BaseAction selectedBaseAction = UnitActionSystem.Instance.GetSelectedAction();
        selectedGameObject.SetActive(selectedBaseAction == action);
    }
}
