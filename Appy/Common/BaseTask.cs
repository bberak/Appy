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

        protected abstract void LoadTasks();

        public virtual void Run()
        {
            LoadTasks();

            Tasks.ForEach(t => t.Run());
        }
    }
}
