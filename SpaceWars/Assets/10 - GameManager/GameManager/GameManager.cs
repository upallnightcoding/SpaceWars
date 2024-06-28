using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject fighterPrefab;
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        GameObject fighter = Instantiate(fighterPrefab, new Vector3(), Quaternion.identity);

        GameObject enemy = Instantiate(enemyPrefab, new Vector3(), Quaternion.identity);
        enemy.GetComponentInChildren<EnemyFighterCntrl>().StartGame(fighter.transform, new Vector3(0.0f, 0.0f, 30.0f));
    }
}