using UnityEngine;
using System;

public class BaseGeneration : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            
            GameObject gameObject = GameObject.Instantiate(GameManager.Instance.basePrefab, GameManager.Instance.nextBasePos.position, 
                Quaternion.identity, GameManager.Instance.baseParent);

            GameManager.Instance.allBases.Add(gameObject);
            GameManager.Instance.nextBasePos = gameObject.GetComponent<BaseManager>().nextBasePosition;
            gameObject.name = "Base " + (GameManager.Instance.allBases.Count - 1);

            #region Delete Bases
            if(GameManager.Instance.allBases.Count >= 6)
            {
                GameObject baseToDelete = GameManager.Instance.allBases[GameManager.Instance.deleteBaseCount];
                Destroy(baseToDelete);
                GameManager.Instance.deleteBaseCount += 1;
            }
            #endregion
        }
    }
}
