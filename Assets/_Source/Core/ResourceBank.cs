using System;
using System.Collections.Generic;

namespace _Source.Core
{
    public class ResourceBank
    {
        
        private Dictionary<GameResource, ObservableInt> _resources;
        private Dictionary<GameResource, ObservableInt> _prodLevels;
        private int _lvlCap;
        
        public ResourceBank()
        {
            _resources = new Dictionary<GameResource, ObservableInt>();
            foreach (GameResource resource in Enum.GetValues(typeof(GameResource)))
            {
                _resources.Add(resource, new ObservableInt(0));
            }
            _prodLevels = new Dictionary<GameResource, ObservableInt>();
            foreach (GameResource resource in Enum.GetValues(typeof(GameResource)))
            {
                _prodLevels.Add(resource, new ObservableInt(1));
            }

            _lvlCap = 99;
        }
        
        public void ChangeResource(GameResource r, int v)
        {
            _resources[r].Value += v;
        }

        public ObservableInt GetResource(GameResource r)
        {
            return _resources[r];
        }
        
        public void ChangeLvl(GameResource r, int v)
        {
            _prodLevels[r].Value = Math.Min(_prodLevels[r].Value + v, _lvlCap);
        }

        public ObservableInt GetLvl(GameResource r)
        {
            return _prodLevels[r];
        }
    }
}

