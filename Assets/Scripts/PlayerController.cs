using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public static PlayerController Instance;

  [SerializeField] private Rigidbody2D rigidBody;
  [SerializeField] private float moveSpeed;
  public Vector3 playerMoveDirection;

  void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        } else {
            Instance = this;
        }
    }


  // Update is called once per frame
  void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        playerMoveDirection = new Vector3(inputX, inputY).normalized;
    }

  void FixedUpdate()
  {
    rigidBody.linearVelocity = new Vector2(playerMoveDirection.x * moveSpeed, playerMoveDirection.y * moveSpeed);  
  }
}
