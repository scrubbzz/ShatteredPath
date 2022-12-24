using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBall : Ball
{
    int moveForce;
    GameObject prefab;
    Vector3 spawnPosition;
    public RegularBall(int moveForce, GameObject regularBallPrefab, Vector3 spawnPosition)
    {
        this.moveForce = moveForce;
        prefab = regularBallPrefab;
        this.spawnPosition = spawnPosition;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
