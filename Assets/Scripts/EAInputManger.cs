using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EAInputManger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        EnemyCardManager.instance.MoveCard(eventData.position);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<cardView>() != null)
            {
                EnemyCardManager.instance.SetSelectedCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<cardView>());
            }
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        EnemyCardManager.instance.ReleseCard();
    }
}