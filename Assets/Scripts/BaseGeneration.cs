using UnityEngine;
using System;

public class BaseGeneration : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            
            GameObject gameObject = GameObject.Instantiate(GameManager.Instance.basePrefab, 
                this.transform.parent.GetComponent<BaseManager>().nextBasePosition.position, 
                Quaternion.identity, GameManager.Instance.baseParent);
        }
    }
}
