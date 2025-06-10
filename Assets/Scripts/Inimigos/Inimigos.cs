using UnityEngine;

public class Inimigos : MonoBehaviour
{
  [SerializeField] private SpriteRenderer spriteRenderer;
  [SerializeField] private Rigidbody2D rigidBody;
  private Vector3 direção;

  [SerializeField] private float moveSpeed;
  [SerializeField] private float damage;
  [SerializeField] private float health;

  
  void Update()
  {
    if (PlayerController.Instance.gameObject.activeSelf)
    {
      
      direção = (PlayerController.Instance.transform.position - transform.position).normalized;
      rigidBody.linearVelocity = new Vector2(direção.x * moveSpeed, direção.y * moveSpeed);
    }
    else
    {
      rigidBody.linearVelocity = Vector2.zero;
    }
  }

  void OnCollisionStay2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      PlayerController.Instance.TakeDamage(damage);
    }
  }

  public void TakeDamage(float damage)
  {
    health -= damage;
    if (health <= 0)
    {
      Destroy(gameObject);
    }
  }
}
