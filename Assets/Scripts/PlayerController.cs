using UnityEngine;


public class PlayerController : MonoBehaviour
{
  public static PlayerController Instance;

  [SerializeField] private Rigidbody2D rigidBody;
  [SerializeField] private Animator animator;
  [SerializeField] private float moveSpeed;
  public Vector3 playerMoveDirection;

  // Iuri- criei essas duas variaveis para usar na UI
  public float playerMaxHealth;
  public float playerHealth;


  void Awake() {
    if (Instance != null && Instance != this) {
      Destroy(this);
    } else {
      Instance = this;
    }
  }

    // Iuri- inicializando a health do inimigo parte 2:30

    void Start()
    {
    playerHealth = playerMaxHealth;
    }

    void Update()
  {
    float inputX = Input.GetAxisRaw("Horizontal");
    float inputY = Input.GetAxisRaw("Vertical");
    playerMoveDirection = new Vector3(inputX, inputY).normalized;

    animator.SetFloat("moveX", inputX);
    animator.SetFloat("moveY", inputY);

    if (playerMoveDirection == Vector3.zero)
    {
      animator.SetBool("moving", false);
    }
    else
    {
      animator.SetBool("moving", true);
    }
  }

  void FixedUpdate()
  {
    rigidBody.linearVelocity = new Vector2(playerMoveDirection.x * moveSpeed, playerMoveDirection.y * moveSpeed);
  }


  //Iuri- Criei essa funcao para a o dano e atualizar na UI -video 2:43:00

  public void TakeDamage(float damage){
      playerHealth -= damage;
      UiController.Instance.UpdateHealthSlider();
      if (playerHealth <= 0){
        gameObject.SetActive(false);
      }
    }
  }


  