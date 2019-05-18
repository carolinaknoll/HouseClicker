using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

public class HouseView : MonoBehaviour
{
    [SerializeField] private RawImage HouseRawImage = null;
    [SerializeField] private Button HouseButton = null;
    [SerializeField] private Slider HouseSlider = null;

    [SerializeField] private TextMeshProUGUI TotalRepairPointsText = null;

    private float _totalRepairPoints;

    public void Start()
    {
        HouseButton
            .OnClickAsObservable()
            .Subscribe(_ => 
            {
                _totalRepairPoints += 0.1f;

                HouseSlider.value += 0.1f;

                TotalRepairPointsText.text = string.Format("{0:#0.00}", _totalRepairPoints);
            });
    }
}
