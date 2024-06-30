using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject fighterPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private CameraCntrl cameraCntrl;

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
        GameObject fighter = enemyManager.StartGame(fighterPrefab, enemyPrefab);

        cameraCntrl.StartGame(fighter.transform);
    }
}