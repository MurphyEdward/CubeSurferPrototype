using System;
using UnityEngine;

public class CubePicker : MonoBehaviour
{
    [SerializeField] private Transform _playerCube;

    private JumpAnimation _jumpAnimation;
    private PlayerInfo _playerInfo;
    private BoxCollider _playerCollider;

    private float _cubeSize;

    private void Awake()
    {
        _playerCollider = GetComponent<BoxCollider>();
        _playerInfo = GetComponent<PlayerInfo>();
        _jumpAnimation = GetComponent<JumpAnimation>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.TryGetComponent<CubePickup>(out CubePickup cubePickup) || cubePickup.IsStacked)
        {
            return;
        }

        _cubeSize = cubePickup.GetComponent<BoxCollider>().bounds.size.x;

        _jumpAnimation.Jump();

        _playerInfo.UpdateCurrentStackCount();
        AttachCubeToPlayer(cubePickup.gameObject);
        _playerInfo.StackCube(cubePickup);
    }

    private void AttachCubeToPlayer(GameObject cube)
    {
        BoxCollider cubeCollider = cube.GetComponent<BoxCollider>();
        Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();
        float sizeOfAllCaughtCubes = _cubeSize * _playerInfo.CurrentStackCubesNumber;

        cubeCollider.isTrigger = false;
        transform.position = new(transform.position.x, transform.position.y + _cubeSize, transform.position.z);

        cube.transform.SetParent(transform);
        cube.transform.position = new(_playerCube.transform.position.x, _playerCube.transform.position.y - sizeOfAllCaughtCubes, _playerCube.transform.position.z);
    }
}
