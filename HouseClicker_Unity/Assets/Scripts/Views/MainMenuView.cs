using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _startButton = null;
    [SerializeField] private Button _exitButton = null;

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
