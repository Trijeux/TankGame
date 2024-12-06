// Script by : Nanatchy

using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class TurretTest : MonoBehaviour
{
    #region Attributs
    
    [SerializeField] private BoxCollider turretCollider;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform player;
    
    [SerializeField] private Projectile bullet;
    [SerializeField] private TargetPlayer target;
    [SerializeField] private DamageTest damage;
    
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private bool fireOn = false;
    [SerializeField] private int life = 0;

    [SerializeField] private float rotationSpeed = 5f;

    #endregion

    #region Methods

    
    
    #endregion

    #region Behaviors

    private void Update()
    {
        if (target.playerIsHere)
        {
            var randomNumberAim = Random.Range(-15f, 15f);
            
            var direction = player.position - transform.position;

            direction.x += randomNumberAim;
            
            var targetRotation = Quaternion.LookRotation(direction);
            
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            if (!fireOn)
            {
                StartCoroutine(Fire());
            }
        }
        else
        {
            StopCoroutine(Fire());
            fireOn = false;
        }

        if (damage.damage)
        {
            life--;
            damage.damage = false;
        }

        if (life <= 0)
        {
            turretCollider.enabled = false;
            damage.isDead = true;
            Destroy(gameObject);
        }
    }
    
    IEnumerator Fire()
    {
        fireOn = true;
        while (fireOn)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(fireRate);
        }
    }
    #endregion
}