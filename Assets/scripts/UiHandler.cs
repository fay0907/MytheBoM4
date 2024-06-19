using UnityEngine;

public class UiHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;
    public bool mouseHasTower = false;

    public void Tower(int towerNumber)
    {
        if (!mouseHasTower)
        {
            mouseHasTower  = true;
            Instantiate(towers[towerNumber]);
        }
    }
}
