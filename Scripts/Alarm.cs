using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _minVolume = 0f;
    [SerializeField] private float _changeSpeed = 0.04f;

    private Security _security;
    private Coroutine _coroutine;

    private void Awake()
    {
        _security = GetComponent<Security>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _security.Entered += IncreaseVolume;
        _security.CameOut += DecreaseVolume;
    }

    private void OnDisable()
    {
        _security.Entered -= IncreaseVolume;
        _security.CameOut -= DecreaseVolume;
    }

    private void IncreaseVolume()
    {
        StartChangingVolume(_maxVolume);
    }

    private void DecreaseVolume()
    {
        StartChangingVolume(_minVolume);
    }

    private void StartChangingVolume(float targetVolume)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Count(targetVolume));
    }

    private IEnumerator Count(float targetVolume)
    {      
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _changeSpeed * Time.deltaTime);

            yield return null;
        }
    }  
}