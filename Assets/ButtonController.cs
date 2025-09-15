using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void PlaySound()
    {
        if (AudioManager.Instance == null) return;
        AudioManager.Instance.PlaySFX(AudioManager.Instance.SelectSFX);
    }
    public void PlayClick()
    {
        if (AudioManager.Instance == null) return;
        AudioManager.Instance.PlaySFX(AudioManager.Instance.UISFX);
    }
}
