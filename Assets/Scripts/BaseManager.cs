using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public Transform nextBasePosition;
    public bool isPooled = false;
    public GameObject baseTrigger;

    private void Awake()
    {
        if (baseTrigger == null)
            baseTrigger = this.GetComponentInChildren<BaseGeneration>().gameObject;
    }

    private void OnEnable()
    {
        if(isPooled && baseTrigger != null)
            baseTrigger.SetActive(true);
    }
}
