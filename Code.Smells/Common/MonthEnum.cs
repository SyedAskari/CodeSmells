using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Smells.Common
{
    /// <summary>
    /// SmartEnum is a class that is designed to replace enum
    /// and provies the same kind of authoring experience that enums have
    /// like statement completion and intelliSense.
    /// Unlike enums a smart enum is not a primitive and so it can be extended
    /// with additional properties and methods as needed.
    /// They don't have implict casting issues enums deals with
    /// </summary>
    public sealed class MonthEnum : SmartEnum<MonthEnum>
    {
        public MonthEnum(string name, int value) : base(name, value)
        {
        }

        public static readonly MonthEnum January = new MonthEnum(nameof(January), 1);
        public static readonly MonthEnum February = new MonthEnum(nameof(February), 2);
        public static readonly MonthEnum March = new MonthEnum(nameof(March), 3);

        public string ShortName { get; set; }
    }
}
