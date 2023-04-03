using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField]
    private GameObject hasProgressGameObject;

    [SerializeField]
    private Image barImage;
    private IHasProgress hasProgress;

    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();

        if (hasProgress == null)
        {
            Debug.LogError(
                "Game Object" + hasProgressGameObject + " does not implement IHasProgress"
            );
            return;
        }
        hasProgress.onProgressChanged += HasProgress_onProgressChanged;

        barImage.fillAmount = 0;
        Hide();
    }

    private void HasProgress_onProgressChanged(
        object sender,
        IHasProgress.onProgressChangedEventArgs e
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
