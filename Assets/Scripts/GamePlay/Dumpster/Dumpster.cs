using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
internal class Dumpster : MonoBehaviour
{
    private AudioSource _audioSource;
    private Animator _animator;

    public event UnityAction<float, float> ScrapCollected;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Bag bag))        
            CollectScrap(bag);                
    }

    private void CollectScrap(Bag bag)
    {
        if (bag.TryGet(out float weight, out float money))
        {
            _audioSource.Play();
            ScrapCollected?.Invoke(weight, money);
            _animator.SetTrigger(AnimatorNames.ScrapCollecting);
        }       
    }
}
