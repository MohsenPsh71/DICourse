using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DICourse.Services
{
    public class ScopedService
    {
        private readonly string guid;

        public ScopedService()
        {
            guid = Guid.NewGuid().ToString();
        }

        public string GetGuid()
        {
            return guid;
        }
    }
}
