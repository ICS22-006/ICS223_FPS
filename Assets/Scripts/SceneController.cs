using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Multiple enemies
    [SerializeField] private GameObject enemyPrefab;
    private Vector3 enemySpawnPoint = new Vector3(0, 0, 5);
    private int numOfEnemies;
    private GameObject[] enemies;

    // Multiple iguanas
    [SerializeField] private GameObject iguanaPrefab;
    private Vector3 iguanaSpawnPoint = new Vector3(5, 0, 5);
    private int numOfIguanas;
    private GameObject[] iguanas;

    // Code that handle events
    [SerializeField] private UIController ui;
    private int score = 0;

    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
        Messenger.AddListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger.AddListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
        Messenger.AddListener(GameEvent.RESTART_GAME, OnRestartGame);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.RemoveListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
        Messenger.RemoveListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
        Messenger.RemoveListener(GameEvent.RESTART_GAME, OnRestartGame);
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void OnPlayerDead()
    {
        ui.ShowGameOverPopup();
    }

    private void OnEnemyDead()
    {
        score++;
        ui.UpdateScore(score);
    }

    private void OnDifficultyChanged(int newDifficulty) 
    {
        Debug.Log("Scene.OnDifficultyChanged(" + newDifficulty + ")");
        for (int i = 0; i < enemies.Length; i++)
        {
            WanderingAI ai = enemies[i].GetComponent<WanderingAI>();
            ai.SetDifficulty(newDifficulty);
        }
    }

    public int GetDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty", 1);
    }

    private void Start()
    {
        ui.UpdateScore(score);
        numOfEnemies = 5;
        enemies = new GameObject[numOfEnemies];

        numOfIguanas = 1;
        iguanas = new GameObject[numOfIguanas];
        for (int i = 0; i < numOfIguanas; i++)
        {
            iguanas[i] = Instantiate(iguanaPrefab) as GameObject;
            iguanas[i].transform.position = iguanaSpawnPoint;
            float angle = Random.Range(0, 360);
            iguanas[i].transform.Rotate(0, angle, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            if (enemies[i] == null)
            {
                enemies[i] = Instantiate(enemyPrefab) as GameObject;
                enemies[i].transform.position = enemySpawnPoint;
                float angle = Random.Range(0, 360);
                enemies[i].transform.Rotate(0, angle, 0);
                WanderingAI ai = enemies[i].GetComponent<WanderingAI>();
                ai.SetDifficulty(GetDifficulty());
            }
        }
    }
}
