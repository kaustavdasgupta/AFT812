using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.coinAudioSource.Play();

            GameManager.Instance.score += GameManager.Instance.points;
            GameManager.Instance.coinsText.text = GameManager.Instance.score.ToString();
            PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("TotalScore") + GameManager.Instance.points);
            
            this.gameObject.SetActive(false);
        }
    }
}
