using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] GameSession gameSession;
    [SerializeField] private GameObject heartIconPrefab;
    private List<GameObject> heartIcons = new List<GameObject>();


    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon = Instantiate(heartIconPrefab, transform);
            heartIcons.Add(newIcon);
        }
    }

    public void DisplayHealth(int health)
    {
        for(int i = 0; i < heartIcons.Count; i++)
        {
            if (i < health)
                heartIcons[i].SetActive(true);
            else
                heartIcons[i].SetActive(false);
        }

    }
}
