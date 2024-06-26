using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCntrl : MonoBehaviour
{
    [SerializeField] private InputCntrl inputCntrl;

    [SerializeField] private GameObject missilePrefab;

    [SerializeField] private Transform[] muzzlePoint;

    [SerializeField] private Transform cameraObject;

    private float speed = 60.0f;
    private float yawAmount = 120.0f;
 
    private float yaw = 0.0f;

    private Vector2 Move { get; set; }
    private bool Fire { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move = inputCntrl.Move;
        Fire = inputCntrl.Fire;

        MoveFighter(Move, Time.deltaTime);
        //MoveFighter1();
        FireWeapon();
    }

    private void MoveFighter(Vector2 moveDirection, float dt)
    {
        Vector3 direction = new Vector3(moveDirection.x, 0.0f, moveDirection.y).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        float horizontalInput = moveDirection.x;
        float verticalInput = moveDirection.y;

        if (direction != Vector3.zero)
        {
            //Quaternion targetRotation = Quaternion.LookRotation(direction);
            //Vector3 angles = targetRotation.eulerAngles;
            //angles.z = Mathf.Lerp(0, 45, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput) * /*Mathf.Sign(verticalInput) * */1.5f;
            //transform.localRotation = Quaternion.Euler(angles);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion playerRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 7.0f * dt);
            //Debug.Log($"transform.rotation: {transform.rotation.eulerAngles}");
            //Debug.Log($"targetRotation: {targetRotation.eulerAngles}");

            float angle = Vector3.Angle(direction, transform.forward);

            if (angle != 0)
            {
                float roll = Mathf.Lerp(0, 45, Mathf.Abs(Mathf.Cos(angle * Mathf.PI / 180.0f))) * -Mathf.Sign(horizontalInput);
                Debug.Log($"Angle/Roll: {angle}/{roll}");
                Vector3 angles = playerRotation.eulerAngles;
                angles.z = roll;
                transform.localRotation = Quaternion.Euler(angles);
            }


            //Quaternion targetRotation = Quaternion.LookRotation(direction);
            //Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, 7.0f * dt);
            //transform.localRotation = playerRotation;
        }
    }

    private void MoveFighter1()
    {
        float horizontalInput = Move.x;
        float verticalInput = Move.y;

        Vector3 position = transform.forward * speed * Mathf.Abs(verticalInput) * Time.deltaTime;
        //Vector3 position = transform.forward * speed * Mathf.Abs(verticalInput) * Time.deltaTime * Mathf.Sign(verticalInput);
        position.y = 0.0f;

        transform.Translate(position, Space.World);
        //Debug.Log($"transform.Translate: {transform.position}");

        yaw += horizontalInput * yawAmount * Time.deltaTime * Mathf.Sign(verticalInput);
        
        float pitch = 0.0f;
        //float roll = Mathf.Lerp(0, 45, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput) * 1.5f;
        float roll = Mathf.Lerp(0, 45, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput) * 1.5f;
        //roll = 0.0f;

        Vector3 angles = Vector3.up * yaw + Vector3.right * pitch + Vector3.forward * roll;
        //angles.x = 0.0f;
        
        transform.localRotation = Quaternion.Euler(angles);
    }

    /*private void xxMoveFighter(Vector2 moveDirection, float dt)
    {
        float gravitySpeed = 0.0f;

        Vector3 direction = cameraObject.forward * moveDirection.y;
        direction = direction + cameraObject.right * moveDirection.x;
        direction.y = 0.0f;
        direction.Normalize();

        Vector3 hortMovement = gameData.runSpeed * direction;
        Vector3 vertMovement = Vector3.up * gravitySpeed;

        charCntrl.Move(dt * (vertMovement + hortMovement));

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, gameData.turnSpeed * dt);

        transform.rotation = playerRotation;
    }*/

    private void FireWeapon()
    {
        if (Fire)
        {
            FireMissle();
        }
    }
    
    private void FireMissle()
    {
        Instantiate(missilePrefab, muzzlePoint[0].position, transform.rotation);
        Instantiate(missilePrefab, muzzlePoint[1].position, transform.rotation);
    }
}
