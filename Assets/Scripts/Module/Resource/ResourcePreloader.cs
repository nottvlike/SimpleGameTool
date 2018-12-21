﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module
{
    public class ResourcePreloader : Module
    {
        NotificationData _notificationData;

        public ResourcePreloader()
        {
            _notificationData = new NotificationData();
            _notificationData.id = Constant.NOTIFICATION_TYPE_RESOURCE;
        }

        protected override void InitRequiredDataType()
        {
            _requiredDataTypeList.Add(typeof(Data.ResourcePreloadData));
        }

        public override void Refresh(ObjectData objData, bool notMet = false)
        {
            var worldMgr = WorldManager.Instance;
            if (worldMgr.ResourcePreloadConfig == null)
            {
                return;
            }

            var resourcePreloadData = objData.GetData<Data.ResourcePreloadData>();
            var resourceNameList = worldMgr.ResourcePreloadConfig.GetResourceNameList(resourcePreloadData.preloadType);
            for (var i = 0; i < resourceNameList.Length; i++)
            {
                var resourceName = resourceNameList[i];
                worldMgr.ResourceMgr.LoadAsync(resourceName, delegate (Object obj)
                {
                    resourcePreloadData.preloadCount++;

                    if (resourcePreloadData.preloadCount == resourceNameList.Length)
                    {
                        _notificationData.mode = NotificationMode.ValueType;
                        _notificationData.data2 = resourcePreloadData.preloadCount;

                        worldMgr.NotificationCenter.Notificate(_notificationData);
                    }
                });
            }
        }
    }
}
