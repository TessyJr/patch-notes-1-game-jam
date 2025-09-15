using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _achievementName;
    [SerializeField] private Image _iconImage;
    [SerializeField] Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private Queue<(string name, Sprite icon)> _popupQueue = new Queue<(string, Sprite)>();
    private bool _isShowing = false;

    public void ShowPopup(string name, Sprite icon)
    {
        _popupQueue.Enqueue((name, icon));
        if (!_isShowing)
        {
            StartCoroutine(ProcessQueue());
        }
    }

    private IEnumerator ProcessQueue()
    {
        _isShowing = true;
        while (_popupQueue.Count > 0)
        {
            var popup = _popupQueue.Dequeue();
            _achievementName.text = popup.name;
            _iconImage.sprite = popup.icon;
            _animator.SetTrigger("Pop");
            yield return new WaitForSeconds(1f); // Slight delay to ensure animation starts
            _audioSource.Play();
            // Wait for animation to finish (adjust duration as needed)
            yield return new WaitForSeconds(3f);
        }
        _isShowing = false;
    }
}
