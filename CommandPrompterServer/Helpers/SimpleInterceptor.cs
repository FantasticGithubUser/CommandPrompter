using Castle.DynamicProxy;
using CommandPrompterServer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Helpers
{
    
    public class SimpleInterceptor : BaseInterceptor
    {
        private ILogger logger { get; set; }

        /// <summary>
        /// <see cref="BaseInterceptor.HandlerBeforeEvent"/>
        /// </summary>
        public override event Action<IInvocation> HandlerBeforeEvent;

        /// <summary>
        /// <see cref="BaseInterceptor.HandlerAfterEvent"/>
        /// </summary>
        public override event Action<IInvocation> HandlerAfterEvent;

        /// <summary>
        /// <see cref="BaseInterceptor.HandlerErrorEvent"/>
        /// </summary>
        public override event Action<IInvocation> HandlerErrorEvent;

        /// <summary>
        /// Do some simple log intercept based on <see cref="BaseInterceptor.Intercept(IInvocation)"/>
        /// </summary>
        /// <param name="invocation"></param>
        public override void Intercept(IInvocation invocation)
        {
            try
            {
                HandlerBeforeEvent?.Invoke(invocation);

                invocation.Proceed();

                HandlerAfterEvent?.Invoke(invocation);
            }catch(InnerException es)
            {
                logger.Log(es.ToString());
                HandlerErrorEvent?.Invoke(invocation);
            }
            catch(Exception es)
            {
                logger.Log(es.ToString());
                HandlerErrorEvent?.Invoke(invocation);
            }
        }
    }
}
