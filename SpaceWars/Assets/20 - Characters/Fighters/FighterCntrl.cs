using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private float health = 50;

    // Start is called before the first frame update
    void Start()
    {
        nGuns = muzzlePoint.Length;
    }

    void Update()
    {
        Vector2 move = inputCntrl.Move;
        bool fire = inputCntrl.Fire;
        Vector2 look = inputCntrl.Look;

        switch (gameData.inputMode)
        {
            case InputMode.CONTROLLER:
                MoveFighterController(move, Time.deltaTime);
                FireWeapon(fire);
                break;
            case InputMode.KEYBOARD:
                MoveFighterKeyBoard(move, look, Time.deltaTime);
                break;
        }
    }

    /*private void MoveFighter(Vector2 moveDirection, float dt)
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
    }*/

    private void MoveFighterKeyBoard(Vector2 move, Vector2 look, float dt)
    {

        float throddle = move.y;
        float speed = 30.0f;
        Vector3 direction = Vector3.zero;

        Debug.Log($"MoveFighterKeyBoard ... {look}");
        if (look != Vector2.zero)
        {
            Ray ray = Camera.main.ScreenPointToRay(look);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 target = new Vector3(hit.point.x, 0.0f, hit.point.z);
                direction = (target - transform.position).normalized;

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, 7.0f * dt);
                transform.localRotation = playerRotation;
            }
        }

        if (throddle > 0.0f)
        {
            transform.Translate(direction * speed * throddle * dt, Space.World);
        }

        //Debug.Log("Fighter Movement ...");
    }

    private void MoveFighterController(Vector2 moveDirection, float dt)
    {
        float horizontalInput = moveDirection.x;
        float verticalInput = moveDirection.y;

        Vector3 direction = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;
        float troddle = Mathf.Sqrt(verticalInput * verticalInput + horizontalInput * horizontalInput);
        transform.Translate(direction * speed * troddle * dt, Space.World);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, 7.0f * dt);
            transform.localRotation = playerRotation;
        }
    }

    /*private void MoveFighterWithYaw(Vector2 moveDirection, float dt)
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
    }*/

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
        if (collision.gameObject.TryGetComponent<EnemyAmmoCntrl>(out EnemyAmmoCntrl ammo))
        {
            health -= 2.0f;

            EventManager.Instance.InvokeOnUpdateFighterHealth(health / 100.0f);

            if (health <= 0.0f)
            {
                EventManager.Instance.InvokeOnDisplayYoureDead();
            }
        }
    }
}
