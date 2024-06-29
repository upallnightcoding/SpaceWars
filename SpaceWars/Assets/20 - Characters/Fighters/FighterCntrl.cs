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

    private float speed = 150.0f;
    private float yawAmount = 300.0f;

    private float yaw = 0.0f;

    private int nGuns = 0;

    private bool readyToFire = true;
    private int ammoCount = 100;
    private float reloadTime = 3.0f;

    private int health = 50;

    //private Vector2 Move { get; set; }
    //private bool Fire { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        nGuns = muzzlePoint.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = inputCntrl.Move;
        bool fire = inputCntrl.Fire;

        MoveFighter(move, Time.deltaTime);
        FireWeapon(fire);
    }

    private void MoveFighter(Vector2 moveDirection, float dt)
    {
        switch (gameData.flightMode)
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
        float horizontalInput = moveDirection.x;
        float verticalInput = moveDirection.y;

        Vector3 direction = new Vector3(moveDirection.x, 0.0f, moveDirection.y).normalized;
        float troddle = Mathf.Sqrt(verticalInput * verticalInput + horizontalInput * horizontalInput);
        transform.Translate(direction * speed * troddle * Time.deltaTime, Space.World);

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
            if (ammoCount > 0)
            {
                StartCoroutine(FireMissle());
            }
            else
            {
                StartCoroutine(ReLoad());
            }
        }
    }

    private IEnumerator ReLoad()
    {
        float timing = 0.0f;

        readyToFire = false;

        while (timing < reloadTime)
        {
            EventManager.Instance.InvokeOnReloadAmmo(timing / reloadTime);

            timing += Time.deltaTime;
            yield return null;
        }

        ammoCount = 100;
        readyToFire = true;
        EventManager.Instance.InvokeOnUpdateAmmo(1.0f);
    }

    private IEnumerator FireMissle()
    {
        readyToFire = false;

        for (int i = 0; i < nGuns; i++)
        {
            GameObject go = Instantiate(missilePrefab, muzzlePoint[i].position, transform.rotation);
            Destroy(go, 2.0f);
        }

        ammoCount -= 2;

        EventManager.Instance.InvokeOnUpdateAmmo(ammoCount / 100.0f);

        yield return new WaitForSeconds(0.1f);
        readyToFire = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Fighter Cntrl ...");
        if (collision.gameObject.TryGetComponent<EnemyAmmoCntrl>(out EnemyAmmoCntrl ammo))
        {
            health -= 5;

            EventManager.Instance.InvokeOnUpdateFighterHealth(health / 100.0f);
        }
    }
}
