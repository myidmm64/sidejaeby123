using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore = null;

    private void Start()
    {
        // TODO: 최고점수를 textHighScore에 표시하세요.
        // 1) 점수 형식은 string.Format("HIGHSCORE {0}", ???)을 사용합니다.
    }

    private void OnClickStart()
    {
        // TODO : 시작 버튼을 클릭하면 Main 씬을 불러오게 하세요.
        // 1) 버튼에 Function을 붙이고 실행하는 부분은 직접 유니티에서 합니다.
    }
}
