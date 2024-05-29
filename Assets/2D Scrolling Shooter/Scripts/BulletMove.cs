using System;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    private Transform refTransform;

    private void Awake()
    {
        refTransform = transform;
    }

    private void Update()
    {
        refTransform.position += moveSpeed * Time.deltaTime * refTransform.up;
    }
}
