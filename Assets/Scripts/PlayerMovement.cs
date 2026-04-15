using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Animator _playerAnimator;
    
    [SerializeField]
    float moveSpeed = 2f;
    [SerializeField]
    float runSpeed = 3.5f;
    [SerializeField]
    float lerpSpeed = 2f;
    
    bool isMoving = false;
    bool isRunning = false;
    
    float currentSpeed = 0f;
    float currentAnimX = 0f;
    float currentAnimY = 0f;
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 inputDir = new Vector2(horizontal, vertical).normalized;
        
        isMoving = inputDir.magnitude > 0.1f;
        isRunning = Input.GetKey(KeyCode.LeftShift);

        float targetSpeed = 0f;
        float targetAnimSpeed = 0f;
        if (isMoving)
        {
            targetSpeed = isRunning ? runSpeed : moveSpeed;
            targetAnimSpeed = isRunning ? 1.0f : 0.5f;     
        }
        
        float targetAnimX = inputDir.x * targetAnimSpeed;
        float targetAnimY = inputDir.y * targetAnimSpeed;
        
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, lerpSpeed * Time.deltaTime);
        currentAnimX = Mathf.Lerp(currentAnimX, targetAnimX, lerpSpeed * Time.deltaTime);
        currentAnimY = Mathf.Lerp(currentAnimY, targetAnimY, lerpSpeed * Time.deltaTime);
        
        _playerAnimator.SetFloat("h", currentAnimX);
        _playerAnimator.SetFloat("v", currentAnimY);

        if (currentSpeed > 0.01f)
        {
            Vector3 moveDir = new Vector3(inputDir.x, 0f, inputDir.y);
            transform.Translate(moveDir * currentSpeed * Time.deltaTime, Space.World);
        }
    }
}
