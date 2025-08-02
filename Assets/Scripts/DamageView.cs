using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DamageView : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _textMeshPro;
    [SerializeField]
    CanvasGroup group;

    public void Initialize(int damage)
    {
        _textMeshPro.text = damage.ToString();
        transform.DOLocalMoveY(3, 2);
        group.DOFade(0, 2);
    }
}
