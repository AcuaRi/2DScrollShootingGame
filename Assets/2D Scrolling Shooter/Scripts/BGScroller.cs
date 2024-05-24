using System;
using UnityEngine;

//Scroll BackGround
public class BGScroller : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
        
    }
}
