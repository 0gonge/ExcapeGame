using UnityEngine;
using UnityEngine.UIElements;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StroiesController : MonoBehaviour
{
    private UIDocument _doc;  // 요 스크립트와 같은 게임 오브젝트에 있는 UI Document 컴포넌트 할당용
    private Button _backButton;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _backButton = _doc.rootVisualElement.Q<Button>("Back_button");
        _backButton.clicked += PlayButtonOnClicked;
    }
    private void PlayButtonOnClicked()
    {
        SceneManager.LoadScene("StartScene");
    }
}