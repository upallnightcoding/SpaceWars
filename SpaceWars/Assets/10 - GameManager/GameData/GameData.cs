using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Space Wars/Game Data")]
public class GameData : ScriptableObject
{
    [Header("Game Attributes")]
    public FlightMode flightMode;

    [Header("Player Fighter")]
    public GameObject basicFighterPrefab;

    [Header("Enemy Fighter")]
    public GameObject enemyFighterA01Prefab;

    [Header("Level Attributes")]
    public float ringSize;
}

public enum FlightMode
{
    WITH_YAW,
    WITHOUT_YAW
}
