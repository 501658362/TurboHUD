using System;
using System.Collections.Generic;
using System.Globalization; 
namespace Turbo.Plugins.Default
{

    public abstract class GLQ_BasePluginCN: IPlugin
	{

        public IController Hud { get; private set; }
        public bool Enabled { get; set; }
        public int Order { get; set; }

        private Dictionary<string, IPerfCounter> _performanceCounters;
        public Dictionary<string, IPerfCounter> PerformanceCounters
        {
            get
            {
                if (_performanceCounters == null)
                {
                    _performanceCounters = new Dictionary<string, IPerfCounter>();
                }
                return _performanceCounters;
            }
        }

        public virtual void Load(IController hud)
        {
            Hud = hud;
        }

        public static string ValueToString(long Value, ValueFormat Format)
        {
            switch (Format)
            {
                case ValueFormat.NormalNumber:
                    return Value.ToString("#,0.#", CultureInfo.InvariantCulture);
                case ValueFormat.NormalNumberNoDecimal:
                    return Value.ToString("#,0", CultureInfo.InvariantCulture);
                case ValueFormat.AlwaysK:
                    return (Value / 1000.0f).ToString("#,0.#千", CultureInfo.InvariantCulture);
                case ValueFormat.AlwaysKNoDecimal:
                    return (Value / 1000.0f).ToString("#,0千", CultureInfo.InvariantCulture);
                case ValueFormat.AlwaysM:
                    return (Value / 1000.0f / 1000.0f).ToString("#,0.#百万", CultureInfo.InvariantCulture);
                case ValueFormat.AlwaysMNoDecimal:
                    return (Value / 1000.0f / 1000.0f).ToString("#,0百万", CultureInfo.InvariantCulture);
                case ValueFormat.LongNumber:
                    if (Value == 0) return "0";
                    if(Value < 10000L * 1000L * 1000 * 1000 * 1000 *100)//100万万亿，100京
                    {
                        if (Value < 10000L * 1000L * 1000 * 1000 * 1000)//1万万亿，京
                        {
                            if (Value < 100L * 1000L * 1000 * 1000 * 1000)//100万亿
                            {
                                if (Value < 1000L * 1000 * 1000 * 1000)//1万亿
                                {
                                    if (Value < 100L * 1000 * 1000 * 1000)//1千亿
                                    {
                                        if (Value < 100 * 1000 * 1000)//1亿
                                        {
                                            if (Value < 10 * 1000 * 1000) //1千万
                                            {
                                                if (Value < 1 * 1000 * 1000) //1百万
                                                {
                                                    if (Value < 1 * 10000) // 1万
                                                    {
                                                        if (Value < 1 * 1000) //1千
                                                        {
                                                            if (Value < 1 * 100) //1百
                                                            {
                                                                return Value.ToString("0.0", CultureInfo.InvariantCulture); //1..99 = '55.5'
                                                            }
                                                            else return Value.ToString("0", CultureInfo.InvariantCulture); //100..999 = '555'
                                                        }
                                                        else return Value.ToString("#,0", CultureInfo.InvariantCulture); // 1000..9999 = 5,555
                                                    }
                                                    else return (Value / 10000.0f).ToString("0.0万", CultureInfo.InvariantCulture); // 10000...999999（99.99万） = 55.5万
                                                }
                                                else return (Value / 10000.0f).ToString("0万", CultureInfo.InvariantCulture); // 1000000...9999999（999.99万） = 555万
                                            }
                                            else return (Value / 10000.0f).ToString("#,0万", CultureInfo.InvariantCulture); // 100000000...99999999（9999.99万） = 1,000万
                                        }
                                        else return (Value / 100.0f / 1000.0f / 1000.0f).ToString("#,0.0亿", CultureInfo.InvariantCulture);
                                    }
                                    else return (Value / 100.0f / 1000.0f / 1000.0f).ToString("#,0亿", CultureInfo.InvariantCulture);
                                }
                                else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f).ToString("#,0.0万亿", CultureInfo.InvariantCulture);
                            }
                            else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f).ToString("#,0万亿", CultureInfo.InvariantCulture);
                        }
                        else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f / 10000.0f).ToString("#,0.0京", CultureInfo.InvariantCulture);
                    }
                    else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f / 10000.0f).ToString("#,0京", CultureInfo.InvariantCulture);
                case ValueFormat.ShortNumber:
                    if (Value == 0) return "0";
                    if (Value < 10000L * 1000L * 1000 * 1000 * 1000 * 100)//100万万亿，100京
                    {
                        if (Value < 10000L * 1000L * 1000 * 1000 * 1000)//1万万亿，京
                        {
                            if (Value < 100L * 1000L * 1000 * 1000 * 1000)//100万亿
                            {
                                if (Value < 1000L * 1000 * 1000 * 1000)//1万亿
                                {
                                    if (Value < 100L * 1000 * 1000 * 1000)//1千亿
                                    {
                                        if (Value < 100 * 1000 * 1000)//1亿
                                        {
                                            if (Value < 10 * 1000 * 1000) //1千万
                                            {
                                                if (Value < 1 * 1000 * 1000) //1百万
                                                {
                                                    if (Value < 1 * 10000) // 1万
                                                    {
                                                        if (Value < 1 * 1000) //1千
                                                        {
                                                            if (Value < 1 * 100) //1百
                                                            {
                                                                return Value.ToString("0.0", CultureInfo.InvariantCulture); //1..99 = '55.5'
                                                            }
                                                            else return Value.ToString("0", CultureInfo.InvariantCulture); //100..999 = '555'
                                                        }
                                                        else return Value.ToString("#,0", CultureInfo.InvariantCulture); // 1000..9999 = 5,555
                                                    }
                                                    else return (Value / 10000.0f).ToString("0.0万", CultureInfo.InvariantCulture); // 10000...999999（99.99万） = 55.5万
                                                }
                                                else return (Value / 10000.0f).ToString("0万", CultureInfo.InvariantCulture); // 1000000...9999999（999.99万） = 555万
                                            }
                                            else return (Value / 10000.0f).ToString("#,0万", CultureInfo.InvariantCulture); // 100000000...99999999（9999.99万） = 1,000万
                                        }
                                        else return (Value / 100.0f / 1000.0f / 1000.0f).ToString("#,0.0亿", CultureInfo.InvariantCulture);
                                    }
                                    else return (Value / 100.0f / 1000.0f / 1000.0f).ToString("#,0亿", CultureInfo.InvariantCulture);
                                }
                                else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f).ToString("#,0.0万亿", CultureInfo.InvariantCulture);
                            }
                            else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f).ToString("#,0万亿", CultureInfo.InvariantCulture);
                        }
                        else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f / 10000.0f).ToString("#,0.0京", CultureInfo.InvariantCulture);
                    }
                    else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f / 10000.0f).ToString("#,0京", CultureInfo.InvariantCulture);
                case ValueFormat.LongTime:
                    {
                        long h = Value / (TimeSpan.TicksPerMillisecond * 60 * 60 * 1000); // value is in ticks
                        return (h > 0 ? h.ToString("D", CultureInfo.InvariantCulture) + "小时 " : "") + new TimeSpan(Value).ToString(@"m\分\ ss\秒", CultureInfo.InvariantCulture);
                    }
                case ValueFormat.LongTimeNoSeconds:
                    {
                        long hrcount = Value / (TimeSpan.TicksPerMillisecond * 60 * 60 * 1000); // value is in ticks
                        return (hrcount > 0 ? hrcount.ToString("D", CultureInfo.InvariantCulture) + "小时 " : "") + new TimeSpan(Value).ToString(@"m\分", CultureInfo.InvariantCulture);
                    }
            }
            return null;
        }

        public static string ValueToString(double Value, ValueFormat Format)
        {
            switch (Format)
            {
                case ValueFormat.NormalNumber:
                    return Value.ToString("#,0.0", CultureInfo.InvariantCulture);
                case ValueFormat.NormalNumberNoDecimal:
                    return Math.Round(Value, 0).ToString("#,0", CultureInfo.InvariantCulture);
                case ValueFormat.AlwaysK:
                    return (Value / 1000.0f).ToString("#,0.0千", CultureInfo.InvariantCulture);
                case ValueFormat.AlwaysKNoDecimal:
                    return (Value / 1000.0f).ToString("#,0千", CultureInfo.InvariantCulture);
                case ValueFormat.AlwaysM:
                    return (Value / 1000.0f / 1000.0f).ToString("#,0.0百万", CultureInfo.InvariantCulture);
                case ValueFormat.AlwaysMNoDecimal:
                    return (Value / 1000.0f / 1000.0f).ToString("#,0百万", CultureInfo.InvariantCulture);
                case ValueFormat.LongNumber:
                    if (Value == 0) return "0";
                    if (Value < 10000L * 1000L * 1000 * 1000 * 1000 * 100)//100万万亿，100京
                    {
                        if (Value < 10000L * 1000L * 1000 * 1000 * 1000)//1万万亿，京
                        {
                            if (Value < 100L * 1000L * 1000 * 1000 * 1000)//100万亿
                            {
                                if (Value < 1000L * 1000 * 1000 * 1000)//1万亿
                                {
                                    if (Value < 100L * 1000 * 1000 * 1000)//1千亿
                                    {
                                        if (Value < 100 * 1000 * 1000)//1亿
                                        {
                                            if (Value < 10 * 1000 * 1000) //1千万
                                            {
                                                if (Value < 1 * 1000 * 1000) //1百万
                                                {
                                                    if (Value < 1 * 10000) // 1万
                                                    {
                                                        if (Value < 1 * 1000) //1千
                                                        {
                                                            if (Value < 1 * 100) //1百
                                                            {
                                                                return Value.ToString("0.0", CultureInfo.InvariantCulture); //1..99 = '55.5'
                                                            }
                                                            else return Value.ToString("0", CultureInfo.InvariantCulture); //100..999 = '555'
                                                        }
                                                        else return Value.ToString("#,0", CultureInfo.InvariantCulture); // 1000..9999 = 5,555
                                                    }
                                                    else return (Value / 10000.0f).ToString("0.0万", CultureInfo.InvariantCulture); // 10000...999999（99.99万） = 55.5万
                                                }
                                                else return (Value / 10000.0f).ToString("0万", CultureInfo.InvariantCulture); // 1000000...9999999（999.99万） = 555万
                                            }
                                            else return (Value / 10000.0f).ToString("#,0万", CultureInfo.InvariantCulture); // 100000000...99999999（9999.99万） = 1,000万
                                        }
                                        else return (Value / 100.0f / 1000.0f / 1000.0f).ToString("#,0.0亿", CultureInfo.InvariantCulture);
                                    }
                                    else return (Value / 100.0f / 1000.0f / 1000.0f).ToString("#,0亿", CultureInfo.InvariantCulture);
                                }
                                else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f).ToString("#,0.0万亿", CultureInfo.InvariantCulture);
                            }
                            else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f).ToString("#,0万亿", CultureInfo.InvariantCulture);
                        }
                        else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f / 10000.0f).ToString("#,0.0京", CultureInfo.InvariantCulture);
                    }
                    else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f / 10000.0f).ToString("#,0京", CultureInfo.InvariantCulture);
                case ValueFormat.ShortNumber:
                    if (Value == 0) return "0";
                    if (Value < 10000L * 1000L * 1000 * 1000 * 1000 * 100)//100万万亿，100京
                    {
                        if (Value < 10000L * 1000L * 1000 * 1000 * 1000)//1万万亿，京
                        {
                            if (Value < 100L * 1000L * 1000 * 1000 * 1000)//100万亿
                            {
                                if (Value < 1000L * 1000 * 1000 * 1000)//1万亿
                                {
                                    if (Value < 100L * 1000 * 1000 * 1000)//1千亿
                                    {
                                        if (Value < 100 * 1000 * 1000)//1亿
                                        {
                                            if (Value < 10 * 1000 * 1000) //1千万
                                            {
                                                if (Value < 1 * 1000 * 1000) //1百万
                                                {
                                                    if (Value < 1 * 10000) // 1万
                                                    {
                                                        if (Value < 1 * 1000) //1千
                                                        {
                                                            if (Value < 1 * 100) //1百
                                                            {
                                                                return Value.ToString("0.0", CultureInfo.InvariantCulture); //1..99 = '55.5'
                                                            }
                                                            else return Value.ToString("0", CultureInfo.InvariantCulture); //100..999 = '555'
                                                        }
                                                        else return Value.ToString("#,0", CultureInfo.InvariantCulture); // 1000..9999 = 5,555
                                                    }
                                                    else return (Value / 10000.0f).ToString("0.0万", CultureInfo.InvariantCulture); // 10000...999999（99.99万） = 55.5万
                                                }
                                                else return (Value / 10000.0f).ToString("0万", CultureInfo.InvariantCulture); // 1000000...9999999（999.99万） = 555万
                                            }
                                            else return (Value / 10000.0f).ToString("#,0万", CultureInfo.InvariantCulture); // 100000000...99999999（9999.99万） = 1,000万
                                        }
                                        else return (Value / 100.0f / 1000.0f / 1000.0f).ToString("#,0.0亿", CultureInfo.InvariantCulture);
                                    }
                                    else return (Value / 100.0f / 1000.0f / 1000.0f).ToString("#,0亿", CultureInfo.InvariantCulture);
                                }
                                else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f).ToString("#,0.0万亿", CultureInfo.InvariantCulture);
                            }
                            else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f).ToString("#,0万亿", CultureInfo.InvariantCulture);
                        }
                        else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f / 10000.0f).ToString("#,0.0京", CultureInfo.InvariantCulture);
                    }
                    else return (Value / 1000.0f / 1000.0f / 1000.0f / 1000.0f / 10000.0f).ToString("#,0京", CultureInfo.InvariantCulture);
            }
            return null;
        }

    }

}