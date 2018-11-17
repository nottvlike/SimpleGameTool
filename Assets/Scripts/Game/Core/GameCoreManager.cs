﻿using Data;

public partial class WorldManager : Singleton<WorldManager>
{
    ObjectData _gameCore;
    public ObjectData GameCore
    {
        get
        {
            if (_gameCore == null)
            {
                _gameCore = new ObjectData();
                _gameCore.AddData(new GameSystemData());
                _objectDataList.Add(_gameCore);

                _gameCore.RefreshModuleAddedObjectIdList();
            }

            return _gameCore;
        }
    }

    ObjectData _gameServer;
    public ObjectData GameServer
    {
        get
        {
            if (_gameServer == null)
            {
                _gameServer = new ObjectData();
                _gameServer.AddData(new GameServerData());
                _objectDataList.Add(_gameServer);

                _gameServer.RefreshModuleAddedObjectIdList();
            }

            return _gameServer;
        }
    }

    ObjectData _item;
    public ObjectData Item
    {
        get
        {
            if (_item == null)
            {
                _item = new ObjectData();
                _item.AddData(new ItemInfoData());
                _objectDataList.Add(_item);

                _item.RefreshModuleAddedObjectIdList();
            }

            return _item;
        }
    }

    ObjectData _player;
    public ObjectData Player
    {
        get
        {
            if (_player == null)
            {
                _player = new ObjectData();
                _player.AddData(new PlayerBaseData());
                _objectDataList.Add(_player);

                _player.RefreshModuleAddedObjectIdList();
            }

            return _player;
        }
    }
}