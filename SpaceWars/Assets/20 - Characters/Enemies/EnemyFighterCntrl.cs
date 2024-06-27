using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighterCntrl : MonoBehaviour
{
    [SerializeField] private Transform[] muzzlePoint;
    [SerializeField] private GameObject missilePrefab;

    private int health = 100;

    private int nGuns = 0;

    private bool readyToFire = true;

    private int ammoCount = 50;

    // Start is called before the first frame update
    void Start()
    {
        nGuns = muzzlePoint.Length;
    }

    // Update is called once per frame
    void Update()
    {
        FireWeapon();
    }

    private void FireWeapon()
    {
        if (readyToFire)
        {
            StartCoroutine(FireMissle());
        }
    }

    private IEnumerator FireMissle()
    {
        readyToFire = false;

        for (int i = 0; i < nGuns; i++)
        {
            GameObject go = Instantiate(missilePrefab, muzzlePoint[i].position, transform.rotation);
            Destroy(go, 2.0f);
        }

        ammoCount -= nGuns;

        yield return new WaitForSeconds(0.1f);
        readyToFire = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<AmmoCntrl>(out AmmoCntrl ammo)) {
            health -= 10;

            if (health <= 0)
            {
                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
        }
    }
}