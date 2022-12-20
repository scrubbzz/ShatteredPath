using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SmashManager : MonoBehaviour, IAudible, ISmashable
{
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    [SerializeField] GameObject[] brokenGlass;

    [Header("Sound Effects")]
    public AudioSource audioSource;
    public AudioClip[] soundEffects;
    // Use this for initialization
    void Start()
    {
        //brokenGlass = new GameObject[2];

        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        //cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        cubesPivot = Vector3.one * cubesPivotDistance;

        audioSource = GetComponent<AudioSource>();

        print(soundEffects.Length);
        audioSource.clip = soundEffects[Random.Range(0, soundEffects.Length - 1)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Floor")
        {
            explode();
        }

    }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //explode();
            SmashTheGlass();

            //PlaySoundEffect();
        }
    }

    public void explode()
    {
        //make object disappear
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z)
    {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }


    public void PlaySoundEffect()
    {
        //audioSource.clip = soundEffects[Random.Range(0, soundEffects.Length - 1)];
        print("played");
        audioSource.PlayOneShot(audioSource.clip);
    }


    public void SmashTheGlass()
    {
       
        gameObject.SetActive(false);

        int randomIndex = Random.Range(0, brokenGlass.Length - 1);
        GameObject smashedGlass = Instantiate(brokenGlass[randomIndex], gameObject.transform.position, Quaternion.identity);
        foreach (var shatteredGlassRB in brokenGlass[randomIndex].GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (shatteredGlassRB.transform.position - this.transform.position).normalized * explosionForce;
            shatteredGlassRB.AddForce(force);
        }
        if (smashedGlass != null)
        {
            Debug.Log("Smahsed Glass using element: " + randomIndex);
        }
    }
}
