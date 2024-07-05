using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject fighterPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private CameraCntrl cameraCntrl;

    private EnemyManager enemyManager = null;

    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();

        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MainMenu()
    {

    }

    public void NewGame()
    {
        GameObject fighter = CreateFighter(fighterPrefab);

        //cameraCntrl.StartGame(fighter.transform);

        StartCoroutine(RotateFighter(fighter));
    }

    public void PlayRound()
    {
        StartCoroutine(SetupPlayCamera());
    }

    /**
    * CreateFighter() -
    */
    private GameObject CreateFighter(GameObject fighterPrefab)
    {
        return (Instantiate(fighterPrefab, new Vector3(), Quaternion.identity));
    }

    private IEnumerator RotateFighter(GameObject fighter)
    {
        float timing = 0.0f;
        float transitionTime = 2.0f;

        while (timing <= transitionTime)
        {
            float delta = timing / transitionTime;

            float ry = Mathf.Lerp(0.0f, 180.0f, delta);

            fighter.transform.rotation = Quaternion.Euler(0.0f, ry, 0.0f);

            timing += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator SetupPlayCamera()
    {
        float timing = 0.0f;
        float transitionTime = 2.0f;

        while (timing <= transitionTime)
        {
            float delta = timing / transitionTime;

            float cy = Mathf.Lerp(20.0f, 250.0f, delta);
            float cz = Mathf.Lerp(-35.0f, 0.0f, delta);
            float px = Mathf.Lerp(30.0f, 90.0f, delta);

            cameraTransform.position = new Vector3(0.0f, cy, cz);
            cameraTransform.rotation = Quaternion.Euler(px, 0.0f, 0.0f);

            timing += Time.deltaTime;
            yield return null;
        }

        EventManager.Instance.InvokeOnDisplayPlayRoundPanel();
    }

    private void OnEnable()
    {
        EventManager.Instance.OnPlayRound += PlayRound;
        EventManager.Instance.OnDisplayNewGamePanel += NewGame;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnPlayRound -= PlayRound;
        EventManager.Instance.OnDisplayNewGamePanel -= NewGame;
    }
}