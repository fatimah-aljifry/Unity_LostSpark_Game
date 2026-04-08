using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public string correctPieceName;
    private PuzzleManager puzzleManager;

    private void Start()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
        if (puzzleManager == null)
        {
            Debug.LogError("PuzzleManager not found in the scene!");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        if (dropped != null)
        {
            Debug.Log("Dropped: " + dropped.name + " on zone: " + gameObject.name);
        }

        if (dropped != null && dropped.name == correctPieceName)
        {
            Debug.Log("Correct match! " + dropped.name + " matched " + correctPieceName);
            dropped.transform.position = transform.position;

            CanvasGroup canvasGroup = dropped.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.blocksRaycasts = false;
            }

            if (puzzleManager != null)
            {
                puzzleManager.RegisterCorrectMatch();
            }
            else
            {
                Debug.LogError("PuzzleManager reference is null!");
            }
        }
        else
        {
            Debug.Log("Incorrect match! Returning piece to original position.");
            Draggable draggable = dropped.GetComponent<Draggable>();
            if (draggable != null)
            {
                draggable.ReturnToOriginalPosition();
            }
        }
    }
}
