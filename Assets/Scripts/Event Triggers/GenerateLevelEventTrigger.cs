using System;
using UnityEngine;

public class GenerateLevelEventTrigger : MonoBehaviour
{
    public static event Action<GameObject> OnFinishZoneEnterWithArgs;
    public static event Action OnFinishZoneEnter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            OnFinishZoneEnterWithArgs?.Invoke(transform.parent.gameObject);
            OnFinishZoneEnter?.Invoke();
        }
    }
}
