using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    
    public float Damage
    {
        get
        {
            return damage;
        }
    }
}