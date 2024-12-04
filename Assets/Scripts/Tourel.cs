using System.Collections;
using UnityEngine;

public class Tourel : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private Projectile bullet;
    [SerializeField] private Transform firePoint;
    
    private Coroutine shoot_routine = null;
    public float rotationSpeed = 5f;
    [SerializeField] private Transform player_;
    [SerializeField] private TargetPlayer target;

    [SerializeField] private bool FireOn = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target.playerIsHere)
        {
            float randomNumbeAim = Random.Range(-10f, 10f);
            
            Vector3 direction = player_.position - transform.position;

            direction.x += randomNumbeAim;
            //direction.z += randomNumbeAim;
            
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Interpolation pour une rotation fluide
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            if (!FireOn)
            {
                StartCoroutine(Fire());
            }
        }
        else
        {
              StopCoroutine(Fire());
              FireOn = false;
        }
    }

    IEnumerator Fire()
    {
        FireOn = true;
        while (FireOn)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(fireRate);
        }
    }
}