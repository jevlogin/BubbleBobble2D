using Pathfinding;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class EnemyConfigurator : MonoBehaviour
    {
        [Header("SimpleAI")]
        [SerializeField] private AIConfig _simplePatrolAIConfig;
        [SerializeField] private EnemyView _simplePatrolAIView;

        [Header("StalkerAI")]
        [SerializeField] private AIConfig _stalkerAIConfig;
        [SerializeField] private EnemyView _stalkerView;
        [SerializeField] private Seeker _stalkerAISeeker;
        [SerializeField] private Transform _stalkerAITarget;

        [Header("ProtectorAI")]
        [SerializeField] private EnemyView _protectorView;
        [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
        [SerializeField] private AIPatrolPath _protectorAIPath;
        [SerializeField] private LevelObjectTrigger _protectorZoneTrigger;
        [SerializeField] private Transform[] _protectorWaypoints;


        private SimplePatrolAI _simplePatrolAI;
        private StalkerAI _stalkerAI;
        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;


        private void Start()
        {
            _simplePatrolAI = new SimplePatrolAI(_simplePatrolAIView, new SimplePatrolAIModel(_simplePatrolAIConfig));

            //_stalkerAI = new StalkerAI(_stalkerView, new StalkerAIModel(_stalkerAIConfig),
            //                            _stalkerAISeeker, _stalkerAITarget);
            //InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);
            //_protectorAI = new ProtectorAI(_protectorView, new PatrolAIModel(_protectorWaypoints),
            //                _protectorAIDestinationSetter, _protectorAIPath);
            //_protectorAI.Init();

            //_protectedZone = new ProtectedZone(new List<IProtector> { _protectorAI }, 
            //                                        _protectorZoneTrigger);
            //_protectedZone.Init();

        }

        private void RecalculateAIPath()
        {
            _stalkerAI.RecalculatePath();
        }

        private void FixedUpdate()
        {
            if (_simplePatrolAI != null) { _simplePatrolAI.FixedExecute(Time.fixedDeltaTime); }
            if (_stalkerAI != null)
            {
                _stalkerAI.FixedExecute(Time.fixedDeltaTime);
            }
        }

        private void OnDestroy()
        {
            _protectorAI?.DeInit();
            _protectedZone?.DeInit();
        }
    }
}