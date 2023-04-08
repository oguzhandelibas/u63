using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeEffect : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    [SerializeField] private Card card;
    [SerializeField] private float swipeDistance = 0.25f;
    private Vector3 _initialPosition;
    private float _distanceMoved;
    private bool _swipeLeft;
    
    public void OnDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.isGameContinue) return;
        card.OnSwipe();
        transform.localPosition = new Vector2(transform.localPosition.x+eventData.delta.x,transform.localPosition.y);

        if(transform.localPosition.x - _initialPosition.x > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -30, (_initialPosition.x + transform.localPosition.x) / (Screen.width / 2)));
            card.SetSwipeObjectActiveness(false, true);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, 30, (_initialPosition.x - transform.localPosition.x) / (Screen.width / 2)));
            card.SetSwipeObjectActiveness(true, false);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.isGameContinue) return;
        _initialPosition = transform.localPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.isGameContinue) return;
        card.SetSwipeObjectActiveness(false,false);
        

        _distanceMoved = Mathf.Abs(transform.localPosition.x - (_initialPosition.x));
        if(_distanceMoved< swipeDistance * Screen.width)
        {
            transform.localPosition = _initialPosition;
            transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            if (transform.localPosition.x > _initialPosition.x)
            {
                _swipeLeft = false;
                
            }
            else
            {
                _swipeLeft = true;
            }
            card.Swipe(!_swipeLeft);
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
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x-Screen.width,time),transform.localPosition.y,0);
            }
            else
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x+Screen.width,time),transform.localPosition.y,0);
            }
            GetComponent<Image>().color = new Color(1,1,1,Mathf.SmoothStep(1,0,4*time));
            yield return null;
        }
        Destroy(gameObject);
    }
}
