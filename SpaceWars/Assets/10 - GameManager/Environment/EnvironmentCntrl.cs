using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCntrl : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    private int nSpaceClouds = 0;
    private float spaceSize = 0.0f;
    private GameObject spaceCloudsPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        nSpaceClouds = gameData.nSpaceClouds;
        spaceSize = gameData.spaceSize;
        spaceCloudsPrefab = gameData.spaceCloudsPrefab;

        BuildEnvironment();
    }

    private void BuildEnvironment()
    {
        for (int i = 0; i < nSpaceClouds; i++)
        {
            Vector2 p = Random.insideUnitCircle * spaceSize;
            Vector3 position = new Vector3(p.x, 0.0f, p.y);
            Instantiate(spaceCloudsPrefab, position, Quaternion.identity);
        }
    }
}
