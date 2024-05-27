using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Speed of delay for drag of player
    [SerializeField] private float lagSpeed = 5f;
    
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
            targetPosition.x = Mathf.Clamp(targetPosition.x, -1.3f, 1.3f);
            targetPosition.y = Mathf.Clamp(targetPosition.y, -2.2f, 1f);
            
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
