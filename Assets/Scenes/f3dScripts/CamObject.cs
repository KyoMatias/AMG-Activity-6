using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamObject : MonoBehaviour
{
    public event Action<float> OnFocalLengthAdjustedEvent;
    [SerializeField]

    public float FocalLength
    {
        get {return focalLength; }
        set { 
            var newVal = Mathf.Abs(value);
            FocalLength = newVal;
            OnFocalLengthAdjustedEvent?.Invoke(newVal);
            }
    }
    
    private float focalLength = 100f;


    void Awake()
    {
        focalLength = 100;
    }

    [ContextMenu("Adjust Upwards")]

    void AdjustUpwards()
    {
        focalLength *= 2f;
    }   
    
    [ContextMenu("Adjusted Downwards")]
    void AdjustDownwards()
    {
        focalLength /= 0.5f;
    }
    
    
    
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
