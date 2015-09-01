using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace XFP
{
    public interface IConfig
    {
        string DirectorioDB { get; }
        ISQLitePlatform Platforma { get; }
    }
}
