using Castle.DynamicProxy;
using CommandPrompterServer.Exceptions;
using CommandPrompterServer.Models.Dao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandPrompterServer.Helpers
{
    public class ServiceInterceptor : BaseInterceptor
    {
        private bool firstRun = true;
        private IConfiguration _configuration { get; set; }
        private ILogger _logger { get; set; }
        public override event Action<IInvocation> HandlerBeforeEvent;
        public override event Action<IInvocation> HandlerAfterEvent;
        public override event Action<IInvocation> HandlerErrorEvent;

        public override void Intercept(IInvocation invocation)
        {
            try
            {
                _logger.Log("before");
                HandlerBeforeEvent?.Invoke(invocation);
                using (var context = new CommandPrompterDbContext(_configuration))
                {
                    if (firstRun)
                    {
                        context.Database.EnsureCreated();
                        firstRun = false;
                    }
                    var strategy = context.Database.CreateExecutionStrategy();
                    strategy.Execute(() =>
                    {
                        using (var context = new CommandPrompterDbContext(_configuration))
                        {
                            using (var transaction = context.Database.BeginTransaction())
                            {
                                try
                                {
                                    invocation.Proceed();
                                    context.SaveChanges();
                                    transaction.Commit();
                                }catch(InnerException es)
                                {
                                    transaction.Rollback();
                                    _logger.Log(es.ToString());
                                }catch(Exception es)
                                {
                                    transaction.Rollback();
                                    _logger.Log(es.ToString());
                                }
                            }
                        }
                    });
                }
                HandlerAfterEvent?.Invoke(invocation);
                _logger.Log("after");

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
