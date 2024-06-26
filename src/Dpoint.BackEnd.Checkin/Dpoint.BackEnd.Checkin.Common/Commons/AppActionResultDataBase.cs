using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpoint.BackEnd.Checkin.Common.Commons
{
    public class AppActionResultDataBase<TData, TDetail> where TDetail : class
    {
        public bool IsSuccess { get; set; }

        public TData Data { get; set; }

        public TDetail Detail { get; set; }

        public AppActionResultDataBase()
        {
            IsSuccess = false;
            Data = default(TData);
            Detail = null;
        }

        public AppActionResultDataBase(TData data)
        {
            BuildResult(data);
        }

        public AppActionResultDataBase<TData, TDetail> BuildResult(TData data, TDetail detail = null)
        {
            SetInfo(success: true, detail);
            Data = data;
            return this;
        }

        public AppActionResultDataBase<TData, TDetail> BuildError(TDetail error)
        {
            SetInfo(success: false, error);
            return this;
        }

        public AppActionResultDataBase<TData, TDetail> SetInfo(bool success, TDetail detail = null)
        {
            IsSuccess = success;
            Detail = detail;
            return this;
        }
    }
}
