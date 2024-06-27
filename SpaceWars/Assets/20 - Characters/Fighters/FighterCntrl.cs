using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCntrl : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private InputCntrl inputCntrl;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform[] muzzlePoint;
    [SerializeField] private Transform cameraObject;

    private float speed = 60.0f;
    private float yawAmount = 300.0f;
 
    private float yaw = 0.0f;

    private bool readyToFire = true;

    private Vector2 Move { get; set; }
    private bool Fire { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Move = inputCntrl.Move;
        bool fire = inputCntrl.Fire;

        MoveFighter(Move, Time.deltaTime);
        FireWeapon(fire);
    }

    private void MoveFighter(Vector2 moveDirection, float dt)
    {
        switch(gameData.flightMode)
        {
            case FlightMode.WITHOUT_YAW:
                MoveFighterWithoutYaw(moveDirection, dt);
                break;
            case FlightMode.WITH_YAW:
                MoveFighterWithYaw(moveDirection, dt);
                break;
        }
    }

    private void MoveFighterWithoutYaw(Vector2 moveDirection, float dt)
    {
        Vector3 direction = new Vector3(moveDirection.x, 0.0f, moveDirection.y).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, 7.0f * dt);
            transform.localRotation = playerRotation;
        }
    }

    private void MoveFighterWithYaw(Vector2 moveDirection, float dt)
    {
        float horizontalInput = moveDirection.x;
        float verticalInput = moveDirection.y;

        Vector3 position = transform.forward * speed * Mathf.Abs(verticalInput) * dt;
        position.y = 0.0f;

        transform.Translate(position, Space.World);

        yaw += horizontalInput * yawAmount * dt * Mathf.Sign(verticalInput);
        
        float pitch = 0.0f;
        float roll = Mathf.Lerp(0, 45, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput) * 3.0f;

        Vector3 angles = Vector3.up * yaw + Vector3.right * pitch + Vector3.forward * roll;
        
        transform.localRotation = Quaternion.Euler(angles);

        angles = cameraObject.eulerAngles;
        angles.y = yaw;
        cameraObject.eulerAngles = angles;
    }

    private void FireWeapon(bool fire)
    {
        if (fire && readyToFire)
        {
            StartCoroutine(FireMissle());
        }
    }
    
    private IEnumerator FireMissle()
    {
        readyToFire = false;

        GameObject go = null;
        go = Instantiate(missilePrefab, muzzlePoint[0].position, transform.rotation);
        Destroy(go, 2.0f);
        go = Instantiate(missilePrefab, muzzlePoint[1].position, transform.rotation);
        Destroy(go, 2.0f);

        yield return new WaitForSeconds(0.5f);
        readyToFire = true;
    }
}
