using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _startButton
            .OnClickAsObservable()
            .Subscribe(_ => 
            {
                SceneManager.LoadScene("play_scene");
            });

        _exitButton
            .OnClickAsObservable()
            .Subscribe(_ => 
            {
                Application.Quit();
            });
    }
}
