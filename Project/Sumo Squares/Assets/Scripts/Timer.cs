using UnityEngine;

/// <summary>
/// A general purpose timer script.
/// </summary>
public class Timer : MonoBehaviour
{
    public float Seconds;
    private float _secondsRemaining;
    private bool _timerActive;

	// Use this for initialization
	void Start ()
	{
	    _secondsRemaining = Seconds;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (_secondsRemaining > float.Epsilon && LevelController.MatchActive && _timerActive)
	    {
	        _secondsRemaining -= Time.deltaTime;
	    }
	}

    public float GetSecondsRemaining()
    {
        return _secondsRemaining;
    }

    /// <summary>
    /// Pauses a running timer.
    /// </summary>
    public void PauseTimer()
    {
        _timerActive = false;
    }

    /// <summary>
    /// Resumes a paused timer.
    /// </summary>
    public void ResumeTimer()
    {
        _timerActive = true;
    }

    /// <summary>
    /// Pauses, resets and resumes a timer.
    /// </summary>
    public void ResetTimer()
    {
        PauseTimer();
        _secondsRemaining = Seconds;
        ResumeTimer();
    }

    /// <summary>
    /// Pauses, resets to the specified seconds and resumes a timer.
    /// </summary>
    /// <param name="seconds">The number of seconds to reset the timer to.</param>
    public void ResetTimer(float seconds)
    {
        PauseTimer();
        Seconds = seconds;
        _secondsRemaining = Seconds;
        ResumeTimer();
    }

    /// <summary>
    /// Stops a timer and sets the current time remaing back to the original.
    /// </summary>
    public void StopTimer()
    {
        PauseTimer();
        _secondsRemaining = Seconds;
    }
}
