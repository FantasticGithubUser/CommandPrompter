using Castle.DynamicProxy;
using CommandPrompterServer.Exceptions;
using System;

namespace CommandPrompterServer.Helpers
{
    public class ManagerInterceptor : BaseInterceptor
    {
        public override event Action<IInvocation> HandlerBeforeEvent;
        public override event Action<IInvocation> HandlerAfterEvent;
        public override event Action<IInvocation> HandlerErrorEvent;

        private ILogger _logger { get; set; }
        public override void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }catch(InnerException inneres)
            {
                _logger.Log(inneres.ToString());
                HandlerErrorEvent?.Invoke(invocation);
            }catch(Exception es)
            {
                _logger.Log(es.ToString());
                HandlerErrorEvent?.Invoke(invocation);
            }
        }
    }
}
