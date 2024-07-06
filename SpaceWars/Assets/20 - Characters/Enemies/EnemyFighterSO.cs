using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFighter", menuName = "Space Wars/Enemy Fighter")]
public class EnemyFighterSO : ScriptableObject
{
    public string fighterName;

    public GameObject missilePrefab;

    public GameObject explosionPreFab;

    public int maxAmmoCount;

    public float topSpeed;

    public long xp;
}
