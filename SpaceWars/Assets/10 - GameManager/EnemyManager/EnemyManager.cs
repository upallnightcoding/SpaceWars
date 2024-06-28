using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform fighter;
    [SerializeField] private GameObject enemyShipPrefab;

    private float distance = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame(Transform fighter)
    {
        Vector3 direction = (new Vector3() - new Vector3(0.0f, 0.0f, distance)).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        //GameObject go = Instantiate(enemyShipPrefab, new Vector3(0.0f, 0.0f, distance), targetRotation);
        //go.GetComponent<EnemyFighterCntrl>().StartGame(fighter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
