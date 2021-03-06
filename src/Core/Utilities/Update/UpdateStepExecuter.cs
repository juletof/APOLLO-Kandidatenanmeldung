﻿using System;
using System.Collections.Generic;
using ApolloDb.Infrastructure;
using Gibraltar.Agent;
using TrueOrFalse.Core.Infrastructure.Persistence;

namespace ApolloDb.Updates
{
    public class UpdateStepExecuter : IRegisterAsInstancePerLifetime
    {
        private readonly DoesTableExist _doesTableExist;
        private readonly DbSettingsRepository _dbSettingsRepository;
        private readonly Dictionary<int, Action> _actions = new Dictionary<int, Action>();

        public UpdateStepExecuter(DoesTableExist doesTableExist, DbSettingsRepository dbSettingsRepository)
        {
            _doesTableExist = doesTableExist;
            _dbSettingsRepository = dbSettingsRepository;
        }

        public UpdateStepExecuter Add(int stepNo, Action action)
        {
            _actions.Add(stepNo, action);
            return this;
        }

        public void Run()
        {
            if (!_doesTableExist.Run("Setting"))
            {
                UpdateToVs001.Run();
            }

            var appVersion = _dbSettingsRepository.GetAppVersion();

            foreach (var dictionaryItem in _actions)
                if (appVersion < dictionaryItem.Key)
                {
                    Log.TraceInformation(String.Format("update to {0} - START", dictionaryItem.Key));
                    dictionaryItem.Value();
                    Log.TraceInformation(String.Format("update to {0} - END", dictionaryItem.Key));
                    _dbSettingsRepository.UpdateAppVersion(dictionaryItem.Key);
                }
        }
    }
}