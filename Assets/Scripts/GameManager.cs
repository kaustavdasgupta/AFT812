using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> allBases = new List<GameObject>();
    public Transform nextBasePos;
    public Transform baseParent;
    public int baseToRemoveCount = 0;
    public List<GameObject> basePrefabList = new List<GameObject>();
    public int score = 0;
    public AudioSource coinAudioSource;
    public Transform basePoolParent;
    public List<GameObject> basePool = new List<GameObject>();
    public bool isPaused = true;
    public TMP_Text coinsText;
    public int points = 1;
    public bool isShieldActive = false;


    //public bool isMagnetActive = false;
    //public bool isDoublePointsActive = false;
    //public bool isSpeedBoostActive = false;

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

        LoadBasePool();
    }

    private void LoadBasePool()
    {
        if(basePrefabList.Count == 0)
        {
            Debug.LogError("Base prefab list is empty!");
            return;
        }

        foreach(GameObject baseprefab in basePrefabList)
        {
            for(int i = 0; i < 5; i++)
            {
                GameObject newbase = Instantiate(baseprefab, new Vector3(0, -1000, 0), Quaternion.identity, basePoolParent);
                newbase.gameObject.SetActive(false);
                newbase.GetComponent<BaseManager>().isPooled = true;
                basePool.Add(newbase);
            }
        }

        isPaused = false;
    }
}
