using UnityEngine;

public class CubeWallCollision : MonoBehaviour
{
    private PlayerInfo _playerInfo;
    private void Awake()
    {
        _playerInfo = GetComponent<PlayerInfo>();
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
}
