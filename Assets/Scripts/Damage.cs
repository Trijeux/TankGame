// Script by : Nanatchy

using System;
using UnityEngine;

public class Damage : MonoBehaviour
{
    #region Attributs
    
    [SerializeField] private string tagName;
    
    public bool damage = false;
    
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
