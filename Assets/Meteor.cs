using UnityEngine;

public class Meteor : MonoBehaviour
{
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        FindObjectOfType<TreasureHuntManager>().ShowLosePanel();
    }
}

}

