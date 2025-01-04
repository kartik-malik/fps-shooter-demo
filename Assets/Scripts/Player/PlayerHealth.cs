using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int health = 10;
    [SerializeField] GameObject gameOverCamera;

    [SerializeField] Transform healthBarsTransform;

    [SerializeField] GameObject healthBarImageObject;
    [SerializeField] Image[] barImages;

    [SerializeField] Sprite shieldBarSprite;

    [SerializeField] Transform healthBarGridContainer;


    int currentHealth;

    public int CurrentHealth { get { return currentHealth; } }

    private void Awake()
    {
        currentHealth = health;
        barImages = new Image[12];
    }

    void Start()
    {


        InitializeHealthBar(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {

        currentHealth -= amount;

        UpdateHealthBar(currentHealth);

        Debug.Log($"Player Health {currentHealth}");
        if (currentHealth <= 0)
        {
            Destroy(gameObject);

            gameOverCamera.SetActive(true);
        }
    }

    void InitializeHealthBar(int health)
    {
        int barsCount = health / 10;

        for (int i = 0; i < barsCount; i++)
        {
            GameObject obj = new GameObject("Bar(" + i.ToString() + ")");

            Image img = obj.AddComponent<Image>();
            img.sprite = shieldBarSprite;

            obj.transform.SetParent(healthBarGridContainer);


            barImages[i] = img;

        }

    }

    public void UpdateHealthBar(int health)
    {
        int barsCount = health / 10;



        for (int i = barsCount; i < barImages.Length; i++)
        {
            if (barImages[i] != null)
            {
                Debug.Log("Disabling  image");
                barImages[i].enabled = false;
            }
        }
    }
}
