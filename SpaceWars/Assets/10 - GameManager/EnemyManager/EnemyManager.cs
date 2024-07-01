using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject StartGame(GameObject fighterPrefab, GameObject enemyPrefab)
    {
        GameObject fighter = Instantiate(fighterPrefab, new Vector3(), Quaternion.identity);
        GameObject enemy = null;

        int n = 4;
        float delt = 360.0f / n;
        float distance = 70.0f;

        for (float i = 0, degree = 0.0f; i < n; i++, degree += delt) 
        {
            float x = distance * Mathf.Cos(degree * 3.145f / 180.0f);
            float y = 0.0f;
            float z = distance * Mathf.Sin(degree * 3.145f / 180.0f);

            enemy = Instantiate(enemyPrefab, new Vector3(), Quaternion.identity);
            enemy.GetComponent<EnemyFighterCntrl>().StartGame(fighter.transform, new Vector3(x, y, z));
        }

        return (fighter);
    }
}
