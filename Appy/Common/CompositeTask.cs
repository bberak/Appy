using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy.Common
{
    public abstract class CompositeTask : ITask
    {
        protected List<ITask> Components;

        public CompositeTask()
        {
            Components = new List<ITask>();
        }

        protected void Add(ITask component)
        {
            Components.Add(component);
        }

        protected abstract void BeforeRun();

        public virtual void Run()
        {
            BeforeRun();

            Components.ForEach(t => t.Run());
        }
    }
}
