using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    [SerializeField] GameObject ballPPrefab;
    public int shootForce;
    public AudioSource audioSource;
    public AudioClip audioclip;

    public Vector3 targetPosition;
    public Vector3 shootDirection;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.Space))
        {
            ShootBall();
        }*/
        CheckShootDirection();
    }
    public void ShootBall(Vector3 shootDir)
    { 
        var ball = Instantiate(ballPPrefab, this.transform.position + new Vector3(0, 0, 5), Quaternion.identity);
        var ballBody = ball.GetComponent<Rigidbody>();

        if (ballBody != null)
        {
            ballBody.AddForce(shootDir * shootForce, ForceMode.Impulse);
            Debug.Log("Force Added");
        }
    }
    public void CheckShootDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(audioclip);
            Debug.Log("You shot");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, 1000))
            {
                shootDirection = (hitInfo.point - this.transform.position).normalized;
                ShootBall(shootDirection);
            }
        }
    }
}
