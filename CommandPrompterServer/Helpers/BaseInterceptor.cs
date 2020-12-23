using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Helpers
{
    public abstract class BaseInterceptor : IInterceptor
    {
        /// <summary>
        /// To let each action can customize their own intercept actions before executed.
        /// </summary>
        public abstract event Action<IInvocation> HandlerBeforeEvent;

        /// <summary>
        /// To let each action can customize their own intercept actions after executed.
        /// </summary>
        public abstract event Action<IInvocation> HandlerAfterEvent;

        /// <summary>
        /// To let each action can customize their own intercept actions on error.
        /// </summary>
        public abstract event Action<IInvocation> HandlerErrorEvent;

        /// <summary>
        /// Intercep method.
        /// </summary>
        /// <param name="invocation"></param>
        public abstract void Intercept(IInvocation invocation);
    }
}
