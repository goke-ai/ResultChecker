using Microsoft.Data.SqlClient;
using System.Linq;
using Goke.Core.Extensions;

namespace Ark.Iskools.Data.Services
{ 

    public partial class BaseService
    {

        protected AppDbContext _context;
        // protected string _username;


        public BaseService(AppDbContext context/*, string username*/)
        {
            _context = context;
            // _username = username;
            //_env = env;
            //_cache = memoryCache;
        }

        protected static string GetErrorTable(SqlException sqlException)
        {
            var y = sqlException.Message.Split('"');
            int i = y.ToList().FindIndex(f => f.Contains("table"));
            var t = y[i + 1];
            var yy = t.Split('.');
            var table = yy.Last().ToSentence();
            return table;
        }

    }
}
