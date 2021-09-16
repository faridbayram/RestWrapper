﻿using Castle.DynamicProxy;
using System;

namespace RestWrapper.Core.Utilities.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = true;

            OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception)
            {
                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                    OnSuccess(invocation);
                OnAfter(invocation);
            }
        }
    }
}
