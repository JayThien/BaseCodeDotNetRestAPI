using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Common
{
    public class PaginationRequest : RequestBase
    {
        protected int _pageNumber;
        protected int _rowsPerPage;
        public string SearchTerm { set; get; }
        public virtual int PageNumber
        {
            get { return _pageNumber; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("PageNumber must be than one");
                }
                this._pageNumber = value;
            }
        }
        public virtual int RowsPerPage
        {
            get { return this._rowsPerPage; }
            set
            {
                if (value < 1 || value > 999)
                { throw new ArgumentOutOfRangeException("RowsPerPage"); }
                _rowsPerPage = value;
            }
        }
        public virtual int SkipCount
        {
            get
            {
                return ((this.PageNumber <= 0 ? 1 : this.PageNumber) - 1) * this.TakeCount;
            }
        }
        public virtual int TakeCount
        {
            get
            {
                return this.RowsPerPage <= 0 ? 10 : this.RowsPerPage;
            }
        }
    }
}
