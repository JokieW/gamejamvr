using UnityEngine;
using System.Collections;

public class CompCache<T>
{
    private GameObject _target;
    private T _ref;

    public T get
    {
        get
        {
            if (_ref == null)
            {
                _ref = _target.GetComponent<T>();
            }
            return _ref;
        }
    }

    private CompCache(){}
    public CompCache(GameObject go)
    {
        _target = go;
    }
}
