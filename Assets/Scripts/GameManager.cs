using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Self;

    private int _progress = 0;
    private float _step = 10f;
    private int _currentIndex = 0;
    private float _lastZ = 70f;


    [SerializeField, Min(1)]
    private int _health = 3;
    [SerializeField] private Transform _player;
    [Space, SerializeField] private Transform[] _blocks;
    [SerializeField] private Text _progressText;

    private void Start()
    {
        Self = this;
    }
    private void Update()
    {
        if (_player.position.y <= -1.5f)
        {
            _health = 0;
            SetDamage(1);
        }
    }
    public void UpdateLevel()
    {
        _progress++;
        _progressText.text = _progress.ToString();

        _lastZ += _step;
        var position = _blocks[_currentIndex].position;
        position.z = _lastZ;
        _blocks[_currentIndex].position = position;

        _currentIndex++;
        if (_currentIndex >= _blocks.Length)   
        {
            _currentIndex = 0;
        }
    }
    public void SetDamage(int value)
    {
        _health -= value;
        Debug.Log("Current health = " + _health);

        if(_health <= 0)
        {
            Debug.Log("--- GAME OVER ---");
            UnityEditor.EditorApplication.isPaused = true;
        }
    }
}
