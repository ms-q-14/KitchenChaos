using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField]
    private CuttingCounter cuttingCounter;

    [SerializeField]
    private Image barImage;

    private void Start()
    {
        cuttingCounter.onProgressChanged += CuttingCounter_onProgressChanged;

        barImage.fillAmount = 0;
        Hide();
    }

    private void CuttingCounter_onProgressChanged(
        object sender,
        CuttingCounter.onProgressChangedEventArgs e
    )
    {
        barImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 1)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
