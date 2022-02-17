using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]  float fltsteerSpeed = 1f;
    [SerializeField] float fltmoveSpeed = 20f;
    [SerializeField] float fltslowSpeed = 15f;
    [SerializeField] float fltboostSpeed = 30f;
    
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        float fltsteerAmount = Input.GetAxis("Horizontal")* fltsteerSpeed * Time.deltaTime;
        float fltmoveAmount = Input.GetAxis("Vertical") * fltmoveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -fltsteerAmount);
        transform.Translate(0, fltmoveAmount, 0);
    }
     
     void OnCollisionEnter2D(Collision2D other) 
    {
        fltmoveSpeed = fltslowSpeed;
    }
     
     
     void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Boost")
        {
            fltmoveSpeed = fltboostSpeed;
        }
    }
}
