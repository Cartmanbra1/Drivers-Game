using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool HasPackage;

    [SerializeField] Color32 HasPackageColor = new Color32(255, 121, 244, 255);
    [SerializeField] Color32 NoPackageColor = new Color32(255, 255, 255, 255);

    [SerializeField] float delay = 1.0f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !HasPackage) {

            Debug.Log("Package picked up");
            HasPackage = true;
            Destroy(other.gameObject, delay);
            spriteRenderer.color = HasPackageColor;

        } else if (other.tag == "Costumer" && HasPackage) {

            Debug.Log("Package delivered Cyka!!");
            HasPackage = false;
            spriteRenderer.color = NoPackageColor;
        }
    }
}
