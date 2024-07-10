using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCntrl : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    private float spaceSize = 0.0f;

    private int nSpaceClouds = 0;
    private GameObject[] spaceCloudsPrefab = null;

    private int nAstroidField;
    private GameObject astroidFieldPrefab;

    private GameObject electricityPrefab;

    // Start is called before the first frame update
    void Start()
    {
        nSpaceClouds = gameData.nSpaceClouds;
        spaceSize = gameData.spaceSize;
        spaceCloudsPrefab = gameData.spaceCloudsPrefab;

        nAstroidField = gameData.nAstroidFieldPrefab;
        astroidFieldPrefab = gameData.astroidFieldPrefab;

        electricityPrefab = gameData.electricityPrefab;

        BuildEnvironment();
    }

    private void BuildEnvironment()
    {
        CreateObject(nSpaceClouds, spaceCloudsPrefab, 0.75f, 1.25f);
        CreateObject(nAstroidField, astroidFieldPrefab, 0.75f, 1.25f);
    }

    private void CreateObject(int n, GameObject prefab, float minScale, float maxScale)
    {
        CreateObject(n, new GameObject[] { prefab }, minScale, maxScale);
    }

    private void CreateObject(int n, GameObject[] prefabList, float minScale, float maxScale)
    {
        int nOptions = prefabList.Length;

        for (int i = 0; i < n; i++)
        {
            Vector2 p = Random.insideUnitCircle * spaceSize;
            Vector3 position = new Vector3(p.x, 0.0f, p.y);
            float size = Random.Range(minScale, maxScale);

            GameObject prefab = prefabList[Random.Range(0, nOptions)];
            GameObject cloud = Instantiate(prefab, position, Quaternion.identity);
            cloud.transform.localScale = new Vector3(size, size, size);

            //GameObject electric = Instantiate(electricityPrefab, position, Quaternion.identity);
            //size *= 300.0f;
            //electric.transform.localScale = new Vector3(size, size, size);
        }
    }
}
