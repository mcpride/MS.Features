﻿using System;

namespace MS.Features.Strategies
{
    public abstract class StrategyReaderBase : IStrategyReader
    {
        protected internal ConfigurationContext Context { get; set; }

        public virtual void Initialize(ConfigurationContext configurationContext)
        {
            Context = configurationContext;
        }

        public abstract bool Read();

        protected bool ConvertToBoolean(object value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
