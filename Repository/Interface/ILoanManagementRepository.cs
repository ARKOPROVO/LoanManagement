using LoanManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Repository.Interface
{
    interface ILoanManagementRepository
    {
        public List<LoanDetail> GetSearchResult(string borrowerName, int loanId, int loanAmount);
        public bool AddLoan(LoanDetail loanDetail);
        public bool EditLoan(int loanId, LoanDetail loanDetail);
    }
}
