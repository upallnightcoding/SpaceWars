using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCntrl : MonoBehaviour
{
    [SerializeField] private InputCntrl inputCntrl;

    private float speed = 20.0f;
    private float yawAmount = 120.0f;
 
    private float yaw = 0.0f;

    private Vector2 Move { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move = inputCntrl.Move;

        MoveFighter();
    }

    private void MoveFighter()
    {
        //Vector3 direction = new Vector3(Move.x, 0.0f, Move.y).normalized;

        //transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;

        float horizontalInput = Move.x;
        float verticalInput = 0.0f;

        yaw += horizontalInput * yawAmount * Time.deltaTime;
        
        //float pitch = Mathf.Lerp(0, 45, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput) * 1.5f;
        float pitch = 0.0f;
        float roll = Mathf.Lerp(0, 45, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput) * 1.5f;

        transform.localRotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch + Vector3.forward * roll);
    }
}
