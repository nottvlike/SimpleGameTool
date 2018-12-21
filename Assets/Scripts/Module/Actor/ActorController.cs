﻿using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Module
{
    public class ActorController : UpdateModule
    {
        protected override void InitRequiredDataType()
        {
            _requiredDataTypeList.Add(typeof(PositionData));
            _requiredDataTypeList.Add(typeof(DirectionData));
            _requiredDataTypeList.Add(typeof(SpeedData));
            _requiredDataTypeList.Add(typeof(JoyStickData));
        }

        public override void Refresh(ObjectData objData)
        {
            var worldMgr = WorldManager.Instance;

            var gameSystemData = worldMgr.GameCore.GetData<GameSystemData>();

            var speedData = objData.GetData<SpeedData>();
            var directionData = objData.GetData<DirectionData>();

            var joyStickData = objData.GetData<JoyStickData>();
            var serverActionList = joyStickData.serverActionList;
            for (var i = 0; i < serverActionList.Count;)
            {
                var serverAction = serverActionList[i];
                if (serverAction.frame == gameSystemData.clientFrame)
                {
                    switch (serverAction.actionType)
                    {
                        case JoyStickActionType.Run:
                            speedData.acceleration = 100;
                            speedData.accelerationDelta = 0;
                            directionData.x = serverAction.actionParam == JoyStickActionFaceType.Right ? 1 : -1;
                            break;
                        case JoyStickActionType.CancelRun:
                            speedData.accelerationDelta = 10;
                            break;
                    }

                    serverActionList.Remove(serverAction);
                    worldMgr.PoolMgr.Release(serverAction);
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
