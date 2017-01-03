using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class vrPersonController : MonoBehaviour {

    private float speed;

    // spline
    public BezierSpline spline;
    public BezierSpline spline_second;

    public float duration;
    public float duration_second;

    public float progress;
    public float progress_second;

    public bool lookForward;

    // mode
    public SplineWalkerMode mode;
    public SplineWalkerMode mode_second;
    private bool goingForward = true;

    public int course;

    // cource 1 , OBJECTS
    public GameObject ternel_environment;
    public GameObject start_environment;

    // engine audio
    private AudioSource m_MovementAudio;
    public float m_PitchRange = 0.2f;

    private float m_OriginalPitch;
    private Vector3 old_position;
    private Vector3 position_length;

    // light
    public Light light;

    // Use this for initialization
    void Start() {

        light.gameObject.SetActive(false);

        speed = 0.5f;
        course = 0;     // first course, second course ..

        m_MovementAudio = GetComponent<AudioSource>();
        // m_OriginalPitch = m_MovementAudio.pitch;

    }

    // Update is called once per frame
    void Update() {

        // if start, set course 1 
        // if first coures.
        if (course == 1)
        {
            // play movement audio
            if (!m_MovementAudio.isPlaying)
            {
                m_MovementAudio.Play();
            }
            course_first();
        }

        // second course
        else if (course == 2)
        {
            course_second();
        }

        position_length = old_position - transform.localPosition;
        old_position = transform.localPosition;
        //EngineAudio();
    }

    private void course_first()
    {
        // spline
        if (goingForward)
        {
            progress += Time.deltaTime / duration;
            if (progress > 1f)
            {
                // once
                if (mode == SplineWalkerMode.Once)
                {
                    progress = 1f;
                    // if onece go second cource
                    course = 2;
                    // clear cource 1 objecs
                    spline.gameObject.SetActive(false);
                    // Destroy(spline.gameObject);

                }
                // loop
                else if (mode == SplineWalkerMode.Loop)
                {
                    progress -= 1f;
                }
                // pingpong
                else
                {
                    progress = 2f - progress;
                    goingForward = false;
                }
            }

            if (progress > 0.1f)
            {
                // clear start objecs
                // start_environment.SetActive(false);
                Destroy(start_environment.gameObject);
            }

            if (progress > 0.447f)
            {
                // clear ternel objecs
                // ternel_environment.SetActive(false);
                Destroy(ternel_environment.gameObject);
                light.gameObject.SetActive(true);

            }

        }
        else
        {
            // going backward
            progress -= Time.deltaTime / duration;
            if (progress < 0f)
            {
                progress = -progress;
                goingForward = true;
            }
        }

        Vector3 position = spline.GetPoint(progress);

        transform.localPosition = position;
        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
    }


    private void course_second()
    {
        {

            // spline
            if (goingForward)
            {
                progress_second += Time.deltaTime / duration_second;
                if (progress_second > 1f)
                {
                    // once
                    if (mode_second == SplineWalkerMode.Once)
                    {
                        progress_second = 1f;
                    }
                    // loop
                    else if (mode_second == SplineWalkerMode.Loop)
                    {
                        progress_second -= 1f;
                    }
                    // pingpong
                    else
                    {
                        progress_second = 2f - progress_second;
                        goingForward = false;
                    }
                }
            }
            else
            {
                // going backward
                progress_second -= Time.deltaTime / duration;
                if (progress_second < 0f)
                {
                    progress_second = -progress_second;
                    goingForward = true;
                }
            }

            Vector3 position = spline_second.GetPoint(progress_second);

            transform.localPosition = position;
            if (lookForward)
            {
                transform.LookAt(position + spline_second.GetDirection(progress_second));
            }
        }
    }


    /*
    private void EngineAudio()
    {
        // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.
        if (Mathf.Abs(position_length.y) < 1f)
        {
            if (m_MovementAudio.clip == m_EngineDriving)
            {
                m_MovementAudio.clip = m_EngineIdling;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
        else
        {
            if (m_MovementAudio.clip == m_EngineIdling)
            {
                m_MovementAudio.clip = m_EngineDriving;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
    }
    */
    
}
