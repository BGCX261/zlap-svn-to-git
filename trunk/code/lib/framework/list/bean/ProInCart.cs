using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace framework.list.bean
{
	public class ProInCart
	{
        public int id = 0;
        public int type = 1;
        public string name = "";
        public string urlImage = "";
        public int warranty = 0;
        public float price = 0;
        public int number=0;
        public float total = 0;
        public float rate = 0;
        public string currency = "";
        public void setTotal()
        {
            this.total = this.price * this.number;
        }
        public string PriceStandard()
        {
            string value = "0";
            try
            {
                float total1 = 1;
                total1 = this.price * rate;
                value = total1.ToString("N").Split('.')[0];
            }
            catch
            { 
            }
            return value;
        }
        public string ValueTotal()
        {
            string value = "0";
            try
            {
                float total1 = 1;
                total1 = this.total * rate;
                value = total1.ToString("N").Split('.')[0];
            }
            catch
            {
            }
            return value;
        }
	}
    public class ManagerProcart
    {
        private ArrayList ListPro = new ArrayList();
        private ProInCart currentpro = new ProInCart();
        public void AddNewPro(ProInCart pro)
        {
            int numPro = ListPro.Count;
            for (int i = 0; i < numPro; i++)
            {
                currentpro = (ProInCart)ListPro[i];
                if ((currentpro.type==pro.type)&&(currentpro.id == pro.id))
                {
                    currentpro.number = currentpro.number + 1;
                    currentpro.rate = pro.rate;
                    currentpro.setTotal();
                    ListPro[i] = currentpro;
                    return;
                }
            }
            this.ListPro.Add(pro);
        }
        public void DeletePro(ProInCart pro)
        {
            int numPro = ListPro.Count;
            for (int i = 0; i < numPro; i++)
            {
                currentpro = (ProInCart)ListPro[i];
                if ((currentpro.type == pro.type) && (currentpro.id == pro.id))
                {
                    ListPro.RemoveAt(i);
                    break;
                }
            }
        }
        public int CountAllPro()
        {
            int num = ListPro.Count;
            int tatalpro = 0;
            for (int i = 0; i < num; i++)
            {
                currentpro = (ProInCart)ListPro[i];
                tatalpro += currentpro.number;
            }
            return tatalpro;
        }
        public float TotalCost()
        {
            int num = ListPro.Count;
            float total = 0;
            for (int i = 0; i < num; i++)
            {
                currentpro = (ProInCart)ListPro[i];
                total += currentpro.total;
            }
            return total;
        }
        public float TotalCostVND()
        {
            int num = ListPro.Count;
            float total = 0;
            for (int i = 0; i < num; i++)
            {
                currentpro = (ProInCart)ListPro[i];
                total += currentpro.total * currentpro.rate;
            }
            return total;
        }
        public int GetNumBerPro()
        {
            int num = ListPro.Count;
            int total = 0;
            for (int i = 0; i < num; i++)
            {
                currentpro = (ProInCart)ListPro[i];
                total += currentpro.number;
            }
            return total;
        }
        public int getLengList()
        {
            return ListPro.Count;
        }
        public ProInCart GetProIndex(int index)
        {
            return (ProInCart)ListPro[index];
        }
        public void SetNumPro(int index, int num)
        {
            currentpro = (ProInCart)ListPro[index];
            if (num <= 0)
            {
                num = 1; 
            }
            currentpro.number = num;
            currentpro.setTotal();
            ListPro[index] = currentpro;
        }
    }
}