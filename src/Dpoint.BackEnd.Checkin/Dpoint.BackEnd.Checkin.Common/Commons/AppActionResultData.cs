using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpoint.BackEnd.Checkin.Common.Commons
{
    public class AppActionResultData<TData> : AppActionResultDataBase<TData, string>
    {
        public AppActionResultData()
        {
        }

        public AppActionResultData(TData data)
            : base(data)
        {
        }

        public new AppActionResultData<TData> BuildResult(TData data, string detail = null)
        {
            SetInfo(success: true, detail);
            base.Data = data;
            return this;
        }

        public new AppActionResultData<TData> BuildError(string error)
        {
            SetInfo(success: false, error);
            return this;
        }
    }
}
