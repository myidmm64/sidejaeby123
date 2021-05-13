using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [Header("이동 속도")]
    [SerializeField]
    private float speed = 10f;
    private GameManager gamemanager = null;
    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        // TODO : GameManager를 가져오세요.
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if(transform.localPosition.x > gamemanager.MaxPosition.x+1.5f)
        {
            Destroy(gameObject);
        }
    }

    // TODO: 총알이 경계영역에서 벗어나면 사라지게 작성해 보세요.
    // 1) 경계영역은 GameManager에 있는 것을 사용해야 합니다.
}
