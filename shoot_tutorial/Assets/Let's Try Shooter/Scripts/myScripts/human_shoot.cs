using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class human_shoot : MonoBehaviour {
    
    //The human's current health point total
    public int currentHealth = 5;

    public GameObject target;
    public Slider healthslider;

    public GameObject m_ExplosionPrefab;

    public GameObject gameManager;

    public int targetScore = 40;
    public int finishScore = 150;

    private gameManager gameManager_script;

    private AudioSource m_ExplosionAudio;
    private ParticleSystem m_ExplosionParticles;
    private Renderer visible;

    private AudioSource m_hitAudio;

    void Start()
    {
        visible = GetComponent<Renderer>();
        visible.enabled = false;

        m_hitAudio = GetComponent<AudioSource>();
        gameManager_script = gameManager.GetComponent<gameManager>();
    }

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = Instantiate(m_ExplosionPrefab).GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;
        if (healthslider != null)
        {
            m_hitAudio.Play();
            healthslider.value = currentHealth;
        }
        // score
        gameManager_script.score += targetScore;

        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            // score
            gameManager_script.score += finishScore;

            m_ExplosionParticles.transform.position = target.transform.position;
            m_ExplosionParticles.gameObject.SetActive(true);

            m_ExplosionParticles.Play();

            m_ExplosionAudio.Play();

            //if health has fallen below zero, deactivate it 
            target.SetActive(false);
            //Destroy(target.gameObject);
        }
    }
}
