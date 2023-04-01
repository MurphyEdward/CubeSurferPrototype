using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpEffectFollow : MonoBehaviour
{
    [SerializeField] Transform _player;
    private Vector3 _offset;
    private void Awake()
    {
        _offset = transform.position;
    }

    private void Update()
    {
        transform.position = _player.transform.position + _offset;               
    }
}
