using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShooterManager : MonoBehaviour
{
    [SerializeField] GameObject ballPPrefab;
    public int shootForce;
    public AudioSource audioSource;
    public AudioClip audioclip;

    public Vector3 targetPosition;
    public Vector3 shootDirection;

    [Header("Ammunition")]
    public int ammo = 20;
    public TextMeshProUGUI ammoText;
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
        Shoot();
        
    }
    public void InstantiateBall(Vector3 shootDir)
    {
        ammo--;
        ammoText.text = ammo.ToString();    
        var ball = Instantiate(ballPPrefab, this.transform.position + new Vector3(0, 0, 5), Quaternion.identity);
        var ballBody = ball.GetComponent<Rigidbody>();

        if (ballBody != null)
        {
            ballBody.AddForce(shootDir * shootForce, ForceMode.Impulse);
            Debug.Log("Force Added");
        }
    }
    public bool Shoot()
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
                InstantiateBall(shootDirection);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
