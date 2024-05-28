using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Serializable]
    class ClampValue
    {
        [SerializeField] private float min;
        [SerializeField] private float max;

        public float Min { get { return min; } }
        public float Max { get { return max; } }

        public float Clamp(float target)
        {
            return Mathf.Clamp(target, min, max);
        }
    }
    
    //Speed of delay for drag of player
    [SerializeField] private float lagSpeed = 5f;
    [SerializeField] private ClampValue clampX;
    [SerializeField] private ClampValue clampY;
    
    private Camera mainCamera;
    private Vector3 offset;
    private Transform refTransform;

    private void Awake()
    {
        mainCamera = Camera.main;
        refTransform = transform;
    }

    private void Update()
    {
        //set offset
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = transform.position.z;
            
            offset = refTransform.position - clickPosition;
        }
        
        //move the player by offset
        if (Input.GetMouseButton(0))
        {
            Vector3 clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = transform.position.z;
            
            //restrict x, y scope
            Vector3 targetPosition = clickPosition + offset;
            targetPosition.x = clampX.Clamp(targetPosition.x);
            targetPosition.y = clampY.Clamp(targetPosition.y);
            
            //refTransform.position = clickPosition + offset;
            refTransform.position = Vector3.Lerp(refTransform.position, targetPosition, Time.deltaTime * lagSpeed);
        }

        //reset offset
        if (Input.GetMouseButtonUp(0))
        {
            offset = Vector3.zero;
        }
    }
}
