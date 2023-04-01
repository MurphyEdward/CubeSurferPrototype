using System.Collections.Generic;
using UnityEngine;

public class WasteDespawner : MonoBehaviour
{
    [SerializeField] private GameObject _wasteContainer;
    private void OnEnable()
    {
        GenerateLevelEventTrigger.OnFinishZoneEnter += DestroyWaste;
    }
    public void DestroyWaste()
    {
        foreach(Transform child in _wasteContainer.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void OnDisable()
    {
        GenerateLevelEventTrigger.OnFinishZoneEnter -= DestroyWaste;
    }
}
                