using LoanManagement.Data;
using LoanManagement.Models;
using LoanManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Repository.Implementation
{
    public class LoanManagementRepository : ILoanManagementRepository
    {
        private LoanDBContext _loanDBContext;

        public LoanManagementRepository(LoanDBContext loanDBContext)
        {
            this._loanDBContext = loanDBContext;
        }

        public bool AddLoan(LoanDetail loanDetail)
        {
            try
            {
                _loanDBContext.LoanDetails.Add(loanDetail);
                _loanDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditLoan(int loanId, LoanDetail loanDetail)
        {
            try
            {
                var loan = _loanDBContext.LoanDetails.Find(loanId);
                loan.BorrowerName = loanDetail.BorrowerName;
                loan.LoanTerm = loanDetail.LoanTerm;
                loan.LoanAmount = loanDetail.LoanAmount;
                loan.LoanType = loanDetail.LoanType;
                loan.AddressLine1 = loanDetail.AddressLine1;
                loan.AddressLine2 = loanDetail.AddressLine2;
                loan.City = loanDetail.City;
                loan.ZipCode = loanDetail.ZipCode;
                loan.LegalInformation = loanDetail.LegalInformation;

                _loanDBContext.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }

        public List<LoanDetail> GetSearchResult(string borrowerName, int loanId, int loanAmount)
        {
            if (loanId != 0)
            {
                var loan = _loanDBContext.LoanDetails.Where(p => p.LoanId == loanId);
                if (loan != null)
                {
                    return loan.ToList();
                }
            }

            var loans = _loanDBContext.LoanDetails.ToList();
            if(!String.IsNullOrEmpty(borrowerName) && loanAmount != 0)
            {
                loans = loans.Where(p => p.BorrowerName == borrowerName && p.LoanAmount == loanAmount).ToList();
                //if(loanAmount != 0)
                //{
                //    loans = loans.Where(p => p.LoanAmount == loanAmount).ToList();
                //}
                return loans;
            }
            else if (loanAmount != 0)
            {
                loans = loans.Where(p => p.LoanAmount == loanAmount).ToList();
                return loans;
            }
            else if(!String.IsNullOrEmpty(borrowerName))
            {
                loans = loans.Where(p => p.BorrowerName == borrowerName).ToList();
                return loans;
            }
            else
            {
                //return _loanDBContext.LoanDetails.Where(p => p.LoanId == loanId || p.BorrowerName == borrowerName || p.LoanAmount == loanAmount).ToList();
                return loans;
            }
            
        }
    }
}
