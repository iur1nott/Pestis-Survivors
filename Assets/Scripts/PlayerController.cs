using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private Rigidbody2D rb;
  [SerializeField] private float moveSpeed;
  public Vector3 playerMoveDirection;

  // Update is called once per frame
  void Update()
  {
    float inputX = Input.GetAxisRaw("Horizontal");
    float inputY = Input.GetAxisRaw("Vertical");
    playerMoveDirection = new Vector2(inputX, inputY).normalized;

    rb.linearVelocity = new Vector2(playerMoveDirection.x * moveSpeed, playerMoveDirection.y * moveSpeed);
  }

  void FixedUpdate()
  {
    rb.linearVelocity = new Vector2(playerMoveDirection.x * moveSpeed, playerMoveDirection.y * moveSpeed);  
  }
}
