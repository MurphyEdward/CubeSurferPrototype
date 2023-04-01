using System;
using UnityEngine;

public class CubeRaycast : MonoBehaviour
{
    public static event Action OnGameOver;

    private PlayerInfo _playerInfo;
    private CubePickup _cubePickup;

    private RaycastHit _leftHit;
    private RaycastHit _rightHit;

    private bool _leftRaycast;
    private bool _rightRaycast;


    private void Awake()
    {
        _cubePickup = GetComponent<CubePickup>();
        _playerInfo = FindObjectOfType<PlayerInfo>();
    }

    private void FixedUpdate()
    {
        CubeRaycastChecker();
        if (_leftRaycast && _leftHit.collider.TryGetComponent<WallCube>(out WallCube leftHitCube) || _rightRaycast && _rightHit.collider.TryGetComponent<WallCube>(out WallCube rightHitCube))
        {
           if (TryGetComponent<PlayerCube>(out PlayerCube playerCube))
           {
               OnGameOver?.Invoke();
               return;
           }
               _playerInfo.RemoveStackedCube(_cubePickup);
        }
    }

    private void CubeRaycastChecker()
    {
        float raycastSidesOffset = 0.3f;
        Vector3 leftRayPosition = new(transform.position.x - raycastSidesOffset, transform.position.y, transform.position.z);
        Vector3 rightRayPosition = new(transform.position.x + raycastSidesOffset, transform.position.y, transform.position.z);

        _leftRaycast = Physics.Raycast(leftRayPosition, Vector3.forward, out _leftHit, 0.5f);
        _rightRaycast = Physics.Raycast(rightRayPosition, Vector3.forward, out _rightHit, 0.5f);
    }
}
