// Script by : Nanatchy

using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Damage : MonoBehaviour
{
    #region Attributs
    
    [SerializeField] private string tagName;
    
    public bool damage = false;
    public bool isDead = false;
    
    #endregion

    #region Methods

    
    
    #endregion

    #region Behaviors
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagName))
        {
            damage = true;
        }
    }
   
    #endregion
}
