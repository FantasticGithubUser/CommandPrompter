using Castle.DynamicProxy;
using CommandPrompterServer.Exceptions;
using CommandPrompterServer.Models.Dao;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Helpers
{
    /// <summary>
    /// The service interceptor works before each action of service.
    /// </summary>
    public class ServiceInterceptor : BaseInterceptor
    {
        private bool firstRun = true;
        private ILogger _logger { get; set; }
        public override event Action<IInvocation> HandlerBeforeEvent;
        public override event Action<IInvocation> HandlerAfterEvent;
        public override event Action<IInvocation> HandlerErrorEvent;

        /// <summary>
        /// Intercept all the services
        /// </summary>
        /// <param name="invocation"></param>
        public override void Intercept(IInvocation invocation)
        {
            
            try
            {
                var context = DbContextHolder.Context;
                HandlerBeforeEvent?.Invoke(invocation);
                if (firstRun)
                {
                    context.Database.EnsureCreated();
                    firstRun = false;
                }
                var strategy = context.Database.CreateExecutionStrategy();
                strategy.Execute(() =>
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            invocation.Proceed();
                            context.SaveChanges();
                            transaction.Commit();
                        }
                        catch (InnerException es)
                        {
                            transaction.Rollback();
                            _logger.Log(es.ToString());
                        }
                        catch (Exception es)
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception inneres)
                            {
                                //do nothing.
                            }
                            _logger.Log(es.ToString());
                        }
                    }
                });
                HandlerAfterEvent?.Invoke(invocation);

            }
            catch(InnerException es)
            {
                _logger.Log(es.ToString());
                HandlerErrorEvent?.Invoke(invocation);
            }
            catch(Exception es)
            {
                _logger.Log(es.ToString());
                HandlerErrorEvent?.Invoke(invocation);
            }
        }
    }
}
