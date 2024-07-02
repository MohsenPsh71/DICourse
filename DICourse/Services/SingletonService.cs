using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DICourse.Services
{
    public class SingletonService
    {
        private readonly string guid;

        public SingletonService()
        {
            guid = Guid.NewGuid().ToString();
        }

        public string GetGuid()
        {
            return guid;
        }
    }
}
