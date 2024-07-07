using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    private int nEnemies = 0;
    private int nEnimiesDestoryed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /**
     * GameLevel() - 
     */
    public GameObject GameLevel(int level, GameObject fighter)
    {
        switch (level)
        {
            case 1:
                CreateEnemyFighter(1, fighter, gameData.enemyFighterA01Prefab);
                break;
            case 2:
                CreateEnemyFighter(3, fighter, gameData.enemyFighterA01Prefab);
                break;
            case 3:
                CreateEnemyFighter(5, fighter, gameData.enemyFighterA01Prefab);
                break;
        }

        return (fighter);
    }

    public void DestoryedEnemy()
    {
        Debug.Log("Destory Enemy ...");

        if (++nEnimiesDestoryed == nEnemies)
        {

        }
    }

    /**
     * CreateEnemyFighter() - 
     */
    private void CreateEnemyFighter(int n, GameObject fighter, GameObject enemyPrefab)
    {
        nEnemies = n;

        for (int i = 0; i < n; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(), Quaternion.identity);
            Vector2 p = Random.insideUnitCircle * gameData.ringSize;
            enemy.GetComponent<EnemyFighterCntrl>().StartGame(fighter.transform, new Vector3(p.x, 0.0f, p.y));
        }
    }

    private void OnDisable()
    {
        EventManager.Instance.OnDestoryedEnemy -= DestoryedEnemy;
    }

    private void OnEnable()
    {
        EventManager.Instance.OnDestoryedEnemy += DestoryedEnemy;
    }

    /**
     * StartGame() - 
     */
    /*public GameObject StartGame(GameObject fighterPrefab, GameObject enemyPrefab)
    {
        GameObject fighter = Instantiate(fighterPrefab, new Vector3(), Quaternion.identity);

        int n = 4;
        float delt = 360.0f / n;
        float distance = 70.0f;

        for (float i = 0, degree = 0.0f; i < n; i++, degree += delt) 
        {
            float x = distance * Mathf.Cos(degree * 3.145f / 180.0f);
            float y = 0.0f;
            float z = distance * Mathf.Sin(degree * 3.145f / 180.0f);

            GameObject enemy = Instantiate(enemyPrefab, new Vector3(), Quaternion.identity);
            enemy.GetComponent<EnemyFighterCntrl>().StartGame(fighter.transform, new Vector3(x, y, z));
        }

        return (fighter);
    }*/
}
