using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats// static ����� �� ����� �� ������������� �� �� ����
{
    public static int Level { get; private set; } = 1; // ��������, � �� ����
    // �������� ��� �������� �� ������ ����� � ������� ������
    // � �������� (set) ������ � ����� ������ 

    private static int _score = 0;
    public static int Score
    {
         get
        {
            return _score;
        }
        set
        {
            _score = value;
            if (_score > 100 * Level)
            {
                Level++;
                _score = 0;
            }
        }
    }

    public static void ResetAllStats()
    {
        Level = 1;
        _score = 0;
    }
}
