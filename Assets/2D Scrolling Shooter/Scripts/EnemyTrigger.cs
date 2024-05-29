using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private string playerBulletTag;
    [SerializeField] private float hp = 50f;
    
    public UnityEvent OnDamaged;
    public UnityEvent<Vector3> OnDead;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerBulletTag))
        {
            //remove bullet
            Destroy(other.gameObject);
            
            //damage event
            OnDamaged?.Invoke();

            //if null, the damage is 0
            hp -= Random.Range(0.8f, 1.2f) * other.GetComponent<BulletDamage>()?.Damage ?? 0;
            hp = (hp < 0) ? 0 : hp;

            if (hp == 0)
            {
                OnDead?.Invoke(transform.position);
                Destroy(gameObject);
            }
        }
    }
    
}
