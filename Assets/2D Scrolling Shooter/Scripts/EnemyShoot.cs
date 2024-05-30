using System;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float shootInterval = 1.5f;
    [SerializeField] private float bulletSpeed = 3f;
    [SerializeField] private GameObject bulletPrefab;

    private Transform refPlayer;
    private float elapsedTime = 0f;
    
    private void Awake()
    {
        refPlayer = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (refPlayer == null)
        {
            Debug.LogError("EnemyShoot.cs : refPlayer is null!");
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > shootInterval)
        {
            Shoot();
            elapsedTime = 0f;
        }
    }

    private void Shoot()
    {
        if (null == refPlayer)
        {
            return;
        }

        Vector3 direction = refPlayer.position - transform.position;

        var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
    }
}
