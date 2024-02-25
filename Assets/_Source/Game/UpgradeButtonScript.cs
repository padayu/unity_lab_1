using System;
using UnityEngine;
using _Source.Core;
using TMPro;
using UnityEngine.UI;

namespace _Source.Game
{
    public class UpgradeButtonScript : MonoBehaviour
    {
        public GameObject gameManager;
        public GameResource resource;
        public TextMeshProUGUI text;

        private void Start()
        {
            if (gameManager.TryGetComponent(out GameManagerScript script))
            {
                var lvl = script.GetLvl(resource);
                lvl.OnValueChanged += UpdateText;
                UpdateText(lvl.Value);
            }
        }

        public void UpgradeProduction()
        {
            if (gameManager.TryGetComponent(out GameManagerScript script))
            {
                script.ChangeLvl(resource, 1);
            }
        }

        private void UpdateText(int value)
        {
            text.SetText(Enum.GetName(typeof(GameResource), resource) + " Lvl " + value.ToString());
        }
    }
}
