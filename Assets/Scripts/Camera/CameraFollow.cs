using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        transform.position = _player.transform.position + _offset;
    }
}
