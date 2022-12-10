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
        verticalV = rb.velocity.y;
        verticalV = 0;

        rb.velocity = new Vector3(0, verticalV, moveSpeed * Time.deltaTime);
    }
}
