using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public AudioSource buttonClick;
    public TextMeshProUGUI totalScoreText;

    private void Start()
    {
       if(!PlayerPrefs.HasKey("TotalScore"))
            PlayerPrefs.SetInt("TotalScore", 0);

       totalScoreText.text = PlayerPrefs.GetInt("TotalScore").ToString();
    }

    public void LoadScene()
    {
        buttonClick.Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
