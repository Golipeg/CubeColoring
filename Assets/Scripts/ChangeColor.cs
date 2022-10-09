using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeColor : MonoBehaviour
{
   [SerializeField] private float _pauseDuration = 2f;
   [SerializeField] float _recoloringDuration = 2f;
   private Color _nextColor;
   private Color _startColor;
   private float _recoloringTime;
   private float _pauseTimeBetweenRecoloring;
   private Renderer _renderer;
   private void Awake()
   {
      _renderer = GetComponent<Renderer>();
   }

   private void Start()
   {
      GenerateColor();
   }
   private void GenerateColor()
   {
      _startColor=_renderer.material.color;
      _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f,1f,1f);
    
   }
   
      private void Update()
      {
         _pauseTimeBetweenRecoloring += Time.deltaTime;
         if (_pauseTimeBetweenRecoloring <= _pauseDuration)
         {
            return;
         }
         _recoloringTime += Time.deltaTime;
         var progress = _recoloringTime/_recoloringDuration;
         _renderer.material.color = Color.Lerp(_startColor, _nextColor, progress);
         if (_recoloringTime > _recoloringDuration)
         {
            _pauseTimeBetweenRecoloring = 0;
            _recoloringTime = 0;
            GenerateColor();
         }
   }
   
}
