using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
//[RequireComponent(typeof (Rigidbody))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] int moveSpeed;
    Rigidbody rb;

    float verticalV;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera(moveSpeed);
    }
    public void MoveCamera(int moveSpeed)
    {
        rb.velocity = new Vector3(0, 0, moveSpeed);
    }
}
