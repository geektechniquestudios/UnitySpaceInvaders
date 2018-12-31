﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{ 
    public float speed = 30;
    public GameObject theBullet;

    private void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Instantiate(theBullet, transform.position, Quaternion.identity);
        }
    }
}
