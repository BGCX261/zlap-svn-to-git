using System;
using System.Data;
using System.Data.SqlClient; 
using System.Configuration;
using System.Web;

/// <summary>
/// Class support devide page display:
/// Date: 25-08-2006
/// Create by: Lê Bùi Sùng
/// Note: Using devide page with number of record is  big.
/// </summary>
namespace framework.list.dynamicviewhelper
{
    public class CDynamicViewHelper
    {
        // attributes:
        private int numberRecord;
        private int pageSize;
        private int pages;
        private int currentPage;
        private int fromRow;
        private int toRow;
        private bool isFirstPage;
        private bool isLastPage;
        public CDynamicViewHelper()
        {
            this.numberRecord = 0;
            this.isFirstPage = true;
            this.isFirstPage = true;
            this.pageSize = 10;
            this.pages = 0;
            this.currentPage = 0;
            this.fromRow = 0;
            this.toRow = 0;
        }
        //Method:
        // Get, set : is First Page.
        public bool GetIsFirstPage()
        {
            return isFirstPage;
        }
        public void SetIsFirstPage()
        {
            if ((this.currentPage > 0) && (this.pages > 0))
            {
                if (this.currentPage == this.pages)
                {
                    if (this.currentPage == 1)
                    {
                        this.isFirstPage = true;
                    }
                    else
                    {
                        this.isFirstPage = false;
                    }
                }
                else
                {
                    if (this.currentPage == 1)
                    {
                        this.isFirstPage = true;
                    }
                    else
                    {
                        this.isFirstPage = false;
                    }
                }
            }
            else
            {
                this.isFirstPage = true;
            }
        }
        //Get , Set : is last Page:
        public bool GetIsLastPage()
        {
            return this.isLastPage;
        }
        public void SetIsLastPage()
        {
            if ((this.currentPage > 0) && (this.pages > 0))
            {
                if (this.currentPage == this.pages)
                {
                    this.isLastPage = true;
                }
                else
                {
                    this.isLastPage = false;
                }
            }
            else
            {
                this.isLastPage = true;
            }
        }
        //Get, Set NumberRecord:
        public void SetNumberRecord(int numberRecord)
        {
            this.numberRecord = numberRecord;
        }
        public int GetNumberRecord()
        {
            return this.numberRecord;
        }
        // Get,Set Ds
        public void SetPages(int pages)
        {
            if (pages > 0)
            {
                this.pages = pages;
            }
            else
            {
                this.pages = 0;
            }
        }
        public int GetPages()
        {
            return this.pages;
        }
        public void SetPages()
        {
            if ((this.numberRecord > 0) && (this.pageSize > 0))
            {
                if (this.pageSize > this.numberRecord)
                {
                    this.pages = 1;
                    this.isLastPage = true;
                }
                else
                {
                    this.pages = this.numberRecord / this.pageSize;
                    if ((this.numberRecord % this.pageSize) > 0)
                    {
                        this.pages += 1;
                    }
                }
            }
            else
            {
                this.pages = 0;
            }
        }

        //Get,Set PageSize:
        public void SetPageSize(int pageSize)
        {
            if (pageSize > 0)
            {
                this.pageSize = pageSize;
            }
            else
            {
                this.pageSize = 0;
            }
        }
        public int GetPageSize()
        {
            return this.pageSize;
        }

        //Get, Set currentPage:
        public void SetCurrentPage(int currentPage)
        {
            if (currentPage > 0)
            {
                this.SetPages();
                if (this.pages > 0)
                {
                    if (currentPage > this.pages)
                    {
                        this.currentPage = this.pages;
                        this.isFirstPage = false;
                    }
                    else
                    {
                        this.currentPage = currentPage;
                    }
                }
                else
                {
                    this.currentPage = 0;
                }
            }
            else
            {
                this.currentPage = 0;
            }
            this.SetIsFirstPage();
            this.SetIsLastPage();
            this.SetFromRow();
            this.SetToRow();
        }
        public void ReSetCurrentPage()
        {
            this.SetPages();
            if (this.pages > 0)
            {
                if (this.currentPage <= 0)
                {
                    this.currentPage = 1;
                }
                if (this.currentPage > this.pages)
                {
                    this.currentPage = this.pages;
                }
            }
            else
            {
                this.currentPage = 0;
            }
            this.SetIsLastPage();
            this.SetIsFirstPage();
            this.SetFromRow();
            this.SetToRow();
        }
        public int GetCurrentPage()
        {
            return this.currentPage;
        }
        public void SetCurrentPage()
        {
            this.currentPage = 1;
            this.SetPages();
            if (this.pages <= 0)
            {
                this.currentPage = 0;
            }
            this.SetIsFirstPage();
            this.SetIsLastPage();
            this.SetFromRow();
            this.SetToRow();
        }
        // Set, Get FromRow :
        public void SetFromRow(int fromRow)
        {
            if (fromRow > 0)
            {
                this.fromRow = fromRow;
            }
            else
            {
                this.fromRow = 0;
            }
        }
        public int GetFromRow()
        {
            return this.fromRow;
        }
        public void SetFromRow()
        {
            if (this.currentPage > 0)
            {
                this.fromRow = (this.currentPage - 1) * this.pageSize;
            }
            else
            {
                this.fromRow = 0;
            }
        }
        //Get,Set ToRow:
        public void SetToRow(int toRow)
        {
            if (toRow > 0)
            {
                this.toRow = toRow;
            }
            else
            {
                this.toRow = 0;
            }
        }
        public int GetToRow()
        {
            return this.toRow;
        }
        public void SetToRow()
        {
            if (this.currentPage > 0)
            {
                if (this.currentPage * this.pageSize <= this.numberRecord)
                {
                    this.toRow = this.currentPage * this.pageSize;
                }
                else
                {
                    this.toRow = this.numberRecord;
                }
            }
            else
            {
                this.toRow = 0;
            }
        }
        public void FirstPage()
        {
            this.SetCurrentPage(1);
            //this.SetFromRow();
            //this.SetToRow(); 
        }
        //Last Page:
        public void LastPage()
        {
            this.SetPages();
            this.currentPage = this.pages;
            this.SetIsFirstPage();
            this.SetIsLastPage();
            this.SetFromRow();
            this.SetToRow();
        }
        //Next Page: 
        public void NextPage()
        {
            this.SetPages();
            if (this.pages > 0)
            {
                this.currentPage = this.currentPage + 1;
                if (this.currentPage > this.pages)
                {
                    this.currentPage = 1;
                }
            }
            else
            {
                this.currentPage = 0;
            }
            this.SetIsFirstPage();
            this.SetIsLastPage();
            this.SetFromRow();
            this.SetToRow();
        }
        //Previous Page:
        public void PreviousPage()
        {
            this.SetPages();
            if (this.pages > 0)
            {
                this.currentPage = this.currentPage - 1;
                if (this.currentPage <= 0)
                {
                    this.currentPage = this.pages;
                }
            }
            else
            {
                this.currentPage = 0;
            }
            this.SetIsFirstPage();
            this.SetIsLastPage();
            this.SetFromRow();
            this.SetToRow();
        }
    }
}

