using UnityEngine;

public class CubePickup : MonoBehaviour
{
    private bool _isStacked;
    public bool IsStacked
    {
        get
        {
            return _isStacked;
        }

        set
        {
            _isStacked = value;
        }
    }
}
