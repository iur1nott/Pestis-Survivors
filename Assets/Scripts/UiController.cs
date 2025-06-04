using UnityEngine;
using UnityEngine.UI;


public class UiController : MonoBehaviour
{

    public static UiController Instance;
    [SerializeField] private Slider playerHealthSlider;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateHealthSlider()
    {
        playerHealthSlider.maxValue = PlayerController.Instance.playerMaxHealth;
        playerHealthSlider.value = PlayerController.Instance.playerHealth;


    } 
}
