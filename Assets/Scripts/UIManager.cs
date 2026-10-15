using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image timerImage;

    private void Update()
    {
        timerImage.fillAmount = Mathf.MoveTowards(timerImage.fillAmount, 0f, Time.deltaTime * 0.1f);
        if (timerImage.fillAmount <= 0f)
        {
            GameManager.Instance.isPaused = false;
            timerImage.gameObject.SetActive(false);
        }
    }
}
