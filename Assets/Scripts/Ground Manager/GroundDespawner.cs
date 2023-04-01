using UnityEngine;

public class GroundDespawner : MonoBehaviour
{

    private void OnEnable()
    {
        GenerateLevelEventTrigger.OnFinishZoneEnterWithArgs += DestroyLastGround;
    }
    public void DestroyLastGround(GameObject groundObject)
    {
        Destroy(groundObject);
    }
    private void OnDisable()
    {
        GenerateLevelEventTrigger.OnFinishZoneEnterWithArgs += DestroyLastGround;
    }
}
