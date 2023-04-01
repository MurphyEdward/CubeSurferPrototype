using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class FingerSlideAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _cursor;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
}
