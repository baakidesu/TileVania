using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
        [SerializeField] private float moveSpeed = 1f;
        private Rigidbody2D myRigidbody;
        private BoxCollider2D myBoxCollider2D;
        
        void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
        }

        private void FlipEnemyFacing()
        { 
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
        }
}
