using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;

    [SerializeField] private float xInput;
    [SerializeField] private float yInput;
    [SerializeField] private int moveSpeed = 20;
    
    [SerializeField] private float zoomModifier;

    public static CameraController instance;

    private void Awake()
    {
        instance = this;
        cam = Camera.main;
    }

    void Start()
    {
        
    }

    void Update()
    {
        MoveByKB();
        ZoomInOut();
    }

    private void MoveByKB()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(xInput, yInput, 0f);
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
    
    
    public void ZoomInOut()
    {
        zoomModifier = -2f * Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetKey(KeyCode.Z))
            zoomModifier = -0.1f;
        if (Input.GetKey(KeyCode.X))
            zoomModifier = 0.1f;

        cam.orthographicSize += zoomModifier;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 4, 10);
    }


}
