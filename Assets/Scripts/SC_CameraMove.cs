using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CameraMove : MonoBehaviour
{

    public float dampTime = 0.15f;
    public Transform target;
    private Vector3 _velocity = Vector3.zero;
    Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 point = _cam.WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.75f, target.position.z), Camera.MonoOrStereoscopicEye.Mono );
            Vector3 delta = new Vector3(target.position.x, target.position.y + 0.75f, target.position.z) - _cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z), Camera.MonoOrStereoscopicEye.Mono); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;


            transform.position = Vector3.SmoothDamp(transform.position, destination, ref _velocity, dampTime);
        }
    }
}
