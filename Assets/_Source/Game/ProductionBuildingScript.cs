using System;
using System.Collections;
using UnityEngine;
using _Source.Core;
using UnityEngine.UI;

namespace _Source.Game
{
    public class ProductionBuilding : MonoBehaviour
    {
        public GameResource resource;
        public GameObject gameManager;
        public Slider slider;
        public Button button;
        private float _productionTime;

        private void Start()
        {
            if (gameManager.TryGetComponent(out GameManagerScript script))
            {
                script.GetLvl(resource).OnValueChanged += UpdateProductionTime;
                UpdateProductionTime(script.GetLvl(resource).Value);
            }
        }

        private void UpdateProductionTime(int value)
        {
            _productionTime = Math.Max(1 - ((float)value / 100), 0);
        }

        public void ProduceResource()
        {
            if (gameManager.TryGetComponent(out GameManagerScript script))
            {
                StartCoroutine(ProductionCoroutine(script));
            }
        }

        private IEnumerator ProductionCoroutine(GameManagerScript script)
        {
            button.enabled = false;
            var timeLeft = _productionTime;
            while (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateSlider(timeLeft);
                yield return null;
            }
            script.ChangeResource(resource, 1);
            UpdateSlider(_productionTime);
            button.enabled = true;
        }

        private void UpdateSlider(float timeLeft)
        {
            slider.value = 1 - (timeLeft / _productionTime);
        }
    }
}
