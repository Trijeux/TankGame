// Script by : Nanatchy

using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Attributs
    
    [SerializeField] private float bulletForce = 10;
    [SerializeField] private string tagName;

    #endregion

    #region Methods
    
    
    
    #endregion

    #region Behaviors

    private void Start()
    {
       
        GetComponent<Rigidbody>().linearVelocity = transform.forward * bulletForce;
       
        Destroy(gameObject, 2);
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagName))
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
