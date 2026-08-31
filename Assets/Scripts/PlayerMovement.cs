using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    void Update()
    {
        transform.Translate(this.transform.forward * speed * Time.deltaTime);
    }
}
