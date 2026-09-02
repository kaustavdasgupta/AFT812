using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasSwipeDetection : MonoBehaviour
{
    private Vector2 startTouchPosition;
    public float minSwipeDistance = 50f;
    private bool hasSwiped = false;
    public PlayerMovement playerMovement;

    public void ManualBeginDrag(BaseEventData axisData)
    {
        PointerEventData eventData = axisData as PointerEventData;
        if (eventData == null) return;

        hasSwiped = false;
        startTouchPosition = eventData.position;
    }

    public void ManualDrag(BaseEventData axisData)
    {
        if (hasSwiped) return;

        PointerEventData eventData = axisData as PointerEventData;
        if (eventData == null) return;

        Vector2 currentTouchPosition = eventData.position;
        Vector2 distance = currentTouchPosition - startTouchPosition;

        if (distance.magnitude >= minSwipeDistance)
        {
            hasSwiped = true;

            if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
            {
                if (distance.x > 0) OnSwipeRight();
                else OnSwipeLeft();
            }
            else
            {
                if (distance.y > 0) OnSwipeUp();
                else OnSwipeDown();
            }
        }
    }

    public void ManualEndDrag(BaseEventData axisData)
    {
        hasSwiped = false;
    }

    void OnSwipeLeft()
    {
        Debug.Log("Swipe Left Registered!");
        playerMovement.MoveLeft();
    }
    void OnSwipeRight() 
    {
        Debug.Log("Swipe Right Registered!");
        playerMovement.MoveRight();
    }
    void OnSwipeUp() 
    {
        Debug.Log("Swipe Up Registered!");
        playerMovement.Jump();
    }
    void OnSwipeDown() 
    {
        Debug.Log("Swipe Down Registered!");
    }
}