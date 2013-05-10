using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appy
{
    public abstract class BaseTask : ITask
    {
        protected List<ITask> Tasks;

        public BaseTask()
        {
            Tasks = new List<ITask>();
        }

        protected abstract void BeforeRun();

        public virtual void Run()
        {
            BeforeRun();

            Tasks.ForEach(t => t.Run());
        }
    }
}
