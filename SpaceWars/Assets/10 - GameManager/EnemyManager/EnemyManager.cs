using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyShipPrefab;

    private float distance = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject StartGame(GameObject fighterPrefab, GameObject enemyPrefab)
    {
        GameObject fighter = Instantiate(fighterPrefab, new Vector3(), Quaternion.identity);
        GameObject enemy = null;

        enemy = Instantiate(enemyPrefab, new Vector3(), Quaternion.identity);
        enemy.GetComponent<EnemyFighterCntrl>().StartGame(fighter.transform, new Vector3(0.0f, 0.0f, 30.0f));

        enemy = Instantiate(enemyPrefab, new Vector3(), Quaternion.identity);
        enemy.GetComponent<EnemyFighterCntrl>().StartGame(fighter.transform, new Vector3(0.0f, 0.0f, -30.0f));

        return (fighter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
