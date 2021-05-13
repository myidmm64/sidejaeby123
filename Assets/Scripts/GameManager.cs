using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }
    [SerializeField]
    private Text lifeText = null;
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text highScoreText = null;
    [Header("적 프리팹")]
    [SerializeField]
    private GameObject enemyPrefab = null;
    private float randomY = 0f;
    private float spawnDelay = 0f;
    private float life = 3f;
    private long score = 0;
    private long highScore = 0;

    private void Start()
    {
        MinPosition = new Vector2(-3f, -1.5f);
        MaxPosition = new Vector2(3f, 1.5f);
        StartCoroutine(SpawnEnemy());
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        UpdateUI();
        // TODO : 적 생성 코루틴을 실행하세요.
    }
    public void Hurt()
    {
        life--;
        UpdateUI();
        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void ScoreUp(long addScore)
    {
        score += addScore;
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGHSCORE", (int)highScore);

        }
        UpdateUI();
    }
    private IEnumerator SpawnEnemy()
    {
        GameObject enemy;
        while (true)
        {
            randomY = Random.Range(MinPosition.y-0.25f, MaxPosition.y+0.25f);
            spawnDelay = Random.Range(1f, 3f);
            for (int i = 0; i < 5; i++)
            {
                enemy = Instantiate(enemyPrefab, new Vector2(5f, randomY), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }


            yield return new WaitForSeconds(spawnDelay);
        }
        // TODO: 적을 생성하는 스크립트를 완성하세요.
        // 1) enemyPrefab에 들어갈 프리팹을 먼저 만들어야 합니다.
        // 2) enemyPrefab 변수를 Inspector에서 채워줘야 합니다.
        // 3) 적의 위치는 x 위치를 5f로 고정, y 위치는 랜덤으로 생성합니다.
        // 4) 적은 5마리를 같은 위치에 반복하여 생성합니다.
        // 5) 랜덤 위치 및 딜레이는 Random.Range()를 사용합니다.

    }

    private void UpdateUI()
    {
        lifeText.text = string.Format("LIFE {0}", life);
        scoreText.text = string.Format("SCORE {0}", score);
        highScoreText.text = string.Format("BEST {0}", highScore);
        // TODO: 이 함수에 UI를 새로고침하는 스크립트를 작성하세요.
        // 1) 점수가 올라가거나, 플레이어가 사망하면 이 함수를 실행합니다.
        // 2) UnityEngine.UI를 사용해서 씬의 Text들을 변수로 받아와야 합니다.
        // 3) string.Format()을 사용해서 씬에 있는 UI와 동일한 모양이 되도록 표시합니다.
    }
}
