using System;
using UnityEngine;
using _Source.Core;

namespace _Source.Game
{
    public class GameManagerScript : MonoBehaviour
    {
        private ResourceBank _resourceBank = new ResourceBank();

        private void Awake()
        {
            SetStartingResources();
        }

        void SetStartingResources()
        {
            _resourceBank.ChangeResource(GameResource.Humans, 10);
            _resourceBank.ChangeResource(GameResource.Food, 5);
            _resourceBank.ChangeResource(GameResource.Wood, 5);
        }

        public ObservableInt GetResource(GameResource resource)
        {
            return _resourceBank.GetResource(resource);
        }
        
        public void ChangeResource(GameResource resource, int value)
        {
            _resourceBank.ChangeResource(resource, value);
        }
        
        public void ChangeLvl(GameResource r, int v)
        {
            _resourceBank.ChangeLvl(r, v);
        }

        public ObservableInt GetLvl(GameResource r)
        {
            return _resourceBank.GetLvl(r);
        }
    }
}
