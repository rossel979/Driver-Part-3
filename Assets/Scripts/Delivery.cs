using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

     void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other) 
    {
        //Debug.Log("Ouch!");
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Pizza" && !hasPackage)
        {
            Debug.Log("Pizza picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Pizza Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}    