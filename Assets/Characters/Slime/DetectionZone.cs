using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectedObjs = new List<Collider2D>();
    CircleCollider2D col;
    public float collisonRadius;
    
    // Start is called before the first frame update
    void Start()
    {
       col = GetComponent<CircleCollider2D>();
       collisonRadius = col.radius;
    }

    // Detected when oject enters range
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            detectedObjs.Add(collider);
        }
    }

    // Detected when object leaves range
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" || 
            collider.gameObject.tag == "Dead")
        {
            detectedObjs.Remove(collider);
        }
    }
   
}
