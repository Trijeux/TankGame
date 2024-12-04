// Script by : Nanatchy

using System;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    #region Attributs

    [SerializeField] private Transform firePoint;
    
    [SerializeField] private Projectile bullet;
    
    [SerializeField] private float fireRate = 0.5f;
    
    private Coroutine _shootRoutine = null;

    #endregion

    #region Methods



    #endregion

    #region Behaviors
    
    void OnShoot(InputValue value)
    {
        if (value.isPressed)
        {
            if (_shootRoutine != null)
                StopCoroutine(_shootRoutine);

            _shootRoutine = StartCoroutine(nameof(Fire));
        }
        else
        {
            StopCoroutine(nameof(Fire));
            _shootRoutine = null;
        }
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(fireRate);
        }
    }
    
    #endregion
    

  
   
}