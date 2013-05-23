using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appy
{
    public abstract class InteractiveTask : ITask
    {
        protected Settings Settings;

        public InteractiveTask(Settings settings)
        {
            Settings = settings;
        }

        public InteractiveTask(IUserInterface ui)
        {
            BeginInteraction(ui);
        }

        protected virtual void BeginInteraction(IUserInterface ui)
        {
            Settings = new Settings();
        }

        public abstract void Run();
    }
}
