using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Screen_Change : MonoBehaviour
{
    private PostProcessingBehaviour myPostProcessingBehaviour;
    private PostProcessingProfile postProcessingProfile;
    #region Border
    //border variables
    private VignetteModel vignetteModel;
    private VignetteModel.Settings vignetteModelSettings;
    //relevant to border
    public PlayerHealth player;
    #endregion

    #region Fade
    private ColorGradingModel colorGradingModel;
    private ColorGradingModel.Settings colorGradingSettings;
    public float offsetA;
    public float fadeSpeed;
    private Coroutine fadeToBlackCoroutine;
    #endregion
    // Use this for initialization
    private void OnEnable()
    {
        #region gets Prossesser
        myPostProcessingBehaviour = GetComponent<PostProcessingBehaviour>();
        if (myPostProcessingBehaviour == null)
        {
            Debug.Log("Post Processing Behaviour is missing on the camera");
        }
        postProcessingProfile = myPostProcessingBehaviour.profile;
        if (postProcessingProfile == null)
        {
            Debug.Log("Post Processing Behaviour is missing profile");
        }
        #endregion
        //event listener for border
        player.OnHealthChange += VignetteRedChange;
        vignetteModel = postProcessingProfile.vignette;
        vignetteModelSettings = vignetteModel.settings;
        colorGradingModel = postProcessingProfile.colorGrading;
        colorGradingSettings = colorGradingModel.settings;
        offsetA = colorGradingSettings.colorWheels.log.offset.a;
    }

    #region border functions
    //sets border intensity to match health
    private void VignetteRedChange(float obj)
    {
        vignetteModel.enabled = true;
        vignetteModelSettings.intensity = (((player.health / player.maxHealth) - 1) * -1);
        vignetteModel.settings = vignetteModelSettings;
    }
    //resets border intensity to 0
    private void VignetteRedChangeDisabled()
    {
        vignetteModelSettings.intensity = 0;
        vignetteModel.settings = vignetteModelSettings;
        vignetteModel.enabled = false;
    }
    #endregion

    #region fade Functions
    public IEnumerator FadeToBlack()
    {
        colorGradingModel.enabled = true;
        while (offsetA > -1)
        {
          offsetA -= fadeSpeed * Time.deltaTime;
          colorGradingSettings.colorWheels.log.offset.a = offsetA;
          colorGradingModel.settings = colorGradingSettings;
        }

        if (offsetA < -1f)
        {
            offsetA = -1f;
        }
        yield return null;
    }
    private void FadeToBlackDisable()
    {
        offsetA = 0.0f;
        if (offsetA > 0)
        {
            offsetA = 0;
        }
        colorGradingSettings.colorWheels.log.offset.a = offsetA;
        colorGradingModel.settings = colorGradingSettings;
        colorGradingModel.enabled = false;
    }
    #endregion
    
    // Update is called once per frame //testing code
    void Update()
    {
        colorGradingSettings.colorWheels.log.offset.a = offsetA;
        colorGradingModel.settings = colorGradingSettings;
        //offsetA -= 0.02f;
        if (Input.GetKeyDown(KeyCode.F))
        {
            fadeToBlackCoroutine = StartCoroutine(FadeToBlack());
        }
    }
    private void OnDisable()
    {
        VignetteRedChangeDisabled();
        FadeToBlackDisable();
    }

    
}
