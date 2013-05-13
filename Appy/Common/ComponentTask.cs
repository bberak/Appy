using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public abstract class ComponentTask : ITask
    {
        protected List<ITask> Components;

        public ComponentTask()
        {
            Components = new List<ITask>();
        }

        protected abstract void BeforeRun();

        public virtual void Run()
        {
            BeforeRun();

            Components.ForEach(t => t.Run());
        }

        protected void Add(ITask component)
        {
            Components.Add(component);
        }
    }
}
