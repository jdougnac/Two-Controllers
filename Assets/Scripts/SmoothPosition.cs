using UnityEngine;
public class SmoothPosition : MonoBehaviour
{
    public Vector3 targetPosition;    
    public float smoothFactor = 2;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);       
    }
}
