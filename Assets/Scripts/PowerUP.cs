using UnityEngine;

public enum PowerUpType
{
    Magnet,
    Shield,
    DoublePoints,
    SpeedBoost,
}

public class PowerUP : MonoBehaviour
{
    public PowerUpType powerUpType;
    private PlayerMovement player;
    private float initialSpeed;

    private void Start()
    {
        if (player == null)
        {
            player = FindFirstObjectByType<PlayerMovement>();
            initialSpeed = player.speed;
        }
    }

    void InitializePowerUp()
    {
        switch (powerUpType)
        {
            case PowerUpType.Magnet:
                // Initialize magnet power-up
                break;
            case PowerUpType.Shield:
                GameManager.Instance.isShieldActive = true;
                Invoke("DeactivateShield", 5f);
                break;
            case PowerUpType.DoublePoints:
                GameManager.Instance.points = GameManager.Instance.points * 2;
                Invoke("DeactivateDoublePoints", 5f);
                break;
            case PowerUpType.SpeedBoost:           
                player.speed = 25f;
                Invoke("DeactivateSpeedBoost", 5f);
                break;
        }
    }

    void DeactivateSpeedBoost()
    {
        player.speed = initialSpeed;
    }

    void DeactivateDoublePoints()
    {
        GameManager.Instance.points = GameManager.Instance.points / 2;
    }

    void DeactivateShield()
    {
        GameManager.Instance.isShieldActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InitializePowerUp();
            this.gameObject.SetActive(false);
        }
    }
}
