using System.Collections;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject lightObject;
    private GameSettings gameSettings;
    private bool lightOn = false;
    private float lightDuration;

    private void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
        gameSettings.SetDifficulty();
        lightObject.SetActive(false);
        lightDuration = gameSettings.GetLightDuration();
    }

    private void Update()
    {
        if (!lightOn && (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.A)))
        {
            ToggleLight();
        }
    }

    private void ToggleLight()
    {
        if (gameSettings.lightUses > 0)
        {
            lightObject.SetActive(true);
            lightOn = true;
            gameSettings.lightUses--;
            StartCoroutine(TurnOffLightAfterDelay());
        }
    }

    private IEnumerator TurnOffLightAfterDelay()
    {
        yield return new WaitForSeconds(lightDuration);
        lightObject.SetActive(false);
        lightOn = false;
    }
}