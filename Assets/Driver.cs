using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 80f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float slowSpeed = 6f;
    [SerializeField] float boostSpeed = 22f;


    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
         transform.Rotate(new Vector3(0, 0, -steerAmount ));
         transform.Translate(new Vector3(0, speedAmount, 0));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Construct")
        {
            moveSpeed = slowSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Booster")
        {
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, 0.5f);
        }
    }
}
