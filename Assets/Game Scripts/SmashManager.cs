using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public ShooterManager shooterManager;

    // Use this for initialization
    void Start()
    {
        //brokenGlass = new GameObject[2];

        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = Vector3.one * cubesPivotDistance;
        shooterManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShooterManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            //explode();
            SmashTheGlass();

            //PlaySoundEffect();
            if(this.gameObject.tag == "AmmoGlass")
            {
                shooterManager.ammo += 5;
                shooterManager.ammoText.text = shooterManager.ammo.ToString();
                Debug.Log("YOU HIT AMMO");
                Debug.Log("Ammo: " + shooterManager.ammo);
            }
        }

    }

    public void PlaySoundEffect()
    {
        //audioSource.clip = soundEffects[Random.Range(0, soundEffects.Length - 1)];
        print("played");
       
    }


    public void SmashTheGlass()
    {

        int randomIndex = Random.Range(0, brokenGlass.Length - 1);
        GameObject smashedGlass = Instantiate(brokenGlass[randomIndex], gameObject.transform.position, brokenGlass[randomIndex].transform.rotation);
        if (smashedGlass != null)
        {
            Debug.Log("Smahsed Glass using element: " + randomIndex);
        }
        /*var child = gameObject.GetComponentInChildren<GameObject>();
        child.transform.SetParent(null);*/
        gameObject.SetActive(false);
    }
}
