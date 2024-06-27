using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighterCntrl : MonoBehaviour
{
    private int health = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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