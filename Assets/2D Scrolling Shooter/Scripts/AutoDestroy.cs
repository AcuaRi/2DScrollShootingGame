using System;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime = 3f;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }
}
