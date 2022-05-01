using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI hpText;

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    List<GameObject> bullets;

    GameObject player;
    PlayerBullet pb;

    float enemyRange = 4.3f;

    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        var choosenIndex = StateManager.Instance.playerType;
        var playerGO = choosenIndex < bullets.Count ? bullets[choosenIndex] : bullets[0];
        player = Instantiate(playerGO);
        pb = player.GetComponent<PlayerBullet>();

        InvokeRepeating("SpawnEnemy", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = $"HP: {pb.hp}";
    }

    void SpawnEnemy()
    {
        if (isGameOver) return;

        float x = Random.Range(-enemyRange, enemyRange);

        Instantiate(enemy, new Vector3(x, enemy.transform.position.y, enemy.transform.position.z), enemy.transform.rotation);
    }

    public void GameOver()
    {
        isGameOver = true;
    }

}
