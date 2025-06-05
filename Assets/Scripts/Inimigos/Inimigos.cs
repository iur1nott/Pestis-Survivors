using UnityEngine;

public class Todos : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidBody;
    private Vector3 direção;

    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instance.gameObject.activeSelf){
            // se movimenta em direção ao player
            direção = (PlayerController.Instance.transform.position - transform.position).normalized;
            rigidBody.linearVelocity = new Vector2(direção.x * moveSpeed, direção.y * moveSpeed);
        } else {
            rigidBody.linearVelocity = Vector2.zero;
        }
    }

    // felipe -- lógica de colisão com player
    void OnCollisionStay2D(Collision2D collision) {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null) {
            player.TakeDamage(1);
        }
    }
}
