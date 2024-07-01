using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighterCntrl : MonoBehaviour
{
    [SerializeField] private EnemyFighterSO enemyFighter;
    [SerializeField] private Transform[] muzzlePoint;

    private GameObject missilePrefab;
    private GameObject explosionPreFab;
    private int maxAmmoCount;
    private float topSpeed;

    private int health = 50;

    private int nGuns = 0;

    private bool readyToFire = true;

    private int ammoCount = 0;
    private Transform fighter = null;

    // Start is called before the first frame update
    void Start()
    {
        missilePrefab = enemyFighter.missilePrefab;
        explosionPreFab = enemyFighter.explosionPreFab;
        maxAmmoCount = enemyFighter.maxAmmoCount;
        topSpeed = enemyFighter.topSpeed;

        nGuns = muzzlePoint.Length;
    }

    // Update is called once per frame
    void Update()
    {
        MoveFighter();
        FireWeapon();
    }

    public void StartGame(Transform fighter, Vector3 position)
    {
        this.fighter = fighter;
        transform.position = position;
    }

    private void MoveFighter()
    {
        if (fighter != null)
        {
            Vector3 direction = (fighter.position - transform.position).normalized;
            transform.Translate(direction * topSpeed * Time.deltaTime, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.localRotation = targetRotation;
        }
    }

    private void FireWeapon()
    {
        if (readyToFire)
        {
            if (ammoCount > 0)
            {
                StartCoroutine(FireMissle());
            } else
            {
                StartCoroutine(ReLoad());
            }
        }
    }

    private IEnumerator ReLoad()
    {
        readyToFire = false;
        yield return new WaitForSeconds(2.0f);
        ammoCount = maxAmmoCount;
        readyToFire = true;
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

        yield return new WaitForSeconds(0.3f);
        readyToFire = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<AmmoCntrl>(out AmmoCntrl ammo)) {
            health -= 10;

            if (health <= 0)
            {
                Instantiate(explosionPreFab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
        }
    }
}