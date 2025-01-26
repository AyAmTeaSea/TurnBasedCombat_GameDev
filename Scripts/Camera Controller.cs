using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    const float MIN_FOLLOW_Y_OFFSET = 2f;
    const float MAX_FOLLOW_Y_OFFSET = 12f;
    
    [SerializeField] private CinemachineFollow cinemachineCameraFollow;

    private Vector3 targetFollowOffset;
    
    float cameraMoveSpeed = 10f;
    float cameraRotationSpeed = 100f;
    float zoomAmount = 1f;
    float zoomSpeed = 5f;

    private void Start()
    {
        targetFollowOffset = cinemachineCameraFollow.FollowOffset;
    }

    void Update()
    {
        HandleMovement();

        HandleRotation();

        HandleZoom();
    }

    private void HandleZoom()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            targetFollowOffset.y -= zoomAmount;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            targetFollowOffset.y += zoomAmount;
        }
        
        targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MIN_FOLLOW_Y_OFFSET, MAX_FOLLOW_Y_OFFSET);

        cinemachineCameraFollow.FollowOffset = Vector3.Lerp(cinemachineCameraFollow.FollowOffset, targetFollowOffset, zoomSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        Vector3 rotationVector = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = +1f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = -1f;
        }
        
        transform.eulerAngles += rotationVector * (Time.deltaTime * cameraRotationSpeed);
    }

    private void HandleMovement()
    {
        Vector3 inputMoveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDirection.z = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDirection.z = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDirection.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDirection.x = +1f;
        }
        
        Vector3 moveVector = transform.forward * inputMoveDirection.z + transform.right * inputMoveDirection.x;
        transform.position += moveVector * (Time.deltaTime * cameraMoveSpeed);
    }
}
