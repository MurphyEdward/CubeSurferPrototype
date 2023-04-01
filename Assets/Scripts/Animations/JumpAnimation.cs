using System.Collections;
using UnityEngine;

public class JumpAnimation : MonoBehaviour
{
    private const string JumpAnimationName = "Jump";

    [SerializeField] private Animator _animator;
    
    private int _jumpSecondDelay;

    public void Jump()
    {
        _animator.SetBool(JumpAnimationName, true);
    }
}
