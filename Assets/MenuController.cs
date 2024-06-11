using UnityEngine;
using UnityEngine.UIElements;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private UIDocument _doc;  // 요 스크립트와 같은 게임 오브젝트에 있는 UI Document 컴포넌트 할당용
    private Button _playButton;
    private Button _storyButton;
    private Button _exitButton;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton");
        _playButton.clicked += PlayButtonOnClicked;

        _storyButton = _doc.rootVisualElement.Q<Button>("StroyButton");
        _storyButton.clicked += StoryButtonOnClicked;

        _exitButton = _doc.rootVisualElement.Q<Button>("ExitButton");
        _exitButton.clicked += ExitButtonOnClicked;
    }
    private void PlayButtonOnClicked()
    {
        SceneManager.LoadScene("HomeScene");
    }

    private void StoryButtonOnClicked()
    {
        SceneManager.LoadScene("StoryScene");
    }
    private void ExitButtonOnClicked()
    {
        Application.Quit();
    }
}