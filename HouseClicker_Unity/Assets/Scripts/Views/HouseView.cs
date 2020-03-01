using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;
using System;

public class HouseView : MonoBehaviour
{
    [SerializeField] private RawImage HouseRawImage = null;
    [SerializeField] private Button HouseButton = null;
    [SerializeField] private Slider HouseSlider = null;

    [SerializeField] private TextMeshProUGUI TotalRepairPointsText = null;

    private float _normalizedRepairPoint;

    public void Start()
    {
        Color houseRawImageColor =  HouseRawImage.color;
        houseRawImageColor.a = 1f;
        HouseRawImage.color = houseRawImageColor;
        HouseRawImage.CrossFadeAlpha(0, 0f, true);
        HouseRawImage.CrossFadeAlpha(1, 1f, true);

        HouseButton
            .OnClickAsObservable()
            .Subscribe(_ => IncreaseRepairPoints());

        EnableClick();
    }

    public void Update()
    {
        if (HouseButton.interactable && Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseRepairPoints();
        }
    }

    private void EnableClick()
    {
        HouseButton.interactable = true;
    }

    private void DisableClick()
    {
        HouseButton.interactable = false;
    }

    private void IncreaseRepairPoints()
    {
        _normalizedRepairPoint += 0.1f;

        UpdateRepairPointUi();

        TryToFinishRepair(); 
    }

    private void TryToFinishRepair()
    {
        if (_normalizedRepairPoint >= 1f)
        {
            DisableClick();

            Observable.Timer(TimeSpan.FromSeconds(1))
                .DoOnCompleted(() =>
                {
                    _normalizedRepairPoint = 0f;
                    UpdateRepairPointUi();
                    EnableClick();
                })
                .Subscribe();
        }
    }

    private void UpdateRepairPointUi()
    {
        HouseSlider.value = _normalizedRepairPoint;
        TotalRepairPointsText.text = string.Format("{0:#0.00}", _normalizedRepairPoint);
    }
}
