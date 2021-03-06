﻿using UnityEngine;
using System.Collections.Generic;
using System;

namespace Module
{
    public abstract class Module
    {
        public Module()
        {
            InitRequiredDataType();
        }

        protected List<Type> _requiredDataTypeList = new List<Type>();
        static List<Type> _tmpList = new List<Type>();

        protected abstract void InitRequiredDataType();

        public bool IsMeet(List<Data.Data> dataList)
        {
            _tmpList.Clear();

            for (var i = 0; i < dataList.Count; i++)
            {
                var data = dataList[i];
                var type = data.GetType();
                if (_requiredDataTypeList.IndexOf(data.GetType()) != -1 && _tmpList.IndexOf(type) == -1)
                {
                    _tmpList.Add(type);
                }
            }
            return _tmpList.Count > 0 && _tmpList.Count == _requiredDataTypeList.Count;
        }

        public virtual bool IsUpdateRequired(Data.Data data)
        {
            return _requiredDataTypeList.IndexOf(data.GetType()) != -1;
        }

        public abstract void Refresh(ObjectData objData);


        protected List<int> _objectIdList = new List<int>();

        public virtual void Add(int objectDataId)
        {
            _objectIdList.Add(objectDataId);

            var objData = WorldManager.Instance.GetObjectData(objectDataId);
            SetDirty(objData);
        }

        public virtual void Remove(int objectDataId)
        {
            _objectIdList.Remove(objectDataId);

            Enabled = _objectIdList.Count != 0;
        }

        public bool Contains(int objectDataId)
        {
            return _objectIdList.IndexOf(objectDataId) != -1;
        }

        public virtual void SetDirty(ObjectData objData)
        {
            Enabled = true;

            Refresh(objData);
        }

        bool _enabled;
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if (_enabled == value)
                {
                    return;
                }

                _enabled = value;

                if (_enabled)
                {
                    OnEnable();
                }
                else
                {
                    OnDisable();
                }
            }
        }

        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
    }
}