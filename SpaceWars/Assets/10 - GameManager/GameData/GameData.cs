using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Space Wars/Game Data")]
public class GameData : ScriptableObject
{
    [Header("Game Attributes")]
    public FlightMode flightMode;
}

public enum FlightMode
{
    WITH_YAW,
    WITHOUT_YAW
}
