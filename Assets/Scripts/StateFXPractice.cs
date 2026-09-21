using UnityEngine;
using UnityEngine.Audio;
public class StateFXPractice : MonoBehaviour
{
    [SerializeField] ParticleSystem practiceFX;
    [SerializeField] AudioClip magic;
    AudioSource audioSource;
    bool effectActive = false;

    void Start()
    {
        practiceFX.Stop();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        RespondToDebugKeys();
    }
    void RespondToDebugKeys()
    {
        // P: start the effect only if it is not already active
        // R: reset the practice state and stop the particles
        if (Input.GetKeyDown(KeyCode.P) && !effectActive)
        {
            ActivateEffect();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetEffect();
        }
    }
    void ActivateEffect()
    {
        // set the state
        // play the particles
        // print a useful Console message
        effectActive = true;
        practiceFX.Play();
        Debug.Log("Effect activated.");
        audioSource.PlayOneShot(magic);
    }
    void ResetEffect()
    {
        // reset the state
        // stop the particles
        // print a useful Console message
        effectActive = false;
        practiceFX.Stop();
        Debug.Log("Effect reset.");
        audioSource.Stop();
    }

    /*Answers to questions
     * Why do we need effectActive?
        * This creates a constant to prevent the constant resarting if someone repeatedly presses 'P'.
     * What is the difference between ParticleSystem.Play() and enabling the entire GameObject?
        * This lets the game object remain acitve and shut just the particle system component off. In the lab we will always want an active player but not always particles.
     * Why is RespondToDebugKeys() separated from Update()?
        * This keeps Update() organized and lets us separate code for handling debug inputs.
     * What advantage do ActivateEffect() and ResetEffect() give us compared with putting all code inside Update()?
         * This gives us clear functions to call and modify and again keeps Update() organized. We can also now call these functions outside of update.
     */
}