using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float lerpSpeed = 5f;
    [SerializeField]
    Vector3 offset = new Vector3(0f, 5f, -5f);
    
    void LateUpdate()
    {
        if (target == null) return;
        transform.LookAt(target);
        var targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        
    }
}
