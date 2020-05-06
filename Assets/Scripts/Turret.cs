using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    public float range = 10f;
    public float fireRate = 1f;

    public Transform rotate;

    public Transform m_FireTransform;
    public Rigidbody m_Mermi;
    private float speed = 3500f;

    private  GroundPlacementComp groundPlacementComp;

    public ParticleSystem namluPatlama;
    private float fireCountDown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        groundPlacementComp = GameObject.Find("Turret Placement Controller").GetComponent<GroundPlacementComp>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotate.rotation, lookRotation , Time.deltaTime * 10f).eulerAngles;
        rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountDown <= 0f && groundPlacementComp.placedToGround)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;

    }


    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }

    }

    void Shoot()
    {
       
            Rigidbody shellInstance =
            Instantiate(m_Mermi, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

            shellInstance.velocity = speed * m_FireTransform.forward * Time.deltaTime;

            ParticleSystem newNamluExplosion = Instantiate(namluPatlama, m_FireTransform.position, m_FireTransform.rotation) as ParticleSystem;

            Destroy(newNamluExplosion.gameObject,0.5f);
    }
   

    //Range i görebilmek için kırmızı gizmos çizmek

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
