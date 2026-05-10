using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private Health playerHealth;

    private void Start()
    {
        coinText.text = GameManager.Instance.GetCoinCount().ToString();
        GameManager.Instance.OnCoinChanged += UpdateUI;

        if (playerHealth == null)
        {
            PlayerController player = FindAnyObjectByType<PlayerController>();
            if (player != null)
            {
                playerHealth = player.gameObject.GetComponent<Health>();
            }
        }

        if (playerHealth != null)
        {
            healthText.text = playerHealth.GetHealth().ToString();
            playerHealth.OnHealthChanged += UpdateHealth;

        }

    }
    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnCoinChanged -= UpdateUI;
        }

        playerHealth.OnHealthChanged -= UpdateHealth;
    }

    private void UpdateUI(int coins)
    {
        coinText.text = coins.ToString();
    }

    private void UpdateHealth(int newHealth)
    {
        healthText.text = newHealth.ToString();
    }

    private void Update()
    {
        int coins = GameManager.Instance.GetCoinCount();
        coinText.text = coins.ToString();
    }
}
