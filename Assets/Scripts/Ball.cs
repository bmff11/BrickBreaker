﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector2 startingVelocity = new Vector2(15, -20);
    private Vector3 startingPosition;
    public GameObject gameover;

    int lives = 3;

    void Start() {
        startingPosition = transform.position;
        GetComponent<Rigidbody2D>().velocity = startingVelocity;
    }


    void Update() {
        if (transform.position.y < -7.6) {
            GetOut();
        }
        if (Input.GetButtonDown("Jump")) ;
        GetComponent<Rigidbody2D>().velocity = startingVelocity;

    }
    void GetOut()
    {
        Debug.Log("You are out");
        lives = lives - 1;

        transform.position = startingPosition;
        GetComponent<Rigidbody2D>().velocity = new Vector2();

        if (lives == 0) {
            GameOver();
        }
    }

    void GameOver()
    {
        gameover.SetActive(true);
    }
}