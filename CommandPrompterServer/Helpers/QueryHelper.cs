using CommandPrompterServer.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CommandPrompterServer.Helpers
{
    public static class QueryHelper
    {
        private static System.Type OwnThisProperty<T>(string name) where T : BaseDao<T>, new()
        {
            var properties = typeof(T).GetProperties();
            foreach(var prop in properties)
            {
                if (prop.Name == name)
                    return prop.PropertyType;
            }
            return null;
        }
        
        /// <summary>
        /// Form a Func delegate for the where clause in linq.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static Func<T,bool> FormLambda<T>(List<QueryField> fields) where T : BaseDao<T>, new()
        {
            //In case this is used for linq.where clause, if fileds not set correctly, the data should not be retrieved at all.
            if (fields == null)
                return new Func<T, bool>(input => false);

            //Use this to concatenate all other expression by using and & or.
            Expression ret = null;
            var parameterT = Expression.Parameter(typeof(T));
            foreach(var field in fields)
            {
                var propType = OwnThisProperty<T>(field.Name);
                if (propType == null)
                    return new Func<T, bool>(input => false);
                switch (field.Type)
                {
                    case Type.String:
                        if(propType != typeof(string))
                            return new Func<T, bool>(input => false);
                        break;
                    case Type.Int:
                        if (propType != typeof(int))
                            return new Func<T, bool>(input => false);
                        break;
                    case Type.Double:
                        if (propType != typeof(double))
                            return new Func<T, bool>(input => false);
                        break;
                    case Type.DateTime:
                        if (propType != typeof(DateTime))
                            return new Func<T, bool>(input => false);
                        break;
                    default:
                        return new Func<T, bool>(input => false);
                }

                ConstantExpression constant = null;
                Expression operation = null;

                var property = Expression.Property(parameterT, typeof(T).GetProperty(field.Name));

                //Set up parameters and constants.
                switch (field.Type)
                {
                    case Type.String:
                        
                        constant = Expression.Constant(field.Value, typeof(string));
                        switch (field.Operator)
                        {
                            case Operator.Contains:
                                operation = Expression.Call(property, typeof(string).GetMethod("Contains", new System.Type[] { typeof(string) }), constant);
                                break;
                            case Operator.Equals:
                                operation = Expression.Equal(property, constant);
                            break;
                            default:
                                return new Func<T, bool>(input => false);
                        }
                        break;
                    case Type.Int:
                        {
                            int value;
                            if (int.TryParse(field.Value, out value) == false)
                                continue;
                            constant = Expression.Constant(value, typeof(int));
                            switch (field.Operator)
                            {
                                case Operator.Equals:
                                    operation = Expression.Equal(property, constant);
                                    break;
                                case Operator.GreaterThan:
                                    operation = Expression.GreaterThan(property, constant);
                                    break;
                                case Operator.LessThan:
                                    operation = Expression.LessThan(property, constant);
                                    break;
                                case Operator.GreaterAndEqualThan:
                                    operation = Expression.GreaterThanOrEqual(property, constant);
                                    break;
                                case Operator.LessAndEqualThan:
                                    operation = Expression.LessThanOrEqual(property, constant);
                                    break;
                                default:
                                    return new Func<T, bool>(input => false);
                            }
                        }
                        break;
                    case Type.Double:
                        {
                            double value;
                            if (double.TryParse(field.Value, out value) == false)
                                continue;
                            constant = Expression.Constant(value, typeof(double));
                            switch (field.Operator)
                            {
                                case Operator.Equals:
                                    operation = Expression.Equal(property, constant);
                                    break;
                                case Operator.GreaterThan:
                                    operation = Expression.GreaterThan(property, constant);
                                    break;
                                case Operator.LessThan:
                                    operation = Expression.LessThan(property, constant);
                                    break;
                                case Operator.GreaterAndEqualThan:
                                    operation = Expression.GreaterThanOrEqual(property, constant);
                                    break;
                                case Operator.LessAndEqualThan:
                                    operation = Expression.LessThanOrEqual(property, constant);
                                    break;
                                default:
                                    return new Func<T, bool>(input => false);
                            }
                        }
                        break;
                    case Type.DateTime:
                        {
                            DateTime value;
                            if (DateTime.TryParse(field.Value, out value) == false)
                                continue;
                            constant = Expression.Constant(value, typeof(DateTime));
                            switch (field.Operator)
                            {
                                case Operator.Equals:
                                    operation = Expression.Equal(property, constant);
                                    break;
                                case Operator.GreaterThan:
                                    operation = Expression.GreaterThan(property, constant);
                                    break;
                                case Operator.LessThan:
                                    operation = Expression.LessThan(property, constant);
                                    break;
                                case Operator.GreaterAndEqualThan:
                                    operation = Expression.GreaterThanOrEqual(property, constant);
                                    break;
                                case Operator.LessAndEqualThan:
                                    operation = Expression.LessThanOrEqual(property, constant);
                                    break;
                                default:
                                    return new Func<T, bool>(input => false);
                            }
                        }
                        break;
                    default:
                        return new Func<T, bool>(input => false);
                }

                if (ret == null)
                    ret = operation;
                else
                {
                    ret = Expression.And(ret, operation);
                }
            }
            return Expression.Lambda<Func<T, bool>>(ret, parameterT).Compile();
        }
    }

    public enum Operator
    {
        Contains = 0, // Used for string variables.
        Equals = 1,
        GreaterThan = 2, // Used for datatime and scarlars
        LessThan = 3,
        GreaterAndEqualThan = 4,
        LessAndEqualThan = 5
    }
    public enum Type
    {
        String = 0,
        Int = 1,
        Double = 2,
        DateTime = 3
    }
    public class QueryField
    {
        /// <summary>
        /// The Dao property name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value, need convert by the type.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// If is compare operator, convert the data to double or datetime
        /// </summary>
        public Operator Operator { get; set; } = Operator.Equals;

        /// <summary>
        /// Specify the type of the value.
        /// </summary>
        public Type Type { get; set; } = Type.String;
    }
}
