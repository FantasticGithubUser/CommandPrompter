using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace CommandPrompter.Helpers
{
    public static class ExpressionHelper
    {
        /// <summary>
        /// Compiles an expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T">The type of return value</typeparam>
        /// <param name="lambda">The expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        /// <summary>
        /// Compiles an expression and gets the functions return value
        /// </summary>
        /// <typeparam name="In">The type of return value</typeparam>
        /// <typeparam name="T">The input to the expression</typeparam>
        /// <param name="lambda">The expression to compile</param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T GetPropertyValue<In, T>(this Expression<Func<In,T>> lambda, In input)
        {
            return lambda.Compile().Invoke(input);
        }


        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            propertyInfo.SetValue(target, value);
        }

        /// <summary>
        /// Sets the underlying properties value to the given value
        /// from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type of value to set</typeparam>
        /// <typeparam name="In">The input to the expression</typeparam>
        /// <param name="lambda">The expression</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<In, T>(this Expression<Func<In, T>> lambda, T value, In input)
        {
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            // Get the property information so we can set it
            var propertyInfo = (PropertyInfo)expression.Member;

            // Set the property value
            propertyInfo.SetValue(input, value);
        }
    }
}
