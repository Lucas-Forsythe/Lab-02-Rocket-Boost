using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float ReloadWait = 0.5f;
    [SerializeField] AudioClip succesSFX;
    [SerializeField] AudioClip failureSFX;
    [SerializeField] ParticleSystem successFX;
    [SerializeField] ParticleSystem failureFX;

    AudioSource audioSource;

    bool isControllable = true;
    bool canCrash = true;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isControllable || !canCrash)
        { return; }
        switch (collision.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("This thing is friendly");
                    break;
                case "Finish":
                    startWinSequence();
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
    }

    void Update()
    {
        DebugKey();
    }

    void DebugKey()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            loadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            canCrash = !canCrash;
        }
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void loadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        failureFX.Play();
        audioSource.PlayOneShot(failureSFX);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", ReloadWait);
    }

    void startWinSequence()
    {
        isControllable = false;
        audioSource.Stop();
        successFX.Play();
        audioSource.PlayOneShot(succesSFX);
        GetComponent<Movement>().enabled = false;
        Invoke("loadNextLevel", ReloadWait);
    }
}