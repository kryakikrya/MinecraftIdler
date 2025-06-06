using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    [SerializeField] GameObject _particle;

    public void ClickEffect(Vector2 position)
    {
        GameObject _effect = Instantiate(_particle, position, Quaternion.identity);
        StartCoroutine(Deactivator(_effect));
    }

    public IEnumerator Deactivator(GameObject _object)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(_object);
        yield return null;
    }
}
