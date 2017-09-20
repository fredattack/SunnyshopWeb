using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sunnyShopWeb.classesMetier
{
    public class Order
    {
        private int idOrder;
        private String dateOrder;
        private String timeOrder;
        private decimal totalPrice;
        private String deliveredOrder;
        private int idUserOrder;




        #region Constructor
        public Order()
        { }

        public Order(int idOrder, string dateOrder, string timeOrder, 
            decimal totalPrice, string deliveredOrder, int idUserOrder)
        {
            this.idOrder = idOrder;
            this.dateOrder = dateOrder;
            this.timeOrder = timeOrder;
            this.totalPrice = totalPrice;
            this.deliveredOrder = deliveredOrder;
            this.idUserOrder = idUserOrder;
        }

        #endregion

        #region Get/Set
        public int IdOrder
        {
            get
            {
                return idOrder;
            }

            set
            {
                idOrder = value;
            }
        }

        public string DateOrder
        {
            get
            {
                return dateOrder;
            }

            set
            {
                dateOrder = value;
            }
        }

        public string TimeOrder
        {
            get
            {
                return timeOrder;
            }

            set
            {
                timeOrder = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }

            set
            {
                totalPrice = value;
            }
        }

        public string DeliveredOrder
        {
            get
            {
                return deliveredOrder;
            }

            set
            {
                deliveredOrder = value;
            }
        }

        public int IdUserOrder
        {
            get
            {
                return idUserOrder;
            }

            set
            {
                idUserOrder = value;
            }
        }
        #endregion
    }
}