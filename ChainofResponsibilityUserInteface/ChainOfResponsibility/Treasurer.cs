using ChainofResponsibilityUserInteface.ChainOfRes.DataAccessLayer;
using ChainofResponsibilityUserInteface.ChainOfRes.DataAccessLayer.Context;
using ChainofResponsibilityUserInteface.Models;

namespace ChainofResponsibilityUserInteface.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        private readonly ChainOfRespDb _chainOfRespDb;

        public Treasurer(ChainOfRespDb chainOfRespDb)
        {
            _chainOfRespDb = chainOfRespDb;
        }

        public override void ProcessRequest(CustomerProcessViewModel model)
        {
            if (model.Amount <= 10000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = model.Amount;
                customerProcess.FirstName = model.FirstName;
                customerProcess.LastName = model.LastName;
                customerProcess.EmployeeName = "Yahya Erdogan";
                customerProcess.Description = "The requested amount was paid to the customer by the cashier.";
                _chainOfRespDb.CustomerProcesses.Add(customerProcess);
                _chainOfRespDb.SaveChanges();
                
            }else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = model.Amount;
                customerProcess.FirstName = model.FirstName;
                customerProcess.LastName = model.LastName;
                customerProcess.EmployeeName = "Yahya Erdogan";
                customerProcess.Description = "The requested amount was not paid to the customer by the cashier.";
                _chainOfRespDb.CustomerProcesses.Add(customerProcess);
                _chainOfRespDb.SaveChanges();
                NextApprover.ProcessRequest(model);

            }
        }
    }
}