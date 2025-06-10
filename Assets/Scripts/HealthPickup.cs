using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount = 20f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null && player.playerHealth < player.playerMaxHealth)
            {
                player.playerHealth = Mathf.Min(player.playerHealth + healAmount, player.playerMaxHealth);

               
                UiController.Instance.UpdateHealthSlider();

                Destroy(gameObject);
            }
        }
    }
}
