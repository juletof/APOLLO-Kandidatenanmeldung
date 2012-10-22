using System.Collections.Generic;

namespace ApolloDb
{
    public class UniStatistikLadenResult
    {
        public Dictionary<int, int> _uniCounts = new Dictionary<int, int>();

        public void Add(int uniId, int uniCount){
            _uniCounts.Add(uniId, uniCount);
        }

        public int GetUniCount(int uniId)
        {
            if (!_uniCounts.ContainsKey(uniId))
                return 0;

            return _uniCounts[uniId];
        }
    }
}