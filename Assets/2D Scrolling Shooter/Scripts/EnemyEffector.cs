using System.Collections;
using UnityEngine;

public class EnemyEffect : MonoBehaviour
{
    //unit time : second
    [SerializeField] private float colorAnimationInterval = 0.1f;
    
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void PlayDamageEffect()
    {
        StartCoroutine(PlayDamageAnimation());
    }

    private IEnumerator PlayDamageAnimation()
    {
        spriteRenderer.color = Color.red;   
        yield return new WaitForSeconds(colorAnimationInterval);

        spriteRenderer.color = Color.white;
    }
}
