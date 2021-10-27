using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGenerator : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    private List<BonusAttach> _levelBonuses = new List<BonusAttach>();
    
    public void Generate(GameLevel gameLevel)
    {
        if (gameLevel != null)
        {
            foreach(var item in gameLevel.Bonuses)
            {
                BonusAttach bonusAttach = Instantiate(item, transform);
                bonusAttach.transform.position = transform.position;
                _levelBonuses.Add(bonusAttach);
            }
        }
    }

    private void Activate(Vector2 position)
    {
        if(_levelBonuses.Count > 0)
        {
            int index = Random.Range(0, _levelBonuses.Count);
            _levelBonuses[index].transform.SetParent(null);
            _levelBonuses[index].transform.position = position;
            _levelBonuses[index].SetEnableBonus(true);
            _levelBonuses.RemoveAt(index);
        }
    }

    private void OnEnable()
    {
        Block.OnDestroyedPosition += BonusActivationChance;
    }

    private void OnDisable()
    {
        Block.OnDestroyedPosition -= BonusActivationChance;
    }

    private void BonusActivationChance(Vector2 position)
    {
        if(_gameState.State == State.GamePlay)
        {
            var chance = Random.Range(0, 100);
            if (chance > 60)
            {
                Activate(position);
            }
        }
    }









}
