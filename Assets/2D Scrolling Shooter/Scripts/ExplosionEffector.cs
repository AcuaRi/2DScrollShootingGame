using UnityEngine;

public class ExplosionEffector : MonoBehaviour
{
   //explosion prefab
   [SerializeField] private GameObject explosion;

   public void PlayExplosionEffect(Vector3 explosionPosition)
   {
      Instantiate(explosion, explosionPosition, Quaternion.identity);
   }
}
