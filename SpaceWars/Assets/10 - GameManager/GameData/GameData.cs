using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Space Wars/Game Data")]
public class GameData : ScriptableObject
{
    [Header("Game Attributes")]
    public InputMode inputMode;

    [Header("Player Fighter")]
    public GameObject basicFighterPrefab;
    public float fighterKeyboardSpeed;

    [Header("Enemy Fighter")]
    public GameObject enemyFighterA01Prefab;

    [Header("Environment Attributes")]
    public float spaceSize;
    public GameObject spaceCloudsPrefab;
    public int nSpaceClouds;

    [Header("Upgrade Camera")]
    public Vector3 UpgradeCameraPosition;
    public Vector3 UpgredeCameraRotation;

    [Header("Game Play Camera")]
    public Vector3 GamePlayCameraPosition;
    public Vector3 GamePlayCameraRotation;
}

public enum InputMode
{
    KEYBOARD,
    CONTROLLER
}
