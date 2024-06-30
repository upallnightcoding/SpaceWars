using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCntrl : MonoBehaviour
{
    [SerializeField] private float damping;
    [SerializeField] private InputCntrl inputCntrl;

    private float speed = 5.0f;

    private Vector3 delta;
    private Vector3 movePosition;
    private Vector3 velocity = Vector3.zero;
    private Transform player;

    private float py = 0.0f;

    private Vector2 Move { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame(Transform player)
    {
        this.player = player;
        delta = player.position - transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //Debug.Log($"Player Position: {player.position}");

        if (player != null)
        {
            movePosition = player.position - delta;

            transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);

            //Vector3 targetDirection = new Vector3(player.forward.x, 0.0f, player.forward.z);
            //float singleStep = speed * Time.deltaTime;
            //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            //transform.rotation = Quaternion.LookRotation(newDirection)

       
            //float turn = -player.transform.localRotation.eulerAngles.y * Mathf.Abs(inputCntrl.Move.x);
            float turn = -player.transform.localRotation.eulerAngles.y;

            //transform.rotation = Quaternion.Euler(90.0f, 0.0f, turn * 0.5f);
            //Debug.Log($"Rotation: {player.transform.localRotation.eulerAngles.y}");

            py = Mathf.Abs(player.transform.localRotation.eulerAngles.y);
        }

    }
}
