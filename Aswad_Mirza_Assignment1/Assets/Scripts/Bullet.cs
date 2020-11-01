﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // to add customization to the life of the bullets
    public float timeToLive = 1f;
    // Start is called before the first frame update

    // particle effects
    public GameObject CollisionEffect;
    public GameObject SpawnEffect;
    void Start()
    {
        GameObject _spawnEffect = Instantiate(SpawnEffect, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //Calls the coroutine for destroying this object
        StartCoroutine(DeleteThisObject());
    }

    // destroys this object after a delay based on the specified timeToLive
    IEnumerator DeleteThisObject() {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject _collisonEffect = Instantiate(CollisionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
