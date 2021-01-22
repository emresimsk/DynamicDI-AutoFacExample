using System;
using AutoFacDI.Core.Attributes;
using AutoFacDI.Core.Enum;
using AutoFacDI.Core.Interfaces;

namespace AutoFacDI.Core.Services
{
    [LifeTime(LifeTimeType.Scoped)]
    public class ScopeServices : IScopeServices
    {
        private readonly Guid ID;
        public ScopeServices()
        {
            ID = Guid.NewGuid();
        }
        public Guid GetId()
        {
            return ID;
        }
    }
}
