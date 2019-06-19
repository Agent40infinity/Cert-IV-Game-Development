using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Player : MonoBehaviour
    {
        public float movementSpeed = 10f;
        public float rotationSpeed = 360f;
        private Rigidbody2D rigid; 
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            Control();
        }
        void Control()
        {
            if (Input.GetKey(KeyCode.W))
            {
                rigid.AddForce(transform.up * movementSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rigid.AddForce(transform.up * -movementSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rigid.rotation += rotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rigid.rotation -= rotationSpeed * Time.deltaTime;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            
        }
    }

}