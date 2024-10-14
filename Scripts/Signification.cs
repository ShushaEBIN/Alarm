using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signification : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _changeSpeed = 0.05f;

    private bool _isInside = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isInside == true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _changeSpeed * Time.deltaTime);
        }
        else
        {
            _audioSource.volume -= _changeSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Thief>(out Thief component))
        {
            _isInside = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Thief>(out Thief component))
        {
            _isInside = false;
        }
    }
}