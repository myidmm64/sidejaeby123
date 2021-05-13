using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    #region 다음의 변수를 사용합니다
    [Header("획득 점수")]
    [SerializeField]
    private int score = 100;
    [Header("적 HP")]
    [SerializeField]
    private int hp = 2;
    [Header("적 이동속도")]
    [SerializeField]
    private float speed = 5f;

    private GameManager gameManager = null;
    private Animator animator = null;
    private Collider2D col = null;
    #endregion    
    // WARNING: 같은 기능을 하는 다른 변수를 임의로 작성하여 만들 경우, 구현하지 못한 것으로 간주합니다.
    // 1) 주어지지 않았지만 구현에 필요한 변수는 직접 작성합니다.

    private void Start()
    {
        // TODO: 변수 gameManager에 GameManager를 찾아서 넣는 스크립트를 작성합니다.
        // TODO: 변수 animator에 Animator를 가져오는 스크립트를 작성합니다.
        // TODO: 변수 col에 Collider2D를 가져오는 스크립트를 작성합니다.
    }

    private void Update()
    {
        // TODO: 적이 이동하는 스크립트를 작성합니다.
        // 1) 적은 일정한 속도로 왼쪽으로 계속 움직입니다.
        // 2) 사망한 경우 적은 움직이지 않습니다.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: 플레이어의 총알에 부딪히면 데미지를 받는 스크립트를 작성합니다.
        // 1) 부딪힌 대상이 총알인 경우 총알을 없애고 데미지를 받습니다.
        // 2) 데미지를 받은 적은 Damaged 코루틴을 실행합니다. (무적 체크 필요)
        // 3) hp가 0 이하가 되면 Dead 코루틴을 실행합니다. (무적 체크 필요)
    }

    private IEnumerator Damaged()
    {
        // TODO: 데미지 연출 스크립트를 작성합니다.
        // 1) 데미지 입는 동안은 다시 데미지를 입지 않습니다.
        // 2) spriteRenderer.material을 사용하여 적의 색깔을 바꿔 데미지 연출을 표시합니다. (작동이 안 될 경우 스크립트로 판단)        
        yield return new WaitForSeconds(0.1f);
        // TODO: 원래 색깔로 돌려놓고 무적 상태를 해제합니다.
    }

    private IEnumerator Dead()
    {
        // TODO: 폭발 연출 스크립트를 작성합니다.        
        // 1) animator를 사용하여 폭발 애니메이션을 다 보여준 후 Destroy합니다. (폭발 애니메이션 이름 : Explosion)
        // 2) 폭발 애니메이션에 플레이어가 부딪히면 안 됩니다. (col을 사용하여 충돌체를 끕니다.)
        // 3) 폭발 애니메이션의 색깔을 초기화해야 합니다.

        yield return new WaitForSeconds(0.5f);
    }
}
