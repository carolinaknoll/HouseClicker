using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

public class HouseView : MonoBehaviour
{
    public RawImage HouseRawImage;
    public Button HouseButton;
    public Slider HouseSlider;

    public TextMeshProUGUI TotalRepairPointsText;

    private float _totalRepairPoints;

    public void Start()
    {
        HouseButton
            .OnClickAsObservable()
            .Subscribe(_ => 
            {
                _totalRepairPoints += 0.01f;

                Debug.LogError("Wololo");
                HouseSlider.value += 0.01f;

                TotalRepairPointsText.text = string.Format("{0:#0.00}", _totalRepairPoints);
            });
    }
}
