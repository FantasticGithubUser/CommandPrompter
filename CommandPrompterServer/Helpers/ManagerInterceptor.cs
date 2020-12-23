using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Helpers
{
    public class ManagerInterceptor : BaseInterceptor
    {
        public override event Action<IInvocation> HandlerBeforeEvent;
        public override event Action<IInvocation> HandlerAfterEvent;
        public override event Action<IInvocation> HandlerErrorEvent;

        public override void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}
