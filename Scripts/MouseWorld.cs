using System;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    [SerializeField] private LayerMask mousePlaneLayerMask;
    
    private Ray ray;
    private static MouseWorld instance;

    private void Awake()
    {
        instance = this;
    }

    // void Update()
    // {
    //     transform.position = MouseWorld.GetMouseWorldPosition();
    // }

    public static Vector3 GetMouseWorldPosition()
    {
        instance.ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(instance.ray, out RaycastHit hit, float.MaxValue, instance.mousePlaneLayerMask);
        
        return hit.point;
    }
}
