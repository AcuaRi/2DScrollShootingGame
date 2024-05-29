using UnityEngine;

public class Explosion : MonoBehaviour
{
    void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}
