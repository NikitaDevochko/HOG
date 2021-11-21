using DG.Tweening;
using System;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public Action<string> OnFind = null;
    public string Name => name;
    public Sprite ItemSprite => spriteRenderer.sprite;

    [Header("General")]
    [SerializeField] private string name = string.Empty;

    [Header("Settings")]
    [SerializeField, Tooltip("end scale mode")] private float targetScaleModification = 1.2f;
    [SerializeField, Tooltip("scale animation speed")] private float scaleDuraction = 0.5f;
    [SerializeField, Tooltip("fade animation speed")] private float fadeDuraction = 0.5f;

    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer = null;

    private BoxCollider2D boxCollider = null;

    private void Awake()
    {
        boxCollider = gameObject.AddComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUpAsButton()
    {
        Find();
    }

    private void Find()
    {
        transform.DOScale(transform.localScale * targetScaleModification, scaleDuraction).OnComplete(() =>
        {
            spriteRenderer.DOFade(0f, fadeDuraction).OnComplete(() =>
            {
                OnFind.Invoke(Name);
                gameObject.SetActive(false);
            });
        });
    }
}