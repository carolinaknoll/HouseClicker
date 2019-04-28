using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class HouseView : MonoBehaviour
{
    public RawImage HouseRawImage;
    public Button HouseButton;
    public Slider HouseSlider;

    public void Start()
    {
        HouseButton
            .OnClickAsObservable()
            .Subscribe(_ => 
            {
                Debug.LogError("Wololo");
                HouseSlider.value += 0.01f;
            });
    }
}
