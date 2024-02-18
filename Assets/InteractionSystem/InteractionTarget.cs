using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTarget : MonoBehaviour
{
    public LayerMask interactionLayer;
    private Transform _mCamera;

    private Ray ray;
    private RaycastHit hitInfo;

    // Start is called before the first frame update
    void Start()
    {
        _mCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ray.origin = _mCamera.position;
        ray.direction = _mCamera.forward;
        if(Physics.Raycast(ray, out hitInfo, interactionLayer))
        {
            transform.position = hitInfo.point;
        }
        else
        {
            transform.position = new Vector3(_mCamera.position.x, _mCamera.position.y, _mCamera.position.z + 20f);
        }
    }
}
