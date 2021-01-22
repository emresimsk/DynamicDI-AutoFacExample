using System;
using AutoFacDI.Core.Attributes;
using AutoFacDI.Core.Enum;
using AutoFacDI.Core.Interfaces;

namespace AutoFacDI.Core.Services
{
    [LifeTime(LifeTimeType.Singleton)]
    public class SingletonServices : ISingletonServices
    {
        private readonly Guid ID;
        public SingletonServices()
        {
            ID = Guid.NewGuid();
        }
        public Guid GetId()
        {
            return ID;
        }
    }
}
