using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeColor : MonoBehaviour
{
   private Color _nextColor;
   private Color _currentColor;
   private Color _startColor;
   private float _recoloringTime;
   private float _pauseTimeBetweenRecoloring;
   private bool _canChangeColor=true;
   
   [SerializeField] private float _pauseDuration = 2f;
   
   [SerializeField] float recoloringDuration = 2f;
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
      _recoloringTime += Time.deltaTime;
      _pauseTimeBetweenRecoloring += Time.deltaTime;
      
      if (_canChangeColor)
      {
         var progress = _recoloringTime / recoloringDuration;
      
         _currentColor=Color.Lerp(_startColor, _nextColor,progress);
         _renderer.material.color = _currentColor;
      }
      if (_recoloringTime>= recoloringDuration)
      {
         _recoloringTime = 0f;
         _canChangeColor = false;
      }
      if (_pauseTimeBetweenRecoloring >= _pauseDuration+recoloringDuration)
      {
         _recoloringTime = 0f;
         _pauseTimeBetweenRecoloring = 0f;
         _canChangeColor = true;
         GenerateColor();
      }
   }
   
}
