using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform parentRect;

    private Vector2 basePos;

    private Vector2 startPos;
    private Vector2 moveOffset;

    void Awake()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startPos;
        parentRect.anchoredPosition = basePos + moveOffset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        parentRect.SetAsLastSibling();
        basePos = parentRect.anchoredPosition;
        startPos = eventData.position;
    }
}
