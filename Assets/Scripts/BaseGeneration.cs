using UnityEngine;
using System;

public class BaseGeneration : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.gameObject.SetActive(false);
            
            int randomIndex = UnityEngine.Random.Range(0, GameManager.Instance.basePool.Count);
            GameObject currentbase = GameManager.Instance.basePool[randomIndex];
            
            GameManager.Instance.basePool.Remove(currentbase);
            currentbase.transform.position = GameManager.Instance.nextBasePos.position;
            GameManager.Instance.nextBasePos = currentbase.GetComponent<BaseManager>().nextBasePosition;
            currentbase.SetActive(true);
            
            currentbase.transform.parent = GameManager.Instance.baseParent;
            GameManager.Instance.allBases.Add(currentbase);
            currentbase.name = "Base " + (GameManager.Instance.allBases.Count - 1);

            #region Return bases to pool
            if (GameManager.Instance.allBases.Count >= 6)
            {
                GameObject baseToPool = GameManager.Instance.allBases[GameManager.Instance.baseToRemoveCount];
                GameManager.Instance.allBases[GameManager.Instance.baseToRemoveCount] = null;
                baseToPool.SetActive(false);

                if(baseToPool.GetComponent<BaseManager>().isPooled)
                {
                    baseToPool.transform.position = new Vector3(0, -1000, 0);
                    baseToPool.transform.parent = GameManager.Instance.basePoolParent;
                    GameManager.Instance.basePool.Add(baseToPool);
                }

                GameManager.Instance.baseToRemoveCount += 1;
            }
            #endregion
        }
    }
}
