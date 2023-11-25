using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectMain<T> where T: MonoBehaviour
{
    public T Prefab { get; }
    public bool AutoExpand { get; set; } // ��������������� (���� ����� 6, �� ������� 7)
    public Transform Container { get; } // ���� ����� ������������ ��� �������

    private List<T> _pool;

    public PoolObjectMain(T prefab, int count)
    {
        this.Prefab = prefab;
        this.Container = null;

        CreatePool(count);
    }

    public PoolObjectMain(T prefab, int count, Transform container)
    {
        this.Prefab = prefab;
        this.Container = container;

        CreatePool(count);
    }

    private void CreatePool(int count){
        _pool = new List<T>(); // ������� ���
        for (int i =0; i < count; i++)
            CreateObject();
    }

    private T CreateObject(bool isActiveByDefault = false)
    // isActiveByDefault: ����� ������� ��� - ������� ������ ����� ���� false (���������)
    // �� ����� ��� ����� ������� ����� ������ (���� �� 6 ���� �� ������� 7 � �.�), �� ������ ������
    // ���� ������� -> ����� ���������� isActiveByDefault = true
    {
        var createdObject = GameObject.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    // ����������, ���� �� ��������� �������
    // out T element - ����� ����� �������� �������, ���� �� ����
    {
        foreach (var elementPool in _pool){
            if (!elementPool.gameObject.activeInHierarchy){
                element = elementPool;
                elementPool.gameObject.SetActive(true); // ���� �������� ������, ����� ��� ����������
                return true;
                // ���� ������ �� �������, �� �� �������� -> ���� ��������� �������
            }  
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out T element))
            return element; // ���� ���� ��������� �������, ���������� ������ element
        if (AutoExpand)
            return CreateObject(true); // ���� �������������, �� ������� ������ (����� �������� ������ true)
        throw new Exception($"There is no free elements in pool of type {typeof(T)}");

    }
}
