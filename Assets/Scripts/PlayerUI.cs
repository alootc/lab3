using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI coinsText;

    void Start()
    {
        PlayerController.onPlayerDamage += UpdateHealth;
        PlayerController.onPlayerGetCoin += UpdateCoins;
    }

    private void UpdateHealth(int health)
    {
        healthText.text = "Vida: " + health.ToString();
    }

    private void UpdateCoins(int coins)
    {
        healthText.text = "Monedas: " + coins.ToString();
    }
}
