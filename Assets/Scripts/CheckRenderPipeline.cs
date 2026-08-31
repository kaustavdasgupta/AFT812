using UnityEngine;
using UnityEngine.Rendering;

public class CheckRenderPipeline : MonoBehaviour
{
    void Start()
    {
        CheckPipeline();
    }

    void Update()
    {       
    }

    void CheckPipeline()
    {
        if (GraphicsSettings.currentRenderPipeline != null)
            Debug.Log("Active Render Pipeline: " + GraphicsSettings.currentRenderPipelineAssetType);
        else
            Debug.Log("Built-In Render Pipeline");
    }
}
