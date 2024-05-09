using Game;
using Input;
using MainMenu;
using Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Zenject;

public class ZoneKill : MonoBehaviour
{
    private IGameExecutor games;
    [Inject]
    public void Init(IGameExecutor _games)
    {
        games = _games;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        games.SetCollisionHash(collision.gameObject.GetHashCode());
    }
}
