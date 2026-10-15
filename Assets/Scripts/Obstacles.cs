using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.isPaused = true;
            this.gameObject.SetActive(false);
            other.GetComponent<Animator>().SetTrigger("Death");
        }
    }
}
