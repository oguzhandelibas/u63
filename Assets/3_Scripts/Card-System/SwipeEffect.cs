﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeEffect : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public Transform cardTransform;
    [SerializeField] private Card card;
    [SerializeField] private float swipeDistance = 0.25f;
    private Vector3 _initialPosition;
    private float _distanceMoved;
    private bool _swipeLeft;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = cardTransform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        card.OnSwipe();
        cardTransform.localPosition = new Vector2(cardTransform.localPosition.x+eventData.delta.x, cardTransform.localPosition.y);
        card.shadow.enabled = false;
        if (cardTransform.localPosition.x - _initialPosition.x > 0)
        {
            cardTransform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -30, (_initialPosition.x + cardTransform.localPosition.x) / (Screen.width / 2)));
            card.SetSwipeObjectActiveness(false, true);
        }
        else
        {
            cardTransform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, 30, (_initialPosition.x - cardTransform.localPosition.x) / (Screen.width / 2)));
            card.SetSwipeObjectActiveness(true, false);
        }
        IndicatorManager.Instance.IndicatorCircleActiveness(card.IndicatorCircleActivenessValue());
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        card.SetSwipeObjectActiveness(false,false);
        IndicatorManager.Instance.IndicatorCircleActiveness();

        _distanceMoved = Mathf.Abs(cardTransform.localPosition.x - (_initialPosition.x));
        if(_distanceMoved< swipeDistance * Screen.width)
        {
            cardTransform.localPosition = _initialPosition;
            cardTransform.localEulerAngles = Vector3.zero;
            card.shadow.enabled = true;
        }
        else
        {
            if (cardTransform.localPosition.x > _initialPosition.x)
            {
                _swipeLeft = false;
                
            }
            else
            {
                _swipeLeft = true;
            }

            if (card.cardManager.cards.Count > 1)
            {
                card.cardManager.cards[1].transform.localScale = new Vector3(1, 1, 1);
                card.cardText.gameObject.SetActive(false);
            }
            StartCoroutine(MovedCard());
        }
    }

    private IEnumerator MovedCard()
    {
        float time = 0;
        
        while (GetComponent<Image>().color != new Color(1, 1, 1, 0))
        {
            time += Time.deltaTime;
            if (_swipeLeft)
            {
                cardTransform.localPosition = new Vector3(Mathf.SmoothStep(cardTransform.localPosition.x,
                    cardTransform.localPosition.x-Screen.width,time), cardTransform.localPosition.y,0);
            }
            else
            {
                cardTransform.localPosition = new Vector3(Mathf.SmoothStep(cardTransform.localPosition.x,
                    cardTransform.localPosition.x+Screen.width,time), cardTransform.localPosition.y,0);
            }
            GetComponent<Image>().color = new Color(1,1,1,Mathf.SmoothStep(1,0,4*time));
            
            yield return null;
        }
        if (GameManager.Instance.gameDone) GameManager.Instance.RestartGame();
        if (card.cardManager.cards.Count > 1)
        {
            card.cardManager.cards[1].GetComponent<Card>().cardText.gameObject.SetActive(true);
        }
        card.RemoveCard();
        card.Swipe(_swipeLeft);
        Destroy(gameObject);
    }
}
