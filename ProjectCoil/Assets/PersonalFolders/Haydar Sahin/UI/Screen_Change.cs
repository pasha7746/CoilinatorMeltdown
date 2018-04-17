using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Screen_Change : MonoBehaviour
{
    private PostProcessingBehaviour myPostProcessingBehaviour;
    private PostProcessingProfile postProcessingProfile;
    //relevant to border
    public PlayerHealth player;
    // Use this for initialization
    private void OnEnable()
    {
        #region border veriable set
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
    }

    #region border functions
    //sets border intensity to match health
    private void VignetteRedChange(float obj)
    {
        VignetteModel vignetteModel = postProcessingProfile.vignette;
        vignetteModel.enabled = true;
        VignetteModel.Settings vignetteModelSettings = vignetteModel.settings;
        vignetteModelSettings.intensity = (((player.health / player.maxHealth)-1)*-1);
        vignetteModel.settings = vignetteModelSettings;
    }
    //resets border intensity to 0
    private void VignetteRedChangeDisabled()
    {
        VignetteModel vignetteModel = postProcessingProfile.vignette;
        VignetteModel.Settings vignetteModelSettings = vignetteModel.settings;
        vignetteModelSettings.intensity = 0;
        vignetteModel.settings = vignetteModelSettings;
        vignetteModel.enabled = false;
    }
    #endregion
    
    // Update is called once per frame //testing code
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
		    player.ChangeHealth(-5.0f);
		}
	}

    private void OnDisable()
    {
        VignetteRedChangeDisabled();
    }

    
}
