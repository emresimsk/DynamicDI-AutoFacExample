using System;
using AutoFacDI.Core.Enum;

namespace AutoFacDI.Core.Attributes
{
    public class LifeTimeAttribute : Attribute
    {
        public LifeTimeAttribute(LifeTimeType lifetime) { }
    }
}
