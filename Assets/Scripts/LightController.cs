using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightController : MonoBehaviour
{
    public GameObject lightObject;
    public GameObject jumpscareObject;
    private GameSettings gameSettings;
    private Light lightComponent;
    private bool lightOn = false;
    private float lightDuration;
    private float originalIntensity;
    private bool jumpscareTriggered = false;

    //public InputAction aButtonPress;
    public InputActionReference aButtonPress;
    public bool isButtonPressed = false;

    private void Start()
    {
        gameSettings = FindObjectOfType<GameSettings>();
        gameSettings.SetDifficulty();
        lightObject.SetActive(false);
        jumpscareObject.SetActive(false);

        lightComponent = lightObject.GetComponent<Light>();
        originalIntensity = lightComponent.intensity;
        lightDuration = gameSettings.GetLightDuration();

        aButtonPress.action.started += ButtonPressFunc;
        //aButtonPress.action.canceled += ButtonPressFuncXD;
    }

    private void Update()
    {
        if (!lightOn && (isButtonPressed || Input.GetKeyDown(KeyCode.A)))
        {
            ToggleLight();
        }
    }

    void ButtonPressFunc(InputAction.CallbackContext context)
    {
        if (!lightOn)
        {
            ToggleLight();
        }        
    }
    //void ButtonPressFuncXD(InputAction.CallbackContext context)
    //{
    //    ToggleLight();
    //}

    private void ToggleLight()
    {
        if (gameSettings.lightUses > 0)
        {
            lightObject.SetActive(true);
            lightOn = true;
            gameSettings.lightUses--;
            StartCoroutine(TurnOffLightAfterDelay());

            
            if (gameSettings.lightUses == 3 && !jumpscareTriggered)
            {
                TriggerJumpscare();
            }
            else if (jumpscareTriggered)
            {
                ResetLightAndJumpscare();
            }
        }
    }

    private IEnumerator TurnOffLightAfterDelay()
    {
        yield return new WaitForSeconds(lightDuration);
        lightObject.SetActive(false);
        lightOn = false;
    }

    private void TriggerJumpscare()
    {
        jumpscareTriggered = true;

        lightComponent.intensity = 5;
        jumpscareObject.SetActive(true);
        jumpscareObject.GetComponent<AudioSource>().Play();

        
        StartCoroutine(DeactivateJumpscareAfterDelay());
    }

    private IEnumerator DeactivateJumpscareAfterDelay()
    {
        yield return new WaitForSeconds(1f);  
        jumpscareObject.SetActive(false);    
    }

    private void ResetLightAndJumpscare()
    {
        lightComponent.intensity = originalIntensity;

        
        jumpscareTriggered = false;
    }
}