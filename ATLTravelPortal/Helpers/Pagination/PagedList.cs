﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATLTravelPortal.Helpers.Pagination
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> source, int index, int pageSize)
            : this(source, index, pageSize, null)
        {
        }

        public PagedList(IEnumerable<T> source, int index, int pageSize, int? totalCount)
        {
            Initialize(source.AsQueryable(), index, pageSize, totalCount);
        }

        public PagedList(IQueryable<T> source, int index, int pageSize)
            : this(source, index, pageSize, null)
        {
        }

        public PagedList(IQueryable<T> source, int index, int pageSize, int? totalCount)
        {
            Initialize(source, index, pageSize, totalCount);
        }

        #region IPagedList Members

        public int PageCount { get; private set; }
        public int TotalItemCount { get; private set; }
        public int PageIndex { get; private set; }
        public int PageNumber { get { return PageIndex + 1; } }
        public int PageSize { get; private set; }
        public bool HasPreviousPage { get; private set; }
        public bool HasNextPage { get; private set; }
        public bool IsFirstPage { get; private set; }
        public bool IsLastPage { get; private set; }

        #endregion

        protected void Initialize(IQueryable<T> source, int index, int pageSize, int? totalCount)
        {
            // for using it externally with 1 based page number
            index = index - 1;

            //### argument checking
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("PageIndex cannot be below 0.");
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("PageSize cannot be less than 1.");
            }

            //### set source to blank list if source is null to prevent exceptions
            if (source == null)
            {
                source = new List<T>().AsQueryable();
            }

            //### set properties
            if (!totalCount.HasValue)
            {
                TotalItemCount = source.Count();
            }
            PageSize = pageSize;
            PageIndex = Math.Ceiling(Convert.ToDecimal(TotalItemCount)/Convert.ToDecimal(pageSize))>= index+1?index:0;
            if (TotalItemCount > 0)
            {
                PageCount = (int)Math.Ceiling(TotalItemCount / (double)PageSize);
            }
            else
            {
                PageCount = 0;
            }
            HasPreviousPage = (PageIndex > 0);
            HasNextPage = (PageIndex < (PageCount - 1));
            IsFirstPage = (PageIndex <= 0);
            IsLastPage = (PageIndex >= (PageCount - 1));

            //### add items to internal list
            if (TotalItemCount > 0)
            {
                AddRange(source.Skip((PageIndex) * pageSize).Take(pageSize).ToList());
            }
        }
    }
}