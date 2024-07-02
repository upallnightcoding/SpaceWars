using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject GameLevel(int level)
    {
        GameObject fighter = null;

        switch (level)
        {
            case 1:
                fighter = CreateFighter(gameData.basicFighterPrefab);
                CreateEnemyFighter(1, fighter, gameData.enemyFighterA01Prefab);
                break;
            case 2:
                fighter = CreateFighter(gameData.basicFighterPrefab);
                CreateEnemyFighter(3, fighter, gameData.enemyFighterA01Prefab);
                break;
            case 3:
                fighter = CreateFighter(gameData.basicFighterPrefab);
                CreateEnemyFighter(5, fighter, gameData.enemyFighterA01Prefab);
                break;
        }

        return (fighter);
    }

    /**
     * CreateFighter() -
     */
    private GameObject CreateFighter(GameObject fighterPrefab)
    {
        return(Instantiate(fighterPrefab, new Vector3(), Quaternion.identity));
    }

    /**
     * CreateEnemyFighter() - 
     */
    private void CreateEnemyFighter(int n, GameObject fighter, GameObject enemyPrefab)
    {
        for (int i = 0; i < n; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(), Quaternion.identity);
            Vector2 p = Random.insideUnitCircle * gameData.ringSize;
            enemy.GetComponent<EnemyFighterCntrl>().StartGame(fighter.transform, new Vector3(p.x, 0.0f, p.y));
        }
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
