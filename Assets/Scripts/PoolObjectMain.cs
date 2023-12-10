using System;
using UnityEngine;
using System.Collections.Generic;


public class PoolObjectMain<T> where T: MonoBehaviour
{
    public T Prefab { get; }
    public bool AutoExpand { get; set; } // Авторасширяемый (если всего 6, то добавит 7)
    public Transform Container { get; } // куда будут складываться все объекты

    private List<T> _pool;

    private Transform _transformPoint { get; set; }


    public PoolObjectMain(T prefab, int count, Transform container, Transform transformPoint)
    {
        Prefab = prefab;
        Container = container;
        _transformPoint = transformPoint;

        CreatePool(count);
    }

    private void CreatePool(int count){
        _pool = new List<T>(); // Создаем пул
        for (int i =0; i < count; i++)
            CreateObject();
    }


    private T CreateObject(bool isActiveByDefault = false)
    // isActiveByDefault: когда создаем пул - объекты должны сразу быть false (отключены)
    // но когда нам нужно создать новый объект (если из 6 пуль мы создали 7 и т.д), то объект должен
    // быть включен -> будем передавать isActiveByDefault = true
    {
        var createdObject = UnityEngine.Object.Instantiate(Prefab, _transformPoint.position, _transformPoint.rotation, Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element, Transform shootPoint)
    // Спрашиваем, есть ли свободный элемент
    // out T element - можем сразу вытащить элемент, если он есть
    {
        foreach (var elementPool in _pool){
            if (!elementPool.gameObject.activeInHierarchy){
                element = elementPool;
                elementPool.transform.position = shootPoint.position; // Обновляем позицию и ротацию рули при активации
                elementPool.transform.rotation = shootPoint.rotation;
                elementPool.gameObject.SetActive(true); // Если свободен оюъект, сразу его активируем   
                return true;
                // Если объект не активен, то он свободен -> есть свободный элемент
            }  
        }

        element = null;
        return false;
    }

    public T GetFreeElement(Transform shootPoint)
    {
        if (HasFreeElement(out T element, shootPoint)) 
            return element; // Если есть свободный элемент, возвращаем объект element
        if (AutoExpand)
            return CreateObject(true); // Если авторасширяем, то создаем объект (сразу активным делаем true)
        throw new Exception($"There is no free elements in pool of type {typeof(T)}");

    }

    public void ReturnActiveElementInPool(T element)
    {
        element.gameObject.SetActive(false);
        element.transform.position = _transformPoint.position;

    }
}
