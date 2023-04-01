using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _runSpeed = 5;
    [SerializeField] private float _turnSpeed = 1;

    private Touch _touch;

    private void OnEnable()
    {
        CubeRaycast.OnGameOver += StopPlayer;
    }

    private void OnDisable()
    {
        CubeRaycast.OnGameOver -= StopPlayer;
    }

    public void StopPlayer()
    {
        _runSpeed = 0;
        _rigidbody.isKinematic = true;
    }

    private void Update()
    {
        GetTouch();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _rigidbody.velocity = new Vector3(_touch.deltaPosition.x * _turnSpeed, _rigidbody.velocity.y, _runSpeed);
    }

    private void GetTouch()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
        }
    }
}
