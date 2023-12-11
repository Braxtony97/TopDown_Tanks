using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats// static класс не может не наследоваться ни от кого
{
    public static int Level { get; private set; } = 1; // свойство, а не поле
    // получать его значение из любого места в проекте сможем
    // а изменять (set) только в самом классе 

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
