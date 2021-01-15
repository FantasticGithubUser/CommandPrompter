using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPrompter.Helpers
{
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
