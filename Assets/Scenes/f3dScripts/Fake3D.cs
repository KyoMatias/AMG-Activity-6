using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake3D : MonoBehaviour
{

    private Vector3 fakePosition;
    private CamObject fakeCamera;
    private float perspective;

    void Awake()
    {
        fakeCamera = FindObjectOfType<CamObject>();
        fakeCamera.OnFocalLengthAdjustedEvent += AdjustBasedOnPerspective;
        AdjustBasedOnPerspective(fakeCamera.FocalLength);
    }

    void AdjustBasedOnPerspective(float focalLength)
        {
            perspective = fakeCamera.FocalLength / (focalLength + fakePosition.z);
        }

    void AdjustBasedOnPerspective()
    {
        perspective = fakeCamera.FocalLength / (fakeCamera.FocalLength + fakePosition.z);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AdjustBasedOnPerspective();
        transform.position = new Vector2(fakePosition.x, fakePosition.y);
        transform.localScale = Vector3.one;    
    }


    public void InitObj(CamObject cam)
    {
        fakeCamera = cam;
    }
}
