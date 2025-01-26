using UnityEngine;

public class GridSystemVisualSingle : MonoBehaviour
{
    [SerializeField] MeshRenderer renderer;

    public void Show()
    {
        renderer.enabled = true;
    }

    public void Hide()
    {
        renderer.enabled = false;
    }
}
