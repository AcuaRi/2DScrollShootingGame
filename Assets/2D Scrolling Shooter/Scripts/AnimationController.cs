using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator refAnimator;

    private void Awake()
    {
        refAnimator = GetComponent<Animator>();
    }

    public void SetShootTrigger()
    {
        refAnimator.SetTrigger("Shoot");
    }
}
