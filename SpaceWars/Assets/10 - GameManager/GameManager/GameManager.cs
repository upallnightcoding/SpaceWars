using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject fighterPrefab;
    [SerializeField] private GameObject enemyPrefab;

    private EnemyManager enemyManager = null;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        enemyManager.StartGame(fighterPrefab, enemyPrefab);
    }
}