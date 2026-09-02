using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject basePrefab;
    public List<GameObject> allBases = new List<GameObject>();
    public Transform nextBasePos;
    public Transform baseParent;
    public int deleteBaseCount = 0;

    private void Start()
    {
        if (Instance == true)
        {
            DestroyImmediate(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
