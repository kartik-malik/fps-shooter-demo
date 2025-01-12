using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int health = 100;

    [SerializeField] int lessHealthEffect = 30;
    [SerializeField] GameObject gameOverCamera;

    [SerializeField] Transform healthBarsTransform;

    [SerializeField] GameObject healthBarImageObject;
    [SerializeField] Image[] barImages;

    [SerializeField] Sprite shieldBarSprite;

    [SerializeField] Transform healthBarGridContainer;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject crossHair;
    [SerializeField] GameObject vignetteZoom;


    [SerializeField] StarterAssetsInputs starterAssetsInputs;

    [SerializeField] Volume globalVolume;

    ColorAdjustments colorAdjustments;
    ChannelMixer channelMixer;




    int currentHealth;

    public int CurrentHealth { get { return currentHealth; } }

    private void Awake()
    {
        currentHealth = health;
        barImages = new Image[12];
    }

    void Start()
    {

        starterAssetsInputs = GetComponent<StarterAssetsInputs>();

        InitializeHealthBar(currentHealth);

        VolumeProfile volumeProfile = globalVolume.sharedProfile;

        volumeProfile.TryGet<ChannelMixer>(out channelMixer);
        volumeProfile.TryGet<ColorAdjustments>(out colorAdjustments);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount)
    {

        currentHealth = Mathf.Max(currentHealth - amount, 0);

        UpdateHealthBar(currentHealth);


        if (currentHealth <= lessHealthEffect)
        {
            OnLessHealth();
        }

        // Debug.Log($"Player Health {currentHealth}");
        if (currentHealth <= 0)
        {

            gameOverCamera.SetActive(true);
            Invoke("OnGameOver", 1f);
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
                // Debug.Log($"Disabling  image ${i}");
                barImages[i].enabled = false;
            }
        }
    }

    public void OnGameOver()
    {
        crossHair.SetActive(false);
        gameOverScreen.SetActive(true);
        starterAssetsInputs.SetCursorState(false);
        vignetteZoom.SetActive(false);
        Destroy(gameObject);

    }

    public void OnLessHealth()
    {

        colorAdjustments.postExposure.Override(-0.13f);
        channelMixer.active = true;

    }

    void OnDestroy()
    {
        colorAdjustments.postExposure.Override(0.2f);
        channelMixer.active = false;

    }
}
