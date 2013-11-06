﻿
namespace ApolloDb.Updates
{
    public class Update : IRegisterAsInstancePerLifetime
    {
        private readonly UpdateStepExecuter _updateStepExecuter;

        public Update(UpdateStepExecuter updateStepExecuter)
        {
            _updateStepExecuter = updateStepExecuter;
        }

        public void Run()
        {
            _updateStepExecuter
                .Add(2, UpdateToVs002.Run)
                .Add(3, UpdateToVs003.Run)
                .Add(4, UpdateToVs004.Run)
                .Add(5, UpdateToVs005.Run)
                .Add(6, UpdateToVs006.Run)
                .Add(7, UpdateToVs007.Run)
                .Add(8, UpdateToVs008.Run)
                .Run();
        }

    }
}
