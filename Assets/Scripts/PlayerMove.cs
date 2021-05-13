using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region 다음 변수를 사용하세요
    [Header("이동 속도")]
    [SerializeField]
    private float speed = 2f;
    [Header("총알 프리팹")]
    [SerializeField]
    private GameObject bulletPrefab = null;
    [Header("총알 발사간격")]
    [SerializeField]
    private float bulletDelay = 0.5f;
    #endregion

    #region 변경금지
    private Animator animator = null;
    private void SetAnimation(Vector2 targetPosition) {
        if(!animator) animator = GetComponent<Animator>();
        if (transform.position.x > targetPosition.x) {
            animator.Play("Player_Left");
        }
        else if (transform.position.x < targetPosition.x) {
            animator.Play("Player_Right");
        }
        else {
            animator.Play("Player_Idle");
        }
    }
    #endregion
    [SerializeField]
    private Transform bulletPosition = null;
    private Vector2 targetPosition = Vector2.zero;
    private GameManager gamemanager = null;
    private SpriteRenderer spriteRenderer = null;
    private Collider2D col = null;

    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        StartCoroutine(Fire());
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // TODO: GameManager를 가져오세요.
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SetAnimation(targetPosition);
            if(transform.localPosition.x < gamemanager.MinPosition.x-0.5f)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (transform.localPosition.x > gamemanager.MaxPosition.x+0.5f)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (transform.localPosition.y < gamemanager.MinPosition.y-0.25f)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            if (transform.localPosition.y > gamemanager.MaxPosition.y+0.25f)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
            // TODO: 경계 영역을 GameManager에서 가져오세요.
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    private IEnumerator Fire()
    {
        GameObject bullet;
        while (true)
        {
            bullet = Instantiate(bulletPrefab, bulletPosition);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(bulletDelay);
        }
        // TODO: 총알 발사 스크립트를 작성해 주세요.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Dead());
        gamemanager.Hurt();
        // TODO : 플레이어가 사망하면 라이프를 줄이고, 다 잃으면 GameOver 씬으로 이동하게 만드세요.
        // 1) UI에 있는 Life를 바꿔서 표시해야 합니다.
        // 2) 무적시간이 존재해야 합니다. (사망한 상태에서 다시 사망하면 안됩니다.)
        // 3) 사망시 깜박이는 애니메이션을 보여줘야 합니다. (spriteRenderer를 사용합니다.)
    }

    private IEnumerator Dead()
    {
        col.enabled = false;
        for(int i = 0; i<5; i++)
        {
            spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        col.enabled = true;
        // TODO : 사망 애니메이션을 작성하세요.
        // 1) 반복문을 사용하여 5회 반짝이게 만듭니다.
        // 2) 사망 애니메이션 재생 중에는 무적 상태가 되어야 합니다.
        // 3) 사망 애니메이션이 종료하면 무적 상태를 해제해야 합니다.
    }
}
