using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float elapsedTime = 0;
    [SerializeField] private float shootInterval = 1f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePosition;

    public UnityEvent OnShoot;
    
    //private Animator refAnimator;

    private void Update()
    {
        // 타이머 업데이트.
        elapsedTime += Time.deltaTime;
    
        // 타이머가 발사 간격 시간만큼 지났으면,
        if (elapsedTime > shootInterval)
        {
            // 발사하고,
            Shoot();

            // 타이머 초기화.
            elapsedTime = 0f;
        }
    }

    private void Shoot()
    {
        OnShoot?.Invoke();
        
        if(bulletPrefab != null)
        {
            Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("<color=red> bulletPrefab object is null </color>");
        }
    }
}
