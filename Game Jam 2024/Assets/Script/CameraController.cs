using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followPlayer;
    public Vector3 playerOffset;
    public float moveSpeed = 5f;

    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer != null) 
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, followPlayer.position + playerOffset, moveSpeed * Time.deltaTime);
        }
    }
}
