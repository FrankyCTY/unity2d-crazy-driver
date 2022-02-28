using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0, 255, 0, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collison happened!!");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage) {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if(other.tag == "Customer" && hasPackage is true) {
            Debug.Log("Delivered to customer");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
