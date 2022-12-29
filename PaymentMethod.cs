using System;

namespace c__project

{
    public class PaymentMethod
    {
        private int Id = 0;
        private string Title;
        private enum Type
        {
            // items of the enum
            visa,
            mastercard,
            american_express,
            discover   
        }
        private string ChosenType;
        private string CardHolderName;
        private string CardNumber;
        private DateTime ExpirationDate;
        private string CVC;
        private float Sold;
        private DateTime DateAdded;

        //constructor
        public PaymentMethod(string Title,int Index,string CardHolderName,string CardNumber,DateTime ExpirationDate,string CVC,float Sold,DateTime DateAdded)
        {
            this.Id++;
            this.Title = Title;
            this.ChosenType = ((Type)Index).ToString();
            this.CardHolderName = CardHolderName;
            this.CardNumber = CardNumber;
            this.ExpirationDate = ExpirationDate;
            this.CVC = CVC;
            this.Sold = Sold;
            this.DateAdded = DateAdded;
        }

        //getters setters
        public int GetId()
        {
            return this.Id;
        }

        public void SetId(int Id)
        {
            this.Id = Id;
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public void SetTitle(string Title)
        {
            this.Title = Title;
        }

        public string GetChosenType()
        {
            return this.ChosenType;
        }

        public void SetChosenType(string ChosenType)
        {
            this.ChosenType = ChosenType;
        }
        
        public string GetCardHolderName()
        {
            return this.CardHolderName;
        }

        public void SetCardHolderName(string CardHolderName)
        {
            this.CardHolderName = CardHolderName;
        }

        public string GetCardNumber()
        {
            return this.CardNumber;
        }

        public void SetCardNumber(string CardNumber)
        {
            this.CardNumber = CardNumber;
        }

        public DateTime GetExpirationDate()
        {
            return this.ExpirationDate;
        }

        public void SetExpirationDate(DateTime ExpirationDate)
        {
            this.ExpirationDate = ExpirationDate;
        }

        public string GetCVC()
        {
            return this.CVC;
        }

        public void SetCVC(string CVC)
        {
            this.CVC = CVC;
        }

        public float GetSold()
        {
            return this.Sold;
        }

        public void SetSold(float Sold)
        {
            this.Sold = Sold;
        }

        public DateTime GetDateAdded()
        {
            return this.DateAdded;
        }

        public void SetDateAdded(DateTime DateAdded)
        {
            this.DateAdded = DateAdded;
        }
    }


}