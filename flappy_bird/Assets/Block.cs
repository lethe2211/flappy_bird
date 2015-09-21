using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public GameObject pivot;
    
    void Start()
    {
        ChangeHeight();
    }

    void ChangeHeight()
    {
        float height = Random.Range(minHeight, maxHeight);
        pivot.transform.localPosition = new Vector3(0.0f, height, 0.0f);
    }
    
    // Receive message from ScrollObject.cs
    void OnScrollEnd()
    {
        ChangeHeight();
    }
    
}
